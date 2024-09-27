using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Management;

using Fove.Unity;
using ViveSR.anipal.Eye;

using KLib;
using KLib.Network;

using Jenks.VVA;

public enum VRHMD { None, FOVE, Vive };

public class Main : MonoBehaviour
{
    public Camera mainCamera;
    public Camera foveCamera;
    public Canvas canvas;
    public Text messageText;

    public RandomDotsController randomDots;
    public WallController wall;

    public VisualFieldController visualFieldController;
    public ViveEyeTracker viveEyeTracker;

    public MoogUDPServer moogUDPServer;

    public DataLogger dataLogger;

    private bool _listenerReady = false;

    KTcpListener _listener = null;
    private bool _stopServer;
    private NetworkDiscoveryServer _discoveryServer;

    private string _address;
    private int _port = 4950;

    private VRHMD _vrHMD;
    private float _fov = 60f;
    private Vector2 _screenSize;

    private TestSpecification _currentTest;
    private DotProperties _dotProperties;
    private WallProperties _wallProperties = new WallProperties();

    private bool _sceneRunning = false;

    private void Awake()
    {
        Application.logMessageReceived += HandleException;
    }

    private void Start()
    {
        Application.runInBackground = true;
#if UNITY_EDITOR
        //Application.targetFrameRate = 90;
#endif

        KLogger.Create(
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Jenks", "Logs", "VVA-VR.txt"), 
            retainDays: 14)
            .StartLogging();

        Debug.Log("App started");

        messageText.text = "Initializing...";

        //foveCamera.enabled = false;
        //_fov = mainCamera.fieldOfView;
        //_screenSize = new Vector2(Screen.width, Screen.height);
        //SetScene(Scene.Bars);

        StartCoroutine(Initialize());
    }

    private IEnumerator Initialize()
    {
        yield return null;

        InitializeHMD();

        yield return null;
        _address = NetworkUtils.FindServerAddress();

        _discoveryServer = gameObject.AddComponent<NetworkDiscoveryServer>();
        StartServer();

        moogUDPServer.StartReceiving();

        messageText.text = "Standing by...";

        yield break;
    }

    private void InitializeHMD()
    {
        _vrHMD = VRHMD.None;
        _screenSize = new Vector2(Screen.width, Screen.height);

        Debug.Log("Initializing HMD");
        var result = FoveManager.IsHardwareConnected();
        if (result.value)
        {
            mainCamera = foveCamera;
            canvas.worldCamera = foveCamera;
            //foveCamera.fieldOfView = WallController.wallSceneFOV;
            //_fov = foveCamera.fieldOfView;
            _fov = 60f;
            _screenSize = new Vector2(1280, 1440);
            _vrHMD = VRHMD.FOVE;
            Debug.Log("FOVE headset detected");
            FoveManager.RegisterCapabilities(Fove.ClientCapabilities.EyeTorsion);
        }

        if (_vrHMD == VRHMD.None)
        {
            foveCamera.enabled = false;
            _fov = mainCamera.fieldOfView;

            var haveVR = XRGeneralSettings.Instance != null && XRGeneralSettings.Instance.Manager.activeLoader != null;

            if (!haveVR)
            {
                Debug.Log("no VR headset found");
            }
            else
            {
                _vrHMD = VRHMD.Vive;
                _fov = 60f;
                //mainCamera.fieldOfView = _fov;
                _screenSize = new Vector2(1440, 1600);
                //UnityEngine.XR.XRSettings.gameViewRenderMode = UnityEngine.XR.GameViewRenderMode.BothEyes;
                Debug.Log("XR headset detected (assuming Vive Pro Eye)");
            }
        }
    }

    private void StartServer()
    {
        _stopServer = false;

        _listener = new KTcpListener();
        _listener.StartListener(_address, _port, false);

        StartCoroutine(TCPServer());
        _discoveryServer.StartReceiving("VVA VR", _address, _port);

        Debug.Log("Started TCP listener on " + _address + ":" + _port);
    }
    

    private void StopServer()
    {
        _stopServer = true;
        if (_listener != null)
        {
            _listener.CloseListener();
            _listener = null;
        }

        _discoveryServer.StopReceiving();
        Debug.Log("Stopped TCP listener");
    }

    void Return()
    {
        moogUDPServer.StopReceiving();
        StopServer();

        Debug.Log("App closing");
#if !UNITY_EDITOR
        Application.Quit();
#endif
    }

    void OnDestroy()
    {
        //StopServer();
        Application.logMessageReceived -= HandleException;
    }

    IEnumerator TCPServer()
    {
        while (!_stopServer)
        {
            if (_listener.Pending())
            {
                ProcessMessage();
            }
            yield return null;
        }
    }

    void ProcessMessage()
    {
        bool exit = false;

        //TestState receivedTestState = null;

        _listener.AcceptTcpClient();

        string input = _listener.ReadString();
        var parts = input.Split(new char[] { ':' });
        string command = parts[0];
        string data = null;
        if (parts.Length > 1)
        {
            data = parts[1];
        }

        if (!command.Equals("GetStatus"))
        {
            Debug.Log("Command received: " + command);
        }

        switch (command)
        {
            case "Ping":
                _listener.SendAcknowledgement();
                break;

            case "Exit":
                _listener.SendAcknowledgement();
                exit = true;
                break;

            case "Run":
                var test = ReceiveTestSpecification();
                _listener.SendAcknowledgement();
                StartCoroutine(RunTest(test));
                break;

            case "DotProperties":
                _dotProperties = _listener.ReceiveProtoBuf<DotProperties>();
                _listener.SendAcknowledgement();
                Debug.Log("Received dot properties: " + _dotProperties.ToLogString());
                break;

            case "GratingProperties":
                _wallProperties = _listener.ReceiveProtoBuf<WallProperties>();
                _listener.SendAcknowledgement();
                Debug.Log("Received wall properties: " + _wallProperties.ToLogString());
                break;

            case "Abort":
                _listener.SendAcknowledgement();
                StartCoroutine(StopTest());
                break;

            case "GetEyeTrackingReady":
                _listener.SendAcknowledgement(IsEyeTrackingReady());
                break;

            case "GetFilename":
                _listener.WriteStringAsByteArray(dataLogger.Filename);
                break;

            case "GetHeadset":
                _listener.WriteStringAsByteArray(_vrHMD.ToString());
                break;

            case "GetHeadsetInformation":
                _listener.WriteStringAsByteArray(GetHeadsetInformation());
                break;

            case "GetStatus":
                _listener.SendAcknowledgement(_sceneRunning);
                break;

            case "DoEyeCalibration":
                _listener.SendAcknowledgement();
                StartCoroutine(DoEyeCalibration());
                break;

            default:
                _listener.SendAcknowledgement(false);
                break;
        }

        _listener.CloseTcpClient();

        if (exit) Return();
    }

    private TestSpecification ReceiveTestSpecification()
    {
        TestSpecification test = null;
        var bytes = _listener.ReadByteArray();
        if (bytes != null)
        {
            test = FileIO.FromProtoBuf<TestSpecification>(bytes);
        }

        return test;
    }

    IEnumerator RunTest(TestSpecification test)
    {
        _currentTest = test;

        Debug.Log("Running test: " + test.ToLogString());

        if (_vrHMD == VRHMD.Vive)
        {
            viveEyeTracker.StartTracking();
        }
        else if (_vrHMD == VRHMD.FOVE)
        {
            Debug.Log("Fove tracking ready = " + FoveManager.IsEyeTrackingReady().value);
        }

        dataLogger.StartLogging(test.ToLogString(), _vrHMD);

        SetScene(test.scene);

        var target = (_vrHMD == VRHMD.FOVE) ? foveCamera.transform.parent : mainCamera.transform;

        if (test.scene == Scene.Dots || test.scene == Scene.Bars)
        {
            if (test.motionSource == MotionSource.Internal)
            {
                if (test.motionDirection == MotionDirection.RollTilt)
                {
                    visualFieldController.StartMotion(target, amplitude: test.amplitude_degrees, frequency: test.frequency_Hz);
                }
                else if (test.motionDirection == MotionDirection.Translation)
                {
                    visualFieldController.StartMotion(target,
                        amplitude: test.amplitude_degrees,
                        frequency: test.frequency_Hz,
                        gain: test.gain,
                        translate: true
                        );
                }
            }
            else if (test.motionSource == MotionSource.UDP)
            {
                visualFieldController.StartMotion(mainCamera.transform, moogUDPServer, test.gain, test.motionDirection == MotionDirection.Translation);
            }
        }

        yield break;
    }

    private bool IsEyeTrackingReady()
    {
        bool isReady = false;
        if (_vrHMD == VRHMD.FOVE)
        {
            isReady = FoveManager.IsEyeTrackingReady();
        }
        else if (_vrHMD == VRHMD.Vive)
        {
            isReady = SRanipal_Eye_Framework.Status == SRanipal_Eye_Framework.FrameworkStatus.WORKING;
        }

        return isReady;
    }

    private void SetScene(Scene scene)
    {
        messageText.enabled = false;

        if (scene == Scene.White)
        {
            mainCamera.backgroundColor = Color.white;
        }
        else if (scene == Scene.Black)
        {
            mainCamera.backgroundColor = Color.black;
        }
        else if (scene == Scene.Dots)
        {
            randomDots.InitializeDots(_dotProperties, _fov);
        }
        else if (scene == Scene.Bars)
        {
            mainCamera.clearFlags = CameraClearFlags.Skybox;
            //mainCamera.fieldOfView = WallController.wallSceneFOV;
            wall.InitializeWall(_wallProperties, _fov, _screenSize);
        }
        _sceneRunning = true;
    }

    private void ClearScene(Scene scene)
    {
        mainCamera.clearFlags = CameraClearFlags.SolidColor;
        mainCamera.backgroundColor = Color.black;
        //mainCamera.fieldOfView = _fov;

        if (scene == Scene.Dots)
        {
            randomDots.ClearDots();
        }
        else if (scene == Scene.Bars)
        {
            wall.HideWall();
        }
        _sceneRunning = false;
    }

    IEnumerator StopTest()
    {
        viveEyeTracker.StopTracking();
        dataLogger.StopLogging();
        visualFieldController.StopMotion();

        ClearScene(_currentTest.scene);

        yield return new WaitForSeconds(2);
        messageText.enabled = true;
    }

    private string GetHeadsetInformation()
    {
        System.Text.StringBuilder builder = new System.Text.StringBuilder();

        if (_vrHMD == VRHMD.FOVE)
        {
            var hardwareInfo = FoveManager.Headset.QueryHardwareInfo().value;
            var manufacturer = FromCharArray(hardwareInfo.manufacturer);
            var model = FromCharArray(hardwareInfo.modelName);
            var sn = FromCharArray(hardwareInfo.serialNumber);

            builder.AppendLine("Headset: " + model);
            builder.AppendLine("SN: " + sn);
            builder.AppendLine();
            builder.AppendLine("Eye tracking");
            builder.AppendLine("------------");
            builder.AppendLine("Enabled:" + FoveManager.IsEyeTrackingEnabled().value);
            builder.AppendLine("Calibrated:" + FoveManager.IsEyeTrackingCalibrated().value);
            builder.AppendLine("Ready:" + FoveManager.IsEyeTrackingReady().value);
        }
        else if (_vrHMD == VRHMD.Vive)
        {
            builder.AppendLine("Vive Pro Eye = " + SRanipal_Eye_API.IsViveProEye());
            builder.AppendLine("Refresh rate = " + UnityEngine.XR.XRDevice.refreshRate);
            builder.AppendLine("SRanipal = " + SRanipal_Eye_Framework.Status);
        }

        return builder.ToString();
    }

    private string FromCharArray(char[] arr)
    {
        int len = 0;
        while (len < arr.Length)
        {
            if (arr[len] == (char) 0)
            {
                break;
            }
            len++;
        }
        return new string(arr, 0, len);
    }

    IEnumerator DoEyeCalibration()
    {
        if (_vrHMD == VRHMD.FOVE)
        {
            FoveManager.StartEyeTrackingCalibration();
        }
        else if (_vrHMD == VRHMD.Vive)
        {
            SRanipal_Eye_v2.LaunchEyeCalibration();
        }

        yield break;
    }

    public void HandleException(string condition, string stackTrace, LogType type)
    {
        if (type == LogType.Log || type == LogType.Warning || condition.Contains("Capability 'microphone'") || condition.Contains("reload asset from disk") || condition.Contains("<RI.Hid>"))
        {
            return;
        }

//        if (_sceneRunning)
        {
            StartCoroutine(StopTest());
        }
    }

}

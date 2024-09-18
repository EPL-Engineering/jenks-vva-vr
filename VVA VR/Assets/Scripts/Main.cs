using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Management;

using Fove.Unity;

using KLib;
using KLib.Network;

using Jenks.VVA;

public class Main : MonoBehaviour
{
    public Camera mainCamera;
    public Camera foveCamera;
    public Canvas canvas;
    public Text messageText;

    public RandomDotsController randomDots;
    public GratingController grating;

    private bool _listenerReady = false;

    KTcpListener _listener = null;
    private bool _stopServer;
    private NetworkDiscoveryServer _discoveryServer;

    private string _address;
    private int _port = 4950;

    private Text _message;

    private enum VRHMD { None, FOVE, Vive};
    private VRHMD _vrHMD;

    private float _fov = 60f;

    private TestSpecification _currentTest;
    private DotProperties _dotProperties;
    private GratingProperties _gratingProperties;

    private void Start()
    {
        KLogger.Create(
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Jenks", "Logs", "VVA-VR.txt"), 
            retainDays: 14)
            .StartLogging();

        Debug.Log("App started");

        InitializeHMD();

        _address = NetworkUtils.FindServerAddress();

        _discoveryServer = gameObject.AddComponent<NetworkDiscoveryServer>();
        StartServer();
    }

    private void InitializeHMD()
    {
        _vrHMD = VRHMD.None;

        Debug.Log("Initializing HMD");
        var result = FoveManager.IsHardwareConnected();
        if (result.value)
        {
            mainCamera = foveCamera;
            canvas.worldCamera = foveCamera;
            _fov = foveCamera.fieldOfView;
            _vrHMD = VRHMD.FOVE;
            Debug.Log("FOVE headset detected");
        }
        else
        {
            foveCamera.enabled = false;
            _fov = mainCamera.fieldOfView;
            var haveVR = XRGeneralSettings.Instance.Manager.activeLoader != null;
            if (!haveVR)
            {
                Debug.Log("no VR headset found");
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
        StopServer();
        Debug.Log("App closing");
#if !UNITY_EDITOR
        Application.Quit();
#endif
    }

    void OnDestroy()
    {
        StopServer();
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

        string input = _listener.ReadStringFromInputStream();
        var parts = input.Split(new char[] { ':' });
        string command = parts[0];
        string data = null;
        if (parts.Length > 1)
        {
            data = parts[1];
        }

        Debug.Log("Command received: " + command);

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
                _gratingProperties = _listener.ReceiveProtoBuf<GratingProperties>();
                _listener.SendAcknowledgement();
                Debug.Log("Received grating properties: " + _gratingProperties.ToLogString());
                break;

            case "Abort":
                _listener.SendAcknowledgement();
                StartCoroutine(StopTest());
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
        var bytes = _listener.ReadByteArrayFromInputStream();
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
        messageText.enabled = false;

        SetScene(test.scene);

        yield break;
    }

    private void SetScene(Scene scene)
    {
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
            grating.InitializeGrating(_gratingProperties, _fov);
        }
    }

    private void ClearScene(Scene scene)
    {
        if (scene == Scene.White)
        {
            mainCamera.backgroundColor = Color.black;
        }
        else if (scene == Scene.Dots)
        {
            randomDots.ClearDots();
        }
        else if (scene == Scene.Bars)
        {
            grating.ClearGrating();
        }
    }

    IEnumerator StopTest()
    {
        ClearScene(_currentTest.scene);

        yield return new WaitForSeconds(2);
        messageText.enabled = true;
    }

}

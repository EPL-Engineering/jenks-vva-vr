using UnityEngine;
using System;
using System.Collections;

#if UNITY_METRO && !UNITY_EDITOR
using Windows.Networking;
using Windows.Networking.Sockets;
#else
using System.Net;
using System.Net.Sockets;
#endif

public class MOOGChairController : MonoBehaviour
{
/*    private Vestibular _vestibular;

#if UNITY_METRO && !UNITY_EDITOR
#else
    private UdpClient _udpClient;
    private IPEndPoint _udpIP;
#endif

    private enum State { Idle, Moving }
    private State _state = State.Idle;

    private float _targetRoll;
    private static float _currentRoll = 0;
    private float _lastMoveTime;
    private float _startMoveTime;
    private float _startRoll;

    private float _rollFreq;
    private float _rollRange;
    private float _lastRamp;

    public bool IsMoving { get { return _state == State.Moving; } }
    public float CurrentRollAngle { get { return _currentRoll; } }

    private float _maxStep = 0.5f;
    private float _minMoveTime = 0.5f;

    private byte[] _byteArray;
    private int _npacket = 0;

    private MOOGCommandLog _log = new MOOGCommandLog(10000);

    private bool _directUDP = true;

    void Start()
    {
        _byteArray = new byte[16];
    }

    void OnDestroy()
    {
//        _log.WriteToDisk();
    }

    public void Initialize(Vestibular v)
    {
        _vestibular = v;
        _vestibular.Initialize();

#if UNITY_METRO && !UNITY_EDITOR
            UDP.Initialize(_vestibular.udpHost, _vestibular.udpPort);
#else
        _udpClient = new UdpClient();
        _udpIP = new IPEndPoint(IPAddress.Parse(_vestibular.udpHost), _vestibular.udpPort);
#endif
        _directUDP = (_vestibular.udpPort == 22123);

        _state = State.Idle;
    }

    public void SendTo(float rollAngle, bool isMoving)
    {
        var delta = rollAngle - _currentRoll;
        if (Mathf.Abs(delta) > _maxStep)
        {
            delta = _maxStep * Mathf.Sign(delta);
            rollAngle = _currentRoll + delta;
        }

        _currentRoll = rollAngle;

#if UNITY_METRO && !UNITY_EDITOR
        if (_directUDP)
        {
            UDP.SendPacket(_vestibular.GetPacketBytes(rollAngle, rollAngle, 1));
        }
        else
        {
            UDP.SendPacket(GetPacketBytes(_npacket++, Time.timeSinceLevelLoad, rollAngle, isMoving));
        }
#else
        if (_directUDP)
        {
            _udpClient.Send(_vestibular.GetPacketBytes(rollAngle, rollAngle, 1), _vestibular.NumBytes, _udpIP);
        }
        else
        {
            _udpClient.Send(GetPacketBytes(_npacket++, Time.timeSinceLevelLoad, rollAngle, isMoving), _byteArray.Length, _udpIP);
        }
#endif
        _log.Add(Time.timeSinceLevelLoad, Time.realtimeSinceStartup, rollAngle);
    }

    public void MoveTo(float rollAngle)
    {
        Debug.Log("roll from " + _currentRoll + " to " + rollAngle);

        _targetRoll = rollAngle;
        _lastMoveTime = -1;
        _startMoveTime = -1;

        _rollRange = _targetRoll - _currentRoll;

        float fmax = 0.5f / _minMoveTime;

        _rollFreq = Mathf.Min(fmax, _vestibular.maxRollSpeed / (Mathf.PI * Mathf.Abs(_rollRange)));

        _lastRamp = -1;

        _state = State.Moving;
    }

    public float ApproximateMoveTime(float rollAngle)
    {
        var rollRange = rollAngle - _currentRoll;

        float fmax = 0.5f / _minMoveTime;

        var rollFreq = Mathf.Min(fmax, _vestibular.maxRollSpeed / (Mathf.PI * Mathf.Abs(_rollRange)));

        return 0.5f / rollFreq;
    }


    void Update()
    {
        if (_state == State.Moving)
        {
            // The assembly scene is obviously not well-designed, in that there are operations tied to Update() that
            // consume an undue amount of time. Consequently, the first Time.deltaTime is bigger than normal and causes
            // a large first step. Hence, we explictly keep track of the delta time.
            if (_lastMoveTime < 0)
            {
                _lastMoveTime = Time.timeSinceLevelLoad;
                _startMoveTime = _lastMoveTime;
                _startRoll = _currentRoll;
            }

            float t = Time.timeSinceLevelLoad - _startMoveTime;
            float ramp = 0.5f * (1 - Mathf.Cos(2 * Mathf.PI * _rollFreq * t));
            if (ramp < _lastRamp)
            {
                ramp = 1;
                _state = State.Idle;
            }
            _lastRamp = ramp;

            var roll = _startRoll + _rollRange * ramp;

            _lastMoveTime = Time.timeSinceLevelLoad;

            SendTo(roll, _state == State.Moving);
        }
    }

    public void StopMoving()
    {
        _state = State.Idle;
    }

    private byte[] GetPacketBytes(int n, float t, float rollAngle, bool isMoving)
    {
        byte[] tmp = BitConverter.GetBytes(n);
        for (int k = 0; k < 4; k++) _byteArray[k] = tmp[3 - k];
        tmp = BitConverter.GetBytes(t);
        for (int k = 0; k < 4; k++) _byteArray[k + 4] = tmp[3 - k];
        tmp = BitConverter.GetBytes(rollAngle);
        for (int k = 0; k < 4; k++) _byteArray[k + 8] = tmp[3 - k];
        int moving = isMoving ? 1 : 0;
        tmp = BitConverter.GetBytes(moving);
        for (int k = 0; k < 4; k++) _byteArray[k + 12] = tmp[3 - k];

        return _byteArray;
    }
    */
}
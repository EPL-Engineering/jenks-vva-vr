using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualFieldController : MonoBehaviour
{
    private Transform _target;

    private float _amplitude;
    private float _frequency;
    private float _gain;
    private bool _translate = false;

    private float _startTime;
    private bool _isRunning = false;

    private bool _useUDP;

    private MoogUDPServer _moogUDPServer;

    public float RollTilt { get; private set; } = 0;
    public float X { get; private set; } = 0;

    public void StartMotion(Transform target, float amplitude = 0, float frequency = 0, float gain = 1, bool translate = false)
    {
        _useUDP = false;

        _target = target;

        _amplitude = amplitude;
        _frequency = frequency;
        _gain = gain;
        _translate = translate;

        _startTime = Time.time;
        _isRunning = true;
    }

    public void StartMotion(Transform target, MoogUDPServer moogUDPServer, float gain, bool translate)
    {
        _useUDP = true;

        _target = target;
        _moogUDPServer = moogUDPServer;
        _gain = gain;
        _translate = translate;

        _startTime = Time.time;
        _isRunning = true;
    }

    public void StopMotion()
    {
        X = 0;
        RollTilt = 0;

        _target.position = Vector3.zero;
        _target.eulerAngles = Vector3.zero;

        _isRunning = false;
    }

    private void Update()
    {
        if (_isRunning)
        {
            if (_useUDP)
            {
                RollTilt = _moogUDPServer.RollTilt;
            }
            else
            {
                RollTilt = _amplitude * Mathf.Sin(2 * Mathf.PI * _frequency * (Time.time - _startTime));
            }

            if (_translate)
            {
                X = _gain * RollTilt;
                _target.position = new Vector3(X, 0, 0);
            }
            else
            {
                _target.eulerAngles = new Vector3(0, 0, RollTilt);
            }
        }
    }
}

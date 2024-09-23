using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualFieldController : MonoBehaviour
{
    private Transform _target;

    private float _tiltAmplitude;
    private float _tiltVelocity;

    private float _transAmplitude;
    private float _transVelocity;

    private float _startTime;
    private bool _isRunning = false;

    private bool _useUDP;

    private MoogUDPServer _moogUDPServer;

    public float X { get; private set; } = 0;
    public float RollTilt { get; private set; } = 0;

    public void StartMotion(Transform target, float tiltAmplitude = 0, float tiltVelocity = 0, float transAmplitude = 0, float transVelocity = 0)
    {
        _useUDP = false;

        _target = target;

        _tiltAmplitude = tiltAmplitude;
        _tiltVelocity = tiltVelocity;

        _transAmplitude = transAmplitude;
        _transVelocity = transVelocity;

        _startTime = Time.time;
        _isRunning = true;
    }

    public void StartMotion(Transform target, MoogUDPServer moogUDPServer)
    {
        _useUDP = true;

        _target = target;
        _moogUDPServer = moogUDPServer;

        _startTime = Time.time;
        _isRunning = true;
    }

    public void StopMotion()
    {
        X = 0;
        RollTilt = 0;

        _isRunning = false;
    }

    private void Update()
    {
        if (_isRunning)
        {
            if (_useUDP)
            {
                X = _moogUDPServer.X;
                RollTilt = _moogUDPServer.RollTilt;
            }
            else
            {
                X = _transAmplitude * Mathf.Sin(2 * Mathf.PI * _transVelocity * (Time.time - _startTime));
                RollTilt = _tiltAmplitude * Mathf.Sin(2 * Mathf.PI * _tiltVelocity * (Time.time - _startTime));
            }

            _target.eulerAngles = new Vector3(0, 0, RollTilt);
            _target.position = new Vector3(X, 0, 0);
        }
    }
}

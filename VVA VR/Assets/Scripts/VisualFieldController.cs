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

    public void StartMotion(Transform target, float tiltAmplitude = 0, float tiltVelocity = 0, float transAmplitude = 0, float transVelocity = 0)
    {
        _target = target;

        _tiltAmplitude = tiltAmplitude;
        _tiltVelocity = tiltVelocity;

        _transAmplitude = transAmplitude;
        _transVelocity = transVelocity;

        _startTime = Time.time;
        _isRunning = true;

        KLib.KLogger.Debug("v = " + _transVelocity);
    }

    public void StopMotion()
    {
        _isRunning = false;
    }

    private void Update()
    {
        if (_isRunning)
        {
            _target.eulerAngles = new Vector3(0, 0, _tiltAmplitude * Mathf.Sin(_tiltVelocity * (Time.time - _startTime)));
            _target.position = new Vector3(_transAmplitude * Mathf.Sin(_transVelocity * (Time.time - _startTime)), 0, 0);
        }
    }
}

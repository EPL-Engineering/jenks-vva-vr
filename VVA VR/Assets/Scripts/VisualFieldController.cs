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

    public float X { get; private set; } = 0;
    public float Z { get; private set; } = 0;

    public void StartMotion(Transform target, float tiltAmplitude = 0, float tiltVelocity = 0, float transAmplitude = 0, float transVelocity = 0)
    {
        _target = target;

        _tiltAmplitude = tiltAmplitude;
        _tiltVelocity = tiltVelocity;

        _transAmplitude = transAmplitude;
        _transVelocity = transVelocity;

        _startTime = Time.time;
        _isRunning = true;
    }

    public void StopMotion()
    {
        X = 0;
        Z = 0;

        _isRunning = false;
    }

    private void Update()
    {
        if (_isRunning)
        {
            X = _transAmplitude * Mathf.Sin(2 * Mathf.PI * _transVelocity * (Time.time - _startTime));
            Z = _tiltAmplitude * Mathf.Sin(2 * Mathf.PI * _tiltVelocity * (Time.time - _startTime));

            _target.eulerAngles = new Vector3(0, 0, Z);
            _target.position = new Vector3(X, 0, 0);
        }
    }
}

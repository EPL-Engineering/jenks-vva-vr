using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataLogger : MonoBehaviour
{
    public VisualFieldController controller;
    public ViveEyeTracker viveEyeTracker;

    private DataLog _log = new DataLog();

    private VRHMD _hmd;

    private bool _isTracking = false;
    private bool _isRunning = false;

    public string Filename
    {
        get
        {
            return _log.Filename;
        }
    }

    public void StartLogging(string config, VRHMD hmd)
    {
        _hmd = hmd;
        _isRunning = true;

        _log.Initialize(config, eyeTracking: _hmd != VRHMD.None);
    }

    public void StopLogging()
    {
        _isRunning = false;
        _log.WriteToDisk();
    }

    void LateUpdate()
    {
        if (!_isRunning) return;

        _log.StartEntry(Time.timeSinceLevelLoad, controller.X, controller.Z);

        if (_hmd == VRHMD.Vive)
        {
            _log.AddGaze(viveEyeTracker.GazeAngle);
        }
        //_log.AddEye(_tracker.LeftPosition, _tracker.LeftGazeAngle, _tracker.LeftGaze, _tracker.LeftSize, _tracker.LeftOpenness);
        //_log.AddEye(_tracker.RightPosition, _tracker.RightGazeAngle, _tracker.RightGaze, _tracker.RightSize, _tracker.RightOpenness);

        _log.EndEntry();
    }
}

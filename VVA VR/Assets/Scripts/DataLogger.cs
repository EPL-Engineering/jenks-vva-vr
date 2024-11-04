using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Fove.Unity;

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

        _log.Initialize(config, hmd);
    }

    public void StopLogging()
    {
        _isRunning = false;
        _log.WriteToDisk();
    }

    void LateUpdate()
    {
        if (!_isRunning) return;

        //_log.StartEntry(Time.timeSinceLevelLoad, controller.X, controller.RollTilt);
        _log.StartEntry(Time.time, controller.X, controller.RollTilt);

        if (_hmd == VRHMD.Vive)
        {
            _log.AddGaze(viveEyeTracker.GazeAngle.x, viveEyeTracker.GazeAngle.y);
        }
        else if (_hmd == VRHMD.FOVE)
        {
            var ray = FoveManager.GetHmdCombinedGazeRay().value;
            _log.AddGaze(ray.direction.x, ray.direction.y);

            var torsionLeft = FoveManager.GetEyeTorsion(Fove.Eye.Left).value;
            var torsionRight = FoveManager.GetEyeTorsion(Fove.Eye.Right).value;
            _log.AddTorsion(torsionLeft, torsionRight);
        }

        _log.EndEntry();
    }
}

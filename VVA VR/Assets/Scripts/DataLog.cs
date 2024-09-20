using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class DataLog
{
    private StringBuilder _data;
    private int _lengthIncrement;

    private string _dataPath;

    public string Filename
    {
        get
        {
            return Path.GetFileName(_dataPath);
        }
    }

    public DataLog() : this(30000) { }

    public DataLog(int lengthIncrement)
    {
        _lengthIncrement = lengthIncrement;
    }

    public void Initialize(string header, bool eyeTracking)
    {
        List<string> columnHeads = new List<string>();
        columnHeads.Add("Time_s");
        {
            columnHeads.Add("X");
            columnHeads.Add("Z");
        }

        if (eyeTracking)
        {
            columnHeads.Add("GazeAngX");
            columnHeads.Add("GazeAngY");
        }

        var dt = System.DateTime.Now;

        int ncols = columnHeads.Count;
        int charsPerDatum = 10;
        _data = new StringBuilder(header.Length + _lengthIncrement * ncols * charsPerDatum);
        _data.AppendLine("[VVA DATA LOG]");
        _data.AppendLine("date = " + dt.ToString("G"));
        foreach (var s in header.Split(','))
        {
            _data.AppendLine(s.TrimStart());
        }
        _data.AppendLine("[DATA]");

        string headerStr = $"{ columnHeads[0],15}";
        for (int k = 1; k < columnHeads.Count; k++)
        {
            headerStr += $"\t{columnHeads[k],10}";
        }
        _data.AppendLine(headerStr);

        string folder = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "Jenks", "VR Data Logs");
        if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);
        _dataPath = Path.Combine(folder, $"VVA-DataLog-{dt.ToString("yyyyMMdd_Hmmss")}.txt");
    }

    public void StartEntry(float time, float x, float z)
    {
        _data.Append($"{time,15:F4}\t{x,10:F4}\t{z,10:F4}");
    }

    public void StartGazeEntry(float time, Vector2 targetPosition)
    {
        _data.Append($"{time,15:F4}\t{targetPosition.x,10:F4}\t{targetPosition.y,10:F4}");
    }

    public void AddGaze(Vector2 gazeAngle)
    {
        _data.Append($"\t{gazeAngle.x,10:F4}\t{gazeAngle.y,10:F4}");
    }

    public void AddEye(Vector2 position, Vector2 gaze, Vector3 gazeDir, float size, float openness)
    {
        _data.Append($"\t{position.x,10:F4}\t{position.y,10:F4}");
        _data.Append($"\t{gaze.x,10:F4}\t{gaze.y,10:F4}");
        _data.Append($"\t{gazeDir.x,10:F4}\t{gazeDir.y,10:F4}\t{gazeDir.z,10:F4}");
        _data.Append($"\t{size,10:F4}\t{openness,10:F4}");
    }

    public void EndEntry()
    {
        _data.Append(System.Environment.NewLine);
    }

    public void WriteToDisk(string path)
    {
        File.WriteAllText(path, _data.ToString());
    }

    public void WriteToDisk()
    {
        WriteToDisk(_dataPath);
    }
}
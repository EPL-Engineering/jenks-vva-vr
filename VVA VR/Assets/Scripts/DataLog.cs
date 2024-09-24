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

    public void Initialize(string header, VRHMD vrHMD)
    {
        List<string> columnHeads = new List<string>();
        columnHeads.Add("Time_s");
        {
            columnHeads.Add("X");
            columnHeads.Add("RollTilt");
        }

        if (vrHMD != VRHMD.None)
        {
            columnHeads.Add("GazeAngX");
            columnHeads.Add("GazeAngY");
        }
        if (vrHMD == VRHMD.FOVE)
        {
            columnHeads.Add("TorsionLeft");
            columnHeads.Add("TorsionRight");
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

    public void StartEntry(float time, float x, float rollTilt)
    {
        _data.Append($"{time,15:F4}\t{x,10:F4}\t{rollTilt,10:F4}");
    }

    public void AddGaze(float x, float y)
    {
        _data.Append($"\t{x,10:F4}\t{y,10:F4}");
    }

    public void AddTorsion(float left, float right)
    {
        _data.Append($"\t{left,10:F4}\t{right,10:F4}");
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
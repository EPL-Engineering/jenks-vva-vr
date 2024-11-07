using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

public class BuildStandalone : MonoBehaviour
{
    [MenuItem("Tools/Build Windows standalone")]
    public static void MyBuild()
    {
        ClearConsole();
        Debug.Log("Beginning Windows standalone build..."); 

        var proc = new System.Diagnostics.Process();

        var scenesInBuild = new List<EditorBuildSettingsScene>(EditorBuildSettings.scenes);

        var buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = scenesInBuild.Select(x => x.path).ToArray();
        buildPlayerOptions.locationPathName = "Build/VVA VR.exe";
        buildPlayerOptions.target = BuildTarget.StandaloneWindows64;
        buildPlayerOptions.options = BuildOptions.None;

        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;

        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded.");
        }

        if (summary.result == BuildResult.Failed)
        {
            Debug.Log("Build failed.");
            return;
        }
    }

    static void ClearConsole()
    {
        var logEntries = System.Type.GetType("UnityEditor.LogEntries, UnityEditor.dll");
        var clearMethod = logEntries.GetMethod("Clear", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
        clearMethod.Invoke(null, null);
    }
}
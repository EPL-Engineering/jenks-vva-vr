using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using KLib;

using Jenks.VVA;

public class WallController : MonoBehaviour
{
    public Material material;
    public Light sceneLight;

    public static readonly float wallSceneFOV = 27f;

    public void InitializeWall(WallProperties properties, float vfov, Vector2 screenSize)
    {
        var aspectRatio = (float)screenSize.x / screenSize.y;

        float hfov = 2 * Mathf.Rad2Deg * Mathf.Atan(aspectRatio * Mathf.Tan(wallSceneFOV / 2 * Mathf.Deg2Rad));

        float width_wu = 2 * properties.wallDistance_m * Mathf.Tan(hfov / 2 * Mathf.Deg2Rad);

        float pixelsPerWU = (float)screenSize.x / width_wu;
        var pixelsPerBar = Mathf.RoundToInt(properties.barSpacing_m * pixelsPerWU);

        width_wu *= 8;

        int numBars = Mathf.CeilToInt(width_wu / properties.barSpacing_m);
        if (numBars % 2 == 0)
        {
            numBars++;
            width_wu = numBars * properties.barSpacing_m;
        }

        float fovCompensatedWallDistance = properties.wallDistance_m * Mathf.Tan(wallSceneFOV / 2 * Mathf.Deg2Rad) / Mathf.Tan(vfov / 2 * Mathf.Deg2Rad);
       
        KLogger.Debug("num bars = " + numBars);
        KLogger.Debug("fov compensated wall distance = " + fovCompensatedWallDistance);


        int barWidth_pixels = Mathf.CeilToInt(properties.barWidth_m * pixelsPerWU);

        Texture2D tex = new Texture2D(pixelsPerBar, pixelsPerBar, TextureFormat.ARGB32, false);
        var colors = tex.GetPixels();
        for (int k = 0; k < colors.Length; k++) colors[k] = Color.white;

        int offset = Mathf.RoundToInt((float)(pixelsPerBar - barWidth_pixels) / 2);
        for (int krow = 0; krow < pixelsPerBar; krow++)
        {
            for (int kcol = 0; kcol < barWidth_pixels; kcol++) colors[kcol + offset] = Color.black;
            offset += pixelsPerBar;
        }

        tex.SetPixels(colors);
        tex.Apply();

        material.mainTexture = tex;
        material.mainTextureScale = new Vector2(numBars, 1);

        transform.position = new Vector3(0, properties.wallOffset_m, fovCompensatedWallDistance);
        transform.localScale = new Vector3(width_wu, properties.wallHeight_m, 1);
        sceneLight.enabled = true;
    }

    public void HideWall()
    {
        transform.position = new Vector3(0, 0, -10);
        sceneLight.enabled = false;
    }

}

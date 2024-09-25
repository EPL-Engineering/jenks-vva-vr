using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using KLib;

using Jenks.VVA;

public class GratingController : MonoBehaviour
{
    public GameObject barPrefab;

    private GameObject _bars;
    public Material material;
    public Transform quad;

    public void InitializeGrating(GratingProperties properties, float vfov, Vector2 screenSize)
    {
        transform.localEulerAngles = Vector3.zero;
        transform.position = new Vector3(0, 0, 1);

        var aspectRatio = (float)screenSize.x / screenSize.y;

        float degreesPerBar = 1f / properties.density_deg;

        float hfov = 2 * Mathf.Rad2Deg * Mathf.Atan(aspectRatio * Mathf.Tan(vfov / 2 * Mathf.Deg2Rad));
        float width_wu = 2 * properties.distance_m * Mathf.Tan(hfov / 2 * Mathf.Deg2Rad);

        width_wu *= 2;

        var wuPerBar = 2 * properties.distance_m * Mathf.Tan(degreesPerBar / 2 * Mathf.Deg2Rad);
        float numBars = (width_wu / wuPerBar);

        float pixelsPerWU = (float)screenSize.x / width_wu;
        var pixelsPerBar = Mathf.RoundToInt(wuPerBar * pixelsPerWU);

        float barWidth_wu = 2 * properties.distance_m * Mathf.Tan(properties.size_deg / 2 * Mathf.Deg2Rad);
        int barWidth_pixels = Mathf.CeilToInt(barWidth_wu * pixelsPerWU);

        KLogger.Debug("Screen width (pixels) = " + screenSize.x);
        KLogger.Debug("Screen width (w.u.) = " + width_wu);
        KLogger.Debug("Screen width (degrees) = " + hfov);
        KLogger.Debug("world units per bar = " + wuPerBar);
        KLogger.Debug("num bars = " + numBars);

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

        quad.localScale = new Vector3(width_wu, width_wu, 1);
        material.mainTexture = tex;
        material.mainTextureScale = new Vector2(numBars, 1);


        //float height = 2 * properties.distance_m * Mathf.Tan(vfov / 2 * Mathf.Deg2Rad);


        //var delta_x = 2 * properties.distance_m * Mathf.Tan(1 / properties.density_deg / 2 * Mathf.Deg2Rad);
        //var numBars = Mathf.CeilToInt(width / delta_x);
        //if (numBars % 2 == 0) ++numBars;
        //KLogger.Debug("numBars = " + numBars);

        //var barSize = 2 * properties.distance_m * Mathf.Tan(properties.size_deg / 2 * Mathf.Deg2Rad);

        //float x = -(numBars - 1) / 2 * delta_x;

        //KLogger.Debug("barSize (cm) = " + barSize * 100);

        //_bars = new GameObject("bars");
        //_bars.transform.parent = transform;

        //barPrefab.SetActive(true);
        //barPrefab.transform.localScale = new Vector3(barSize, 0.2f, 1);

        //for (int k = 0; k < numBars; k++)
        //{
        //    var obj = GameObject.Instantiate(barPrefab, new Vector3(x, 0, 0), Quaternion.identity, _bars.transform);
        //    obj.name = "Bar " + (k+1).ToString();

        //    x += delta_x;
        //}

        //barPrefab.SetActive(false);
        //_bars.transform.localPosition = new Vector3(0, 0, 1);

    }

    public void ClearGrating()
    {
        transform.position = new Vector3(0, -10, 1);

        //GameObject.Destroy(_bars);
    }

}

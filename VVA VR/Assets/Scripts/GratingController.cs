using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using KLib;

using Jenks.VVA;

public class GratingController : MonoBehaviour
{
    public GameObject barPrefab;

    private GameObject _bars;

    public void InitializeGrating(GratingProperties properties, float vfov, float amplitude)
    {
        var aspectRatio = (float)Screen.width / Screen.height;
        float height = 2 * properties.distance_m * Mathf.Tan(vfov / 2 * Mathf.Deg2Rad);

        float hfov = vfov * aspectRatio;
        float width_deg = hfov; // + 2 * amplitude;
        float width = 2 * properties.distance_m * Mathf.Tan(hfov / 2 * Mathf.Deg2Rad);

        var numBars = Mathf.CeilToInt(width_deg * properties.density_deg);

        var barSize = 2 * properties.distance_m * Mathf.Tan(properties.size_deg / 2 * Mathf.Deg2Rad);
        barSize = 0.01f;

        var delta_x = width / (numBars - 1);
        float x = -(numBars - 1) / 2 * delta_x;

        KLogger.Debug("barSize (cm) = " + barSize*100);

        _bars = new GameObject("bars");
        _bars.transform.parent = transform;

        barPrefab.SetActive(true);
        barPrefab.transform.localScale = new Vector3(barSize, 10, 1);

        for (int k = 0; k < numBars; k++)
        {
            var obj = GameObject.Instantiate(barPrefab, new Vector3(x, 0, 0), Quaternion.identity, _bars.transform);
            obj.name = "Bar " + (k+1).ToString();

            x += delta_x;
        }

        barPrefab.SetActive(false);
        _bars.transform.localPosition = new Vector3(0, 0, 1);

    }

    public void ClearGrating()
    {
        GameObject.Destroy(_bars);
    }

}

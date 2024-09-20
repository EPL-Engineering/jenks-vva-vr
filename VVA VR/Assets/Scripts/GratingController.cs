using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using KLib;

using Jenks.VVA;

public class GratingController : MonoBehaviour
{
    public GameObject barPrefab;

    private GameObject _bars;

    public void InitializeGrating(GratingProperties properties, float vfov)
    {
        transform.localEulerAngles = Vector3.zero;
        transform.position = Vector3.zero;

        var aspectRatio = (float)Screen.width / Screen.height;
        float height = 2 * properties.distance_m * Mathf.Tan(vfov / 2 * Mathf.Deg2Rad);

        float hfov = 2 * Mathf.Rad2Deg * Mathf.Atan(aspectRatio * Mathf.Tan(vfov/2 * Mathf.Deg2Rad));
        float width = 2 * 2 * properties.distance_m * Mathf.Tan(hfov / 2 * Mathf.Deg2Rad);

        var delta_x = 2 * properties.distance_m * Mathf.Tan(1 / properties.density_deg / 2 * Mathf.Deg2Rad);
        var numBars = Mathf.CeilToInt(width / delta_x);
        if (numBars % 2 == 0) ++numBars;
        KLogger.Debug("numBars = " + numBars);

        var barSize = 2 * properties.distance_m * Mathf.Tan(properties.size_deg / 2 * Mathf.Deg2Rad);
        barSize = 0.01f;

        float x = -(numBars - 1) / 2 * delta_x;

        KLogger.Debug("barSize (cm) = " + barSize * 100);

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

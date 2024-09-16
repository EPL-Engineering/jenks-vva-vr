using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using KLib;

using Jenks.VVA;

public class RandomDotsController : MonoBehaviour
{
    public GameObject dotPrefab;

    private float _fov;

    private List<RandomDot> _dots = new List<RandomDot>();

    public void InitializeDots(Dots dots, float vfov)
    {
        _fov = vfov;
        var aspectRatio = (float)Screen.width / Screen.height;
        float height = 2 * dots.distance_m * Mathf.Tan(_fov/2 * Mathf.Deg2Rad);
        float width = height * aspectRatio;

        float width_deg = 2 * Mathf.Rad2Deg * Mathf.Atan(width / (2 * dots.distance_m));
        float height_deg = 2 * Mathf.Rad2Deg* Mathf.Atan(height / (2 * dots.distance_m));

        float surfaceArea_deg2 = height_deg * width_deg;
        var numDots = Mathf.RoundToInt(surfaceArea_deg2 * dots.density_deg2);

        KLogger.Debug("ndots = " + numDots);

        var dotSize = 2 * dots.distance_m * Mathf.Tan(dots.size_deg / 2 * Mathf.Deg2Rad);
        var sdDotVel = 2 * dots.distance_m * Mathf.Tan(dots.sdVelocity_deg_per_s / 2 * Mathf.Deg2Rad);

        KLogger.Debug("dotSize = " + dotSize);

        dotPrefab.SetActive(true);
        for (int k = 0; k < numDots; k++)
        {
            var obj = GameObject.Instantiate(dotPrefab, new Vector3(0, 0, 0), Quaternion.identity, transform);
            obj.name = "Dot" + _dots.Count.ToString();

            var rd = obj.GetComponent<RandomDot>();
            _dots.Add(rd);
        }

        var grn = new KLib.Math.GaussianRandom();

        foreach (var d in _dots)
        {
            d.Initialize(dotSize, height, width, grn.Next(0, sdDotVel));
        }

        dotPrefab.SetActive(false);
        transform.localPosition = new Vector3(0, 0, 1);
    }

    public void ClearDots()
    {
        transform.localPosition = new Vector3(0, -10, 1);
        foreach (var d in _dots)
        {
            GameObject.Destroy(d.gameObject);
        }
        _dots.Clear();
    }
}

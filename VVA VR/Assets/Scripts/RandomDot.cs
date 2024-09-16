using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDot : MonoBehaviour
{
    public Transform quad;

    private float _velocity;
    private Vector3 _direction;
    private float _height;
    private float _width;

    public void Initialize(float size, float projectionHeight, float projectionWidth, float velocity)
    {
        _height = projectionHeight;
        _width = projectionWidth;

        _velocity = velocity;
        var angle = Random.Range(0, 2 * Mathf.PI);
        _direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);

        quad.localScale = size * Vector3.one;
        quad.localPosition = new Vector3(0, 0, 0);

        RandomizePosition(_height, _width);
    }

    private void RandomizePosition(float height, float width)
    {
        float x = Random.Range(-width / 2, width / 2);
        float y = Random.Range(-height / 2, height / 2);
        transform.localPosition = new Vector3(x, y, 0);
    }

    private void LateUpdate()
    {
        var delta = _velocity * Time.deltaTime * _direction;
        var pos = transform.localPosition + delta;
        if (pos.x > _width / 2) pos.x -= _width;
        if (pos.x < -_width / 2) pos.x += _width;
        if (pos.y > _height / 2) pos.y -= _height;
        if (pos.y < -_height / 2) pos.y += _height;
        transform.localPosition = pos;
    }
}

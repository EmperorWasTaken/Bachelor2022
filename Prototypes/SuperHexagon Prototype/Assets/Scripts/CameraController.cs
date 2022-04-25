using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraController : MonoBehaviour
{
    private float _rotationSpeed = 100f;
    private float _rotationDuration = 2f;
    private float _rotation;

    private void Update()
    {
        SetRotation();
        Rotate();
    }

    private void Rotate()
    {
        _rotationDuration -= Time.deltaTime;
        
        if (_rotationDuration > 0f)
        {
            transform.RotateAround(
                transform.localPosition,
                Vector3.up,
                _rotation * Time.deltaTime);
        }
    }

    private void SetRotation()
    {
        if (_rotationDuration > 0f)
        {
            return;
        }

        _rotation = Random.Range(-_rotationSpeed, _rotationSpeed);
        _rotationDuration = Random.Range(1f, 3f);
    }
}

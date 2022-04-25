using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;
    
    private Transform _transform;
    private float _rotation;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        Rotation();
    }

    private void Rotation()
    {
        _rotation = Input.GetAxis("Horizontal");
        
        transform.Rotate(Vector3.up * _rotation * rotationSpeed * Time.deltaTime);
    }
}

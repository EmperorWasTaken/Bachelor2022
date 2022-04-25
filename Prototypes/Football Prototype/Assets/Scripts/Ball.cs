using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector3 _startPos;
    private Rigidbody _rb;
    public Vector3 StartPos() => _startPos;

    public void ResetVelocity()
    {
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
    }
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _startPos = transform.position;
    }
}

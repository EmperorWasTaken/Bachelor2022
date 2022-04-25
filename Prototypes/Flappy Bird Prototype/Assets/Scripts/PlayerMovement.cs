using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce = 250f;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponentInChildren<Rigidbody>();
    }

    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rb.velocity = Vector3.zero;
            _rb.AddForce(Vector3.up * jumpForce);
        }
    }
}

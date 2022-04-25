using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 _startPosition;
    
    private float _xMovement;
    private float _yMovement;
    private float _movementSpeed = 3f;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        _xMovement = Input.GetAxis("Horizontal");
        _yMovement = Input.GetAxis("Vertical");
        
        transform.position += new Vector3(_xMovement, transform.position.y, _yMovement)
                                  .normalized * _movementSpeed * Time.deltaTime;
    }
}

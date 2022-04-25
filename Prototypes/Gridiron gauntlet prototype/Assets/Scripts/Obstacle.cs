using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float _moveSpeed = 1f;
    private float _timeToLive = 10f;
    private Vector3 _moveDirection = Vector3.zero;

    private void Awake()
    {
        switch (transform.position.x)
        {
            case -2f:
                _moveDirection = Vector3.right;
                break;
            case .5f:
                _moveDirection = Vector3.back;
                break;
            case 7f:
                _moveDirection = Vector3.left;
                break;
            case 4.5f:
                _moveDirection = Vector3.forward;
                break;
        }
    }

    private void Update()
    {
        CheckLifetime();
        MoveObject();
    }

    private void CheckLifetime()
    {
        _timeToLive -= Time.deltaTime;
        if (_timeToLive <= 0f)
        {
            Destroy(gameObject);
        }
    }
    
    private void MoveObject()
    {
        transform.position += _moveDirection * _moveSpeed * Time.deltaTime;
    }
}

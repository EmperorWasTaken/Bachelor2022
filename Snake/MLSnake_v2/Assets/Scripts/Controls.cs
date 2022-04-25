using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    private EnvironmentEventManager _eventManager;
    
    private float _horizontal;
    private float _vertical;

    private void Start()
    {
        _eventManager = GetComponentInParent<EnvironmentEventManager>();
    }

    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        SetDirection();
    }

    private void SetDirection()
    {
        if (_horizontal > 0f)
        {
            _eventManager.DirectionChange(MoveDirection.East);
        }
        else if (_horizontal < 0f)
        {
            _eventManager.DirectionChange(MoveDirection.West);
        }
        else if (_vertical > 0f)
        {
            _eventManager.DirectionChange(MoveDirection.North);
        }
        else if (_vertical < 0f)
        {
            _eventManager.DirectionChange(MoveDirection.South);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private Vector2Int _position;
    private bool _moving = true;

    public Vector2Int Position() => _position;

    private void Start()
    {
        _position.x = Mathf.RoundToInt(transform.position.x);
        _position.y = Mathf.RoundToInt(transform.position.z);
    }

    private void Update()
    {
        if (_moving)
        {
            UpdatePosition();    
        }
    }

    private void UpdatePosition()
    {
        _position.x = Mathf.RoundToInt(transform.position.x);
        _position.y = Mathf.RoundToInt(transform.position.z);
    }
}

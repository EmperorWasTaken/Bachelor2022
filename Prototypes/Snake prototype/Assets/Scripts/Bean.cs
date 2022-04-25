using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bean : MonoBehaviour
{
    private float _xBoundaryMin = 1f;
    private float _zBoundaryMin = 1f;
    private float _xBoundaryMax = 18f;
    private float _zBoundaryMax = 18f;
    
    private float _xPosition;
    private float _zPosition;

    private float _halfSquare = 0.5f; // To get bean in the middle of a square
    public event Action BeanPickedUp;

    private void OnTriggerEnter(Collider other)
    {
        BeanPickedUp?.Invoke();
        Relocate();
    }

    private void Relocate()
    {
        _xPosition = Random.Range(_xBoundaryMin, _xBoundaryMax) + _halfSquare;
        _zPosition = Random.Range(_zBoundaryMin, _zBoundaryMax) + _halfSquare;

        transform.position = new Vector3(_xPosition, transform.position.y, _zPosition);
    }
}

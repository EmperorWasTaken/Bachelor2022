using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class BoundsHandler : MonoBehaviour
{
    [SerializeField] private Snake snake;
    private EnvironmentEvents _environmentEvents;

    private int _xBoundsMin = -10;
    private int _xBoundsMax = 10;
    private int _zBoundsMin = -10;
    private int _zBoundsMax = 10;

    private void Awake()
    {
        _environmentEvents = GetComponentInParent<EnvironmentEvents>();
        _environmentEvents.OnMove += CheckBounds;
    }

    private void OnDestroy()
    {
        _environmentEvents.OnMove -= CheckBounds;
    }

    private void LateUpdate()
    {
        if (Input.GetKey(KeyCode.R))
        {
            _environmentEvents.ResetGame();
        }
    }

    private void CheckBounds(Vector3 position)
    {
        if (position.x < _xBoundsMin || position.x >= _xBoundsMax)
        {
            _environmentEvents.ResetGame();
            return;
        }

        if (position.z < _zBoundsMin || position.z >= _zBoundsMax)
        {
            _environmentEvents.ResetGame();
            return;
        }
    }
}

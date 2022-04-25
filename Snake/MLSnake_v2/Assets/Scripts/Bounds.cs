using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    private EnvironmentEventManager _eventManager;
    private Player _player;

    private float _xMin = -10f;
    private float _xMax = 9f;
    private float _zMin = -10f;
    private float _zMax = 9f;

    private void Start()
    {
        _player = GetComponentInChildren<Player>();
        _eventManager = GetComponent<EnvironmentEventManager>();
        _eventManager.OnMovePlayer += CheckBounds;
    }

    private void OnDestroy()
    {
        _eventManager.OnMovePlayer -= CheckBounds;
    }

    private void CheckBounds()
    {
        Vector3 position = _player.Head.transform.localPosition;

        if (position.x < _xMin || position.x > _xMax || position.z < _zMin || position.z > _zMax)
        {
            _eventManager.GameReset();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    private EnvironmentEventManager _eventManager;
    private Player _player;

    private void Start()
    {
        _eventManager = GetComponentInParent<EnvironmentEventManager>();
        _player = GetComponentInParent<Player>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == _player.Head)
        {
            _eventManager.GameReset();
        }
    }
}

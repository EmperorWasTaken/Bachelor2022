using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePart : MonoBehaviour
{
    private EnvironmentEvents _environmentEvents;

    private void Awake()
    {
        _environmentEvents = GetComponentInParent<EnvironmentEvents>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _environmentEvents.ResetGame();
        }
    }
}

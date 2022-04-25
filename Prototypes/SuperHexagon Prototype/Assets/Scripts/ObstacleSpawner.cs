using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject hexagon;

    private float _spawnTimer = 1.5f;
    private float _timeToSpawn = 1f;

    private void Update()
    {
        SpawnHexagon();
    }

    private void SpawnHexagon()
    {
        _spawnTimer -= Time.deltaTime;

        if (_spawnTimer <= 0f)
        {
            Instantiate(hexagon, transform.position, Quaternion.identity);
            _spawnTimer = _timeToSpawn;
        }
    }
}

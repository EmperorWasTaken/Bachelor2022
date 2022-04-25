using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private float spawnTimer = 5f;
    [SerializeField] private GameObject obstacle;

    private float _timeToSpawn = 3f;

    private void Update()
    {
        SpawnObstacle();
    }

    private void SpawnObstacle()
    {
        _timeToSpawn -= Time.deltaTime;

        if (_timeToSpawn <= 0f)
        {
            Instantiate(obstacle, transform.position + GetYOffset(), Quaternion.identity);
            _timeToSpawn = spawnTimer;
        }
    }

    private Vector3 GetYOffset()
    {
        return new Vector3(0f, Random.Range(-3f, 3f), 0f);
    }
}

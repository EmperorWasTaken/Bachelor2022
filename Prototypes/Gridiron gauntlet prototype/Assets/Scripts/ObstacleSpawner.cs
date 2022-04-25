using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private List<Obstacle> obstacles;
    [SerializeField] private List<GameObject> spawnPoints;

    private float _timeToWait = 4f;
    private float _respawnTimer = 4f;
    
    private void Update()
    {
        SpawnObstacle();
    }

    private void SpawnObstacle()
    {
        _timeToWait -= Time.deltaTime;

        GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];

        if (_timeToWait <= 0f)
        {
            int obstacleChoice = Random.Range(0, obstacles.Count);
            Debug.Log("Spawning object");
            
            Instantiate(
                obstacles[obstacleChoice].gameObject,
                spawnPoint.transform.position,
                spawnPoint.transform.rotation);

            _timeToWait = _respawnTimer;
        }
    }
}

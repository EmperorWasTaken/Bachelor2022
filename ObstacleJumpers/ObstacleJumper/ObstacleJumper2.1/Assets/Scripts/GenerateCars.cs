using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class GenerateCars : MonoBehaviour
{
    public GameObject carPrefab;

    private float nextSpawnTime;
    public float maxSpawnDelay = 2;
    public float minSpawnDelay = 1;
    private Vector3 screenBounds;
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        
    }

    private void Update()
    {
        
        if (ShouldSpawn())
        {
            SpawnCar();
        }
    }

    private void SpawnCar()
    {
        nextSpawnTime = Time.time + Random.Range(minSpawnDelay, maxSpawnDelay);
        Instantiate(carPrefab);
    }

    private bool ShouldSpawn()
    {
        return Time.time >= nextSpawnTime;
    }
}

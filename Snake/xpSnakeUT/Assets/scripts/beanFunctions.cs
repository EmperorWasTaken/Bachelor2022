using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class beanFunctions : MonoBehaviour
{

    [SerializeField] private playerMovment _player;
    [SerializeField] private scoreCounter _score;
    
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(-9f, 9f), 0.6f, Random.Range(-9f, 9f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        _player.moveSpeed += 0.5f;
        transform.position = new Vector3(Random.Range(-9f, 9f), 0.6f, Random.Range(-9f, 9f));
        _player.Grow();
        _score.beanScore += 1;
    }
}

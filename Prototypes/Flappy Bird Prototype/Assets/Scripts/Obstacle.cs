using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float _movementSpeed = 3f;

    public static event Action OnScore;
    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.position += Vector3.left * _movementSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Score yay");
            OnScore?.Invoke();
        }
    }
}

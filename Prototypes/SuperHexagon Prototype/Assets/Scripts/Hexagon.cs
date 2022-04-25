using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Hexagon : MonoBehaviour
{
    private Rigidbody _rb;

    private float _shrinkSpeed = 3f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.rotation = Quaternion.Euler(Vector3.up * Random.Range(0f, 360f));
        transform.localScale = Vector3.one * 10f;
    }

    private void Update()
    {
        transform.localScale -= Vector3.one * _shrinkSpeed * Time.deltaTime;
        if (transform.localScale.x <= .05f)
        {
            Destroy(gameObject);
        }
    }
}

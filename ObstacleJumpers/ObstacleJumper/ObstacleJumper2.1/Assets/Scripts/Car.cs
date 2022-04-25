using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = System.Random;

public class Car : MonoBehaviour
{
    [SerializeField] private float carSpeed = 10f;

    public Rigidbody rb;

    
    // Start is called before the first frame update
    void Start()
    {
        rb.transform.parent = null;
    }
    

    // Update is called once per frame
    void Update()
    {
        transform.position = rb.transform.position;
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * carSpeed * 100);
        rb.AddRelativeForce(transform.forward * carSpeed * 100);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float jumpSpeed = 100f;
    [SerializeField] private float jumpHeight;
    private bool onGround = false;
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            rb.AddForce(Vector3.up * jumpSpeed);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    [SerializeField] private float baseMoveSpeed = 1f;
    [SerializeField] private float movementModifier = 1f;
    [SerializeField] private float rotateSpeed = 50f;
    
    private Rigidbody _rb;
    private float _moveX;
    private float _moveY;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        GetInput();
        Movement();
    }

    private void GetInput()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            _moveX = Input.GetAxis("Horizontal");
        }
        else
        {
            _moveX = 0f;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            _moveY = Input.GetAxis("Vertical");
        }
        else
        {
            _moveY = 0f;
        }
    }

    private void Movement()
    {
        if (_moveY > 0)
        {
            if (movementModifier < 1.5f)
            {
                movementModifier += 0.5f * Time.deltaTime;
            }
        }
        else
        {
            movementModifier = 1f;
        }
        
        transform.Rotate(Vector3.up * _moveX * rotateSpeed * Time.deltaTime);
        _rb.AddForce(transform.forward * _moveY * baseMoveSpeed * movementModifier * Time.deltaTime);
    }
}

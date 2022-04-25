using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControlls : MonoBehaviour
{
    [SerializeField] private gameFunctions gameFunc;
    public Rigidbody rb;
    private Vector3 bodyControll;
    private Vector3 move;
    public bool tailbite = false;
    [SerializeField] public float moveSpeed = 10000;
    
    private string lastInput = "";

    public List<Transform> _segments;
    public Transform segmentPrefab;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(this.transform);

    }

    private void FixedUpdate()
    {
        if (lastInput == "W")
        {
            bodyControll = new Vector3(-1, 0, 0);
        }

        if (lastInput == "S")
        {
            bodyControll = new Vector3(1, 0, 0);
        }
        if (lastInput == "A")
        {
            bodyControll =  new Vector3(0, 0, -1);
        }
        if (lastInput == "D")
        {
            bodyControll =  new Vector3(0, 0, 1);
        }
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position - bodyControll;
        }

        if (_segments.Count > 1)
        {
            tailbite = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(move * Time.deltaTime - rb.velocity);
        
        if (gameFunc.speedUpdate)
        {
            Grow();
            
            if (lastInput == "W")
            {
                move = new Vector3(-moveSpeed, 0, 0);
                gameFunc.speedUpdate = false;
            }    
            if (lastInput == "S")
            {
                move = new Vector3(moveSpeed, 0, 0);
                gameFunc.speedUpdate = false;
            }   
            if (lastInput == "A")
            {
                move = new Vector3(0, 0, -moveSpeed);
                gameFunc.speedUpdate = false;
            }   
            if (lastInput == "D")
            {
                move = new Vector3(0, 0, moveSpeed);
                gameFunc.speedUpdate = false;
            }   
        }
        
        
        if (Input.GetKey(KeyCode.A) && lastInput != "D")
        {
            move = new Vector3(0, 0, -moveSpeed);
            lastInput = "A";
        }
        if (Input.GetKey(KeyCode.D) && lastInput != "A")
        {
            move = new Vector3(0, 0, moveSpeed);
            lastInput = "D";
        }
        if (Input.GetKey(KeyCode.W) && lastInput != "S")
        {
            move = new Vector3(-moveSpeed, 0, 0);
            lastInput = "W";
        }
        if (Input.GetKey(KeyCode.S)&& lastInput != "W")
        {
            move = new Vector3(moveSpeed, 0, 0);
            lastInput = "S";
        }

        
        
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
        
    }
    
}

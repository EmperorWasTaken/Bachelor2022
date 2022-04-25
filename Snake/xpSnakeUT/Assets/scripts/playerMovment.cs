using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovment : MonoBehaviour
{


    private Vector3 direction;

    public float moveSpeed = 5;

    private string lastKey = "";

    public List<Transform> _segments;
    public Transform segmentPrefab;
    private Vector3 bodyControll;
    
    // Start is called before the first frame update
    void Start()
    {
        _segments = new List<Transform>();
        _segments.Add(this.transform);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        bodyPosUpdate();
        
        transform.position += direction * moveSpeed * Time.deltaTime;
        
        if (Input.GetKey(KeyCode.W) && lastKey != "S")
        {
            direction = Vector3.forward;
            lastKey = "W";
        }
        if (Input.GetKey(KeyCode.S) && lastKey != "W")
        {
            direction = Vector3.back;
            lastKey = "S";
        }
        if (Input.GetKey(KeyCode.A) && lastKey != "D")
        {
            direction = Vector3.left;
            lastKey = "A";
        }
        if (Input.GetKey(KeyCode.D) && lastKey != "A")
        {
            direction = Vector3.right;
            lastKey = "D";
        }
    }

    private void bodyPosUpdate()
    {
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position - bodyControll;
        }

    }

    public void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        _segments.Add(segment);
        
    }
}

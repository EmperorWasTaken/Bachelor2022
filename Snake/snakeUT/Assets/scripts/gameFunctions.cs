using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using Random = UnityEngine.Random;

public class gameFunctions : MonoBehaviour
{
    [SerializeField] private playerControlls player;
    [SerializeField] private Transform tf;
    [SerializeField] private scoreCounter scoreC;
    public bool speedUpdate = false;
    
    public Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        pos = new Vector3(Random.Range(-4f, 14f), 5, Random.Range(-17f, 2f));
        
        player.moveSpeed += 500;
        speedUpdate = true;
        scoreC.beanScore += 1;
        tf.position = pos;

    }
    
}

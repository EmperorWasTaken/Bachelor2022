using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerGrowth : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;

    private Collider m_Collider;

    public bool restart = false;
    
    
    
    void Start()
    {
        m_Collider = GetComponent<Collider>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<playerMovment>()._segments.Count < 14)
        {
            m_Collider.enabled = false;
        }
        
        if (restart)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            restart = false;
        }    
    }

    private void OnTriggerEnter(Collider other)
    {
        restart = true;
    }
}

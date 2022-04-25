using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathZone : MonoBehaviour
{
    
    public bool restart = false;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

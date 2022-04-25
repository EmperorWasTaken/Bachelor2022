using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerGrowth : MonoBehaviour
{
    
    private bool restart = false;

    public playerControlls pc;
    
    
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


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "playerSeg")
        {
            restart = true;
        }
    }
}

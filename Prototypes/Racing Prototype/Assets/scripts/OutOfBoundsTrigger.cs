using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBoundsTrigger : MonoBehaviour
{
    public static bool bounds = false;
    public Vector3 start = new Vector3(5.03f, 11.84f, 13.47f);
    public GameObject theCar;
    
    
    private void Update()
    {
        if (bounds)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            bounds = false;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Prometheus Variant")
        {
            bounds = true;
        }
    }
}

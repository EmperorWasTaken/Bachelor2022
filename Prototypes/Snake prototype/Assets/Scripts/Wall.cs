using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wall : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Crash");
        playerController.ResetGame();
    }
}

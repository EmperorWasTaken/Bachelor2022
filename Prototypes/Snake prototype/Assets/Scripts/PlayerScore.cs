using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private Bean bean;
    [SerializeField] private PlayerController playerController;
    
    private int _score;

    public int Score() => _score;

    private void Start()
    {
        bean.BeanPickedUp += HandleBeanPickedUp;
        playerController.GameReset += HandleResetGame;
    }

    private void OnDestroy()
    {
        bean.BeanPickedUp -= HandleBeanPickedUp;
        playerController.GameReset -= HandleResetGame;
    }

    private void HandleBeanPickedUp()
    {
        _score++;
        Debug.Log($"Bean so nice, current score: {_score}");
    }

    private void HandleResetGame()
    {
        _score = 0;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private int _score;
    
    private void Awake()
    {
        scoreText.text = "0";
        Obstacle.OnScore += OnScoreHandler;
    }

    private void OnDestroy()
    {
        Obstacle.OnScore -= OnScoreHandler;
    }

    private void OnScoreHandler()
    {
        Debug.Log("Increasing score");
        _score++;
        scoreText.text = _score.ToString();
    }
}

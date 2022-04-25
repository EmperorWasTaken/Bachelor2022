using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] [Range(1, 100)] private int speedIncreaseInterval = 5;
    
    private EnvironmentEvents _environmentEvents;
    public int Points { get; set; }
    private void Awake()
    {
        _environmentEvents = GetComponentInParent<EnvironmentEvents>();
        _environmentEvents.OnBeanPickedUp += OnBeanPickedUp;
        _environmentEvents.OnResetGame += OnGameReset;
        UpdateScore();
    }

    private void OnDestroy()
    {
        _environmentEvents.OnBeanPickedUp -= OnBeanPickedUp;
    }

    private void UpdateScore()
    {
        scoreText.text = $"Score:\n{Points}";
    }

    private void OnBeanPickedUp()
    {
        Points++;
        UpdateScore();

        if (Points % speedIncreaseInterval == 0)
        {
            _environmentEvents.SpeedIncrease();
        }
    }

    private void OnGameReset()
    {
        Points = 0;
        UpdateScore();
    }
}

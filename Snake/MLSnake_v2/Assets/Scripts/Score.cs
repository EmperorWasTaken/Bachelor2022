using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Player player;
    private EnvironmentEventManager _eventManager;
    private TMP_Text _scoreText;

    private void Start()
    {
        _scoreText = GetComponentInChildren<TMP_Text>();
        _eventManager = GetComponentInParent<EnvironmentEventManager>();
        _eventManager.OnRewardPickedUp += UpdateText;
        _eventManager.OnGameReset += GameReset;
        _eventManager.OnEpisodeBegin += GameReset;
        GameReset();
    }

    private void OnDestroy()
    {
        _eventManager.OnRewardPickedUp -= UpdateText;
    }

    private void UpdateText()
    {
        _scoreText.text = $"Score: {(player.Length) * 10}";
    }

    private void GameReset()
    {
        _scoreText.text = $"try finger, but hole";
    }
}

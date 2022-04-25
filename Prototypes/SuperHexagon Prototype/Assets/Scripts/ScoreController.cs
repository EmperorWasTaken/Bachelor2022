using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    private float _score;
    private float _highScore;

    private void Update()
    {
        _score += 1f * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_score > _highScore)
        {
            _highScore = _score;
        }
        
        Debug.Log($"Score: {_score}");
        Debug.Log($"Highscore: {_highScore}");

        _score = 0f;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Ball footBall;

    private int _goalCount;
    private float _resetTime = 1.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            _goalCount++;
            scoreText.text = _goalCount.ToString();
            Invoke(nameof(ResetBall), _resetTime);
        }
    }

    private void ResetBall()
    {
        footBall.ResetVelocity();
        footBall.transform.position = footBall.StartPos();
    }
}

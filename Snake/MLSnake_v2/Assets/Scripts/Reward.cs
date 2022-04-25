using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Reward : MonoBehaviour
{
    private EnvironmentEventManager _eventManager;

    private Vector3 _offset = new Vector3(.5f, 0f, .5f);
    private int _xMin = -10;
    private int _xMax = 9;
    private int _zMin = -10;
    private int _zMax = 9;

    private void Start()
    {
        _eventManager = GetComponentInParent<EnvironmentEventManager>();
        _eventManager.OnRewardPickedUp += MoveReward;
        _eventManager.OnEpisodeBegin += MoveReward;
    }

    private void OnDestroy()
    {
        _eventManager.OnRewardPickedUp -= MoveReward;
    }

    private void OnTriggerEnter(Collider other)
    {
        _eventManager.RewardPickedUp();
    }

    private void MoveReward()
    {
        Vector3 newPosition = new Vector3(Random.Range(_xMin, _xMax), 0f, Random.Range(_zMin, _zMax)) + _offset;
        transform.localPosition = newPosition;
    }
}

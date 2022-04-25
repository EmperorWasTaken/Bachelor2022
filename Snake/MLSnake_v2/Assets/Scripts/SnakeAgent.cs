using System;
using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using UnityEngine;

public class SnakeAgent : Agent
{
    [SerializeField] private Reward target;
    
    private EnvironmentEventManager _eventManager;
    private Player _player;

    private void Start()
    {
        _eventManager = GetComponentInParent<EnvironmentEventManager>();
        _eventManager.OnRewardPickedUp += RewardPickedUp;
        _eventManager.OnGameReset += GameReset;
        _eventManager.OnMovePlayer += ExistencePenalty;
        _player = GetComponent<Player>();
    }

    private void OnDestroy()
    {
        _eventManager.OnRewardPickedUp -= RewardPickedUp;
        _eventManager.OnGameReset -= GameReset;
        _eventManager.OnMovePlayer -= ExistencePenalty;
    }

    public override void OnEpisodeBegin()
    {
        _eventManager.EpisodeBegin();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(_player.Head.transform.localPosition);
        sensor.AddObservation(target.transform.localPosition);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        if (actions.DiscreteActions[0] == 0)
        {
            _eventManager.DirectionChange(MoveDirection.North);
        }
        else if (actions.DiscreteActions[0] == 1)
        {
            _eventManager.DirectionChange(MoveDirection.South);
        }
        else if (actions.DiscreteActions[0] == 2)
        {
            _eventManager.DirectionChange(MoveDirection.West);
        }
        else if (actions.DiscreteActions[0] == 3)
        {
            _eventManager.DirectionChange(MoveDirection.East);
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActions = actionsOut.DiscreteActions;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        if (horizontal > 0f)
        {
            discreteActions[0] = 3;
        }
        else if (horizontal < 0f)
        {
            discreteActions[0] = 2;
        }
        else if (vertical > 0f)
        {
            discreteActions[0] = 0;
        }
        else if (vertical < 0f)
        {
            discreteActions[0] = 1;
        }
        else
        {
            discreteActions[0] = 5;
        }
    }

    private void GameReset()
    {
        SetReward(-1f);
        EndEpisode();
    }

    private void RewardPickedUp()
    {
        AddReward(1f);
    }
    
    private void ExistencePenalty()
    {
        AddReward(-0.001f);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using UnityEngine;

public class SnakeAgent : Agent
{
    [SerializeField] private Bean target;
    [SerializeField] private List<GameObject> walls;
    
    private EnvironmentEvents _environmentEvents;
    private PlayerController _playerController;
    private Movement _movement;
    private Snake _snake;
    private void Start()
    {
        _environmentEvents = GetComponentInParent<EnvironmentEvents>();
        _playerController = GetComponent<PlayerController>();
        _movement = GetComponent<Movement>();
        _snake = GetComponent<Snake>();

        _environmentEvents.OnBeanPickedUp += OnBeanPickedUp;
        _environmentEvents.OnResetGame += OnResetGame;
    }

    private void OnDestroy()
    {
        _environmentEvents.OnBeanPickedUp -= OnBeanPickedUp;
        _environmentEvents.OnResetGame -= OnResetGame;
    }

    public override void OnEpisodeBegin()
    {
        
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(target.transform.localPosition);
        sensor.AddObservation(_snake.Head.transform.localPosition);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        AddReward(-0.001f);
        
        _playerController.ValidateInput(actions.DiscreteActions[0]);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActionsOut = actionsOut.DiscreteActions;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal > 0f)
        {
            discreteActionsOut[0] = 1;
        }
        
        else if (horizontal < 0f)
        {
            discreteActionsOut[0] = 2;
        }
        
        else if (vertical > 0f)
        {
            discreteActionsOut[0] = 3;
        }
        
        else if (vertical < 0f)
        {
            discreteActionsOut[0] = 4;
        }

        else
        {
            discreteActionsOut[0] = 0;
        }
    }

    private void OnBeanPickedUp()
    {
        SetReward(1.0f);
    }

    private void OnResetGame()
    {
        SetReward(-1.0f);
        EndEpisode();
    }
}

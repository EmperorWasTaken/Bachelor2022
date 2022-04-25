using System;
using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents.Actuators;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Direction direction;
    public Vector3 UserInput { get; set; }
    public Direction Direction => direction;
    
    private EnvironmentEvents _environmentEvents;
    private float _horizontalInput;
    private float _verticalInput;

    private void Awake()
    {
        _environmentEvents = GetComponentInParent<EnvironmentEvents>();
        _environmentEvents.OnResetGame += OnResetGame;
        _environmentEvents.OnInput += OnInput;
    }

    private void Update()
    {
        // GetUserInput();
    }

    private void OnDestroy()
    {
        _environmentEvents.OnResetGame -= OnResetGame;
        _environmentEvents.OnInput -= OnInput;
    }

    private void GetUserInput()
    {
        // _horizontalInput = Input.GetAxis("Horizontal");
        // _verticalInput = Input.GetAxis("Vertical");
        //
        // ValidateInput(_horizontalInput, _verticalInput);
    }

    private void OnInput(Vector3 input)
    {
        if (input == Vector3.zero)
        {
            return;
        }

        Direction newDirection = Directions.GetDirection(input);
        
        if (Directions.IsValidDirection(direction, newDirection))
        {
            direction = newDirection;
            _environmentEvents.DirectionChanged(newDirection);
        }
    }

    public void ValidateInput(int action)
    {
        if (action == 0)
        {
            return;
        }
        
        UserInput = Vector3.zero;
        
        if (action == 1)
        {
            UserInput += Vector3.right;
        }
        else if (action == 2)
        {
            UserInput += Vector3.left;
        }
        else if (action == 3)
        {
            UserInput += Vector3.forward;
        }
        else if (action == 4)
        {
            UserInput += Vector3.back;
        }

        if (UserInput != Vector3.zero)
        {
            _environmentEvents.Input(UserInput);
        }
    }

    private void OnResetGame()
    {
        direction = Direction.None;
    }
}

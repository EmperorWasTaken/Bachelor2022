using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float movementInterval = .5f;
    [SerializeField] private float speedIncreasePercentage = .2f;
    [SerializeField] private Snake snake;
    
    private EnvironmentEvents _environmentEvents;
    private Vector3 _direction;
    private bool _pause;
    private float _movementSpeed;

    private void Start()
    {
        _environmentEvents = GetComponentInParent<EnvironmentEvents>();
        _environmentEvents.OnResetGame += OnGameReset;
        _environmentEvents.OnDirectionChanged += OnDirectionChanged;
        _environmentEvents.OnSpeedIncrease += OnSpeedIncrease;
        InitSpeed();
        StartCoroutine(MoveCoroutine());
    }

    private void OnDestroy()
    {
        _environmentEvents.OnResetGame -= OnGameReset;
        _environmentEvents.OnDirectionChanged -= OnDirectionChanged;
        _environmentEvents.OnSpeedIncrease -= OnSpeedIncrease;
    }

    private IEnumerator MoveCoroutine()
    {
        while (true)
        {
            if (_pause)
            {
                yield return new WaitForSeconds(_movementSpeed);
                _pause = false;
            }
            Move();
            yield return new WaitForSeconds(_movementSpeed);
        }
    }

    private void Move()
    {
        int newTail = snake.TailIndex;

        GameObject tail = snake.Tail;
        GameObject head = snake.Head;
        
        tail.transform.localPosition = head.transform.localPosition + _direction;
        snake.Head = tail;

        newTail++;
        
        if (newTail == snake.SnakeSize)
        {
            newTail = 0;
        }

        snake.TailIndex = newTail;
        _environmentEvents.Move(tail.transform.localPosition);
    }

    private void InitSpeed()
    {
        _movementSpeed = movementInterval;
    }

    private void OnDirectionChanged(Direction newDirections)
    {
        _direction = Directions.GetVector(newDirections);
        Move();
        _pause = true;
    }

    private void OnGameReset()
    {
        GameObject head = snake.StartHead;
        head.transform.localPosition = Vector3.zero;
        InitSpeed();
    }

    private void OnSpeedIncrease()
    {
        _movementSpeed -= (_movementSpeed * speedIncreasePercentage);
    }
}

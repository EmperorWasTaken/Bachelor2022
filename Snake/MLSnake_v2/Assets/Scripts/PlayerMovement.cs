using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] [Range(.01f, 10f)] private float movementInterval = .3f;
    [SerializeField] [Range(.01f, .99f)] private float intervalModifier = .8f; 
    [SerializeField] private Player player;
    
    private EnvironmentEventManager _eventManager;
    private MoveDirection _direction = MoveDirection.None;
    private Coroutine _coroutine;
    private Coroutine _delayedMove;
    private bool _playing = true;
    private float _movementInterval;
    private void Start()
    {
        GameReset();
        _eventManager = GetComponentInParent<EnvironmentEventManager>();
        
        _eventManager.OnDirectionChange += DirectionChange;
        _eventManager.OnRewardPickedUp += LowerInterval;
        _eventManager.OnGameReset += GameReset;
        _eventManager.OnEpisodeBegin += ResetDirection;
        _coroutine = StartCoroutine(MoveCoroutine());
    }

    private void OnDestroy()
    {
        _eventManager.OnDirectionChange -= DirectionChange;
    }

    private IEnumerator MoveCoroutine()
    {
        while (_playing)
        {
            Move();
            yield return new WaitForSeconds(_movementInterval);
        }    
    }

    private void Move()
    {
        player.Tail.transform.localPosition = player.Head.transform.localPosition + Direction.GetVector(_direction);
        player.Head = player.Tail; 
        player.TailIndex++;

        if (player.TailIndex == player.Length)
        {
            player.TailIndex = 0;
        }
        player.Tail = player.body[player.TailIndex];
        
        _eventManager.MovePlayer();
    }

    private void DirectionChange(MoveDirection newDirection)
    {
        if (!Direction.ValidateDirection(_direction, newDirection))
        {
            return;
        }

        if (_delayedMove != null)
        {
            StopCoroutine(_delayedMove);
        }
        
        _direction = newDirection;
        StopCoroutine(_coroutine);
        Move();
        _delayedMove = StartCoroutine(DelayedMove());
    }

    private IEnumerator DelayedMove()
    {
        yield return new WaitForSeconds(_movementInterval);
        _coroutine = StartCoroutine(MoveCoroutine());
    }

    private void LowerInterval()
    {
        _movementInterval *= intervalModifier;
    }

    private void GameReset()
    {
        _movementInterval = movementInterval;
    }
    
    private void ResetDirection()
    {
        _direction = MoveDirection.None;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentEventManager : MonoBehaviour
{
    public event Action OnGameStart;
    public event Action OnGameReset;
    public event Action OnRewardPickedUp;
    public event Action OnMovePlayer;
    public event Action<MoveDirection> OnDirectionChange;
    public event Action OnEpisodeBegin;

    public void GameStart()
    {
        OnGameStart?.Invoke();
    }

    public void GameReset()
    {
        OnGameReset?.Invoke();
    }

    public void RewardPickedUp()
    {
        OnRewardPickedUp?.Invoke();
    }

    public void MovePlayer()
    {
        OnMovePlayer?.Invoke();
    }

    public void DirectionChange(MoveDirection newDirection)
    {
        OnDirectionChange?.Invoke(newDirection);
    }

    public void EpisodeBegin()
    {
        OnEpisodeBegin?.Invoke();
    }
}

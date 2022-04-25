using System;
using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents.Actuators;
using UnityEngine;

public class EnvironmentEvents : MonoBehaviour
{
    public event Action OnResetGame;
    public event Action OnBeanPickedUp;
    public event Action<Direction> OnDirectionChanged;
    public event Action<Vector3> OnMove;
    public event Action<Vector3> OnInput;
    public event Action OnSpeedIncrease;

    public void ResetGame()
    {
        OnResetGame?.Invoke();
    }
    public void BeanPickedUp()
    {
        OnBeanPickedUp?.Invoke();
    }

    public void DirectionChanged(Direction dir)
    {
        OnDirectionChanged?.Invoke(dir);
    }

    public void Move(Vector3 pos)
    {
        OnMove?.Invoke(pos);
    }

    public void Input(Vector3 input)
    {
        OnInput?.Invoke(input);
    }

    public void SpeedIncrease()
    {
        OnSpeedIncrease?.Invoke();
    }
}

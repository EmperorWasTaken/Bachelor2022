using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Directions
{
    
    public static Direction GetDirection(Vector3 input)
    {
        if (input == Vector3.forward)
        {
            return Direction.Up;
        }
        
        if (input == Vector3.back)
        {
            return Direction.Down;
        }
        
        if (input == Vector3.left)
        {
            return Direction.Left;
        }
        
        if (input == Vector3.right)
        {
            return Direction.Right;
        }

        return Direction.None;
    }

    public static Vector3 GetVector(Direction direction)
    {
        Vector3 vector = Vector3.zero;
        
        switch (direction)
        {
            case Direction.Up:
                vector = Vector3.forward;
                break;
            case Direction.Down:
                vector = Vector3.back;
                break;
            case Direction.Left:
                vector = Vector3.left;
                break;
            case Direction.Right:
                vector = Vector3.right;
                break;
        }

        return vector;
    }
    
    public static bool IsValidDirection(Direction previousDirection, Direction newDirection)
    {
        if (previousDirection == newDirection)
        {
            return false;
        }

        switch (previousDirection)
        {
            case Direction.Up:
                if (newDirection == Direction.Down)
                {
                    return false;
                }
                break;
            case Direction.Down:
                if (newDirection == Direction.Up)
                {
                    return false;
                }
                break;
            case Direction.Left:
                if (newDirection == Direction.Right)
                {
                    return false;
                }
                break;
            case Direction.Right:
                if (newDirection == Direction.Left)
                {
                    return false;
                }
                break;
        }

        return true;
    }
}

public enum Direction
{
    Up,
    Down,
    Left,
    Right,
    None
}

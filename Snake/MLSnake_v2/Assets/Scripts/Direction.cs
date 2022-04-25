using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Direction
{
    public static MoveDirection GetDirection(Vector3 input)
    {
        if (input == Vector3.forward)
        {
            return MoveDirection.North;
        }
        else if (input == Vector3.left)
        {
            return MoveDirection.West;
        }
        else if (input == Vector3.right)
        {
            return MoveDirection.East;
        }
        else if (input == Vector3.back)
        {
            return MoveDirection.South;
        }
        else
        {
            return MoveDirection.None;
        }
    }

    public static Vector3 GetVector(MoveDirection direction)
    {
        if (direction == MoveDirection.North)
        {
            return Vector3.forward;
        }
        else if (direction == MoveDirection.West)
        {
            return Vector3.left;
        }
        else if (direction == MoveDirection.East)
        {
            return Vector3.right;
        }
        else if (direction == MoveDirection.South)
        {
            return Vector3.back;
        }
        else
        {
            return Vector3.zero;
        }
    }

    public static bool ValidateDirection(MoveDirection direction, MoveDirection newDirection)
    {
        if (direction == newDirection)
        {
            return false;
        }

        if (direction == MoveDirection.North && newDirection == MoveDirection.South)
        {
            return false;
        }

        if (direction == MoveDirection.West && newDirection == MoveDirection.East)
        {
            return false;
        }

        if (direction == MoveDirection.East && newDirection == MoveDirection.West)
        {
            return false;
        }

        if (direction == MoveDirection.South && newDirection == MoveDirection.North)
        {
            return false;
        }

        return true;
    }
}

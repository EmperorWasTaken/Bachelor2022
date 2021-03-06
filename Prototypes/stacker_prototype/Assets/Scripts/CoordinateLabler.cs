using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteAlways]
public class CoordinateLabler : MonoBehaviour
{
    private TextMeshPro _label;
    private Vector2Int _coordinates;

    private void Awake()
    {
        _label = GetComponent<TextMeshPro>();
        DisplayCoordinates();
    }

    private void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
    }

    private void DisplayCoordinates()
    {
        _coordinates.x = Mathf.RoundToInt(transform.parent.position.x);
        _coordinates.y = Mathf.RoundToInt(transform.parent.position.z);
        
        _label.text = $"{_coordinates.x},{_coordinates.y}";
        
    }

    private void UpdateObjectName()
    {
        transform.parent.name = _coordinates.ToString();
    }
}

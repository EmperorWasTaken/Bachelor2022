using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public List<GameObject> SnakeBody;
    
    private EnvironmentEvents _environmentEvents;
    [HideInInspector] public GameObject Head { get; set; }
    [HideInInspector] public GameObject Tail { get; set; }
    
    [HideInInspector] public int TailIndex { get; set; }
    [HideInInspector] public int SnakeSize { get; set; }
    
    public GameObject StartHead => SnakeBody[0];

    private void Awake()
    {
        InitSnake();
        _environmentEvents = GetComponentInParent<EnvironmentEvents>();
        _environmentEvents.OnBeanPickedUp += OnBeanPickedUp;
        _environmentEvents.OnResetGame += OnResetGame;
        _environmentEvents.OnMove += OnMove;
    }

    private void OnDestroy()
    {
        _environmentEvents.OnBeanPickedUp -= OnBeanPickedUp;
        _environmentEvents.OnResetGame -= OnResetGame;
        _environmentEvents.OnMove -= OnMove;
    }

    public int FindSnakeSize()
    {
        int size = 0;

        foreach (var part in SnakeBody)
        {
            if (part.activeInHierarchy)
            {
                size++;
            }
            else
            {
                break;
            }
        }

        return size;
    }
    
    public void InitSnake()
    {
        SnakeSize = FindSnakeSize();
        TailIndex = SnakeSize - 1;
        Head = SnakeBody[0];
        Tail = SnakeBody[TailIndex];
    }

    private void OnBeanPickedUp()
    {
        foreach (var part in SnakeBody)
        {
            if (!part.activeInHierarchy)
            {
                part.SetActive(true);
                SnakeSize++;
                break;
            }
        }
    }

    private void OnResetGame()
    {
        for (int i = 1; i < SnakeBody.Count; i++)
        {
            SnakeBody[i].transform.localPosition = new Vector3(0f, -5f, 0f);
            SnakeBody[i].SetActive(false);
        }

        InitSnake();
    }

    private void OnMove(Vector3 pos)
    {
        Tail = SnakeBody[TailIndex];
    }
}

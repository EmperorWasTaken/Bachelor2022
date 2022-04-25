using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private EnvironmentEventManager _environmentEvent;
    public List<GameObject> body;
    public GameObject Head { get; set; }
    public GameObject Tail { get; set; }
    public int TailIndex { get; set; }
    public int Length { get; set; }

    private void Awake()
    {
        InitGame();
    }

    private void Start()
    {
        _environmentEvent = GetComponentInParent<EnvironmentEventManager>();
        _environmentEvent.OnGameReset += InitGame;
        _environmentEvent.OnRewardPickedUp += Grow;
        _environmentEvent.OnGameReset += GameReset;
    }

    private void OnDestroy()
    {
        _environmentEvent.OnGameReset -= InitGame;
        _environmentEvent.OnRewardPickedUp -= Grow;
        _environmentEvent.OnGameReset -= GameReset;
    }

    private void InitGame()
    {
        ResetBody();
        SetLength();
        TailIndex = Length - 1;
        Tail = body[TailIndex];
        Head = body[0];
    }

    private void ResetBody()
    {
        for (int i = 1; i < body.Count; i++)
        {
            body[i].SetActive(false);
            body[i].transform.localPosition = new Vector3(0f, -5f, 0f);
        }
    }

    private void SetLength()
    {
        int length = 0;
        foreach (var part in body)
        {
            if (part.activeInHierarchy)
            {
                length++;
            }
            else
            {
                break;
            }
        }

        Length = length;
    }

    private void Grow()
    {
        if (Length == body.Count)
        {
            return;
        }
        
        body[Length].SetActive(true);
        SetLength();
    }

    private void GameReset()
    {
        InitGame();
        Head.transform.localPosition = Vector3.zero;
    }
}

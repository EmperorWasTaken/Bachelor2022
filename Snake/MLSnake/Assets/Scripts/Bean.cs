using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bean : MonoBehaviour
{
    private EnvironmentEvents _environmentEvents;
    private Vector3 _offset = new Vector3(.5f, .3f, .5f);
    
    public int XMin { get; private set; }
    public int XMax { get; private set; }
    public int ZMin { get; private set; }
    public int ZMax { get; private set; }

    private void Awake()
    {
        _environmentEvents = GetComponentInParent<EnvironmentEvents>();
        _environmentEvents.OnBeanPickedUp += Move;
    }

    private void Start()
    {
        XMin = -10;
        XMax = 10;
        ZMin = -10;
        ZMax = 10;
        Move();
    }

    private void OnDestroy()
    {
        _environmentEvents.OnBeanPickedUp -= Move;
    }

    private void OnTriggerEnter(Collider other)
    {
        _environmentEvents.BeanPickedUp();
    }

    public void Move()
    {
        transform.localPosition = new Vector3(Random.Range(XMin, XMax), 0f, Random.Range(ZMin, ZMax))
                                  + _offset;
    }
}

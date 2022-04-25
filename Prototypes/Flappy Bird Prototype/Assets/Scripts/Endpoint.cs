using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endpoint : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Removing obstacle");
        other.gameObject.SetActive(false);
    }
}

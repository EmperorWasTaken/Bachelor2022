using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Destroy(other.transform.parent.gameObject);
    }
}

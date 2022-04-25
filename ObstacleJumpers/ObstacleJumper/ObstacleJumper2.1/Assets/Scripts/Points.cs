using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using System;

public class Points : MonoBehaviour
{
    public TMP_Text pointsText;
    public int pointCount = 0;

    void Update()
    {
        showPoints();
    }

    private void OnTriggerEnter(Collider other)
    {
        pointCount += 1;
    }

    private void showPoints()
    {
        pointsText.text = String.Format("{0}", pointCount);
    }
}

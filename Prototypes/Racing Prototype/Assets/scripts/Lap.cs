using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lap : MonoBehaviour
{
    public bool stopTime = false;
    public TMP_Text lapText;
    public int lapcount = 0;
    
    void Update()
    {
         displayLap();
    }

    private void OnTriggerEnter(Collider col)
    {
        lapcount += 1;
        if (lapcount == 3)
        {
            stopTime = true;
        }
    }

    private void displayLap()
    {
        lapText.text = String.Format("{0}", lapcount);
    }
    
}

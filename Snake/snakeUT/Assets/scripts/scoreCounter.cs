using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scoreCounter : MonoBehaviour
{
    public TMP_Text beanCount;
    public int beanScore = 0;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        displayBean();
    }
    

    private void displayBean()
    {
        beanCount.text = string.Format("{0}", beanScore);
    }
}

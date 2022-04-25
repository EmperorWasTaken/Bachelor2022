using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Lap timelap;
    private float InGameTime = 0f;
    public TMP_Text timeText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        DisplayTime(InGameTime);
        if (timelap.stopTime)
        {
            DisplayTime(InGameTime);
        }
        else
        {
            InGameTime += Time.deltaTime;
            DisplayTime(InGameTime);
        }
    }

    void DisplayTime(float TimeToDisplay)
    {
        float min = Mathf.FloorToInt(TimeToDisplay / 60);
        float sec = Mathf.FloorToInt(TimeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", min, sec);
    }
}

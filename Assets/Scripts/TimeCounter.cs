using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    public float timeToDisplay = 23;
    public TMP_Text timerText;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeToDisplay += Time.deltaTime;
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeToDisplay);
        timerText.text = timeSpan.ToString(format: @"mm\:ss\:fff");
    }
}

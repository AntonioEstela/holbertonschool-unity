using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    private float startTime;
    private TimeSpan timePlaying;
    public GameObject WinCanvas;
    public Text WinTime;

    void Start()
    {
        startTime = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        startTime += Time.deltaTime;
        timePlaying = TimeSpan.FromSeconds(startTime);
        TimerText.text = timePlaying.ToString("m':'ss'.'ff");
    }
}

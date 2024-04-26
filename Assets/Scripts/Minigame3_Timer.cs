using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Minigame3_Timer : MonoBehaviour
{
    public double timer;

    public TMP_Text timerText;
    public static bool timerIsRunning;

    void Start()
    {
        timerIsRunning = true;
    }
    void Update()
    {
        if (timerIsRunning)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0f)
        {
            timerIsRunning = false;
        }

        DisplayTime((float)timer);
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        else if (timeToDisplay > 0)
        {
            timeToDisplay += 1;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}

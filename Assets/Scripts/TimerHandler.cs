using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class TimerHandler : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    public bool stopped;
    public string score;
    public float highscore;

    void Start()
    {
        startTime = Time.time;
        score = "0";
    }

    void Update()
    {
        if (stopped) return;
        TimeCounter();
    }

    public void TimeCounter()
    {
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");
        timerText.text = minutes + ":" + seconds;

        highscore = (int)t;
        score = timerText.ToString();
        PlayerPrefs.SetString("score", highscore.ToString());
    }

    public void TimerStopper()
    {
        stopped = true;
    }
}

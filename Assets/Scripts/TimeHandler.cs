using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeHandler : MonoBehaviour
{
    private int time = 0;
    public Text timer;
    public Text highscore;

    void Start()
    {
        if(PlayerPrefs.HasKey("Highscore"))
        {
            highscore.text = PlayerPrefs.GetInt("Highscore").ToString();
        }
        else
        {
            highscore.text = "No highscores yet!";
        }
    }

    void Update()
    {
        
    }

    public void StartTimer()
    {
        time = 0;
        InvokeRepeating("IncrementTime", 1, 1);
    }

    public void StopTimer()
    {
        CancelInvoke();
        if(PlayerPrefs.GetInt("Highscore") < time)
        {
            SetHighscore();
        }
    }

    public void SetHighscore()
    {
        PlayerPrefs.SetInt("Highscore", time);
        highscore.text = PlayerPrefs.GetInt("Highscore").ToString();
    }

    void IncrementTime()
    {
        time++;
        timer.text = "Time: " + time;
    }
}

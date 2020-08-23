using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

namespace HighScore
{
    
    public class TimerHandler : MonoBehaviour
    {
        public Text timerText;
        public Text highScoreText;
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
            PlayerPrefs.SetFloat("firstScore", t);
            if(PlayerPrefs.GetFloat("firstScore") <= highscore)
            {
                highscore = PlayerPrefs.GetFloat("firstScore");
            }

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f0");
            timerText.text = minutes + ":" + seconds;

            score = timerText.ToString();

            if(t <= highscore)
            {
                PlayerPrefs.SetString("score", highscore.ToString());
            }
            highScoreText.text = PlayerPrefs.GetString("score").ToString();
        }

        public void TimerStopper()
        {
            stopped = true;
        }
    }
}


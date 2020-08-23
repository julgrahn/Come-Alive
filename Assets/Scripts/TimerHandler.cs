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
        public Text scoreText;
        public Text highScoreText;
        private float startTime;
        public bool stopped;
        public int highscore;
        public float score;


        void Start()
        {
            startTime = Time.time;
            score = 0;
        }

        void Update()
        {
            if (stopped) return;
            TimeCounter();
        }

        public void TimeCounter()
        {
            float t = Time.time - startTime;

            score += Time.deltaTime * 5;
            highscore = (int)score;
            scoreText.text = highscore.ToString();

            if(PlayerPrefs.GetInt("score") <= highscore)
            {
                PlayerPrefs.SetInt("score", highscore);
            }
            highScoreText.text = PlayerPrefs.GetInt("score").ToString();


            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f0");
            timerText.text = minutes + ":" + seconds;


        }

        public void TimerStopper()
        {
            stopped = true;
        }
    }
}


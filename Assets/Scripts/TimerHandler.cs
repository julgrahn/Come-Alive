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
        private float startTime;
        public bool stopped;


        void Start()
        {
            startTime = Time.time;
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


        }

        public void TimerStopper()
        {
            stopped = true;
        }
    }
}


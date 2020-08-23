using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public Text highScoreText;
    public Text scoreText;
    float score;
    int highscore;

    private void Start()
    {
        score = 0;
    }

    private void Update()
    {
        score += Time.deltaTime;
        highscore = (int)score;
        scoreText.text = "Score: " + highscore.ToString();

        if(PlayerPrefs.GetInt("score") <= highscore)
        {
            PlayerPrefs.SetInt("score", highscore);
        }
        highScoreText.text = PlayerPrefs.GetInt("score").ToString();

    }
}

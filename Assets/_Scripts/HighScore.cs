using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public int score;
    public int highscore;
    public TMP_Text scoreText;
    public TMP_Text highscoreText;

    private void Start()
    {
        score = PlayerPrefs.GetInt("score");
        highscore = PlayerPrefs.GetInt("highscore");
        scoreText.text = "Quota Level Reached: " + score;
        highscoreText.text = "Highest Quota Reached: " + highscore;
        PlayerPrefs.SetInt("score", 0);
    }
}

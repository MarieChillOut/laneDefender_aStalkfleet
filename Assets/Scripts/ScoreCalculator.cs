using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ScoreCalculator : MonoBehaviour
{
    private int totalScore;
    private int highestScore;

    private int totalLives;

    [SerializeField] private TMP_Text life_text;
    [SerializeField] private TMP_Text score_text;
    [SerializeField] private TMP_Text highscore_text;

    void Start()
    {
        totalScore = 0;
        totalLives = 3;

        highestScore = PlayerPrefs.GetInt("HighScore");
        score_text.text = "Score:\n" + totalScore.ToString();
        highscore_text.text = "High Score:\n" + highestScore.ToString();
        life_text.text = "Lives:\n" + totalLives.ToString();
    }

    public void AddScore(int x)
    {
        totalScore += x;
        score_text.text = "Score:\n" + totalScore.ToString();

        if (totalScore > highestScore)
        {
            NewHighScore();
        }
    }

    private void NewHighScore()
    {
        PlayerPrefs.SetInt("HighScore", totalScore);
        highscore_text.text = "High Score:\n" + PlayerPrefs.GetInt("HighScore");
    }

    public void LifeDown()
    {
        totalLives--;
    }
}

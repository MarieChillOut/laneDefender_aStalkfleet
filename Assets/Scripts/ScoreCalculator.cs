using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ScoreCalculator : MonoBehaviour
{
    private int totalScore;
    private int highestScore;

    private int totalLives;

    private PlayerController pC;
    private SpawnController spawnC;
    private ButtonController bC;

    private bool isPaused;

    [SerializeField] private TMP_Text life_text;
    [SerializeField] private TMP_Text score_text;
    [SerializeField] private TMP_Text highscore_text;

    [SerializeField] private AudioClip lifeClip;

    void Start()
    {
        isPaused = false;
        pC = FindObjectOfType<PlayerController>();
        spawnC = FindObjectOfType<SpawnController>();
        bC = FindObjectOfType<ButtonController>();

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
        bC.SetNewHigh();
        PlayerPrefs.SetInt("HighScore", totalScore);
        highscore_text.text = "High Score:\n" + PlayerPrefs.GetInt("HighScore");
    }

    public bool IsGamePaused()
    {
        return isPaused;
    }

    public void LifeDown()
    {
        AudioSource.PlayClipAtPoint(lifeClip, Vector3.zero);
        totalLives--;
        life_text.text = "Lives:\n" + totalLives.ToString();
        if (totalLives <= 0)
        {
            bC.SetScoreText(totalScore, PlayerPrefs.GetInt("HighScore"));
            isPaused = true;
            pC.PauseGame();
            spawnC.PausedGame();
            bC.GameOverScreen(true);
        }
    }
}

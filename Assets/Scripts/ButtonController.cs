using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private TMP_Text gameOver_txt;
    [SerializeField] private TMP_Text gOHighScore_txt;
    [SerializeField] private TMP_Text score_txt;
    [SerializeField] private TMP_Text newHigh_txt;

    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject quit;
    [SerializeField] private GameObject restart;

    private bool newHigh;
    
    void Start()
    {
        newHigh_txt.gameObject.SetActive(false);
        newHigh = false;
        GameOverScreen(false);
    }

    public void GameOverScreen(bool x)
    {
        gameOver_txt.gameObject.SetActive(x);
        gOHighScore_txt.gameObject.SetActive(x);
        score_txt.gameObject.SetActive(x);
        panel.gameObject.SetActive(x);
        quit.gameObject.SetActive(x);
        restart.gameObject.SetActive(x);
    }

    public void SetNewHigh()
    {
        newHigh = true;
    }

    public void SetScoreText(int score, int high)
    {
        score_txt.text = "Score: " + score;
        gOHighScore_txt.text = "High Score: " + high;
        if (newHigh)
        {
            newHigh_txt.gameObject.SetActive(true);
        }
    }


    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

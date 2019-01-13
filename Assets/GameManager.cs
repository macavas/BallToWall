using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    int score;

    public Text scoreText;
    public Text highScoreText;
    public GameObject endGamePanel;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }

        startGame();
    }

    private void showScore()
    {
        scoreText.text = score.ToString();
    }

    public void increaseScore()
    {
        score++;
        showScore();
    }

    public void startGame()
    {
        Player.instance.resetPosition();
        endGamePanel.SetActive(false);
        score = 0;
        showScore();
    }

    public void checkHighScore()
    {
        int oldHS = PlayerPrefs.GetInt("highscore", 0);
        if(oldHS < score)
        {
            PlayerPrefs.SetInt("highscore", score);
            highScoreText.text = "HighScore\n"+score;
        }
        else
        {
            highScoreText.text = "HighScore\n" + oldHS.ToString();
        }
    }


    private IEnumerator endGameEnu()
    {
        yield return new WaitForSeconds(1);
        endGamePanel.SetActive(true);
    }

    public void endGame()
    {
        checkHighScore();
        StartCoroutine(endGameEnu());
    }
}

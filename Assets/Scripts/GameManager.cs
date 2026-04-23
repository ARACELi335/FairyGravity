using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverCanva;
    public GameObject Glow;
    private bool isGameOver = false;

    public double score = 0;

     public TextMeshProUGUI scoreText;
     public TextMeshProUGUI scoreInGame;
     public TextMeshProUGUI highScoreText;
     public GameObject scoreGameObject;

    private void Start()
    {
        
    }
    private void Update()
    {
        score += 0.1;
        scoreInGame.text = "score: " + Math.Round(score);
    }
    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;

        Time.timeScale = 0f; //Para el juego

        Glow.SetActive(true);
        GameOverCanva.SetActive(true);
        score = Math.Round(score);
        scoreText.text = "Score: " + score;
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", (int)score);
            PlayerPrefs.Save();
        }
        scoreGameObject.SetActive(false);
        highScoreText.text = "High score: " + PlayerPrefs.GetInt("HighScore", 0);
    }

    public void Restart()
    {       
        Time.timeScale = 1f;
        GameOverCanva.SetActive(false);
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        FindObjectOfType<MusicManager>().ResumeMusic();
    }

   
}

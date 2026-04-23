using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    private void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High score: " + highScore;
    }
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

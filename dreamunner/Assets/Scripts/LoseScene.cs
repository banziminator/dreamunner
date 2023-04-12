using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseScene : MonoBehaviour

{
    public Text scoreText;
    
    void Start()
    {
        int score = PlayerPrefs.GetInt("Score");
        if (scoreText != null)
        {
        scoreText.text = "Score: " + score.ToString();
        }
    }

    public void RestartGame()
    {
        PlayerPrefs.DeleteKey("Score");
        SceneManager.LoadScene("GameScene");
    }
}
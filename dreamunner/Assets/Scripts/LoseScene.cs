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
        int score = PlayerPrefs.GetInt("Score"); // retrieve the score from PlayerPrefs
        scoreText.text = "Score: " + score.ToString(); // display the score in the text field
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
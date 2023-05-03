using UnityEngine;
using UnityEngine.UI;

public class LoseScene : MonoBehaviour
{
    [SerializeField] private Text scoreText = null;
    [SerializeField] private Text highScoreText = null;

    private int score = 0;
    private int highScore = 0;
    private string highScoreKey = "Highscore";

    private void Start()
    {
        score = PlayerPrefs.GetInt("Score", 0);
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        scoreText.text = "Score: " + score;

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt(highScoreKey, highScore);
        }
        highScoreText.text = "Highscore: " + highScore;
    }
}
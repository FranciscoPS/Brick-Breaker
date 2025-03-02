using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;

    void Start()
    {
        enableGameOver(false);
    }

    public void updateScoreText(int score)
    {
        scoreText.text = score.ToString();
    }

    public void updateHighScoreText(int highScore)
    {
        highScoreText.text = highScore.ToString();
    }

    public void enableGameOver(bool enabled)
    {
        gameOverScreen.SetActive(enabled);
    }
}

using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen; 
    [SerializeField] GameObject victoryScreen;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highScoreText;

    void Start()
    {
        enableGameOver(false);
        enableVictory(false);
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

    public void enableVictory(bool enabled)
    {
        victoryScreen.SetActive(enabled);
    }

    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}

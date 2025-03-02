using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int currentScore;
    int highScore;

    [SerializeField] UIManager uiManager;

    //Singleton
    public static ScoreManager instance;

    void Start()
    {
        if (instance == null) instance = this;
        else { Destroy(this); }
        getHighScore();
    }
    //End Singleton

    private void OnDestroy()
    {
        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
        }
    }

    public void addScore(int score)
    {
        currentScore += score;
        uiManager.updateScoreText(currentScore);
    }

    public void getHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        uiManager.updateHighScoreText(highScore);
    }
}

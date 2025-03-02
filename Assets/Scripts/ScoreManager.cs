using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int currentScore;

    //Singleton
    public static ScoreManager instance;

    void Start()
    {
        if (instance == null) instance = this;
        else { Destroy(this); }
    }
    //End Singleton

    public void addScore(int score)
    {
        currentScore += score;
        Debug.Log("SCOREEEEE =====> "+currentScore);
    }
}

using UnityEngine;

public class ScorePowerUp : PowerUp
{
    [SerializeField] int scoreValue;

    protected override void ResolvePowerUp()
    {
        ScoreManager.instance.addScore(scoreValue);
    }

}

using UnityEngine;

public class DoubleBallsPU : PowerUp
{
    protected override void ResolvePowerUp() {
        BallsManager.instance.DuplicateBalls();
    }
}

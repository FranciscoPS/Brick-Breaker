using UnityEngine;

public class BallSpeedPU : PowerUp
{
    [SerializeField] float speedMult;
    [SerializeField] float duration;

    protected override void ResolvePowerUp()
    {
        BallsManager.instance.ChangeSpeedState(speedMult, duration);
    }
}

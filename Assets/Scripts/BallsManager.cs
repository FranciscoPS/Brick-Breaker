using System.Collections.Generic;
using UnityEngine;

public class BallsManager : MonoBehaviour
{
    public static BallsManager instance;

    [SerializeField] GameObject ballPref;
    List<GameObject> ballsPool = new List<GameObject>();
    BallSpeedState currentState = BallSpeedState.Normal;
    float speedPUStartTime;
    float speedPUDuration;
    float speedPUMult;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
    }

    private void Start()
    {
        SpawnBall(Vector2.zero);
    }

    public void Update()
    {
        if (currentState != BallSpeedState.Normal) { 
            if(Time.time - speedPUStartTime >= speedPUDuration)
            {
                currentState = BallSpeedState.Normal;
                SetBallsSpeed(1);
            }
        }
    }

    public void ChangeSpeedState(float newSpeedMult, float duration)
    {
        switch (newSpeedMult) {
            case < 1: //Slow PowerUp
                if(currentState == BallSpeedState.Fast)
                {
                    currentState = BallSpeedState.Normal;
                    newSpeedMult = 1;
                    break;
                }
                currentState = BallSpeedState.Slow;
                break;

            case > 1: //Fast PowerUps
                if (currentState == BallSpeedState.Slow)
                {
                    currentState = BallSpeedState.Normal;
                    newSpeedMult = 1;
                    break;
                }
                currentState = BallSpeedState.Fast;
                break;

            default: //En caso de un mau escenario
                currentState = BallSpeedState.Normal;
                newSpeedMult = 1;
                break;
        }

        speedPUDuration = duration;
        speedPUStartTime = Time.time;
        SetBallsSpeed(newSpeedMult);
    }

    void SetBallsSpeed(float multi)
    {
        speedPUMult = multi;
        foreach (GameObject ball in ballsPool) {
            if (!ball.activeSelf) continue;

            ball.GetComponent<Ball>().SetNewSpeed(multi);
        }
    }

    public void DuplicateBalls()
    {
        List<Rigidbody2D> rigidbody2Ds = new List<Rigidbody2D>();
        List<Vector2> newBallPos = new List<Vector2>();

        foreach (var ball in ballsPool)
        {
            if (ball.activeSelf) { 
                newBallPos.Add(ball.transform.position); 
                rigidbody2Ds.Add(ball.GetComponent<Rigidbody2D>()); 
            }
        }

        for (int i = 0; i < newBallPos.Count; i++) { 
            SpawnBall(newBallPos[i], false, rigidbody2Ds[i]);
        }
    }

    void SpawnBall(Vector2 pos, bool firstBall = true, Rigidbody2D rb = null)
    {
        GameObject ball = GetBall();
        ball.transform.position = pos;
        ball.transform.rotation = Quaternion.identity;
        if (!firstBall) {
            Ball ballRb = ball.GetComponent<Ball>();
            ballRb.SetNewSpeed(speedPUMult);
            ballRb.initDirection = rb.linearVelocity.normalized;
            ballRb.initDirection *= -1;
        }
        ball.SetActive(true);
    }


    GameObject GetBall()
    {
        foreach (GameObject Ball in ballsPool)
        {
            if (!Ball.activeSelf) return Ball;
        }
        GameObject NewBullet = Instantiate(ballPref);
        NewBullet.SetActive(false);
        ballsPool.Add(NewBullet);
        return NewBullet;
    }

    public bool AreAllBallsInactive()
    {
        foreach (GameObject ball in ballsPool)
        {
            if (ball.activeSelf)
            {
                return false;
            }
        }

        return true;
    }
}

public enum BallSpeedState
{
    Normal,
    Fast,
    Slow
}
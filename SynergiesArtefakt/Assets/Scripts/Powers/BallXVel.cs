using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallXVel : BallEffect
{
    public override void OnBallMoving(GameObject gameObject)
    {
        base.OnBallMoving(gameObject);

        Vector2 workspace = gameObject.GetComponent<Rigidbody2D>().velocity + new Vector2(Random.Range(-5, 5), 0);

        gameObject.GetComponent<Rigidbody2D>().velocity = workspace;
    }
}

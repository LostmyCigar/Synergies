using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSlow : BallEffect
{
    public float speedMultiplier = 0.5f;

    public override void OnBallSpawn(GameObject gameObject)
    {
        base.OnBallSpawn(gameObject);

        var velocity = gameObject.GetComponent<Rigidbody2D>().velocity * speedMultiplier;
        gameObject.GetComponent<Rigidbody2D>().velocity = velocity;
    }
}

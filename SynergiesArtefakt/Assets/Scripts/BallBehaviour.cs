using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 10;
    public int damage;

    public BallEffect power1;
    public BallEffect power2;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    

    private void FixedUpdate()
    {
        IsMoving();
    }

    public void Launch(Vector2 dir)
    {

        rb.velocity = dir * moveSpeed;

        Debug.Log(dir);
        Debug.Log(moveSpeed);

        if (power1 != null)
        {
            power1.OnBallSpawn();
        }
        if (power2 != null)
        {
            power2.OnBallSpawn();
        }


    }

    public void IsMoving()
    {
        if (power1 != null)
        {
            power1.OnBallMoving(gameObject);
        }
        if (power2 != null)
        {
            power2.OnBallMoving(gameObject);
        }

    }

    public void Hit(EnemyBalls enemyBall)
    {
        enemyBall.takeDamage(damage);


        if (power1 != null)
        {
            power1.OnBallHit();
        }
        if (power2 != null)
        {
            power2.OnBallHit();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Hit: " + collision.gameObject.name);
        EnemyBalls enemyBall = collision.gameObject.GetComponent<EnemyBalls>();

        if (enemyBall != null)
        {
            Hit(enemyBall);
        }
    }
}

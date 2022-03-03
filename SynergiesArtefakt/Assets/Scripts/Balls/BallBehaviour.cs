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

        if (power1 != null)
        {
            power1.OnBallSpawn(gameObject);
        }
        if (power2 != null)
        {
            power2.OnBallSpawn(gameObject);
        }

        Debug.Log("Power1 = " + power1);
        Debug.Log("Power2 = " + power2);
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
        enemyBall.TakeDamage(damage);

        if (power1 != null)
        {
            power1.OnBallHit(gameObject);
        }
        if (power2 != null)
        {
            power2.OnBallHit(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyBalls enemyBall = collision.gameObject.GetComponent<EnemyBalls>();

        if (enemyBall != null)
        {
            Hit(enemyBall);
        }
    }
}

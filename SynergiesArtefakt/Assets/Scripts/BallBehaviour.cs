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
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void Launch(Vector2 dir)
    {
        rb.velocity = dir * moveSpeed;

        power1.OnBallSpawn();
        power2.OnBallSpawn();
    }

    public void IsMoving()
    {
        power1.OnBallMoving();
        power2.OnBallMoving();
    }

    public void Hit(EnemyBalls enemyBall)
    {
        enemyBall.takeDamage(damage);

        power1.OnBallHit();
        power2.OnBallHit();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hit something");
        EnemyBalls enemyBall = collision.gameObject.GetComponent<EnemyBalls>();

        if (enemyBall != null)
        {
            Hit(enemyBall);
            Debug.Log("was enemyball!");
        }
    }
}

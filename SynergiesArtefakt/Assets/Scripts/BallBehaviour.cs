using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed = 10;
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

        //balleffect.OnBallSpawn()
    }

    public void IsMoving()
    {
        //balleffect.OnBallMoving()
    }

    public void Hit()
    {
        //balleffect.OnBallHit()
    }
}

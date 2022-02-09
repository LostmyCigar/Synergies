using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEffect : MonoBehaviour
{
    public string effectName;
    public int index;

    public GameManager gameManager;
    public virtual void OnBallSpawn(GameObject gameObject)
    {

    }

    public virtual void OnBallMoving(GameObject gameObject)
    {

    }

    public virtual void OnBallHit(GameObject gameObject)
    {
        
    }

    public virtual void UpdateOnPlayScene()
    {

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    private Vector2 startDrag;
    private Vector2 endDrag;
    public Vector2 startPos;
    private float lastLaunch;
    public float launchCooldown;

    [SerializeField] private GameObject BallPrefab;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startDrag = touch.position;
                    StartDrag(startDrag);
                    break;

                case TouchPhase.Moved:
                    endDrag = touch.position;
                    break;

                case TouchPhase.Ended:
                    Vector2 dir = new Vector2(endDrag.x - startDrag.x, endDrag.y - startDrag.y).normalized;
                  //  Vector2 pos = Camera.main.ScreenToWorldPoint(new Vector3(endDrag.x, endDrag.y, 1f));
                    EndDrag(dir);
                    break;
            }
        }


    }

    public void StartDrag(Vector2 pos)
    {
        
    }

    public void EndDrag(Vector2 dir)
    {
        TryLaunch(dir);

    }

    private void TryLaunch(Vector2 dir)
    {
        if (Time.time > lastLaunch + launchCooldown)
        {
            Launch(dir);
            lastLaunch = Time.time;
        }
    }

    private void Launch(Vector2 dir)
    {
        var ball = Instantiate(BallPrefab, startPos, Quaternion.identity);
        ball.GetComponent<BallBehaviour>().Launch(-dir);
    }
}

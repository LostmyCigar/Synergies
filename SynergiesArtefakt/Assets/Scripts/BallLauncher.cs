using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallLauncher : MonoBehaviour
{
    private Vector2 startDrag;
    private Vector2 endDrag;
    public Vector2 startPos;
    private float lastLaunch;
    public float launchCooldown;
    

    private LaunchPreview launchPreview;
    private GameManager gameManager;
    private DataHolder dataHolder;
    private BallEffect effect1;
    private BallEffect effect2;

    [SerializeField] private GameObject BallPrefab;
    [SerializeField] private Image cooldownImage;

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
        launchPreview = GetComponent<LaunchPreview>();
    }
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
                    ContinueDrag(endDrag);
                    break;

                case TouchPhase.Ended:
                    Vector2 dir = new Vector2(endDrag.x - startDrag.x, endDrag.y - startDrag.y).normalized;
                    EndDrag(dir);
                    break;
            }
        }

        UppdateUI();

    }

    private void UppdateUI()
    {


        cooldownImage.fillAmount = (Time.time - lastLaunch)/launchCooldown;
    }

    public void StartDrag(Vector2 pos)
    {
        launchPreview.SetStartPoint(pos);
    }

    public void ContinueDrag(Vector2 pos)
    {
        launchPreview.SetEndPoint(pos);
    }
    public void EndDrag(Vector2 dir)
    {
        TryLaunch(dir);

    }

    private void TryLaunch(Vector2 dir)
    {
        if (Time.time > lastLaunch + launchCooldown)
        {
            lastLaunch = Time.time;
            Launch(dir);
        }
    }

    private void Launch(Vector2 dir)
    {
        var ball = Instantiate(BallPrefab, startPos, Quaternion.identity);
        ball.GetComponent<BallBehaviour>().power1 = gameManager.EquippedPower1;
        ball.GetComponent<BallBehaviour>().power2 = gameManager.EquippedPower2;
        ball.GetComponent<BallBehaviour>().Launch(-dir);
    }
}

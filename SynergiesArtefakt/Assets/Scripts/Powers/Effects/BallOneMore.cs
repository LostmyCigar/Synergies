using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallOneMore : BallEffect
{
    private BallEffect otherEffect;
    public GameObject ExtraBall;
    public float timeBetweenSpawn;

   // private Vector2 dir
    public override void OnBallSpawn(GameObject ball)
    {
        base.OnBallSpawn(ball);

        StartCoroutine(SpawnWithDelay(gameManager.gameObject.GetComponent<BallLauncher>().startPos, ball));
        
    }

    IEnumerator SpawnWithDelay(Vector2 startPos, GameObject extraBall)
    {
        yield return new WaitForSeconds(timeBetweenSpawn);
        var ball = Instantiate(ExtraBall, startPos, Quaternion.identity);
        ball.GetComponent<BallBehaviour>().power1 = otherEffect;
        ball.GetComponent<BallBehaviour>().Launch(extraBall.GetComponent<Rigidbody2D>().velocity.normalized);
        Debug.Log("Launched");
    }
    public override void UpdateOnPlayScene()
    {
        base.UpdateOnPlayScene();

        if (gameManager.EquippedPower1.effectName != effectName)
        {
            otherEffect = gameManager.EquippedPower1;
        }
        else if (gameManager.EquippedPower2.effectName != effectName)
        {
            otherEffect = gameManager.EquippedPower2;
        }

    }
}

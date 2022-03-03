using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallExplosion : BallEffect
{
    private BallEffect otherEffect;
    public GameObject smallBall;

    public override void OnBallHit(GameObject gameObject)
    {
        base.OnBallHit(gameObject);



        var smallball1 = Instantiate(smallBall, gameObject.transform.position, Quaternion.identity);
        if (!otherEffect.CannotDoubleCast)
        {
            smallball1.GetComponent<BallBehaviour>().power1 = otherEffect;
        }
        smallball1.GetComponent<BallBehaviour>().Launch(Vector2.up);

        var smallball2 = Instantiate(smallBall, gameObject.transform.position, Quaternion.identity);
        if (!otherEffect.CannotDoubleCast)
        {
            smallball2.GetComponent<BallBehaviour>().power1 = otherEffect;
        }
        smallball2.GetComponent<BallBehaviour>().Launch(new Vector2(1, 0.2f));

        var smallball3 = Instantiate(smallBall, gameObject.transform.position, Quaternion.identity);
        if (!otherEffect.CannotDoubleCast)
        {
            smallball3.GetComponent<BallBehaviour>().power1 = otherEffect;
        }
        smallball3.GetComponent<BallBehaviour>().Launch(new Vector2(-1, 0.2f));

        var smallball4 = Instantiate(smallBall, gameObject.transform.position, Quaternion.identity);
        if (!otherEffect.CannotDoubleCast)
        {
            smallball4.GetComponent<BallBehaviour>().power1 = otherEffect;
        }
        smallball4.GetComponent<BallBehaviour>().Launch(Vector2.down);

        Destroy(gameObject);
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

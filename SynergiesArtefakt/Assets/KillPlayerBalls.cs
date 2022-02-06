using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerBalls : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<BallBehaviour>() != null)
        {
            Destroy(collision.gameObject);
        }
    }
}

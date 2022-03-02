using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    [SerializeField] private float DestroyInSeconds;
    void Start()
    {
        Destroy(gameObject, DestroyInSeconds);
    }
}

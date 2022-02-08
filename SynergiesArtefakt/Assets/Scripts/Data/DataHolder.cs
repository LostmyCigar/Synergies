using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHolder : MonoBehaviour
{
    public List<BallEffect> ballEffects = new List<BallEffect>();

    public BallEffect equippedEffect1;
    public BallEffect equippedEffect2;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

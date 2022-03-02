using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerHolder : MonoBehaviour
{
    private DataHolder dataHolder;
    public List<BallEffect> gameManagerDependant = new List<BallEffect>();
    private void Awake()
    {
        dataHolder = GetComponentInParent<DataHolder>();
    }

    public void UpdateOnPlayScene()
    {
        for (int i = 0; i < gameManagerDependant.Count; i++)
        {
            gameManagerDependant[i].gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            gameManagerDependant[i].UpdateOnPlayScene();
        }
    }
}

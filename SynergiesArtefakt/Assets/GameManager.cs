using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public Text scoreText;


    public BallEffect EquippedPower1;
    public BallEffect EquippedPower2;
    public DataHolder dataHolder;

    [SerializeField] private SpriteRenderer effectImage1;
    [SerializeField] private SpriteRenderer effectImage2;


    private void Awake()
    {
        dataHolder = GameObject.Find("DataHolder").GetComponent<DataHolder>();

        if (dataHolder != null)
        {
            EquippedPower1 = dataHolder.effect1;
            EquippedPower2 = dataHolder.effect2;

            for (int i = 0; i < dataHolder.ballEffectIcons.Count; i++)
            {
                var powerIcon = dataHolder.ballEffectIcons[i].GetComponent<PowerIcon>();

                if (EquippedPower1 != null)
                {
                    if (powerIcon.effect == EquippedPower1.effectName)
                    {
                        effectImage1.sprite = powerIcon.image.sprite;
                    }
                }

                if (EquippedPower2 != null)
                {
                    if (powerIcon.effect == EquippedPower2.effectName)
                    {
                        effectImage2.sprite = powerIcon.image.sprite;
                    }
                }
            }
        }
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
    public void EndGame()
    {
        Time.timeScale = 0;
    }
}

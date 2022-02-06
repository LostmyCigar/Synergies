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
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
    public void EndGame()
    {

    }
}

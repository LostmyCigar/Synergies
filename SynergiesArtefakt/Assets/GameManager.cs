using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverScoreText;


    public BallEffect EquippedPower1;
    public BallEffect EquippedPower2;
    public DataHolder dataHolder;
    

    [SerializeField] private SpriteRenderer effectImage1;
    [SerializeField] private SpriteRenderer effectImage2;

    [SerializeField] private GameObject gameOverMenu;
    private bool freezeScore;

    private BallLauncher ballLauncher;
    private EnemyBallSpawner enemyBallSpawner;

    private void Awake()
    {
        ballLauncher = GetComponent<BallLauncher>();
        enemyBallSpawner = GetComponent<EnemyBallSpawner>();
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
        if (!freezeScore)
        {
            score++;
            scoreText.text = score.ToString();
        }
    }
    public void EndGame()
    {
        ballLauncher.enabled = false;
        enemyBallSpawner.enabled = false;
        freezeScore = true;

        GameObject[] PlayerBalls;
        PlayerBalls = GameObject.FindGameObjectsWithTag("PlayerBall");
        for (int i = 0; i < PlayerBalls.Length; i++)
        {
            Destroy(PlayerBalls[i]); 
        }

        StartCoroutine(EndGameTimer());

        IEnumerator EndGameTimer()
        {
            GameObject[] EnemyBalls;
            EnemyBalls = GameObject.FindGameObjectsWithTag("DangerBall");
            for (int i = 0; i < EnemyBalls.Length; i++)
            {
                EnemyBalls enemyball = EnemyBalls[i].GetComponent<EnemyBalls>();
                if (enemyball != null)
                {
                    EnemyBalls[i].gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
                }
            }


            yield return new WaitForSecondsRealtime(1.3f);
            for (int i = 0; i < EnemyBalls.Length; i++)
            {
                EnemyBalls enemyball = EnemyBalls[i].GetComponent<EnemyBalls>();
                if (enemyball != null)
                {
                    enemyball.Die();
                }

                if (EnemyBalls.Length > 10)
                {
                    yield return new WaitForSecondsRealtime(0.03f);
                }
                else yield return new WaitForSecondsRealtime(0.07f);
            }
            yield return new WaitForSecondsRealtime(1.2f);
            gameOverMenu.SetActive(true);
            gameOverScoreText.text = score.ToString();
        }
    }
}

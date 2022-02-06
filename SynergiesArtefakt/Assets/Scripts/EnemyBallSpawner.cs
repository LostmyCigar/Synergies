using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBallSpawner : MonoBehaviour
{

    [SerializeField] private GameObject enemyBall;
    [SerializeField] private Vector2 firstBlockPosition;
    [SerializeField] private float distanceBetweenUnits = 10;
    [SerializeField] private float playWidth = 7;



    [SerializeField] private int rowsSpawned;
    [SerializeField] private float ballSpeed;
    [SerializeField] private float chanceToSpawn = 20;
    [SerializeField] private float spawnTimer = 6;

    private float lastSpawnTime;

    public float TimerCheck;


    private void Start()
    {
        SpawnNewRow();
    }

    private void Update()
    {
        if (Time.time > lastSpawnTime + spawnTimer)
        {
            SpawnNewRow();
        }

        TimerCheck = Time.time;
    }

    private void SpawnNewRow()
    {
        lastSpawnTime = Time.time;
        DifficultyIncrease();
        int i = 0;
        while (i < playWidth)
        {

            if (UnityEngine.Random.Range(0, 100) <= chanceToSpawn)
            {
                var ball = Instantiate(enemyBall, GetPosition(i), Quaternion.identity);
                if (ball.GetComponent<EnemyBalls>() != null)
                {
                    ball.GetComponent<EnemyBalls>().SetSpeed(ballSpeed);
                    ball.GetComponent<EnemyBalls>().SetHp(UnityEngine.Random.Range(1, rowsSpawned));
                }
            }
            i++;
        }
    }

    private Vector2 GetPosition(int i)
    {
        Vector2 position = firstBlockPosition;
        position += Vector2.right * i * distanceBetweenUnits;
        return position;
    }

    private void DifficultyIncrease()
    {
        if (rowsSpawned < 4)
        {
            if (UnityEngine.Random.Range(0, 100) <= 30)
            {
                rowsSpawned++;
            }
        }
        else if (chanceToSpawn < 80)
        {
            chanceToSpawn += 5;
        }
        else if (spawnTimer > 2)
        {
            spawnTimer -= 0.3f;
        }

        if (ballSpeed < 2)
        {
            ballSpeed += 0.01f;
            if (spawnTimer <= 2)
            {
                ballSpeed += 0.02f;
            }
        }
    }
}

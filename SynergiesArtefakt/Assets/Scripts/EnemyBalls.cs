using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EnemyBalls : MonoBehaviour
{
    public List<Sprite> sprites = new List<Sprite>();

    private SpriteRenderer spriteRenderer;
    private TextMeshPro text;
    private Rigidbody2D rb;


    [SerializeField] private int hpLeft = 2;
    [SerializeField] private float downSpeed = 5;

    private GameManager gameManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        text = GetComponentInChildren<TextMeshPro>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = ChooseRandomSprite();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void Start()
    {

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x, -downSpeed);
    }

    public void takeDamage(int damage)
    {
        hpLeft -= damage;
        UppdateUI();
        CheckIfDead();
    }

    private void CheckIfDead()
    {
        if (hpLeft <= 0)
        {
            Destroy(gameObject);
            gameManager.IncreaseScore();
        }
    }

    private void UppdateUI()
    {
        text.SetText(hpLeft.ToString());
    }
    private Sprite ChooseRandomSprite()
    {
        int i = UnityEngine.Random.Range(0, sprites.Count);
        return sprites[i];
    }

    public void SetSpeed(float speed)
    {
        if (speed > 1)
        {
            downSpeed = speed;
        }
    }

    public void SetHp(int hp)
    {
        hpLeft = hp;
        UppdateUI();
    }
}

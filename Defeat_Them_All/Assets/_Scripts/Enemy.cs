using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
using static UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private const string CIRCLE_TAG_TEXT = "Circle";

    // for tokens
    private int randNum;

    // === Health system ===
    [SerializeField]
    private int maxHealth = 40;
    [SerializeField]
    private int currentHealth;
    public static int damageToGive = 10;// incremented in upgrades
    // === score system ===
    [SerializeField]
    private int scoreValue = 10;// indidual score value for each enemy

    // === collectables ===
    [SerializeField]
    private Coin coinPrefab;
    [SerializeField]
    public Token tokenPrefab;

    private GameObject coinParent;
    private GameObject tokenParent;

    // create public property
    public int ScoreValue { get { return scoreValue; } }

    // EnemyKilledEvent handlers
    public delegate void EnemyKilled(Enemy enemy);

    // static event
    public static EnemyKilled EnemyKilledEvent;

    // == private methods ==
    private void Start()
    {
        coinParent = ParentUtils.FindCoinParent();
        tokenParent = ParentUtils.FindTokenParent();
        SetMaxHealth();// initialize the health
    }

    private void OnCollisionEnter2D(Collision2D enemy)
    {
        string tagType = gameObject.tag;
        if (enemy.gameObject.tag == "bullet")// inflicts damage to the enemy
        {
            HurtEnemy(damageToGive);
        }
        if(enemy.gameObject.tag == "player")// destroy game object on collision with player
        {
            GameObject.Destroy(gameObject);
        }
    }

    private void PublishEnemyKilledEvent()
    {
        if (EnemyKilledEvent != null)
        {
            EnemyKilledEvent(this);
        }

    }

    private void SpawnCoin()
    {
        Coin coin = Instantiate(coinPrefab, coinParent.transform);
        coin.transform.position = transform.position;
    }

    private void SpawnToken()
    {
        Token token = Instantiate(tokenPrefab, tokenParent.transform);
        token.transform.position = transform.position;

    }

    void Update()
    {
        Invoke("DestroyAfterTime", 2);

        if (currentHealth <= 0)// current health drops below 0 enemy is destroyed
        {
            GameObject.Destroy(gameObject);
            PublishEnemyKilledEvent();
            SpawnCoin();
            RandomNumGen();// gets random number to determine if a token will spawn

            if (randNum == 5)
            {
                // spawn token
                SpawnToken();
            }
        }
    }
    private void DestroyAfterTime()// destroys after time to avoid clutter
    {
        GameObject.Destroy(gameObject);
    }

    public void HurtEnemy(int damageToGive)// health system managed here 
    {
        currentHealth -= damageToGive;
    }

    public void SetMaxHealth()// initializes health
    {
        currentHealth = maxHealth;
    }

    private void RandomNumGen()
    {
        randNum = UnityEngine.Random.Range(1, 10);// generates a random number between 1 and 10 inclusive
        //Debug.Log("Random Number" + randNum);
    }
}

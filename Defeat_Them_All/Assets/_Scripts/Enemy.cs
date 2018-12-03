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

    // ----------- Health system -------------
    public int maxHealth = 30;
    public int currentHealth;
    public int damageToGive = 10;

    [SerializeField]
    private int scoreValue = 10;

    [SerializeField]
    private AudioClip hitClip;

    [SerializeField]
    private AudioClip crashClip;

    [SerializeField]
    private Coin coinPrefab;

    [SerializeField]
    public Token tokenPrefab;

    private GameObject coinParent;
    private GameObject tokenParent;

    private SoundController soundController;

    // create public property
    public int ScoreValue { get { return scoreValue; } }

    // EnemyKilledEvent handlers
    public delegate void EnemyKilled(Enemy enemy);

    // static event
    public static EnemyKilled EnemyKilledEvent;

    // == private methods ==
    private void Start()
    {
        soundController = SoundController.FindSoundController();
        coinParent = ParentUtils.FindCoinParent();
        tokenParent = ParentUtils.FindTokenParent();
        SetMaxHealth();
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        // need to determine the type of "collision"
        string tagType = gameObject.tag;
        //var bullet = collision.GetComponent<Bullet>();
        //var player = collision.GetComponent<PlayerBehaviour>();

        if(collision.gameObject.tag =="bullet")
        {
            //PlayClip(hitClip);
            //GameObject.Destroy(gameObject);
            //PublishEnemyKilledEvent();
            //Destroy(gameObject);
            //SpawnCoin();
        }
        
    }*/

    //void OnTriggerEnter2D(Collider2D enemy)
    private void OnCollisionEnter2D(Collision2D enemy)
    {
        string tagType = gameObject.tag;
        if (enemy.gameObject.tag == "bullet")
        {
            Debug.Log("Colssion detected");
            HurtEnemy(damageToGive);
        }
    }

    private void PlayClip(AudioClip clip)
    {
        if (soundController)
        {
            soundController.PlayOneShot(clip);
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
        //Rigidbody2D rb = coin.GetComponent<Rigidbody2D>();
    }
    
    private void SpawnToken()
    {
        Token token = Instantiate(tokenPrefab, tokenParent.transform);
        token.transform.position = transform.position;

    }

    void Update()
    {
        Invoke("DestroyAfterTime", 2);

        if (currentHealth <= 0)
        {
            GameObject.Destroy(gameObject);
            PublishEnemyKilledEvent();
            SpawnCoin();
            
            if(randNum = 5)
            {
                // spawn token
                SpawnToken();
            }
        }
    }

    private void DestroyAfterTime()
    {
        GameObject.Destroy(gameObject);
    }

    public void HurtEnemy(int damageToGive)
    {
        currentHealth -= damageToGive;
    }

    public void SetMaxHealth()
    {
        currentHealth = maxHealth;
    }

    private void RandomNumGen()
    {
        //randNum = Random.Range(1, 10);
    }
}

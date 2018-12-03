﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{

    private const string INCREASE_SPEED_METHOD = "increaseSpeedPerTime";

    [SerializeField]
    public static float speed = 4f;
    [SerializeField]
    public float acceleration = 1f; //Every 10 seconds, the speed will increase by this much

    // == fields ==
    private int playerScore = 0;
    private int enemiesKilled = 0;
    private int coinsCollected = 0;

    [SerializeField]
    private Text scoreText; // update in private method
    [SerializeField]
    private Text scoreResultText; // update in private method
    [SerializeField]
    private Text enemiesKilledText; // update in private method
    [SerializeField]
    private Text coinsCollectedText;// update in private method
    [SerializeField]
    private Text coinsResultText;// update in private method

    // Use this for initialization
    void Start()
    {
        speed = 4f;
        Time.timeScale = 1.0f;// so the game isn't frozen when playing again
        InvokeRepeating(INCREASE_SPEED_METHOD, 0f, 7f);
    }


    // subscribe to events here
    private void OnEnable()
    {
        Enemy.EnemyKilledEvent += HandleEnemyKilledEvent;
        Coin.coinsCollectedEvent += HandleCoinCollectedEvent;
    }
    private void OnDisable()
    {
        Enemy.EnemyKilledEvent -= HandleEnemyKilledEvent;
        Coin.coinsCollectedEvent -= HandleCoinCollectedEvent;

    }

    private void HandleEnemyKilledEvent(Enemy enemy)
    {
        enemiesKilled++;
        playerScore += enemy.ScoreValue;
        //Debug.Log("Score: " + playerScore);
        UpdateScoreText();
        UpdateEnemiesKilled();
            
    }

    private void HandleCoinCollectedEvent(Coin coin)
    {
        coinsCollected++;
        UpdateCoinsCollected();
    }
    private void UpdateScoreText()
    {
        scoreText.text = playerScore.ToString("000000");
        scoreResultText.text = playerScore.ToString("Score: 0");

    }
    private void UpdateEnemiesKilled()
    {
        enemiesKilledText.text = enemiesKilled.ToString("Defeated: 0");
    }
    private void UpdateCoinsCollected()
    {
        coinsCollectedText.text = coinsCollected.ToString("0");
        coinsResultText.text = coinsCollected.ToString("Coins: 0");
    }

    private void increaseSpeedPerTime()
    {
        // speed controller singleton
        speed += acceleration;
        Debug.Log("Speed + acceloration is: " + speed);
    }
}

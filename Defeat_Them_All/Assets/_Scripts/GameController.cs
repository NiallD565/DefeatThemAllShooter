using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{

    // == fields ==
    public int playerScore = 0;
    private int enemiesKilled = 0;
    [SerializeField]
    private Text scoreText; // update in private method


    // subscribe to events here
    private void OnEnable()
    {
        Enemy.EnemyKilledEvent += HandleEnemyKilledEvent;
    }
    private void OnDisable()
    {
        Enemy.EnemyKilledEvent -= HandleEnemyKilledEvent;
    }

    private void HandleEnemyKilledEvent(Enemy enemy)
    {
        enemiesKilled++;
        playerScore += enemy.ScoreValue;
        //Debug.Log("Score: " + playerScore);
        UpdateScoreText();

    }
    private void UpdateScoreText()
    {
        scoreText.text = playerScore.ToString("000000");
    }
}

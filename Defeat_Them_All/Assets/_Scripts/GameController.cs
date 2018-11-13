using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{

    // == fields ==
    public int playerScore = 0;
    public int enemiesKilled = 0;
    [SerializeField]
    private Text scoreText; // update in private method
    [SerializeField]
    private Text scoreResultText; // update in private method
    [SerializeField]
    private Text enemiesKilledText; // update in private method

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1.0f;// so the game isn't frozen when playing again
    }


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
        UpdateEnemiesKilled();

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
}

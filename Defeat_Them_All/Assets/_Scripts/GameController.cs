using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    private const string INCREASE_SPEED_METHOD = "increaseSpeedPerTime";

    // == Character selection ==
    public GameObject DragonitePlayer;
    public GameObject LugiaPlayer;
    public GameObject LatiasPlayer;

    // == falling behaviour controllers ==
    [SerializeField]
    public static float speed = 4f;
    [SerializeField]
    public float acceleration = 1f; //Every 7 seconds, the speed will increase by this much

    // == fields ==
    public static int playerScore = 0;
    public static int highScore = 0;
    private int enemiesKilled = 0;

    // == currency ==
    public static int coinsCollected = 0;
    public static int currentBalance;

    // == special ==
    private int tokensCollected = 0;
    public static int tempTokenCollected = 0;

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
    [SerializeField]
    private Text tokensCollectedText;// update in private method
    [SerializeField]
    private Text tokensResultText;// update in private method

    // Use this for initialization
    void Start()
    {
        // resets the temperary values each run of the game
        coinsCollected = 0;
        tempTokenCollected = 0;
        playerScore = 0;
        speed = 4f;
        Time.timeScale = 1.0f;// so the game isn't frozen when playing again
        // increasing the falling speed every 7 seconds
        InvokeRepeating(INCREASE_SPEED_METHOD, 0f, 7f);
        highScore = PlayerPrefs.GetInt("highScore");
        // to determine which character is selected
        CharacterSelect();
    }


    // subscribe to events here
    private void OnEnable()
    {
        Enemy.EnemyKilledEvent += HandleEnemyKilledEvent;
        Coin.coinsCollectedEvent += HandleCoinCollectedEvent;
        Token.tokensCollectedEvent += HandleTokensCollectedEvent;
    }
    private void OnDisable()
    {
        Enemy.EnemyKilledEvent -= HandleEnemyKilledEvent;
        Coin.coinsCollectedEvent -= HandleCoinCollectedEvent;
        Token.tokensCollectedEvent -= HandleTokensCollectedEvent;

    }

    private void HandleEnemyKilledEvent(Enemy enemy)
    {
        enemiesKilled++;
        StatsController.tempTotalDefeated++;
        playerScore += enemy.ScoreValue;// increment player score by value in enemy script
        //Debug.Log("Score: " + playerScore);
        UpdateScoreText();
        UpdateEnemiesKilled();
    }

    private void HandleCoinCollectedEvent(Coin coin)
    {
        coinsCollected++;
        StatsController.tempCoinsCollected++;// tracks total stats
        UpdateCoinsCollected();

    }

    private void HandleTokensCollectedEvent(Token token)
    {
        tempTokenCollected++;
        StatsController.tempTokensCollected++;// tracks total stats
        tokensCollected++;
        UpdateTokensCollected();
        //Debug.Log("Tokens collected" + tokensCollected);
    }

    private void UpdateScoreText()
    {
        scoreText.text = playerScore.ToString("0000");// tracks score durring game
        scoreResultText.text = playerScore.ToString("Score: 0");// outputs score on game over panel
    }
    private void UpdateEnemiesKilled()
    {
        enemiesKilledText.text = enemiesKilled.ToString("Defeated: 0");// outputs total defeated to the game over panel
    }
    private void UpdateCoinsCollected()
    {
        coinsCollectedText.text = coinsCollected.ToString("0");// tracks coins collected during game 
        coinsResultText.text = coinsCollected.ToString("Coins: 0");// outputs total coins collected during run
    }
    private void UpdateTokensCollected()
    {
        tokensCollectedText.text = tokensCollected.ToString("T: 0");// tracks tokens collected during game
        tokensResultText.text = tokensCollected.ToString("Tokens: 0");// outputs total tokens collected during run
    }

    private void increaseSpeedPerTime()
    {
        // speed controller singleton
        speed += acceleration;
        //Debug.Log("Speed + acceloration is: " + speed);
    }

    public static void LoseGame()
    {
        currentBalance = PlayerPrefs.GetInt("currentBalance");// gets old balance
        currentBalance += coinsCollected;// adds new coins to balance
        PlayerPrefs.SetInt("currentBalance", currentBalance);// sets current balance
        coinsCollected = 0;

        if (playerScore >= highScore)// checks the new score against the highscore
        {
            PlayerPrefs.SetInt("highScore", playerScore);// sets the highscore to the new high score
        }
        //Debug.Log("High score: " + highScore);
        Debug.Log("Coin balance: " + currentBalance);
        StatsController.SetStats();// sets stats in stats in stats panel
        StatsController.tempTotalDefeated = 0;
        StatsController.tempCoinsCollected = 0;
        StatsController.tempTokensCollected = 0;
    }

    private void CharacterSelect()
    {
        // sets which player object is selected to active
        if (PlayerPrefs.GetInt("DragniteActive") == 1)
        {
            //Debug.Log("Dragonite Active");
            DragonitePlayer.SetActive(true);
            LugiaPlayer.SetActive(false);
            LatiasPlayer.SetActive(false);
        }
        if (PlayerPrefs.GetInt("LugiaActive") == 1)
        {
            DragonitePlayer.SetActive(false);
            LugiaPlayer.SetActive(true);
            LatiasPlayer.SetActive(false);
        }
        if (PlayerPrefs.GetInt("LatiasActive") == 1)
        {
            DragonitePlayer.SetActive(false);
            LugiaPlayer.SetActive(false);
            LatiasPlayer.SetActive(true);
        }      
    }
}

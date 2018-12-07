using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StatsController : MonoBehaviour {

    public static int tempTotalDefeated;
    public static int tempCoinsCollected;
    public static int tempTokensCollected;

    private static int totalCoinsCollected;
    private static int totalTokensCollected;
    private static int totalDefeated;

    // == fields ==
    [SerializeField]
    private Text totalDefeatedText; // update in private method
    [SerializeField]
    private Text totalCoinsCollectedText; // update in private method
    [SerializeField]
    private Text totalTokensCollectedText; // update in private method

    // Use this for initialization
    void Start () {
        UpdateStats();
    }

    public static void SetStats()
    {
        // Sets the values gained from each run to variables
        totalDefeated += tempTotalDefeated;
        totalCoinsCollected += tempCoinsCollected;
        totalTokensCollected += tempTokensCollected;

        // sets the totals to player prefs to track and for achievements
        PlayerPrefs.SetInt("TotalDefeated", totalDefeated);
        PlayerPrefs.SetInt("TotalCoins", totalCoinsCollected);
        PlayerPrefs.SetInt("TotalTokensCollected", totalTokensCollected);
    }

    public void UpdateStats()// known error when game is shut down total stats are lost but all other functionality works even achievments
    {
        totalDefeatedText.text = "Total defeated: " + PlayerPrefs.GetInt("TotalDefeated").ToString();
        totalCoinsCollectedText.text = "Total coins: " + PlayerPrefs.GetInt("TotalCoins").ToString();
        totalTokensCollectedText.text = "Total tokens: " + PlayerPrefs.GetInt("TotalTokensCollected").ToString();
    }
    // Update is called once per frame
    void Update () {

    }
}

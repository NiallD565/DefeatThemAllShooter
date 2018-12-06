using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StatsController : MonoBehaviour {

    public static int totalDefeated;
    public static int totalCoinsCollected;
    public static int totalTokensCollected;

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
        PlayerPrefs.SetInt("TotalDefeated", PlayerPrefs.GetInt("TotalDefeated") + totalDefeated);
        PlayerPrefs.SetInt("TotalCoins", PlayerPrefs.GetInt("TotalCoins") + totalCoinsCollected);
        PlayerPrefs.SetInt("TotalTokensCollected", PlayerPrefs.GetInt("TotalTokensCollected") + totalTokensCollected);

    }

    private void UpdateStats()
    {
        totalDefeatedText.text = "Total defeated: " + PlayerPrefs.GetInt("TotalDefeated").ToString();
        totalCoinsCollectedText.text = "Total coins: " + PlayerPrefs.GetInt("TotalCoins").ToString();
        totalTokensCollectedText.text = "Total tokens: " + PlayerPrefs.GetInt("TotalTokensCollected").ToString();
    }
    // Update is called once per frame
    void Update () {
        UpdateStats();
	}
}

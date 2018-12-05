using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuCoins : MonoBehaviour {
    
    private int currency = 0;
    
    [SerializeField]
    private Text TotalCoinsText; // update in private method
    
    // Use this for initialization
    void Start ()
    {
        //Fetch the PlayerPref settings
        SetCurrency();
    }
    void SetCurrency()
    {
        //Debug.Log("Currency set to balance");
        currency = PlayerPrefs.GetInt("currentBalance");
        //Fetch the score from the PlayerPrefs (set these Playerprefs in another script). If no Int of this name exists, the default is 0.
        TotalCoinsText.text = currency.ToString();

    }

    // Update is called once per frame
    void Update ()
    {
        SetCurrency();
    }
}

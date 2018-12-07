using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeController : MonoBehaviour {

    private int currency = 0;

    // Use this for initialization
    void Start ()
    {
        initCurrency();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void initCurrency()
    {
        currency = PlayerPrefs.GetInt("currentBalance", 0);
        //Debug.Log("Coins: " + currency);

    }

    public void Upgrade1()
    {
        // to stop increasing the damage endlessly
        if (PlayerPrefs.GetInt("grade1") == 0)// controller so the upgrade can only be purchased once
        {
            if (currency >= 50) // checks the currency to allow payment
            {
                currency -= 50;// deducts cost from currency
                PlayerPrefs.SetInt("grade1", 1);
                Debug.Log("Coins: " + currency);
                Enemy.damageToGive += 2; // increases damage taken by enemies
                Debug.Log("Damage per hit: " + Enemy.damageToGive);
                PlayerPrefs.SetInt("currentBalance", currency);// sets the balance to new value
            }
            else
                Debug.Log("Not enough coins");
        }
        Debug.Log("Button already clicked");
    }

    public void Upgrade2()
    {
        if (PlayerPrefs.GetInt("grade2") == 0)// controller so the upgrade can only be purchased once
        {
            if (currency >= 100)// checks the currency to allow payment
            {
                PlayerPrefs.SetInt("grade2", 1);
                currency -= 100;
                Enemy.damageToGive += 3;// increases damage taken by enemies
                PlayerPrefs.SetInt("currentBalance", currency);// sets the balance to new value
            }
            else
                Debug.Log("Not enough coins");
        }
        Debug.Log("Button already clicked");
    }

    public void Upgrade3()
    {
        if (PlayerPrefs.GetInt("grade3") == 0)// controller so the upgrade can only be purchased once
        {
            if (currency >= 150)// checks the currency to allow payment
            {
                PlayerPrefs.SetInt("grade3", 1);
                currency -= 150;
                Enemy.damageToGive += 5;// increases damage taken by enemies
                PlayerPrefs.SetInt("currentBalance", currency);// sets the balance to new value
            }
            else
                Debug.Log("Not enough coins");
        }
    }
}

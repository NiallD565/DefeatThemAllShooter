using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeController : MonoBehaviour {

    private int currency = 0;

    private bool up1Clicked = false;
    private bool up2Clicked = false;
    private bool up3Clicked = false;


    // Use this for initialization
    void Start () {
        initCurrency();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void initCurrency()
    {
        currency = PlayerPrefs.GetInt("currentBalance", 0);
        Debug.Log("Coins: " + currency);

    }

    public void Upgrade1()
    {
        // to stop increasing the damage endlessly
        if (up1Clicked == false)
        {
            if (currency >= 5)
            {
                currency -= 5;
                up1Clicked = true;
                Debug.Log("Coins: " + currency);
                Enemy.damageToGive += 5;
                Debug.Log("Damage per hit: " + Enemy.damageToGive);

            }
            else
                Debug.Log("Not enough coins");
        }
        Debug.Log("Button already clicked");
    }

    public void Upgrade2()
    {
        if (up2Clicked == false)
        {
            if (currency >= 100)
            {
                currency -= 100;
            }
            else
                Debug.Log("Not enough coins");
        }
        Debug.Log("Button already clicked");
    }

    public void Upgrade3()
    {
        if (up3Clicked == false)
        {
            if (currency >= 150)
            {
                currency -= 150;
            }
            else
                Debug.Log("Not enough coins");
        }
    }
}

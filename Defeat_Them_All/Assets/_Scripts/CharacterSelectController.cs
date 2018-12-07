using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectController : MonoBehaviour
{
    private int currency = 0;

    // Use this for initialization
    void Start ()
    {
        //DontDestroyOnLoad(this.gameObject);
        initCurrency();
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void initCurrency()
    {
        currency = PlayerPrefs.GetInt("currentBalance");
        //Debug.Log("Coins: " + currency);
    }

    public void Character1Selected()// Using player prefs as booleans to control which player is active
    {
        PlayerPrefs.SetInt("DragniteActive", 1);
        PlayerPrefs.SetInt("LugiaActive", 0);
        PlayerPrefs.SetInt("LatiasActive", 0);
       
    }

    public void Character2Selected()// Using player prefs as booleans to control which player is active
    {
        if (PlayerPrefs.GetInt("LugiaPaid") == 0)// tracks whether player has paid but still alllowing them to select the character they want onced it has been paid
        {
            if (currency >= 100)
            {
                currency -= 100;// deduct cost from currency
                PlayerPrefs.SetInt("DragniteActive", 0);
                PlayerPrefs.SetInt("LugiaActive", 1);
                PlayerPrefs.SetInt("LatiasActive", 0);

                // curency set and condition to avoid paying twice
                PlayerPrefs.SetInt("currentBalance", currency);// set balance to currency
                PlayerPrefs.SetInt("LugiaPaid", 1);// has been paid so set to 1
            }
        }
        if (PlayerPrefs.GetInt("LugiaPaid") == 1)// paid so freely allowed to choose character
        {
            PlayerPrefs.SetInt("DragniteActive", 0);
            PlayerPrefs.SetInt("LugiaActive", 1);
            PlayerPrefs.SetInt("LatiasActive", 0);
        }
    }

    public void Character3Selected()// Using player prefs as booleans to control which player is active
    {
        if (PlayerPrefs.GetInt("LatiasPaid") == 0)// tracks whether player has paid but still alllowing them to select the character they want onced it has been paid
        {
            if (currency >= 150)
            {
                currency -= 150;// deduct cost from currency
                PlayerPrefs.SetInt("DragniteActive", 0);
                PlayerPrefs.SetInt("LugiaActive", 0);
                PlayerPrefs.SetInt("LatiasActive", 1);

                // curency set and condition to avoid paying twice
                PlayerPrefs.SetInt("currentBalance", currency);// set balance to currency
                PlayerPrefs.SetInt("LatiasPaid", 1);// has been paid so set to 1
            }
        }
        if (PlayerPrefs.GetInt("LatiasPaid") == 1)// paid so freely allowed to choose character
        {
            PlayerPrefs.SetInt("DragniteActive", 0);
            PlayerPrefs.SetInt("LugiaActive", 0);
            PlayerPrefs.SetInt("LatiasActive", 1);
        }
    }
}

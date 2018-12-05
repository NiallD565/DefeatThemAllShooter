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

    public void Character1Selected()
    {
        PlayerPrefs.SetInt("DragniteActive", 1);
        PlayerPrefs.SetInt("LugiaActive", 0);
        PlayerPrefs.SetInt("LatiasActive", 0);
       
    }

    public void Character2Selected()
    {
        if (PlayerPrefs.GetInt("LugiaPaid") == 0)
        {
            if (currency >= 100)
            {
                currency -= 100;
                PlayerPrefs.SetInt("DragniteActive", 0);
                PlayerPrefs.SetInt("LugiaActive", 1);
                PlayerPrefs.SetInt("LatiasActive", 0);

                // curency set and condition to avoid paying twice
                PlayerPrefs.SetInt("currentBalance", currency);
                PlayerPrefs.SetInt("LugiaPaid", 1);
            }
        }
        if (PlayerPrefs.GetInt("LugiaPaid") == 1)
        {
            PlayerPrefs.SetInt("DragniteActive", 0);
            PlayerPrefs.SetInt("LugiaActive", 1);
            PlayerPrefs.SetInt("LatiasActive", 0);
        }
    }

    public void Character3Selected()
    {
        if (PlayerPrefs.GetInt("LatiasPaid") == 0)
        {
            if (currency >= 150)
            {
                currency -= 150;
                PlayerPrefs.SetInt("DragniteActive", 0);
                PlayerPrefs.SetInt("LugiaActive", 0);
                PlayerPrefs.SetInt("LatiasActive", 1);

                // curency set and condition to avoid paying twice
                PlayerPrefs.SetInt("currentBalance", currency);
                PlayerPrefs.SetInt("LatiasPaid", 1);
            }
        }
        if (PlayerPrefs.GetInt("LatiasPaid") == 1)
        {
            PlayerPrefs.SetInt("DragniteActive", 0);
            PlayerPrefs.SetInt("LugiaActive", 0);
            PlayerPrefs.SetInt("LatiasActive", 1);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuCoins : MonoBehaviour {

     private int currency;

    [SerializeField]
    private Text currecyText; // update in private method

    // Use this for initialization
    void Start () {
        //Fetch the PlayerPref settings
        SetText();
    }
    void SetText()
    {
        Debug.Log("Currency set to balance");
        //Fetch the score from the PlayerPrefs (set these Playerprefs in another script). If no Int of this name exists, the default is 0.
        curencyText.text = PlayerPrefs.GetInt("currentBalance", 0).toString();

        currency = PlayerPrefs.GetInt("currentBalance", 0);
    }
	// Update is called once per frame
	void Update () {
		
	}
}

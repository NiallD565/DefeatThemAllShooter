using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighScoreController : MonoBehaviour {


    private int highScore = 0;

    [SerializeField]
    private Text HighScoreText; // update in private method

    // Use this for initialization
    void Start () {
        SetHighScore();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    void SetHighScore()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);

        HighScoreText.text = highScore.ToString();

    }
}

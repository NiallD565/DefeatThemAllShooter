using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighScoreController : MonoBehaviour
{
    private int highScore = 0;

    [SerializeField]
    private Text HighScoreText; // update in private method

    // Use this for initialization
    void Start () {
        SetHighScore();// sets the highscore on the main menu
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    void SetHighScore()// sets the highscore on the main menu
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
        HighScoreText.text = highScore.ToString();
    }
}

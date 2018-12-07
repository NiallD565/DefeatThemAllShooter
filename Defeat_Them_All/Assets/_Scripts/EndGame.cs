using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {

    public GameObject PauseMenuPanel; //holds the user interface
    public GameObject GameOverPanel; //holds the user interface

    public void Quit()// doesn't track collectables
    {
        //Debug.Log("GameEnded");
        PauseMenuPanel.SetActive(false);// deactivate pause menu
        GameOverPanel.SetActive(true);// activate game over screen
        Time.timeScale = 0.0f;// stopping time and gameplay
        
    }
}

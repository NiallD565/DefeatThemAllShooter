using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {

    public GameObject PauseMenuPanel; //holds the user interface
    public GameObject GameOverPanel; //holds the user interface

    public void Quit()
    {
        Debug.Log("GameEnded");
        PauseMenuPanel.SetActive(false);
        GameOverPanel.SetActive(true);
        Time.timeScale = 0.0f;// stopping time

    }
}

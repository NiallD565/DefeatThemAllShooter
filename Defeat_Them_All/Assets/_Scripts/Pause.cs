using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool GamePause = false;

    public GameObject PauseMenuPanel; //holds the user interface

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))// allows the use to pause
        {
            if (GamePause == true)
            {
                ResumeGame();
            }
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        //Debug.Log("test");
        //when pause want to set the pauseGame = true
        PauseMenuPanel.SetActive(true);// activates the pause menu
        Time.timeScale = 0.0f;// freezes the game
        GamePause = true;
    }

    public void ResumeGame()
    {
        PauseMenuPanel.SetActive(false);// deactivates the pause menu
        Time.timeScale = 1.0f;// resumes the game
        GamePause = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {

    public GameObject PauseMenuPanel; //holds the user interface
    public GameObject GameOverPanel; //holds the user interface


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Quit()
    {
        Debug.Log("GameEnded");
        PauseMenuPanel.SetActive(false);
        GameOverPanel.SetActive(true);

    }
}

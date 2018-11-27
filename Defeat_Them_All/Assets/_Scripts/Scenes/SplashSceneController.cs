﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

public class SplashSceneController : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(LoadMainMenu());
	}
	
	IEnumerator LoadMainMenu()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadSceneAsync(SceneNames.MAIN_MENU);// Load main menu after 2 seconds

    }
}

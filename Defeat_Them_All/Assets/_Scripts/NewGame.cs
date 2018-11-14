using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

public class NewGame : MonoBehaviour {

    public void NewGameOnClick()
    {
        SceneManager.LoadSceneAsync(SceneNames.LEVEL_NAME);
    }
}

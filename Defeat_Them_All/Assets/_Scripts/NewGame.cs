using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

public class NewGame : MonoBehaviour {

    public void NewGameOnClick()
    {
        SceneManager.LoadSceneAsync(SceneNames.LEVEL_NAME);// reloads the scene setting all temp values back to 0
    }
}

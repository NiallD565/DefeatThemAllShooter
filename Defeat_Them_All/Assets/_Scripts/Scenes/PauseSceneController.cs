using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

public class PauseSceneController : MonoBehaviour {

    // == OnClick events ==
    public void MainMenuOnClick()
    {
        // go back to main menu
        SceneManager.LoadSceneAsync(SceneNames.MAIN_MENU);
    }
}

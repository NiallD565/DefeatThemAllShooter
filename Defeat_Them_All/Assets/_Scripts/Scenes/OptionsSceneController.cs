using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

namespace Scenes
{

    public class OptionsSceneController : MonoBehaviour
    {
        // == OnClick events ==
        public void BackOnClick()
        {
            // go back to main menu using back button
            SceneManager.LoadSceneAsync(SceneNames.MAIN_MENU);
        }

    }
}
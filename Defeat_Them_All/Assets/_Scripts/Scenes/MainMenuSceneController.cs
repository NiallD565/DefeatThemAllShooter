using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

namespace Scenes
{
    public class MainMenuSceneController : MonoBehaviour
    {
        // first step is to handle the play button
        // load the level scene when play is clicked.
        // use SceneManager - class introduced in Unity 5
        // LoadScene, UnloadScene

        // == OnClick events ==
        public void PlayOnClick()
        {
            SceneManager.LoadSceneAsync(SceneNames.LEVEL_NAME);
        }

        public void OptionsOnClick()
        {
            SceneManager.LoadSceneAsync(SceneNames.OPTIONS_MENU,
                                        LoadSceneMode.Additive);
        }

        public void CharacterSelectOnClick()
        {
            SceneManager.LoadSceneAsync(SceneNames.CHARACTER_SELECT);
        }

        public void AudioOnClick()
        {
            SceneManager.LoadSceneAsync(SceneNames.AUDIO_MENU);
        }
    }
}
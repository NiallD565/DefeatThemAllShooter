using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {
    public bool volumeOn = true;

    void Start()
    {
        //audio = GetComponent<AudioSource>();
    }

    public void muteOnClick()
    {
        if (volumeOn == true)// attached to a toggle and sets volumeOn to false stopping the sound effects but not interupting the background music
        {
            AudioListener.pause = true;
            Debug.Log("Audio Disabled");
            volumeOn = false;

        }
        else if (volumeOn == false)
        {
            AudioListener.pause = false;
            Debug.Log("Audio Enabled");
            volumeOn = true;
        }
    }
}

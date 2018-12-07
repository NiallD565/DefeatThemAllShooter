using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoop : MonoBehaviour {

	private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);// keeps the sound controller from splash screen in other scenes
    }
}

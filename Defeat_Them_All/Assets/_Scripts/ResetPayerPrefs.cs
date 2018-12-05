using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPayerPrefs : MonoBehaviour {


    public void resetSettingsOnClick()
    {
        PlayerPrefs.DeleteAll();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

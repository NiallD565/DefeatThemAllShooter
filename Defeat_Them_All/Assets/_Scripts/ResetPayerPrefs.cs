using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPayerPrefs : MonoBehaviour
{
    // For developer and testing only to reset player prefs
    public void resetSettingsOnClick()
    {
        PlayerPrefs.DeleteAll();
    }
}

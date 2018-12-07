using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyController : MonoBehaviour
{
    // == fields ==
    public GameObject Trophy1Image;
    public GameObject Trophy2Image;
    public GameObject Trophy3Image;

    // Use this for initialization
    void Start ()
    {
        SetTrophies();
	}
	 private void SetTrophies()
    {
        // sets the trophy sprite once the total stats have been completed
        // determined by stat controller
        if (PlayerPrefs.GetInt("TotalDefeated") > 1000)
        {
            Trophy1Image.SetActive(true);
        }
        if(PlayerPrefs.GetInt("TotalCoins") > 1000)
        {
            Trophy2Image.SetActive(true);
        }
        if (PlayerPrefs.GetInt("TotalTokensCollected") > 500)
        {
            Trophy3Image.SetActive(true);

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaidController : MonoBehaviour {
    // notifys the player what has been paid for
    public GameObject Tick2PaidImage;
    public GameObject Tick3PaidImage;
    public GameObject Upgrade1PaidImage;
    public GameObject Upgrade2PaidImage;
    public GameObject Upgrade3PaidImage;

    // Use this for initialization
    void Start () {
        Paid();
	}
	
	// Update is called once per frame
	void Update () {
        Paid();
	}

    void Paid()
    {
        // activates the tick game object to notify the player that they have paid for a character
        if (PlayerPrefs.GetInt("LugiaPaid") == 1)
        {
            Tick2PaidImage.SetActive(true);
        }
        if (PlayerPrefs.GetInt("LatiasPaid") == 1)
        {
            Tick3PaidImage.SetActive(true);

        }
        if (PlayerPrefs.GetInt("grade1") == 1)
        {
            Upgrade1PaidImage.SetActive(true);
        }
        if (PlayerPrefs.GetInt("grade2") == 1)
        {
            Upgrade2PaidImage.SetActive(true);
        }
        if (PlayerPrefs.GetInt("grade3") == 1)
        {
            Upgrade3PaidImage.SetActive(true);
        }
    }
}

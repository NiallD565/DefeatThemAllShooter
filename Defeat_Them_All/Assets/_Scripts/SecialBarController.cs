using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecialBarController : MonoBehaviour {

    [SerializeField]
    private GameObject ProgressBar0;
    [SerializeField]
    private GameObject ProgressBar1;
    [SerializeField]
    private GameObject ProgressBar2;
    [SerializeField]
    private GameObject ProgressBar3;
    [SerializeField]
    private GameObject ProgressBar4;
    [SerializeField]
    private GameObject ProgressBar5;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SetProgressBar();
	}

    void SetProgressBar()
    {
        if (GameController.tempTokenCollected == 0)
        {
            ProgressBar5.SetActive(false);
            ProgressBar0.SetActive(true);
        }
        if (GameController.tempTokenCollected == 1)
        {
            ProgressBar0.SetActive(false);
            ProgressBar1.SetActive(true);
        }
        if (GameController.tempTokenCollected == 2)
        {
            ProgressBar1.SetActive(false);
            ProgressBar2.SetActive(true);
        }
        if (GameController.tempTokenCollected == 3)
        {
            ProgressBar2.SetActive(false);
            ProgressBar3.SetActive(true);
        }
        if (GameController.tempTokenCollected == 4)
        {
            ProgressBar3.SetActive(false);
            ProgressBar4.SetActive(true);
        }
        if (GameController.tempTokenCollected == 5)
        {
            ProgressBar4.SetActive(false);
            ProgressBar5.SetActive(true);
        }
    }
}

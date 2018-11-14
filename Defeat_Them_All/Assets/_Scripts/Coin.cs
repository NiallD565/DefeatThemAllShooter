using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class Coin : MonoBehaviour {


    // EnemyKilledEvent handlers
    public delegate void coinsCollected(Coin coin);

    // static event
    public static coinsCollected coinsCollectedEvent;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tagType = gameObject.tag;

        if (collision.gameObject.tag == "player")
        {
            GameObject.Destroy(gameObject);
            PublishCoinCollectedEvent();
        }
        else if (collision.gameObject.tag == "bullet")
        {

        }
    }

    private void PublishCoinCollectedEvent()
    {
        Debug.Log("Coin collected published");
        if (coinsCollectedEvent != null)
        {
            coinsCollectedEvent(this);
        }
    }
    
}

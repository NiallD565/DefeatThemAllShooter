using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class Token : MonoBehaviour {
    // EnemyKilledEvent handlers
    public delegate void tokensCollected(Token token);
    // static event
    public static tokensCollected tokensCollectedEvent;
    
    void OnTriggerEnter2D(Collider2D collision)// ignores collision with all other object except objects with specified tags
    {
        if (collision.gameObject.tag == "player")
        {
            GameObject.Destroy(gameObject);
            PublishTokenCollectedEvent();
        }
    }

    private void PublishTokenCollectedEvent()
    {
        Debug.Log("Token collected published");
        if (tokensCollectedEvent != null)
        {
            tokensCollectedEvent(this);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class Token : MonoBehaviour {

    public GameObject BulletPrefab;

    // EnemyKilledEvent handlers
    public delegate void tokensCollected(Token token);

    // static event
    public static tokensCollected tokensCollectedEvent;
    // Use this for initialization
    void Start () {

    }
    
    void OnTriggerEnter2D(Collider2D collision)
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

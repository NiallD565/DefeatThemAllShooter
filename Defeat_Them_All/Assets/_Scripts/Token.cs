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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tagType = gameObject.tag;
        //Debug.Log("Token detected");

        if (collision.gameObject.tag == "player")
        {
            GameObject.Destroy(gameObject);
            PublishTokenCollectedEvent();
        }
        else if (collision.gameObject.tag == "bullet")
        {
            //Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());

            //Physics2D.IgnoreCollision(this.gameObject.GetComponent<BoxCollider2D>(), BulletPrefab.GetComponent<BoxCollider2D>());
            //Debug.Log("Collision detected");
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

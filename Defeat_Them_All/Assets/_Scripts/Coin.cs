using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class Coin : MonoBehaviour {

    public GameObject BulletPrefab;

    // EnemyKilledEvent handlers
    public delegate void coinsCollected(Coin coin);

    // static event
    public static coinsCollected coinsCollectedEvent;

    // Use this for initialization
    void Start () {
        // attempt to ignore collision
        //Physics2D.IgnoreCollision(this.gameObject.GetComponent<BoxCollider2D>(), BulletPrefab.GetComponent<BoxCollider2D>());
    }

    // Update is called once per frame
    void Update () {
        Invoke("DestroyAfterTime", 2);// destroyed after 2 seconds to avoid clutter
    }
    
    void OnTriggerEnter2D(Collider2D collision)// only detects collision with objects with player tags
    {
        if (collision.gameObject.tag == "player")
        {
            GameObject.Destroy(gameObject);// destroys game object once collided with player
            PublishCoinCollectedEvent();
        }
    }

    private void PublishCoinCollectedEvent()// calls the event handlers in game controller
    {
        //Debug.Log("Coin collected published");
        if (coinsCollectedEvent != null)
        {
            coinsCollectedEvent(this);
        }
    }
    private void DestroyAfterTime()
    {
        GameObject.Destroy(gameObject);
    }
}

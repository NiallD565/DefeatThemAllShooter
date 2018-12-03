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
        Physics2D.IgnoreCollision(this.gameObject.GetComponent<BoxCollider2D>(), BulletPrefab.GetComponent<BoxCollider2D>());
    }

    // Update is called once per frame
    void Update () {
        //bullet = GameObject.Find("bullet");
    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tagType = gameObject.tag;

        if (collision.gameObject.tag == "player")
        {
            GameObject.Destroy(gameObject);
            PublishCoinCollectedEvent();
        }
        else
        {
            //Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());

            //Physics2D.IgnoreCollision(this.gameObject.GetComponent<BoxCollider2D>(), BulletPrefab.GetComponent<BoxCollider2D>());
            Debug.Log("Collision detected");
        }
    }*/
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            GameObject.Destroy(gameObject);
            PublishCoinCollectedEvent();
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

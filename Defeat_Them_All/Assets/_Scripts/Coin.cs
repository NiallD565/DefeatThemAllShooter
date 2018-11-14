using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

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
        }
        else if (collision.gameObject.tag == "bullet")
        {
            Physics.IgnoreCollision(collision.collider, collider); 
        }
    }
}

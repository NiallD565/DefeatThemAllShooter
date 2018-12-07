using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    void Update()
    {
        Invoke("Destroy", 2);// destroys bullets after 2 seconds to avoid clutter in game
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy();// destroys on collision with anything
    }
    private void Destroy()
    {
        GameObject.Destroy(gameObject);
        //Debug.Log("bullet Destroyed");
    }
}

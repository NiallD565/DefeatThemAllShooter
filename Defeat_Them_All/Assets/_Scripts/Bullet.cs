using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    void Update()
    {
        Invoke("Destroy", 2);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tagType = gameObject.tag;

        if (collision.gameObject.tag == "enemy")
        {
            Destroy();
        }
        else
        {
            //Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());

            //Physics2D.IgnoreCollision(this.gameObject.GetComponent<BoxCollider2D>(), BulletPrefab.GetComponent<BoxCollider2D>());
            Debug.Log("Collision detected");
        }
    }
    private void Destroy()
    {
        GameObject.Destroy(gameObject);
        //Debug.Log("bullet Destroyed");
    }
}

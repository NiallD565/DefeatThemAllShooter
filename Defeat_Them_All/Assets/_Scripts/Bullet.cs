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
        Destroy();
    }
    private void Destroy()
    {
        GameObject.Destroy(gameObject);
        //Debug.Log("bullet Destroyed");
    }
}

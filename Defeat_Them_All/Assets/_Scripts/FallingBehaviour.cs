using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FallingBehaviour : MonoBehaviour
{

    private const string INCREASE_SPEED_METHOD = "increaseSpeedPerTime";

    [SerializeField]
    private float speed = 4f;// set initial speed
    
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * speed;
    }
    private void FixedUpdate()
    {
        // gets static value speed and sets it to the velocity vector 2 down
        rb.velocity = Vector2.down * GameController.speed;
        //Debug.Log("Speed + acceloration is: " + rb.velocity);
    }

    // Update is called once per frame
    void Update()
    {

    }

}
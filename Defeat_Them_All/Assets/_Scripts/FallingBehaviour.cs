using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FallingBehaviour : MonoBehaviour
{

    [SerializeField]
    private float speed = 4f;
    [SerializeField]
    public float acceleration = 5f; //Every 500 points, the speed will increase by this much

    private float nextActionTime = 0.0f;
    public float period = 0.5f;

    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * speed;
    }
    private void FixedUpdate()
    {
        
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;

            speed += Time.deltaTime * acceleration;

            rb.velocity = Vector2.down * speed;

            Debug.Log("Speed + acceloration is: " + rb.velocity);
        }
    }
    /* Update is called once per frame
    void Update()
    {

    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FallingBehaviour : MonoBehaviour
{

    [SerializeField]
    private float speed = 4f;
    [SerializeField]
    public float acceleration = 1f; //Every 500 points, the speed will increase by this much


    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * speed;
    }
    private void FixedUpdate()
    {
        GameObject PointSpawners = GameObject.Find("PointSpawners");
        PointSpawner pointspawner = PointSpawners.GetComponent<PointSpawner>();
        if (pointspawner.numWaves % 5 != 0)
        {
            speed += Time.deltaTime * acceleration;

            rb.velocity = Vector2.down * speed;

            Debug.Log("Speed + acceloration is: " + rb.velocity);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}

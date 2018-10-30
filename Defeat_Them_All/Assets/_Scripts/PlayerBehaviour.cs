using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.Debug;

public class PlayerBehaviour : MonoBehaviour
{

    // constants
    private const string H_AXIS = "Horizontal";
    private const string V_AXIS = "Vertical";

    public Vector2 startPos;
    public Vector2 direction;

    public Text m_Text;
    string message;

    // fields
    // make available in the unity to test
    [SerializeField]
    private float speed = 15f;
    [SerializeField]
    private float xMin = -2.7f;
    [SerializeField]
    private float xMax = 2.7f;


    private Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        // get the current object
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per view frame
    /*void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Handle finger movements based on TouchPhase
            switch (touch.phase)
            {
                //When a touch has first been detected, change the message and record the starting position
                case TouchPhase.Began:
                    Debug.Log("Touchphase began");
                    // Record initial touch position.
                    startPos = touch.position;
                    message = "Begun ";
                    break;

                //Determine if the touch is a moving touch
                case TouchPhase.Moved:
                    // Determine direction by comparing the current touch position with the initial one
                    direction = touch.position - startPos;
                    message = "Moving ";
                    break;

                case TouchPhase.Ended:
                    // Report that the touch has ended when it ends
                    message = "Ending ";
                    break;
            }
        }
        Debug.Log("Touch : " + message + "in direction" + direction);

    }*/
    // update with the physics engine
    private void FixedUpdate()
    {
        //        Input.GetKey(KeyCode.UpArrow )

        // get movement on the axes
        float hMovement = Input.GetAxis(H_AXIS);
        float vMovement = Input.GetAxis(V_AXIS);
        // get the current body and change the velocity
        // using the horizontal movement * speed value

        if (Input.touchCount > 0)
        {
            hMovement = Input.touches[0].deltaPosition.x;
            vMovement = Input.touches[0].deltaPosition.y;
        }

        rb.velocity = new Vector3(hMovement * speed, vMovement * speed);

        // Mathf.Clamp
        // work out the xValue based on the limits
        float xValue = Mathf.Clamp(rb.position.x, xMin, xMax);

        
        //float xValue = Mathf.Clamp01(rb.position.x);
         
        // keep position.x between two values
        rb.position = new Vector2(xValue, rb.position.y);

        //Update the Text on the screen depending on current TouchPhase, and the current direction vector

        // Track a single touch as a direction control.
        
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.Debug;

public class Player2Behaviour : MonoBehaviour
{
    // Controls Lugia game object
    // Has 2 additional lives (total 3) standard movement speed
    public GameObject GameOverPanel; //holds the user interface

    // constants
    private const string H_AXIS = "Horizontal";
    private const string V_AXIS = "Vertical";

    [SerializeField]
    private AudioClip crashClip;

    private SoundController soundController;

    // PlayerKilledEvent handlers
    public delegate void PlayerKilled(Player2Behaviour player);

    // static event
    public static PlayerKilled PlayerKilledEvent;

    // fields
    // make available in the unity to test
    [SerializeField]
    private float touchSpeed = 0.4f;
    [SerializeField]
    private float keySpeed = 1f;
    [SerializeField]
    private float xMin = -2.7f;
    [SerializeField]
    private float xMax = 2.7f;
    [SerializeField]
    private float yMin = -4.5f;
    [SerializeField]
    private float yMax = 4f;

    // For lives
    private int collisionCounter = 3;


    private Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        // get the current object
        rb = GetComponent<Rigidbody2D>();
        soundController = SoundController.FindSoundController();// get audio clips for gameplay
        collisionCounter = 3;// set the lives
    }

    // update with the physics engine
    private void FixedUpdate()
    {
        // get movement on the axes
        float hMovement = Input.GetAxis(H_AXIS);
        float vMovement = Input.GetAxis(V_AXIS);
        // get the current body and change the velocity
        // using the horizontal movement * speed value

        if (Input.touchCount > 0)//Update the Text on the screen depending on current TouchPhase, and the current direction vector

        {
            hMovement = Input.touches[0].deltaPosition.x;
            vMovement = Input.touches[0].deltaPosition.y;
            rb.velocity = new Vector2(hMovement * touchSpeed, vMovement * touchSpeed);

        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(hMovement * keySpeed, vMovement * keySpeed);
        }
        // Mathf.Clamp
        // work out the xValue based on the limits
        float xValue = Mathf.Clamp(rb.position.x, xMin, xMax);
        float yValue = Mathf.Clamp(rb.position.y, yMin, yMax);

        // keep position.x and position.y between two values
        rb.position = new Vector2(xValue, yValue);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // need to determine the type of "collision"
        string tagType = gameObject.tag;

        if (collision.gameObject.tag == "enemy")
        {
            collisionCounter--;
            if (soundController)
            {
                soundController.PlayOneShot(crashClip);// sound notifies player of a collision
            }
            if (collisionCounter == 0) {
                Debug.Log("GameEnded");
                GameOverPanel.SetActive(true);
                Time.timeScale = 0.0f;// stopping time
                GameController.LoseGame();// activates the game over panel
            }
            Debug.Log("Collision counter: " + collisionCounter);

        }
    }

    private void PublishPlayerKilledEvent()
    {
        if (PlayerKilledEvent != null)
        {
            PlayerKilledEvent(this);
        }

    }

}
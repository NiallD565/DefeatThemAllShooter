using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpeedController : MonoBehaviour {

    private const string FALLING_SPEED_METHOD = "NewSpeed";
    private bool isFalling = false;

    [SerializeField]
    private float speed = 4;
    [SerializeField]
    public float acceleration = 0.5f; //Every second, the speed will increase by this much

    private float newSpeed = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
            Invoke(FALLING_SPEED_METHOD, 0.2f);
        }
	}

    /*private float NewSpeed()
    {
        newSpeed += speed + acceleration;

        return NewSpeed;
    }*/
}

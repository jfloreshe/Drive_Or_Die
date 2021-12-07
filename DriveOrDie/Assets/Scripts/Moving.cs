using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moving : MonoBehaviour
{
    const float MAX_SPEED = 35f;
    public float multForce, acceleration;
    
    public Rigidbody player;
    public Rigidbody bike;
    public Transform bikeRotation;
    public Transform playerRotation;
    public Transform handLeft;
    public Transform handRight;

    public float timeIdle, timeStart;

    public Text speedInApp;
    public bool firstAccelerationDone;
<<<<<<< HEAD
=======

    public MainControllers controllers;
>>>>>>> pause
    public void checkHighestSpeed()
    {
        if (multForce >= 35f)
        {
            multForce = MAX_SPEED;
            acceleration = 0f;
        }
    }
    public void checkLowestSpeed()
    {
        if (multForce <= 0f)
        {
            multForce = 0f;
            acceleration = 0f;
        }
    }
    public void applyAcceleration()
    {     
        multForce += acceleration;
        checkHighestSpeed(); checkLowestSpeed();
        bike.velocity = bike.transform.forward * -multForce;
        player.velocity = bike.velocity;
    }
    public void checkChangeOfAcceleration()
    {
        if (firstAccelerationDone)
        {
            timeIdle = Time.time - timeStart;
            if (timeIdle >= 10f)
            {
                acceleration = -0.1f;
                timeStart = Time.time;
                timeIdle = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            firstAccelerationDone = true;
            acceleration += 0.05f;
            timeStart = Time.time;
            return;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            acceleration -= 0.05f;
            timeStart = Time.time;
            return;
        }

    }
    void Start()
    {
        bike = GameObject.Find("bike").GetComponent<Rigidbody>();
        bikeRotation = GameObject.Find("bike").GetComponent<Transform>();
        player = GameObject.Find("OVRPlayerController").GetComponent<Rigidbody>();
        playerRotation = GameObject.Find("OVRPlayerController").GetComponent<Transform>();
        handLeft = GameObject.Find("OVRPlayerController/OVRCameraRig/TrackingSpace/LeftHandAnchor").GetComponent<Transform>();
        handRight = GameObject.Find("OVRPlayerController/OVRCameraRig/TrackingSpace/LeftHandAnchor").GetComponent<Transform>();
        bike.velocity = bike.transform.forward *-multForce;
        player.velocity = bike.velocity;
        multForce = MAX_SPEED;
        acceleration = -0.05f;
<<<<<<< HEAD
        speedInApp = GameObject.Find("bike/Velocimetro/Canvas/Speed").GetComponent<Text>();
        timeStart = Time.time;
        firstAccelerationDone = false;
=======
        speedInApp = GameObject.Find("Bomb/Module1/Canvas/Speed").GetComponent<Text>();
        timeStart = Time.time;
        firstAccelerationDone = false;
        controllers = new MainControllers();
>>>>>>> pause
    }

    // Update is called once per frame
    void Update()
    {
        //if (handLeft.localRotation.z >= 0.5 && handLeft.localRotation.z <= 0.8) {
        
        applyAcceleration();
        checkChangeOfAcceleration();
<<<<<<< HEAD
=======
        controllers.checkUserInputs();
>>>>>>> pause
        speedInApp.text = multForce.ToString("F1");
        //Debug.Log(OVRInput.Get(OVRInput.Button.Four) || Input.GetKey(KeyCode.LeftArrow));
        if (OVRInput.Get(OVRInput.Button.Four) || Input.GetKey(KeyCode.LeftArrow)) { 
            bikeRotation.Rotate(new Vector3(0, -1f, 0));
            playerRotation.Rotate(new Vector3(0, -1f, 0));
            bike.velocity = bike.transform.forward * -multForce;
            player.velocity = bike.velocity;


        } else if (OVRInput.Get(OVRInput.Button.Two) || Input.GetKey(KeyCode.RightArrow)) {
            bikeRotation.Rotate(new Vector3(0, 1f, 0));
            playerRotation.Rotate(new Vector3(0, 1f, 0));
            bike.velocity = bike.transform.forward * -multForce;
            player.velocity = bike.velocity;
<<<<<<< HEAD
        } 
        //  }
=======
        }
        //  }
        
>>>>>>> pause
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementController : Controller
{
    public float currentAcceleration;
    public float timeIdle, timeStart;
    public bool firstAccelerationDone;
    public Rigidbody player;
    public Rigidbody bike;
    public Transform bikeRotation;
    public Transform playerRotation;
    public Transform handLeft;
    public Transform handRight;
    public Text velocityInApp;
    

    public MovementController()
    {
        currentAcceleration = -0.05f;
        bike = GameObject.Find("bike").GetComponent<Rigidbody>();
        bikeRotation = GameObject.Find("bike").GetComponent<Transform>();
        player = GameObject.Find("OVRPlayerController").GetComponent<Rigidbody>();
        playerRotation = GameObject.Find("OVRPlayerController").GetComponent<Transform>();
        handLeft = GameObject.Find("OVRPlayerController/OVRCameraRig/TrackingSpace/LeftHandAnchor").GetComponent<Transform>();
        handRight = GameObject.Find("OVRPlayerController/OVRCameraRig/TrackingSpace/LeftHandAnchor").GetComponent<Transform>();
        velocityInApp = GameObject.Find("bike/Velocimetro/Canvas/Speed").GetComponent<Text>();
        timeStart = Time.time;
        firstAccelerationDone = false;
        bike.velocity = bike.transform.forward * -BikeObject.velocity;
        player.velocity = bike.velocity;
    }
    public void checkHighestSpeed()
    {
        if (BikeObject.velocity >= BikeObject.MAX_VELOCITY)
        {
            BikeObject.velocity = BikeObject.MAX_VELOCITY;
            currentAcceleration = 0f;
        }
    }
    public void checkLowestSpeed()
    {
        if (BikeObject.velocity <= BikeObject.MIN_VELOCITY)
        {
            BikeObject.velocity = 0f;
            currentAcceleration = 0f;
        }
    }
    public void applyAcceleration()
    {
        if (bike != null)
        {
            BikeObject.velocity += currentAcceleration * Time.deltaTime * 20;
            checkHighestSpeed(); checkLowestSpeed();
            bike.velocity = bike.transform.forward * -BikeObject.velocity;
            player.velocity = bike.velocity;
            //if idle then acceleration decrease
            checkIdleStatus();
            velocityInApp.text = BikeObject.velocity.ToString("F1");
        }
        
    }
    public void checkIdleStatus()
    {
        if (firstAccelerationDone)
        {
            timeIdle = Time.time - timeStart;
            if (timeIdle >= 10f)
            {
                currentAcceleration = -0.1f;
                timeStart = Time.time;
                timeIdle = 0;
            }
        }
    }
    public void checkUserInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            firstAccelerationDone = true;
            currentAcceleration += 0.05f;
            timeStart = Time.time;
            return;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            currentAcceleration -= 0.05f;
            timeStart = Time.time;
            return;
        }
        if (OVRInput.Get(OVRInput.Button.Four) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            bikeRotation.Rotate(new Vector3(0, -1f, 0));
            playerRotation.Rotate(new Vector3(0, -1f, 0));
            bike.velocity = bike.transform.forward * -BikeObject.velocity;
            player.velocity = bike.velocity;


        }
        else if (OVRInput.Get(OVRInput.Button.Two) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            bikeRotation.Rotate(new Vector3(0, 1f, 0));
            playerRotation.Rotate(new Vector3(0, 1f, 0));
            bike.velocity = bike.transform.forward * -BikeObject.velocity;
            player.velocity = bike.velocity;

        }
    }
}

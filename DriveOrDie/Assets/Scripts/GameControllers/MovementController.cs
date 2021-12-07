using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementController : Controller
{
    const float MAX_SPEED = 35f;
    const float MIN_SPEED = 0f;
    public float currentVelocity, currentAcceleration;
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
        currentVelocity = MAX_SPEED;
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
        bike.velocity = bike.transform.forward * -currentVelocity;
        player.velocity = bike.velocity;
    }
    public void checkHighestSpeed()
    {
        if (currentVelocity >= MAX_SPEED)
        {
            currentVelocity = MAX_SPEED;
            currentAcceleration = 0f;
        }
    }
    public void checkLowestSpeed()
    {
        if (currentVelocity <= MIN_SPEED)
        {
            currentVelocity = 0f;
            currentAcceleration = 0f;
        }
    }
    public void applyAcceleration()
    {
        currentVelocity += currentAcceleration*Time.deltaTime*20;
        checkHighestSpeed(); checkLowestSpeed();
        bike.velocity = bike.transform.forward * -currentVelocity;
        player.velocity = bike.velocity;
        //if idle then acceleration decrease
        checkIdleStatus();
        velocityInApp.text = currentVelocity.ToString("F1");
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
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            firstAccelerationDone = true;
            currentAcceleration += 0.05f;
            timeStart = Time.time;
            return;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentAcceleration -= 0.05f;
            timeStart = Time.time;
            return;
        }
        if (OVRInput.Get(OVRInput.Button.Four) || Input.GetKey(KeyCode.LeftArrow))
        {
            bikeRotation.Rotate(new Vector3(0, -1f, 0));
            playerRotation.Rotate(new Vector3(0, -1f, 0));
            bike.velocity = bike.transform.forward * -currentVelocity;
            player.velocity = bike.velocity;


        }
        else if (OVRInput.Get(OVRInput.Button.Two) || Input.GetKey(KeyCode.RightArrow))
        {
            bikeRotation.Rotate(new Vector3(0, 1f, 0));
            playerRotation.Rotate(new Vector3(0, 1f, 0));
            bike.velocity = bike.transform.forward * -currentVelocity;
            player.velocity = bike.velocity;

        }
    }
}

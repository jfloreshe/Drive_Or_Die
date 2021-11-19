using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    float multForce = 40f;

    public Rigidbody player;
    public Rigidbody bike;
    public Transform bikeRotation;
    public Transform playerRotation;
    public Transform handLeft;
    public Transform handRight;

    // Start is called before the first frame update
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
    }

    // Update is called once per frame
    void Update()
    {
       //if (handLeft.localRotation.z >= 0.5 && handLeft.localRotation.z <= 0.8) {

            Debug.Log(OVRInput.Get(OVRInput.Button.Four) || Input.GetKey(KeyCode.LeftArrow));
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
       
            }
      //  }
    }
}

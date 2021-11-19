using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeInitPosition : MonoBehaviour
{
    public GameObject bike;
    public GameObject player;
    public GameObject cameraPlayer;
   
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.Find("OVRPlayerController");
        bike = GameObject.Find("bike");
        cameraPlayer = GameObject.Find("OVRPlayerController");
        cameraPlayer.transform.position = bike.transform.position;

    }
    // Update is called once per frame
    void Update()
    {

    }
}

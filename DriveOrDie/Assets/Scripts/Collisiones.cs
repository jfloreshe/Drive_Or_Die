using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Collisiones : MonoBehaviour
{
    float multForce = 15f;
    public Rigidbody carRigidBody;
    public Transform carTransform;

    string[] noCollisiona = { "WallAddTakeRoute", "WallCompleteTakeRoute2", "WallCompleteTakeRoute1",
        "WallTriggerRoute0", "WallTriggerRoute1","WallTriggerRoute2","WallAddFindTrafficSign", "WallAddDodgeCars",
    "WallTrigger30", "WallTrigger40", "WallTrigger20", "WallTriggerRoute2-30", "WallTriggerRoute2-40", "WallTriggerRoute2-20", "GrabVolumeBig",
    "GrabVolumeSmall", "acelerador", "Wall1", "Cube"};
     

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Poste8")
        {
            carTransform.Rotate(0, 45, 0);
            carRigidBody.transform.position = new Vector3(2.03f, -0f, -120f);
            carRigidBody.velocity = carRigidBody.transform.right * -multForce;

        }
        
        else if(Array.IndexOf(noCollisiona, other.gameObject.name) != -1)
        {
            ; // Do nothing
        }
        else
        {
            Debug.Log(other.gameObject.name);
            carTransform.Rotate(0, 45, 0);
            carRigidBody.velocity = carRigidBody.transform.right * -multForce;
        }

    }
}

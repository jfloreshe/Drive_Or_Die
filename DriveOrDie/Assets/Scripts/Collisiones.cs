using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisiones : MonoBehaviour
{
    float multForce = 30f;
    public Rigidbody carRigidBody;
    public Transform carTransform;
    
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
        
        else if(other.gameObject.name == "GrabVolumeBig" || other.gameObject.name == "GrabVolumeSmall" || 
                other.gameObject.name == "acelerador"|| other.gameObject.name == "Wall1")
        {
            ; // Do nothing
        }
        else
        {
            carTransform.Rotate(0, 45, 0);
            carRigidBody.velocity = carRigidBody.transform.right * -multForce;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollisionCars : MonoBehaviour
{
    float forceMult = 20f;
    private Rigidbody carRigidBody;
    private Transform carTransform;
    

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

            carTransform.Rotate(0, 45, 0);
            carRigidBody.velocity = carRigidBody.transform.right * -forceMult;

    }
}

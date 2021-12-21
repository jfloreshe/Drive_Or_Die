using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitMovement : MonoBehaviour
{
    float multForce = 15f;
    public Rigidbody car;
    // Start is called before the first frame update
    void Start()
    {
        car.velocity = car.transform.right * -multForce;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeInitPosition : MonoBehaviour
{
    public GameObject bike;
   
    // Start is called before the first frame update
    void Start()
    {
        
        bike = GameObject.Find("bike");

    }
    // Update is called once per frame
    void Update()
    {

    }
}

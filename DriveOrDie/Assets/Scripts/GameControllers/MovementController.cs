using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementController : Controller
{
    public float currentAcceleration;
    public float timePressed, timeStart;
    public bool firstAccelerationDone;
    public Rigidbody bike;
    public Transform bikeRotation;
    public Text velocityInApp;
    public Text module1InApp;
    public Text module2InApp;
    public Renderer light1Renderer;
    public Renderer light2Renderer;


    public MovementController()
    {
        currentAcceleration = -0.05f;
        bike = GameObject.Find("bike").GetComponent<Rigidbody>();
        bikeRotation = GameObject.Find("bike").GetComponent<Transform>();
        velocityInApp = GameObject.Find("bike/Velocimetro/Canvas/Speed").GetComponent<Text>();
        module1InApp = GameObject.Find("bike/Bomb/Module1/Canvas/Speed").GetComponent<Text>();
        module2InApp = GameObject.Find("bike/Bomb/Module2/Canvas/Speed").GetComponent<Text>();
        light1Renderer = GameObject.Find("bike/Bomb/Light1").GetComponent<Renderer>();
        light2Renderer = GameObject.Find("bike/Bomb/Light2").GetComponent<Renderer>();
        timeStart = Time.time;
        firstAccelerationDone = false;
        bike.velocity = bike.transform.forward * -BikeObject.velocity;
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
            BikeObject.velocity = 40f;
            currentAcceleration = 0f;
            UnityEngine.SceneManagement.SceneManager.LoadScene("YouLose");
        }
    }
    public void applyAcceleration()
    {
        if (bike != null)
        {
            BikeObject.velocity += currentAcceleration * Time.deltaTime * 20;
            checkHighestSpeed(); checkLowestSpeed();
            bike.velocity = bike.transform.forward * -BikeObject.velocity;
            //if idle then acceleration decrease
            //checkIdleStatus();
            currentAcceleration = -0.025f;
            checkVelocityPuzzle();
            velocityInApp.text = BikeObject.velocity.ToString("F1");
        }
        
    }
    public void checkVelocityPuzzle()
    {
        if(BombObject.module1Done == false)
        {
            if (BikeObject.velocity >= BombObject.module1Velocity - 3 && BikeObject.velocity <= BombObject.module1Velocity + 3)
            {
                BombObject.module1Timer -= 1 * Time.deltaTime;
                light1Renderer.material.color = Color.green;
            }
            else
            {
                light1Renderer.material.color = Color.red;
            }
            if (BombObject.module1Timer <= 0)
            {
                BombObject.module1Timer = 0;
                BombObject.module1Done = true;
            }
        }
        if(BombObject.module2Done == false)
        {
            if (BikeObject.velocity >= BombObject.module2Velocity - 3 && BikeObject.velocity <= BombObject.module2Velocity + 3)
            {
                BombObject.module2Timer -= 1 * Time.deltaTime;
                light2Renderer.material.color = Color.green;
            }
            else
            {
                light2Renderer.material.color = Color.red;
            }
            if (BombObject.module2Timer <= 0)
            {
                BombObject.module2Timer = 0;
                BombObject.module2Done = true;
            }
        }
        
        if (BombObject.module2Done && BombObject.module1Done)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("YouWin");
        }
        if (BombObject.module1Done)
        {
            light1Renderer.material.color = Color.green;
        }
        if (BombObject.module2Done)
        {
            light2Renderer.material.color = Color.green;
        }
        module1InApp.text = BombObject.module1Timer.ToString("F1");
        module2InApp.text = BombObject.module2Timer.ToString("F1");

    }
   
    public void checkUserInput()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                timeStart = Time.time;
                timePressed = 0.01f;
            }
            timePressed = Time.time - timeStart;
            firstAccelerationDone = true;
            currentAcceleration += (0.2f * timePressed);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                timeStart = Time.time;
                timePressed = 0.01f;
            }
            timePressed = Time.time - timeStart;
            if (currentAcceleration <= 5.0)
            {
                currentAcceleration -= (0.2f * timePressed);
            } else
            {
                currentAcceleration -= 5.0f;
            }            
        }


        if (OVRInput.Get(OVRInput.Button.Four) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if(bike != null)
            {
                bikeRotation.Rotate(new Vector3(0, -1f, 0));
                bike.velocity = bike.transform.forward * -BikeObject.velocity;
            }
            
        }
        if (OVRInput.Get(OVRInput.Button.Two) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if(bike != null)
            {
                bikeRotation.Rotate(new Vector3(0, 1f, 0));
                bike.velocity = bike.transform.forward * -BikeObject.velocity;
            }
        }
    }
}

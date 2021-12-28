using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class CheckEvents : MonoBehaviour
{
    public const int TOTAL_TASKS = 8;
    public const float HEIGHT = 0.8f;
    public float lastPos = 0;
    public string[] tasksInFile;
    public GameObject[] tasks;
    public GameObject taskPrefab;
    public GameObject bike;
    public Transform imageTask;
    public Canvas taskCanvas;
    bool hasCollided = false;
    bool hasCollided2 = false;
    string[] noCollisiona = { "WallAddTakeRoute","WallAddFindTrafficSign","WallAddDodgeCars",
        "WallCompleteTakeRoute1","WallCompleteTakeRoute2",
        "WallTrigger30","WallTrigger40","WallTrigger20",
        "WallTriggerRoute2-30","WallTriggerRoute2-40","WallTriggerRoute2-20",
        "WallTriggerRoute0", "WallTriggerRoute1","WallTriggerRoute2",
        "Poste1", "Poste2", "Poste3", "Poste4","Poste5", 
        "Poste6", "Poste7", "Poste8", "Poste1_2", "Poste2_2", "Poste3_2", "Poste4_2", "Poste5_2", 
        "Poste6_2", "Poste7_2", "Poste8_2" };

    private void OnTriggerEnter(Collider other)
    {

        AddedTasks.checkEvents(other);
        CompletedTasks.checkEvents(other);
        BombObject.checkModule1State(other);
        BombObject.checkModule2State(other);
        BikeObject.checkRoute(other);

        if (Array.IndexOf(noCollisiona, other.gameObject.name) == -1)
        {
            Destroy(bike);
            BombObject.timerIsRunning = false;
            BombObject.module1Velocity = 0f;
            BombObject.module2Velocity = 0f;
            BikeObject.currentRoute = 0;
            SceneManager.LoadScene("Drive");
        }
    }
    void Start()
    {
        bike = GameObject.Find("bike");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

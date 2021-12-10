using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitTaskPool : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TaskPoolObject.taskPrefab = Resources.Load<GameObject>("Task");
        TaskPoolObject.imageTask = GameObject.Find("OVRPlayerController/TasksPool/TaskCanvas/Image").GetComponent<Transform>();
        TaskPoolObject.taskCanvas = GameObject.Find("OVRPlayerController/TasksPool/TaskCanvas").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

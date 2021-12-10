using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InitTaskPool : MonoBehaviour
{
    public Transform image;
    public Canvas canvas;
    void Start()
    {
        TaskPoolObject.lastPosition = 0;//we may change this
        TaskPoolObject.taskPrefab = Resources.Load<GameObject>("Task");
        TaskPoolObject.imageTask = image;//GameObject.Find("InGameMenu/InGameMenu/Image").GetComponent<Transform>();
        TaskPoolObject.taskCanvas = canvas;// GameObject.Find("InGameMenu/InGameMenu").GetComponent<Canvas>();
        Debug.Log(TaskPoolObject.taskPool.Count);
        string[] keys = TaskPoolObject.taskPool.Keys.ToArray();
        bool[] values = TaskPoolObject.taskPool.Values.ToArray();
        for (int i = 0; i < keys.Count(); i++)
        {
            Task newTask = TaskPoolObject.addNewTask(keys[i]);
            if (values[i])
                newTask.completeTask();
            TaskPoolObject.lastPosition -= TaskPoolObject.HEIGHT;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

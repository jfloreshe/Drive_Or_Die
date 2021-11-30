using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    // Start is called before the first frame update
    void addTask(int index)
    {
        tasks[index] = GameObject.Instantiate(taskPrefab, imageTask.position + new Vector3(0,lastPos,0), imageTask.rotation) as GameObject;
        lastPos -= HEIGHT;
        tasks[index].transform.SetParent(taskCanvas.gameObject.transform, true);
        Texture taskTexture = Resources.Load("Images/task" + (index + 1), typeof(Texture2D)) as Texture;
        Debug.Log(index);
        Debug.Log(taskTexture);
        tasks[index].transform.GetChild(0).gameObject.GetComponent<RawImage>().texture = taskTexture;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.name == "Wall1" && !hasCollided)
        {
            hasCollided = true;
            addTask(3);
            addTask(4);
        }
        else if (other.gameObject.name == "Wall2" && !hasCollided2)
        {
            hasCollided2 = true;
            tasks[4].transform.GetChild(1).gameObject.GetComponent<RawImage>().color = new Color(1f, 1f, 1f, 1f);
        }
    }
    void Start()
    {
        tasks = new GameObject[TOTAL_TASKS];
        tasksInFile = new string[TOTAL_TASKS];
        taskPrefab = Resources.Load<GameObject>("Task");
        taskCanvas = GameObject.Find("OVRPlayerController/TasksPool/TaskCanvas").GetComponent<Canvas>();
        imageTask = GameObject.Find("OVRPlayerController/TasksPool/TaskCanvas/Image").GetComponent<Transform>();
        bike = GameObject.Find("bike");
        for(int i = 0; i < TOTAL_TASKS; i++)
        {
            tasksInFile[i] = "Task" + (i+1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

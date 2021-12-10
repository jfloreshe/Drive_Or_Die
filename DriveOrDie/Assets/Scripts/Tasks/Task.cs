using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task
{
    public bool hasCollided { get; set; }
    public GameObject task;
    public Texture taskTexture;
    public Task(Canvas parent, GameObject prefab, Vector3 pos, Quaternion rotation, string name)
    {
        hasCollided = false;
        task = GameObject.Instantiate(prefab, pos, rotation) as GameObject;
        task.transform.SetParent(parent.gameObject.transform, true);
        taskTexture = Resources.Load("Images/task" + name, typeof(Texture2D)) as Texture;
        task.transform.GetChild(0).gameObject.GetComponent<RawImage>().texture = taskTexture;
    }
    public void completeTask()
    {
        hasCollided = true;
        task.transform.GetChild(1).gameObject.GetComponent<RawImage>().color = new Color(1f, 1f, 1f, 1f);
    }
}

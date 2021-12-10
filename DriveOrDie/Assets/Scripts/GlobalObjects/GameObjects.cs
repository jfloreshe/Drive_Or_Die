using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BikeObject
{
    public const float MAX_VELOCITY = 35f;
    public const float MIN_VELOCITY = 0f;
    public static float velocity { get; set; }
}

public static class BombObject
{
    public static float startTime { get; set; }
    public static bool timerIsRunning { get; set; }
}

public static class TimerObject
{
    public static int totalTime { get; set; }
}

public static class TaskPoolObject
{

    public const float HEIGHT = 0.8f;
    public static GameObject taskPrefab { get; set; }
    public static Transform imageTask { get; set; }
    public static Canvas taskCanvas { get; set; }
    public static IDictionary<string, Task> taskPool { get; set; }
    public static float lastPosition { get; set; }
    public static void addNewTask(string name)
    {
        taskPool[name] = new Task(taskCanvas, taskPrefab, imageTask.position + new Vector3(0, lastPosition, 0), imageTask.rotation, name);
        lastPosition -= HEIGHT;
    }
    
}
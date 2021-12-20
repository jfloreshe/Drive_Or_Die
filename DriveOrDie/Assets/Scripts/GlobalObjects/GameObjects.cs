using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BikeObject
{
    public const float MAX_VELOCITY = 45f;
    public const float MIN_VELOCITY = 0f;
    public static float velocity { get; set; }
}

public static class BombObject
{
    public static float startTime { get; set; }
    public static bool timerIsRunning { get; set; }
    public static float module1Timer { get; set; }
    public static float module2Timer { get; set; }
    public static float module1Velocity { get; set; }
    public static float module2Velocity { get; set; }
    public static bool module1Done { get; set; }
    public static bool module2Done { get; set; }
    public static void checkModule1State(Collider obj)
    {
        if(obj.name == "WallTrigger30")
        {
            module1Velocity = 30f;
            module2Velocity = 0f;
        }
        else if(obj.name == "WallTrigger40")
        {
            module1Velocity = 40f;
            module2Velocity = 0f;
        }
        else if(obj.name == "WallTrigger20")
        {
            module1Velocity = 20f;
            module2Velocity = 0f;
        }
    }
    public static void checkModule2State(Collider obj)
    {
        if (obj.name == "WallTriggerRoute2-30")
        {
            module2Velocity = 30f;
            module1Velocity = 0f;
        }
        else if (obj.name == "WallTriggerRoute2-40")
        {
            module2Velocity = 40f;
            module1Velocity = 0f;
        }
        else if (obj.name == "WallTriggerRoute2-20")
        {
            module2Velocity = 20f;
            module1Velocity = 0f;
        }
    }
}

public static class TimerObject
{
    public static int totalTime { get; set; }
}

public static class TaskPoolObject
{

    public const float HEIGHT = 35f;
    public static GameObject taskPrefab { get; set; }
    public static Transform imageTask { get; set; }
    public static Canvas taskCanvas { get; set; }
    public static Dictionary<string, bool> taskPool { get; set; }
    public static float lastPosition { get; set; }
    public static Task addNewTask(string name)
    {
        return new Task(taskCanvas, taskPrefab, imageTask.position + new Vector3(0, lastPosition, 0), imageTask.rotation, name);
    }
    
}
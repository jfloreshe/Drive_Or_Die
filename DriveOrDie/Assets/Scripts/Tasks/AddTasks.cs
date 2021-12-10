using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AddedTasks
{
    public static IDictionary<string, bool> tasks;
    public static void checkEvents (Collider obj)
    {
        foreach( KeyValuePair<string,bool> task in tasks)
        {
            if (obj.gameObject.name == "WallAdd" + task.Key && !task.Value)
            {
                if(task.Key == "TakeRoute")
                {
                    TaskPoolObject.taskPool.Add("TakeRoute1", false);
                    TaskPoolObject.taskPool.Add("TakeRoute2", false);
                }
                else
                {
                    TaskPoolObject.taskPool[task.Key] = false;
                }
                tasks[task.Key] = true;
            }
        }
    }
}

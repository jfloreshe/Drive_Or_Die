using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CompletedTasks {

    public static IDictionary<string, bool> tasks;
    public static void checkEvents(Collider obj)
    {
        foreach (KeyValuePair<string, bool> task in tasks)
        {
            if (obj.gameObject.name == "WallComplete" + task.Key && !task.Value)
            {
                TaskPoolObject.taskPool[task.Key].completeTask();
                tasks[task.Key] = true;
            }
        }
    }
}

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
                    TaskPoolObject.addNewTask("TakeRoute1");
                    TaskPoolObject.addNewTask("TakeRoute2");
                }
                else
                {
                    TaskPoolObject.addNewTask(task.Key);
                }
                tasks[task.Key] = true;
            }
        }
    }
}

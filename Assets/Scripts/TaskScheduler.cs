using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskScheduler : MonoBehaviour
{
    [HideInInspector]
    public List<(Tasks, bool)> taskList = new List<(Tasks, bool)>();
    public List<Tasks> MissionTasksList = new List<Tasks>();
    // Start is called before the first frame update
    
    void Start()
    {
        foreach (Tasks t in MissionTasksList)
            taskList.Add((t, false));
    }
    
    public void markTask(Tasks T)
    {
        int i = taskList.IndexOf((T, false));
        if (i != -1)
            taskList[i]= (T,true);
    }
    
    public float getCompletion()
    {
       return taskList.FindAll( (x) => x.Item2 == true ).Count/taskList.Count;
    }

}
public enum Tasks 
{
    init, throttle, fuel, rotatation
}
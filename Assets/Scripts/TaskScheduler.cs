using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    public void unmarkTask(Tasks T)
    {
        int i = taskList.IndexOf((T, true));
        if (i != -1)
            taskList[i] = (T, false);

    }

    public float getCompletion()
    {
       return (float)taskList.FindAll( (x) => x.Item2 == true ).Count/(float)taskList.Count;
    }
    
}
public enum Tasks 
{
    Init, Throttle, Fuel, Rotatation, Engines, SensorsCalibrated, Readings, DetachBack,
}


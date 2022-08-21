using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TaskUI : MonoBehaviour
{
    public TMPro.TextMeshProUGUI midScreen;
    public TMPro.TextMeshProUGUI leftScreen;
    public TMPro.TextMeshProUGUI rightScreen;
    private TaskScheduler scheduler;
    // Start is called before the first frame update
    void Start()
    {
        scheduler = GameObject.Find("Scheduler").GetComponent<TaskScheduler>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        string taskString="";
        foreach(var task in scheduler.taskList) 
        {
            taskString+= task.Item1.ToString()+" "+(task.Item2==false?" NOT ":"")+"completed\n";
        }
        leftScreen.text = taskString;
        
    }
}

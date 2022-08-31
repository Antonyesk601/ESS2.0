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
    private Dictionary<string, Dictionary<Color,string>> MessageKWDict=  new Dictionary<string, Dictionary<Color,string>>();
    private Dictionary<Tasks, string> displayTasks = new Dictionary<Tasks, string>();
    
    // Start is called before the first frame update
    void Start()
    {
        scheduler = GameObject.Find("Scheduler").GetComponent<TaskScheduler>();

        MessageKWDict["DestinationMapper"] = new Dictionary<Color, string>();
        MessageKWDict["DestinationMapper"].Add(GameManager.Instance.Colors[0], "Earth");
        MessageKWDict["DestinationMapper"].Add(GameManager.Instance.Colors[1], "Mercury");
        MessageKWDict["DestinationMapper"].Add(GameManager.Instance.Colors[2], "Venus");
        MessageKWDict["DestinationMapper"].Add(GameManager.Instance.Colors[3], "Mars");
        MessageKWDict["DestinationMapper"].Add(GameManager.Instance.Colors[4], "Jupiter");
        MessageKWDict["DestinationMapper"].Add(GameManager.Instance.Colors[5], "Uranus");
        MessageKWDict["DestinationMapper"].Add(GameManager.Instance.Colors[6], "Neptune");

        MessageKWDict[Tasks.Rotatation.ToString()] = new Dictionary<Color, string>();
        MessageKWDict[Tasks.Rotatation.ToString()].Add(GameManager.Instance.Colors[0], "20N 90W 40D");
        MessageKWDict[Tasks.Rotatation.ToString()].Add(GameManager.Instance.Colors[2], "-92N 40E 6D");
        MessageKWDict[Tasks.Rotatation.ToString()].Add(GameManager.Instance.Colors[1], "29S 90W 70U");
        MessageKWDict[Tasks.Rotatation.ToString()].Add(GameManager.Instance.Colors[3], "6S 6W 6D");
        MessageKWDict[Tasks.Rotatation.ToString()].Add(GameManager.Instance.Colors[4], "4N 2E 0UD");
        MessageKWDict[Tasks.Rotatation.ToString()].Add(GameManager.Instance.Colors[5], "64N 9W 40U");
        MessageKWDict[Tasks.Rotatation.ToString()].Add(GameManager.Instance.Colors[6], "200N 30E -180D");

        MessageKWDict[Tasks.Fuel.ToString()] = new Dictionary<Color, string>();
        MessageKWDict[Tasks.Fuel.ToString()].Add(GameManager.Instance.Colors[0], "200 TJ");
        MessageKWDict[Tasks.Fuel.ToString()].Add(GameManager.Instance.Colors[1], "3000 MJ");
        MessageKWDict[Tasks.Fuel.ToString()].Add(GameManager.Instance.Colors[2], "10 YJ");
        MessageKWDict[Tasks.Fuel.ToString()].Add(GameManager.Instance.Colors[3], "110 ZJ");
        MessageKWDict[Tasks.Fuel.ToString()].Add(GameManager.Instance.Colors[4], "20877 MJ");
        MessageKWDict[Tasks.Fuel.ToString()].Add(GameManager.Instance.Colors[5], "9999 ZJ");
        MessageKWDict[Tasks.Fuel.ToString()].Add(GameManager.Instance.Colors[6], "0 J");

        MessageKWDict[Tasks.Engines.ToString()] = new Dictionary<Color, string>();
        MessageKWDict[Tasks.Engines.ToString()].Add(GameManager.Instance.Colors[0], "Warp Drive Damaged");
        MessageKWDict[Tasks.Engines.ToString()].Add(GameManager.Instance.Colors[1], "Hyper Drive Damaged");
        MessageKWDict[Tasks.Engines.ToString()].Add(GameManager.Instance.Colors[2], "Infinite Improbability Drive Damaged");
        MessageKWDict[Tasks.Engines.ToString()].Add(GameManager.Instance.Colors[3], "FTL Drive Live");
        MessageKWDict[Tasks.Engines.ToString()].Add(GameManager.Instance.Colors[4], "Tardis Active");
        MessageKWDict[Tasks.Engines.ToString()].Add(GameManager.Instance.Colors[5], "Holtzman Drive Enabled");
        MessageKWDict[Tasks.Engines.ToString()].Add(GameManager.Instance.Colors[6], "Boom Tube Enabled");

        MessageKWDict[Tasks.Throttle.ToString()] = new Dictionary<Color, string>();
        MessageKWDict[Tasks.Throttle.ToString()].Add(GameManager.Instance.Colors[0], "314159265359 m/s");
        MessageKWDict[Tasks.Throttle.ToString()].Add(GameManager.Instance.Colors[1], "11802852677.165 inches/s");
        MessageKWDict[Tasks.Throttle.ToString()].Add(GameManager.Instance.Colors[2], "186,282 mps");
        MessageKWDict[Tasks.Throttle.ToString()].Add(GameManager.Instance.Colors[3], "9000 years/second");
        MessageKWDict[Tasks.Throttle.ToString()].Add(GameManager.Instance.Colors[4], "5555 booms/minute");
        MessageKWDict[Tasks.Throttle.ToString()].Add(GameManager.Instance.Colors[5], "the universe moves around you");
        MessageKWDict[Tasks.Throttle.ToString()].Add(GameManager.Instance.Colors[6], "591c3 visions/sandworm");

        MessageKWDict[Tasks.SensorsCalibrated.ToString()] = new Dictionary<Color, string>();
        MessageKWDict[Tasks.SensorsCalibrated.ToString()].Add(GameManager.Instance.Colors[0], "Check your accelerometer");
        MessageKWDict[Tasks.SensorsCalibrated.ToString()].Add(GameManager.Instance.Colors[1], "All is Well");
        MessageKWDict[Tasks.SensorsCalibrated.ToString()].Add(GameManager.Instance.Colors[2], "Universal positioning system malfunctioning");
        MessageKWDict[Tasks.SensorsCalibrated.ToString()].Add(GameManager.Instance.Colors[3], "Gyroscope is inverted");
        MessageKWDict[Tasks.SensorsCalibrated.ToString()].Add(GameManager.Instance.Colors[4], "AstroAstrolabe can't find refernce point");
        MessageKWDict[Tasks.SensorsCalibrated.ToString()].Add(GameManager.Instance.Colors[5], "driver_irql_not_less_or_equal");
        MessageKWDict[Tasks.SensorsCalibrated.ToString()].Add(GameManager.Instance.Colors[6], "0xC0000005");

        MessageKWDict[Tasks.Readings.ToString()] = new Dictionary<Color, string>();
        MessageKWDict[Tasks.Readings.ToString()].Add(GameManager.Instance.Colors[0], "Engine 6 defective");
        MessageKWDict[Tasks.Readings.ToString()].Add(GameManager.Instance.Colors[1], "Detach luggage Compartment");
        MessageKWDict[Tasks.Readings.ToString()].Add(GameManager.Instance.Colors[2], "a crew member must be sacrificed");
        MessageKWDict[Tasks.Readings.ToString()].Add(GameManager.Instance.Colors[3], "the black hole god requires a sacrifice");
        MessageKWDict[Tasks.Readings.ToString()].Add(GameManager.Instance.Colors[4], "cuthulu is eating you ship, cut it off to prevent eminnet death");
        MessageKWDict[Tasks.Readings.ToString()].Add(GameManager.Instance.Colors[5], "get moving quick before something happens");
        MessageKWDict[Tasks.Readings.ToString()].Add(GameManager.Instance.Colors[6], "go for it and pretend nothing is wrong");

        MessageKWDict[Tasks.WeightLimitation.ToString()] = new Dictionary<Color, string>();
        MessageKWDict[Tasks.WeightLimitation.ToString()].Add(GameManager.Instance.Colors[0], "800 Tons");
        MessageKWDict[Tasks.WeightLimitation.ToString()].Add(GameManager.Instance.Colors[1], "as big as your guilt");
        MessageKWDict[Tasks.WeightLimitation.ToString()].Add(GameManager.Instance.Colors[2], "weight of the world");
        MessageKWDict[Tasks.WeightLimitation.ToString()].Add(GameManager.Instance.Colors[3], "you can fit so much into this baby *slaps the roof*");
        MessageKWDict[Tasks.WeightLimitation.ToString()].Add(GameManager.Instance.Colors[4], "$#*/, we're in trouble");
        MessageKWDict[Tasks.WeightLimitation.ToString()].Add(GameManager.Instance.Colors[5], "Rock Lee and Goku's training weights");
        MessageKWDict[Tasks.WeightLimitation.ToString()].Add(GameManager.Instance.Colors[6], "Gordon Ramsay's ego");

        displayTasks[Tasks.Fuel] = "Energy Levels";
        displayTasks[Tasks.Init] = "Initialize";
        displayTasks[Tasks.Throttle] = "Target Speed";
        displayTasks[Tasks.Rotatation] = "Ship Orientation";
        displayTasks[Tasks.SensorsCalibrated] = "Sensors Calibration Status";
        displayTasks[Tasks.WeightLimitation] = "Fuel-Weight limitations";
        displayTasks[Tasks.Engines] = "Engine Status";
        displayTasks[Tasks.Readings] = "Sensor Readings";
    }

    // Update is called once per frame
    void LateUpdate()
    {
        string taskString="";
        string infoStringMid = "";
        string infoStringRight = "";
        if (scheduler.MissionTasksList.Count == GameManager.Instance.IntendedTaskCount)
        {
            foreach(var task in scheduler.taskList) 
            {
                taskString+= displayTasks[task.Item1]+" "+(task.Item2==false?" NOT ":"")+"completed\n";
            }
            infoStringMid += "Destination : "+ MessageKWDict["DestinationMapper"][GameManager.Instance.Colors[(GameManager.Instance.SimilarColorCount + GameManager.Instance.Chosen.Values.Count + GameManager.Instance.IntendedTaskCount)%GameManager.Instance.Colors.Count]]+"\n";
            foreach (var task in scheduler.taskList.GetRange(0, scheduler.taskList.Count / 2))
            {
                infoStringMid += displayTasks[task.Item1] + " : " + MessageKWDict[task.Item1.ToString()][GameManager.Instance.Interactables.transform.GetChild((int)task.Item1).GetComponent<Task>().Target]+"\n";
            }
            foreach (var task in scheduler.taskList.GetRange(scheduler.taskList.Count / 2, scheduler.taskList.Count / 2))
            {
                infoStringRight+= displayTasks[task.Item1] + " : " + MessageKWDict[task.Item1.ToString()][GameManager.Instance.Interactables.transform.GetChild((int)task.Item1).GetComponent<Task>().Target] + "\n";
            }
            leftScreen.text = taskString;
            midScreen.text = infoStringMid;
            rightScreen.text = infoStringRight;

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{

    public float score = 0;

    StreamWriter writer ;
    private void Start()
    {
        writer = new StreamWriter(Application.persistentDataPath + "/Scores.txt", true);
    }
    void FixedUpdate()
    {
        score++;
    }
    private void OnApplicationQuit()
    {
        
    }
}

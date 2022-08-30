using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance 
    {
        get
        {

            return _instance;
        }
        private set
        {
            if (_instance == null)
                _instance = value;
            else
                Destroy(value);
        }
    }
    private static GameManager _instance;
    public List<Color> Colors;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(this);
        }
        else if(Instance == null)
            Instance = this;
        else
        {
            DontDestroyOnLoad(this);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

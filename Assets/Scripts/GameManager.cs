using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
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
    public bool initailized;
    public int SimilarColorCount = 0;
    public TaskScheduler schedueler;
    public Dictionary<Color, int> Chosen;
    public GameObject Interactables;
    public int IntendedTaskCount = 4;

    // Start is called before the first frame update
    private void Start()
    {
        initailized = false;
    }
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

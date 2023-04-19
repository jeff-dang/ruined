using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance;
    public static string CurrentLevel = "Start";
    public static string CurrentArea = "Forest";
    public static List<string> CompletedLevels = new List<string>();
    public static int maxHP = 10;
    public static int currentHP = 10;
    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddToCompletedLevels(string level)
    {
        CompletedLevels.Add(level);
    }

    public static bool CheckIfCompleted(string level)
    {
        return CompletedLevels.Contains(level);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

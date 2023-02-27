using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        // //string levelCompleted = NextSceneScript.levelSelected;
        // foreach(level in buttonStrings)
        // {
        //     //Button for level == unclickable
        //     if(levelCompleted == level){
        //         break;
        //     }
        // }
    }

    //     // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void OpenScene(string sceneArea) {
        int index = sceneArea.LastIndexOfAny("0123456789".ToCharArray());

        string areaName = sceneArea.Substring(0, index);
        int areaLevel = int.Parse(sceneArea.Substring(index));

        PlayerPrefs.SetString("areaName", areaName);
        PlayerPrefs.SetInt("areaLevel", areaLevel);
        Debug.Log(areaName);
        Debug.Log(areaLevel);
        SceneManager.LoadScene("GridScene");
    }
}

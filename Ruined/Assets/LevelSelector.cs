using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelSelector : MonoBehaviour
{
    Button Start1;

    Button Safe1;
    Button Safe2;
    
    Button Forest1;
    Button Forest2;
    Button Forest3;
    Button Forest4;

    Button Mist1;
    Button Mist2;
    Button Mist3;

    Button Swamp1;
    Button Swamp2;
    Button Swamp3;

    Button Volcano1;
    Button Volcano2;
    Button Volcano3;

    Button Boss1;



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
        Start1 = GameObject.Find("Main Camera/Canvas/Start").GetComponent<Button>();
        Safe1 = GameObject.Find("Main Camera/Canvas/Safe1").GetComponent<Button>();
        Safe2 = GameObject.Find("Main Camera/Canvas/Safe2").GetComponent<Button>();
        Forest1 = GameObject.Find("Main Camera/Canvas/Forest1").GetComponent<Button>();
        Forest2 = GameObject.Find("Main Camera/Canvas/Forest2").GetComponent<Button>();
        Forest3 = GameObject.Find("Main Camera/Canvas/Forest3").GetComponent<Button>();
        Forest4 = GameObject.Find("Main Camera/Canvas/Forest4").GetComponent<Button>();
        Mist1 = GameObject.Find("Main Camera/Canvas/Mist1").GetComponent<Button>();
        Mist2 = GameObject.Find("Main Camera/Canvas/Mist2").GetComponent<Button>();
        Mist3 = GameObject.Find("Main Camera/Canvas/Mist3").GetComponent<Button>();
        Swamp1 = GameObject.Find("Main Camera/Canvas/Swamp1").GetComponent<Button>();
        Swamp2 = GameObject.Find("Main Camera/Canvas/Swamp2").GetComponent<Button>();
        Swamp3 = GameObject.Find("Main Camera/Canvas/Swamp3").GetComponent<Button>();
        Volcano1 = GameObject.Find("Main Camera/Canvas/Volcano1").GetComponent<Button>();
        Volcano2 = GameObject.Find("Main Camera/Canvas/Volcano2").GetComponent<Button>();
        Volcano3 = GameObject.Find("Main Camera/Canvas/Volcano3").GetComponent<Button>();
        Boss1 = GameObject.Find("Main Camera/Canvas/Boss1").GetComponent<Button>();

        changeColorToWhite(Safe1);
        changeColorToWhite(Safe2);
        changeColorToWhite(Forest1);
        changeColorToWhite(Forest2);
        changeColorToWhite(Forest3);
        changeColorToWhite(Forest4);
        changeColorToWhite(Mist1);
        changeColorToWhite(Mist2);
        changeColorToWhite(Mist3);
        changeColorToWhite(Swamp1);
        changeColorToWhite(Swamp2);
        changeColorToWhite(Swamp3);
        changeColorToWhite(Volcano1);
        changeColorToWhite(Volcano2);
        changeColorToWhite(Volcano3);
        changeColorToWhite(Boss1);

        string currentSceneArea = PlayerPrefs.GetString("areaName");
        int currentSceneLevel = PlayerPrefs.GetInt("areaLevel");

        switch(currentSceneArea){
            case "start":
                changeColorToYellow(Forest1);
                changeColorToYellow(Safe1);
                break;
            case "safe":
                if (currentSceneLevel == 1){
                    changeColorToYellow(Safe2);
                    changeColorToYellow(Mist1);

                }
                else if (currentSceneLevel == 2){
                    changeColorToYellow(Volcano1);
                    changeColorToYellow(Swamp1);
                    changeColorToYellow(Boss1);

                }
                break;
            case "forest":
                if (currentSceneLevel == 1){
                    changeColorToYellow(Forest2);
                    changeColorToYellow(Forest4);
                }
                else if (currentSceneLevel == 2){
                    changeColorToYellow(Forest3);

                }
                else if (currentSceneLevel == 3){
                    changeColorToYellow(Safe2);
                    changeColorToYellow(Volcano1);

                }
                else if (currentSceneLevel == 4){
                    changeColorToYellow(Safe2);
                }
                break;
            case "mist":
                if (currentSceneLevel == 1){
                    changeColorToYellow(Mist2);
                    changeColorToYellow(Mist3);

                }
                else if (currentSceneLevel == 2){
                    changeColorToYellow(Mist3);

                }
                else if (currentSceneLevel == 3){
                    changeColorToYellow(Swamp1);
                    changeColorToYellow(Boss1);

                }
                break;
            case "swamp":
                if (currentSceneLevel == 1){
                    changeColorToYellow(Swamp2);
                    changeColorToYellow(Swamp3);

                }
                else if (currentSceneLevel == 2){
                    changeColorToYellow(Swamp3);

                }
                else if (currentSceneLevel == 3){
                    changeColorToYellow(Boss1);

                }
                break;
            case "volcano":
                if (currentSceneLevel == 1){
                    changeColorToYellow(Volcano2);
                    changeColorToYellow(Volcano3);

                }
                else if (currentSceneLevel == 2){
                    changeColorToYellow(Volcano3);

                }
                else if (currentSceneLevel == 3){
                    changeColorToYellow(Boss1);

                }
                break;
            case "boss":
                if (currentSceneLevel == 1){
                    changeColorToYellow(Start1);
                }
                break;
        }
    }

    //     // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void OpenScene(string sceneArea) {

        int index = sceneArea.LastIndexOfAny("0123456789".ToCharArray());

        string areaName = sceneArea.Substring(0, index);
        int areaLevel = int.Parse(sceneArea.Substring(index));
        Debug.Log(areaName);
        Debug.Log(areaLevel);

        Button button = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();

        if (button != null) {
            ColorBlock colors = button.colors;
            if (colors.normalColor == Color.yellow) {
                PlayerPrefs.SetString("areaName", areaName);
                PlayerPrefs.SetInt("areaLevel", areaLevel);
                SceneManager.LoadScene("GridScene");
            }
        }
    }

    void changeColorToYellow(Button button) {
        ColorBlock color = button.GetComponent<Button>().colors;
        color.normalColor = Color.yellow;
        button.colors = color;
        // // Set the color back to its original color after wait time
        // float x = 1f;
        // float r = 255f;
        // float g = 0f;
        // float b = 0f;
        // // yield return new WaitForSeconds(x);
        // color.normalColor = new Color(r, g, b, 1);
        // button.colors = color;
    }
    
    void changeColorToWhite(Button button) {
        ColorBlock color = button.GetComponent<Button>().colors;
        color.normalColor = Color.white;
        button.colors = color;
        // Set the color back to its original color after wait time
        float x = 1f;
        float r = 255f;
        float g = 255f;
        float b = 255f;
        // yield return new WaitForSeconds(x);
        color.normalColor = new Color(r, g, b, 1);
        button.colors = color;
    }   
}

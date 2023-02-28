using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ViewMapHandler : MonoBehaviour
{
    //public GameObject MapScreen;
    //public CanvasGroup mapCanvasGroup; // This is the Canvas Group component of the Map Screen object

    public void onViewMapButtonClick()
    {
        PlayerPrefs.SetString("areaName", "start");
        PlayerPrefs.SetInt("areaLevel", 1);
        SceneManager.LoadScene("MapScene");

        //MapScreen.GetComponent<CanvasGroup>().alpha = 1f;
    
        /*if (mapCanvasGroup.alpha == 0f) {
            mapCanvasGroup.alpha = 1f;
            Debug.Log("View Map");
        }
        
        else {
            mapCanvasGroup.alpha =0f;
            Debug.Log("Hide Map");
        }*/
    }


    // Start is called before the first frame update
    void Start()
    {
        // Initialize mapScreen to be invisible
        //MapScreen.GetComponent<CanvasGroup>().alpha = 0f;

        //mapCanvasGroup = MapScreen.GetComponent<CanvasGroup>();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}

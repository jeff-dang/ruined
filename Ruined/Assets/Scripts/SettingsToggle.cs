using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsToggle : MonoBehaviour
{
    public GameObject SettingWindow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSettingsClick()
    {
        if (SettingWindow.activeSelf)
        {
            SettingWindow.SetActive(false);
        }
        else
        {
            SettingWindow.SetActive(true);
        }
        
    }
}

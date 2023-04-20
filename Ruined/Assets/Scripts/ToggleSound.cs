using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSound : MonoBehaviour
{
    private Image i;
    // Start is called before the first frame update
    void Start()
    {
        i = this.gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnToggleButtonClick()
    {
        if (SoundManager.isMute)
        {
            SoundManager.isMute = false;
            Debug.Log(SoundManager.isMute);
            changeColorToRed(i);
        }
        else
        {
            SoundManager.isMute = true;
            changeColorToGreen(i);
        }
    }

    void changeColorToRed(Image image)
    {
        Color color = image.GetComponent<Image>().color;
        image.color = Color.red;
        
    }

    void changeColorToGreen(Image image)
    {
        Color color = image.GetComponent<Image>().color;
        image.color = Color.green;
        
    }
}

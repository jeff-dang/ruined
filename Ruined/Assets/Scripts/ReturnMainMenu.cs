using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource menuClickSource;

    public void onViewMainButtonClick()
    {
        if (!SoundManager.isMute)
        {
            menuClickSource.Play();
        }
        StartCoroutine(waitForSound(menuClickSource));

    }

    IEnumerator waitForSound(AudioSource menuClickSource)
    {
        //Wait Until Sound has finished playing
        while (menuClickSource.isPlaying)
        {
            yield return null;
        }

        SceneManager.LoadScene("UserInterfaceScene");
    }

    void Start()
    {
        menuClickSource = GetComponent<AudioSource>();
        if (SoundManager.isMute)
        {
            this.gameObject.GetComponent<AudioSource>().enabled = false;
        }
        
    }

    public void onMainMenuClick()
    {
        SceneManager.LoadScene("UserInterfaceScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

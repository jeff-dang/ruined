using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class ButtonHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public string[] PreviousLevels;
    public string[] AccesibleLevels;
    public string LevelName;
    public string Area;
    private AudioSource menuClickSource;

    private Button b;

    void Start()
    {
        menuClickSource = GetComponent<AudioSource>();
        Debug.Log(MapManager.CurrentLevel);
        b = this.gameObject.GetComponent<Button>();
        if (PreviousLevels.Contains(MapManager.CurrentLevel)) {
            changeIconToDestination(b);
            b.onClick.AddListener(delegate () {
                if (!SoundManager.isMute)
                {
                    menuClickSource.Play();
                }
                StartCoroutine(waitForSound(menuClickSource));               
            });
        }

        if (MapManager.CheckIfCompleted(LevelName))
        {
            changeIconToCompleted(b);
        }
        
    }

    IEnumerator waitForSound(AudioSource menuClickSource)
    {
        //Wait Until Sound has finished playing
        while (menuClickSource.isPlaying)
        {
            yield return null;
        }

        //Auidio has finished playing
        MapManager.CurrentLevel = LevelName;
        MapManager.CurrentArea = Area;
        if (MapManager.CurrentLevel == "Safe1" || MapManager.CurrentLevel == "Safe2" || MapManager.CurrentLevel == "Safe3" || MapManager.CurrentLevel == "Safe4")
        {

            SceneManager.LoadScene("SafeScene");
        }
        else
        {
            SceneManager.LoadScene("GridScene");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void changeColorToYellow(Button button)
    {
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

    void changeIconToDestination(Button button)
    {
        Sprite icon = Resources.Load<Sprite>("destination_icon");
        button.image.sprite = icon;
    }

    void changeIconToCompleted(Button button)
    {
        Sprite icon = Resources.Load<Sprite>("completed_icon");
        button.image.sprite = icon;
    }
}

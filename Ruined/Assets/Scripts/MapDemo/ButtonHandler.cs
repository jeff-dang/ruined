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

    private Button b;

    void Start()
    {
        Debug.Log(MapManager.CurrentLevel);
        b = this.gameObject.GetComponent<Button>();
        if (PreviousLevels.Contains(MapManager.CurrentLevel)) {
            changeIconToDestination(b);
            b.onClick.AddListener(delegate () {
                MapManager.CurrentLevel = LevelName;
                MapManager.CurrentArea = Area;
                if (MapManager.CurrentLevel == "Safe1" || MapManager.CurrentLevel == "Safe2" || MapManager.CurrentLevel == "Safe3")
                {
                    
                    SceneManager.LoadScene("SafeScene");
                }
                else
                {
                    SceneManager.LoadScene("GridScene");
                }
                
            });
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

}

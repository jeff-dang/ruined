using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public int HealAmount = 5;
    public GameObject HUD;

    public void OnHealPlayerButton()
    {
        Debug.Log(MapManager.currentHP);
        MapManager.currentHP += HealAmount;
        if (MapManager.currentHP > MapManager.maxHP)
        {
            MapManager.currentHP = MapManager.maxHP;
        }
        SafeHUD script = HUD.GetComponent<SafeHUD>();
        script.SetHP(MapManager.currentHP);
        StartCoroutine(SceneChange());
        //SafeHUD.SetHP(MapManager.currentHP + HealAmount);
    }

    IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("MapDemoScene");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

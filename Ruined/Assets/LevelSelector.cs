using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //     // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void OpenScene(string scene) {
        Debug.Log("TEST 1");
        if(scene == "forest"){
            Debug.Log("TEST forest");
            SceneManager.LoadScene("Level 1");
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        if(scene == "swamp"){
            Debug.Log("TEST swamp");
            SceneManager.LoadScene("Level 2");
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        if(scene == "volcano"){
            Debug.Log("TEST volcano");
            SceneManager.LoadScene("Level 3");
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        if(scene == "boss"){
            Debug.Log("TEST boss");
            SceneManager.LoadScene("Level 4");
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        if (scene.name == "Level 1")
        {
            // NextSceneScript.LevelName = "Level 1";
        }
        if (scene.name == "Level 2")
        {
            // NextSceneScript.LevelName = "Level 2";
        }
        if (scene.name == "Level 3")
        {
            // NextSceneScript.LevelName = "Level 3";
        }
        if (scene.name == "Level 4")
        {
            // NextSceneScript.LevelName = "Level 4";
        }
    }
}

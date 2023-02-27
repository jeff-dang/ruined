using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{

    public Button b0;
    public Button b1;
    public Button b2;
    public Button b3;
    public Button b4;
    public Button b5;
    public Button b6;
    public Button b7;
    public Button b8;

    public Button[] PLAYER_GRID;
    public int[] ENEMY_GRID; // x,y coordinates with all the possible locations

    public GameObject player;

    int playerLocation = 4;

    public void movePlayer(int tileIndex) {
        Transform transform = PLAYER_GRID[tileIndex].transform;
        // Debug.Log("Player's position BEFORE moving: " + player.transform.position);
        player.transform.position = transform.position;
        // Debug.Log("Player's position AFTER moving: " + player.transform.position);
        playerLocation = tileIndex;
    }

    // Shows where can enemy attack on the player's grid
    public void highlightAllEnemyAttackPositions(int[] buttonIndexes) {

    }

    // Shows where can a single enemy attack unit on the player's grid
    public void highlightSingleEnemyAttackPositions(int[] buttonIndexes) {
        for(int i = 0; i < buttonIndexes.Length; i++) {
            Button button = PLAYER_GRID[buttonIndexes[i]];
            changeColorToRed(button);
        }
    }

    // Resets the player's grid after player closes the enemy attack locations
    public void defaultGridColor() {
        for(int i = 0; i < PLAYER_GRID.Length; i++) {
            Button button = PLAYER_GRID[i];
            changeColorToWhite(button);
        }
    }

    public void getPossibleLocations() {
        
    }

    void changeColorToRed(Button button) {
        ColorBlock color = button.GetComponent<Button>().colors;
        color.normalColor = Color.red;
        button.colors = color;
        // Set the color back to its original color after wait time
        float x = 1f;
        float r = 255f;
        float g = 0f;
        float b = 0f;
        // yield return new WaitForSeconds(x);
        color.normalColor = new Color(r, g, b, 1);
        button.colors = color;
    }

    void changeColorToWhite(Button button) {
        ColorBlock color = button.GetComponent<Button>().colors;
        color.normalColor = Color.red;
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

    // Start is called before the first frame update
    void Start()
    {
        PLAYER_GRID = new Button[] {b0, b1, b2, b3, b4, b5, b6, b7, b8};
        ENEMY_GRID = new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0};
        // player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

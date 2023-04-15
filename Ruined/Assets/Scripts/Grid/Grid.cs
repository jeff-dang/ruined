using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Grid : MonoBehaviour
{

    Button b0;
    Button b1;
    Button b2;
    Button b3;
    Button b4;
    Button b5;
    Button b6;
    Button b7;
    Button b8;

    public static Button[] PLAYER_GRID;
    int[] ENEMY_GRID; // x,y coordinates with all the possible locations

    //public AudioClip RunningClip;
    GameObject player;
    CanvasGroup staticMap;
    Rigidbody2D playerRigidBody;
    Animator PlayerAnimator;
    AudioSource audioSource;

    bool moving = false;
    Transform destination;
    int playerLocation = 4;
    string DirectionString;

    public static Grid Instance;

    public void movePlayer(int tileIndex) {
        if (BattleSystem.Instance.hasMoved == false)
        {
            BattleSystem.Instance.OnMoveButton(tileIndex);
            destination = PLAYER_GRID[tileIndex].transform;
            if (playerLocation == tileIndex + 2)
            {
                DirectionString = "TR";
            }
            else if (playerLocation == tileIndex + 4)
            {
                player.transform.Rotate(new Vector3(0, -180));
                DirectionString = "TL";
            }
            else if (playerLocation + 4 == tileIndex)
            {
                DirectionString = "BR";
            }
            else if (playerLocation + 2 == tileIndex)
            {
                player.transform.Rotate(new Vector3(0, -180));
                DirectionString = "BL";
            }
            else if (playerLocation + 1 == tileIndex)
            {
                DirectionString = "R";
            }
            else if (playerLocation - 1 == tileIndex)
            {
                player.transform.Rotate(new Vector3(0, -180));
                DirectionString = "L";
            }
            else if (playerLocation - 3 == tileIndex)
            {
                DirectionString = "T";
            }
            else
            {
                DirectionString = "B";
            }

            Vector3 Direction = new Vector3();
            Direction = destination.position - player.transform.position;
            Direction = Direction.normalized;
            playerRigidBody.velocity = new Vector2(Direction.x, Direction.y);
            moving = true;
            PlayerAnimator.SetBool("moving", true);
            audioSource.Play();
            //Debug.Log(Direction);
            // Debug.Log("Player's position BEFORE moving: " + player.transform.position);
            //player.transform.position = transform.position;
            // Debug.Log("Player's position AFTER moving: " + player.transform.position);
            playerLocation = tileIndex;
        }
        else
        {
            BattleSystem.Instance.dialogueText.text = "You may only move once per turn...";
        }
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

    void loadBackgroundImage(string element) {
        Image image = GameObject.Find("Background").GetComponent<Image>();
        if(element == "Forest") {
            Sprite backgroundImage = Resources.Load<Sprite>("Forest");
            image.sprite = backgroundImage;
        } else if (element == "Mist") {
            Sprite backgroundImage = Resources.Load<Sprite>("Toxic Mist");
            image.sprite = backgroundImage;
        } else if(element == "Volcano") {
            Sprite backgroundImage = Resources.Load<Sprite>("Volcano");
            image.sprite = backgroundImage;
        } else if(element == "Swamp") {
            Sprite backgroundImage = Resources.Load<Sprite>("Swamp");
            image.sprite = backgroundImage;
        }
    }

    public void closeStaticMap() {
        staticMap.alpha = 0;
        staticMap.interactable = false;
        staticMap.blocksRaycasts = false;
    }

    public void openStaticMap() {
        staticMap.alpha = 1;
        staticMap.interactable = true;
        staticMap.blocksRaycasts = true;
    }

    public void goToMainMenu() {
        SceneManager.LoadScene("UserInterfaceScene");
    }

    public void goToMap() {
        SceneManager.LoadScene("MapScene");
    }

    bool checkDestinationReached(Vector3 playerLoc, Vector3 destLoc)
    {
        if (DirectionString.Equals("R"))
        {
            //Debug.Log(1);
            return playerLoc.x >= destLoc.x;
        }
        else if (DirectionString.Equals("L"))
        {
            if (playerLoc.x <= destLoc.x)
                player.transform.Rotate(new Vector3(0, -180));
            //Debug.Log(2);
            return playerLoc.x <= destLoc.x;
        }
        else if (DirectionString.Equals("T"))
        {
            //Debug.Log(3);
            return playerLoc.y >= destLoc.y;
        }
        else if (DirectionString.Equals("B"))
        {
            //Debug.Log(4);
            return playerLoc.y <= destLoc.y;
        }
        else if (DirectionString.Equals("TR"))
        {
            //Debug.Log(5);
            return playerLoc.x >= destLoc.x || playerLoc.y >= destLoc.y;
        }
        else if (DirectionString.Equals("TL"))
        {
            if (playerLoc.x <= destLoc.x || playerLoc.y >= destLoc.y)
                player.transform.Rotate(new Vector3(0, -180));
            //Debug.Log(6);
            return playerLoc.x <= destLoc.x || playerLoc.y >= destLoc.y;
        }
        else if (DirectionString.Equals("BR"))
        {
            //Debug.Log(7);
            return playerLoc.x >= destLoc.x || playerLoc.y <= destLoc.y;
        }
        else
        {
            if (playerLoc.x <= destLoc.x || playerLoc.y <= destLoc.y)
                player.transform.Rotate(new Vector3(0, -180));
            //Debug.Log(8);
            return playerLoc.x <= destLoc.x || playerLoc.y <= destLoc.y;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        b0 = GameObject.Find("PlayerGrid/Button").GetComponent<Button>();
        b1 = GameObject.Find("PlayerGrid/Button (1)").GetComponent<Button>();
        b2 = GameObject.Find("PlayerGrid/Button (2)").GetComponent<Button>();
        b3 = GameObject.Find("PlayerGrid/Button (3)").GetComponent<Button>();
        b4 = GameObject.Find("PlayerGrid/Button (4)").GetComponent<Button>();
        b5 = GameObject.Find("PlayerGrid/Button (5)").GetComponent<Button>();
        b6 = GameObject.Find("PlayerGrid/Button (6)").GetComponent<Button>();
        b7 = GameObject.Find("PlayerGrid/Button (7)").GetComponent<Button>();
        b8 = GameObject.Find("PlayerGrid/Button (8)").GetComponent<Button>();
        player = GameObject.Find("Player");
        staticMap = GameObject.Find("MenuPeak").GetComponent<CanvasGroup>();
        playerRigidBody = player.GetComponent<Rigidbody2D>();
        PlayerAnimator = player.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        PLAYER_GRID = new Button[] {b0, b1, b2, b3, b4, b5, b6, b7, b8};
        ENEMY_GRID = new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0};
        // Set background image dynamically
        string currentArea = MapManager.CurrentArea;
        Debug.Log("Current Area is: " + currentArea);
        loadBackgroundImage(currentArea);
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            if (checkDestinationReached(player.transform.position, destination.position))
            {
                //Debug.Log("STOOOOOP");
                moving = false;
                PlayerAnimator.SetBool("moving", false);
                audioSource.Stop();
                playerRigidBody.velocity = new Vector2(0, 0);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class GenerateEnemy : MonoBehaviour
{

    public Sprite BatSprite;
    public AnimatorController BatController;
    public Sprite GoblinSprite;
    public AnimatorController GoblinController;
    public Sprite SkeletonSprite;
    public AnimatorController SkeletonController;
    public Sprite BossSprite;
    public AnimatorController BossController;
    public string levelName;
    public Button b0;
    public Button b1;
    public Button b2;
    public Button b3;
    public Button b4;
    public Button b5;
    public Button b6;
    public Button b7;
    public Button b8;
    // Start is called before the first frame update
    void Start()
    {
        levelName = MapManager.CurrentLevel;
        HashSet<int> useLoc = new HashSet<int>();
        Dictionary<int, Button> buttonMapping = new Dictionary<int, Button>();
        List<EnemyData> enemyDataList = EnemyDataManager.getEnemyData(levelName);
        buttonMapping.Add(0, b0);
        buttonMapping.Add(1, b1);
        buttonMapping.Add(2, b2);
        buttonMapping.Add(3, b3);
        buttonMapping.Add(4, b4);
        buttonMapping.Add(5, b5);
        buttonMapping.Add(6, b6);
        buttonMapping.Add(7, b7);
        buttonMapping.Add(8, b8);

        for (int i = 0; i < enemyDataList.Count; i++)
        {
            GameObject EnemyTest = new GameObject(enemyDataList[i].Name);
            EnemyTest.transform.localScale = new Vector3(2, 2, 1);
            EnemyTest.transform.Rotate(new Vector3(0, -180));
            SpriteRenderer sc = EnemyTest.AddComponent<SpriteRenderer>() as SpriteRenderer;
            Animator animator = EnemyTest.AddComponent<Animator>() as Animator;
            if (enemyDataList[i].Name.Contains("Bat"))
            {
                animator.runtimeAnimatorController = BatController;
                sc.sprite = BatSprite;
            }else if (enemyDataList[i].Name.Contains("Goblin"))
            {
                animator.runtimeAnimatorController = GoblinController;
                sc.sprite = GoblinSprite;
            }else if (enemyDataList[i].Name.Contains("Skeleton"))
            {
                animator.runtimeAnimatorController = SkeletonController;
                sc.sprite = SkeletonSprite;
            }else
            {
                animator.runtimeAnimatorController = BossController;
                sc.sprite = BossSprite;
            }
            Instantiate(EnemyTest, gameObject.transform);
            //int x, y;

            //int locIndex = Random.Range(1, 9);
            //while (useLoc.Contains(locIndex))
            //{
            //    locIndex = Random.Range(1, 9);
            //}

            //int[] loc = new int[] { possibleLocations[locIndex-1, 0], possibleLocations[locIndex - 1, 1] };

            EnemyTest.transform.position = new Vector3(buttonMapping[enemyDataList[i].location].transform.position.x, buttonMapping[enemyDataList[i].location].transform.position.y, 0.40f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
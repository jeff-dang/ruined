using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemy : MonoBehaviour
{

    public Sprite img;
    public int numEnemies;
    public string levelName;
    private int[ , ] possibleLocations = { { 1, 2 }, { 2, 2 }, { 3, 2 }, { 1, 3 }, { 2, 3 }, { 3, 3 }, { 1, 4 }, { 2, 4 }, { 3, 4 } };
    // Start is called before the first frame update
    void Start()
    {
        HashSet<int> useLoc = new HashSet<int>();
        List<EnemyData> enemyDataList = EnemyDataManager.getEnemyData(levelName);

        for (int i = 0; i < enemyDataList.Count; i++)
        {
            GameObject EnemyTest = new GameObject(enemyDataList[i].Name);
            SpriteRenderer sc = EnemyTest.AddComponent<SpriteRenderer>() as SpriteRenderer;
            sc.sprite = img;

            //int locIndex = Random.Range(1, 9);
            //while (useLoc.Contains(locIndex))
            //{
            //    locIndex = Random.Range(1, 9);
            //}

            //int[] loc = new int[] { possibleLocations[locIndex-1, 0], possibleLocations[locIndex - 1, 1] };

            EnemyTest.transform.position = new Vector3(enemyDataList[i].xCord, enemyDataList[i].yCord, -0.24f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

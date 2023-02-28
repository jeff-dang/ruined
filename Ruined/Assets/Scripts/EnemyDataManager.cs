using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class EnemyDataManager
{
    private static string directory = Application.dataPath + "/StreamingAssets";
    private static string fileName = "EnemyData.json";

    public static List<EnemyData> getEnemyData(string identifier)
    {
        List<EnemyData> res = new List<EnemyData>();
        int len = 0;
        string jsonText = File.ReadAllText(directory + "/" + fileName);


        //Debug.Log(jsonText);
        EnemyDataJSON enemyDataJSON = JsonUtility.FromJson<EnemyDataJSON>(jsonText);
        //Debug.Log(enemyDataJSON.data.ToString());
        len = enemyDataJSON.data.Count;

        for (int i = 0; i < len; i++)
        {
            if (string.Equals(enemyDataJSON.data[i].LevelIdentifier, identifier))
            {
                res.Add(enemyDataJSON.data[i]);
            }
        }


        return res;
    }


}
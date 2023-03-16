using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;
using static PlayerDeck;
using static BattleSystem;


public static class RewardButtonExtension
{
    public static void AddRewardEventListener<T>(this Button button, T param, int[] attackRange, int damage, GameObject card, Card newCard)
    {
        button.onClick.AddListener(delegate () {
            //OnClick(param);
            PlayerDeck.Instance.addCard(newCard);
        });
        button.onClick.AddListener(delegate () {
            button.interactable = false;
            RewardLoader.CheckMapMove();
        });
        
    }
}

public class RewardLoader : MonoBehaviour
{
    //[Serializable]
    //public struct Card  //change name to spell later
    //{
    //    public string Name;
    //    public int[] Pattern;
    //    public int Damage;
    //    public Sprite Icon;
    //}

    [SerializeField] GameObject playerDeck;
    public Card[] rewardPool;
    public Card[] rewardDeck;
    public GameObject BattleSystemObj;
    public static int numSpellsSelected = 0;


    void Start()
    {
        
        int[] rewardPoolChoice = generateRewards(rewardPool.Length);
        Card[] rewardDeck = new Card[rewardPoolChoice.Length];
        for (int i = 0; i < rewardPoolChoice.Length; i++)
        {
            rewardDeck[i] = rewardPool[rewardPoolChoice[i]];
        }
        GameObject buttonReward = transform.GetChild(0).gameObject;
        GameObject g;


        int N = rewardDeck.Length;

        for (int i = 0; i < N; i++)
        {
            g = Instantiate(buttonReward, transform);
            Debug.Log(g.transform.GetChild(0).gameObject.name);
            g.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = rewardDeck[i].Name;
            g.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = rewardDeck[i].Icon;
            g.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = rewardDeck[i].Damage.ToString();
            int K = rewardDeck[i].Pattern.Length;
            for (int j = 0; j < K; j++)
            {
                int pattern_square = rewardDeck[i].Pattern[j]; //gives u square
                g.transform.GetChild(pattern_square + 3).gameObject.GetComponent<Image>().color = Color.red;
            }
            //g.transform.GetChild(2).GetComponent<Text>().text = rewardDeck[i].Pattern;

            /*g.GetComponent <Button> ().onClick.AddListener (delegate() {
       ItemClicked (i);
   });*/
            g.GetComponent<Button>().AddRewardEventListener(i, rewardDeck[i].Pattern, rewardDeck[i].Damage, g, rewardDeck[i]);
        }

        Destroy(buttonReward);
    }



    // Update is called once per frame
    void Update()
    {

    }

    int[] generateRewards(int RewardPoolLength)
    {
        int[] rewardPoolint = new int[RewardPoolLength];
        for (int i = 0; i < rewardPoolint.Length; i++)
        {
            int RandomNumber = UnityEngine.Random.Range(0, RewardPoolLength);
            rewardPoolint[i] = RandomNumber;
        }
        return rewardPoolint;
    }

    public static void CheckMapMove()
    {
        numSpellsSelected += 1;
        if (numSpellsSelected > 1)
        {
            SceneManager.LoadScene("MapScene");
        }
    }
}
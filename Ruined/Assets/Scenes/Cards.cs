using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public static class ButtonExtension
{
    public static void AddEventListener<T>(this Button button, T param, Action<T> OnClick)
    {
        button.onClick.AddListener(delegate () {
            OnClick(param);
        });
    }
}

public class Cards : MonoBehaviour
{
    [Serializable]
    public struct Card  //change name to spell later
    {
        public string Name;
        public int[] Pattern;
        public int Damage;
        //public Sprite Icon;
    }

    //map card here
   
    
   
    


    
    //[SerializeField] Card[] cardDeck;
    [SerializeField] int[] cardDeck;


    void Start()
    {
        Card card1;
        Card card2;
        Card card3;
        card1.Name = "Line Attack";
        card1.Pattern = new int[]{ 1,4,7 };
        card1.Damage = 3;

        card2.Name = "Whole";
        card2.Pattern = new int[] { 0,1,2,3, 4,5,6,7,8 };
        card2.Damage = 2;

        card3.Name = "Horizontal Attack";
        card3.Pattern = new int[] { 3, 4, 5 };
        card3.Damage = 3;

        Card[] availableCards = { card1, card2, card3 };
        GameObject buttonTemplate = transform.GetChild(0).gameObject;
        GameObject buttonTemplate1 = transform.GetChild(1).gameObject;
        GameObject buttonTemplate2 = transform.GetChild(2).gameObject;
        GameObject g;


        

        int N = cardDeck.Length;

        for (int i = 0; i < N; i++)
        {
            
            if (cardDeck[i] == 1)
            {
                g = Instantiate(buttonTemplate, transform);
                g.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = card1.Name;
                g.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = card1.Damage.ToString();
                int K = card1.Pattern.Length;
                for (int j=0;j < K; j++)
                {
                    int pattern_square = card1.Pattern[j];
                    g.transform.GetChild(pattern_square + 3).gameObject.GetComponent<Image>().color = Color.red;
                }
            }
            else if (cardDeck[i] == 2)
            {
                g = Instantiate(buttonTemplate1, transform);
                g.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = card2.Name;
                g.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = card2.Damage.ToString();
                int K = card2.Pattern.Length;
                for (int j = 0; j < K; j++)
                {
                    int pattern_square = card2.Pattern[j];
                    g.transform.GetChild(pattern_square + 3).gameObject.GetComponent<Image>().color = Color.red;
                }
            }
            else
            {
                g = Instantiate(buttonTemplate2, transform);
                g.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = card3.Name;
                g.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = card3.Damage.ToString();
                int K = card3.Pattern.Length;
                for (int j = 0; j < K; j++)
                {
                    int pattern_square = card3.Pattern[j];
                    g.transform.GetChild(pattern_square + 3).gameObject.GetComponent<Image>().color = Color.red;
                }
            }
            //g.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = cardDeck[i].Name;
            ////g.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = cardDeck[i].Icon;
            //g.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = cardDeck[i].Damage.ToString();
            //int K = cardDeck[i].Pattern.Length;
            //for (int j = 0; j < K; j++)
            //{
            //    int pattern_square = cardDeck[i].Pattern[j]; //gives u square
            //    g.transform.GetChild(pattern_square + 3).gameObject.GetComponent<Image>().color = Color.red;
            //}
            //g.transform.GetChild(2).GetComponent<Text>().text = cardDeck[i].Pattern;
            //Debug.Log(g.transform.GetChild(0).gameObject.name);
            //g.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = cardDeck[i].Name;
            ////g.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = cardDeck[i].Icon;
            //g.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = cardDeck[i].Damage.ToString();
            //int K = cardDeck[i].Pattern.Length;
            //for (int j = 0;j < K; j++)
            //{
            //    int pattern_square = cardDeck[i].Pattern[j]; //gives u square
            //    g.transform.GetChild(pattern_square + 3).gameObject.GetComponent<Image>().color = Color.red;
            //        }
            //g.transform.GetChild(2).GetComponent<Text>().text = cardDeck[i].Pattern;

            /*g.GetComponent <Button> ().onClick.AddListener (delegate() {
       ItemClicked (i);
   });*/
            g.GetComponent<Button>().AddEventListener(i, ItemClicked);
        }

        Destroy(buttonTemplate);
        Destroy(buttonTemplate1);
        Destroy(buttonTemplate2);
    }

    void ItemClicked(int itemIndex)
    {
        //Debug.Log("------------item " + itemIndex + " clicked---------------");
        //Debug.Log("name " + cardDeck[itemIndex].Name);
        //Debug.Log("desc " + cardDeck[itemIndex].Damage.ToString());
    }

    //public void cardAttack(string s)
    //{
    //    GameObject BattleSystemObj = GameObject.Find("BattleSystem");
    //    BattleSystemObj.GetComponent<BattleSystem>().OnAttackButton();
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}

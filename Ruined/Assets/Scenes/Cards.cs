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
        public Sprite Icon;
    }

    [SerializeField] Card[] cardDeck;

    void Start()
    {
        GameObject buttonTemplate = transform.GetChild(0).gameObject;
        GameObject g;


        int N = cardDeck.Length;

        for (int i = 0; i < N; i++)
        {
            g = Instantiate(buttonTemplate, transform);
            Debug.Log(g.transform.GetChild(0).gameObject.name);
            g.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = cardDeck[i].Name;
            g.transform.GetChild(1).gameObject.GetComponent<Image>().sprite = cardDeck[i].Icon;
            g.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = cardDeck[i].Damage.ToString();
            int K = cardDeck[i].Pattern.Length;
            for (int j = 0;j < K; j++)
            {
                int pattern_square = cardDeck[i].Pattern[j]; //gives u square
                g.transform.GetChild(pattern_square + 3).gameObject.GetComponent<Image>().color = Color.red;
                    }
            //g.transform.GetChild(2).GetComponent<Text>().text = cardDeck[i].Pattern;

            /*g.GetComponent <Button> ().onClick.AddListener (delegate() {
       ItemClicked (i);
   });*/
            g.GetComponent<Button>().AddEventListener(i, ItemClicked);
        }

        Destroy(buttonTemplate);
    }

    void ItemClicked(int itemIndex)
    {
        Debug.Log("------------item " + itemIndex + " clicked---------------");
        Debug.Log("name " + cardDeck[itemIndex].Name);
        Debug.Log("desc " + cardDeck[itemIndex].Damage.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

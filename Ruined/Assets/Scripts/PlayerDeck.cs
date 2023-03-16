using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerDeck : MonoBehaviour
{
    [Serializable]
    public struct Card  //change name to spell later
    {
        public string Name;
        public int[] Pattern;
        public int Damage;
        public Sprite Icon;
    }

    public static PlayerDeck Instance;
    public string CurrentLevel;

    [SerializeField] public Card[] cardDeck;

    public Card[] getCardDeck()
    {
        return cardDeck;
    }

    public void addCard(Card newCard)
    {
        Array.Resize<Card>(ref cardDeck, cardDeck.Length + 1);
        cardDeck[cardDeck.Length-1] = newCard;
    }

    public void removeCard(Card newCard)
    {
        Array.Resize<Card>(ref cardDeck, cardDeck.Length + 1);
        cardDeck[cardDeck.Length] = newCard;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
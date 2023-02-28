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

    [SerializeField] Card[] cardDeck;
}
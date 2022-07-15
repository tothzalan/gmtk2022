using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private string _name;
    // CARD TYPES
    // 0 == Attack
    // 1 == Balanced
    // 2 == Defense
    private int _cardType;
    private int _health;
    private int _damage;

    public Card(string name, int cardType)
    {
        _name = name;
        _cardType = cardType;
    }
}

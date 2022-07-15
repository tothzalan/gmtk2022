using System.Collections;
using System.Collections.Generic;
using Model;
using UnityEngine;

public class Card : MonoBehaviour
{
    private string _name;
    private CardType _cardType;
    private int _health;
    private int _damage;

    public Card(string name, CardType cardType)
    {
        _name = name;
        _cardType = cardType;
    }
    
    
}

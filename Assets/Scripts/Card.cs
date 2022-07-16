using System.Collections;
using System.Collections.Generic;
using Model;
using UnityEngine;
using System;

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
        GenerateCard(cardType);
    }

    private void GenerateCard(CardType cardType)
    {
        
        if (cardType == CardType.Defense)
        {
            DefenseCard();
        }else if (cardType == CardType.Offense)
        {
            OffenseCard();
        }else if (cardType == CardType.Balanced)
        {
            BalancedCard();
        }
    }

    private void OffenseCard()
    {
        System.Random rnd = new System.Random();
        _health = rnd.Next(1, 5);
        _damage = rnd.Next(7, 11);
        //HP: 1-5 DMG:7-11
    }

    private void DefenseCard()
    {
        System.Random rnd = new System.Random();
        _health = rnd.Next(6, 10);
        _damage = rnd.Next(1, 4);
        //HP: 6-10 DMG:1-4
    }

    private void BalancedCard()
    {
        System.Random rnd = new System.Random();
        _health = rnd.Next(4, 7);
        _damage = rnd.Next(4, 7);
        //HP: 4-7 DMG: 4-7
    }

    private void OnMouseDown()
    {
    }
}

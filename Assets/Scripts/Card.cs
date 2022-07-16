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
    private System.Random _rnd = new System.Random();

    public Card(string name, CardType cardType)
    {
        
        _name = name;
        _cardType = cardType;
        GenerateCard(cardType);
    }

    private void GenerateCard(CardType cardType)
    {
        switch(cardType) {
            case CardType.Defense:
                DefenseCard();
                break;
            case CardType.Offense:
                OffenseCard();
                break;
            case CardType.Balanced:
                BalancedCard();
                break;
        }
    }

    private void OffenseCard()
    {
        _health = _rnd.Next(1, 5);
        _damage = _rnd.Next(7, 11);
        //HP: 1-5 DMG:7-11
    }

    private void DefenseCard()
    {
        _health = _rnd.Next(6, 10);
        _damage = _rnd.Next(1, 4);
        //HP: 6-10 DMG:1-4
    }

    private void BalancedCard()
    {
        _health = _rnd.Next(4, 7);
        _damage = _rnd.Next(4, 7);
        //HP: 4-7 DMG: 4-7
    }

    private void OnMouseDown()
    {
    }
}

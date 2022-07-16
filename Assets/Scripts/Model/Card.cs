using System.Collections;
using System.Collections.Generic;
using Model;
using System;

public class Card
{
    private string _name;
    private CardType _cardType;
    private int _health;
    private int _damage;

    public Card(string name, CardType cardType, int health, int damage)
    {
        _name = name;
        _cardType = cardType;
        _health = health;
        _damage = damage;
    }

    public override string ToString()
    {
        return $"{_name} {_cardType} {_health} {_damage}";
    }
}

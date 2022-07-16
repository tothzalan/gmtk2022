using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model;

public class CardFactory : MonoBehaviour
{
    [SerializeField]
    private TextAsset _cardAdjsFile;
    [SerializeField]
    private TextAsset _cardNameFile;
    [SerializeField]
    private bool _show;

    private System.Random _rnd = new System.Random();

    private List<Card> _cards;
    public List<Card> Cards { get { return _cards; } set { _cards = value; } }

    void Start()
    {
        if(_show) {
            _cards = new List<Card>();
            CardType[] types = new CardType[] { CardType.Defense, CardType.Offense, CardType.Balanced };
            foreach(CardType type in types) {
                string name = GenerateName();
                int health = GenerateHealth(type);
                int damage = GenerateDamage(type);
                _cards.Add(new Card(name, type, health, damage));
            }
            foreach(Card card in _cards) {
                Debug.Log(card.ToString());
            }
        }

    }

    void Update()
    {
        
    }



    private string GenerateName()
    {
        string[] adjs = _cardAdjsFile.text.Split(',');
        string[] name = _cardNameFile.text.Split(',');
        return $"{adjs[_rnd.Next(0, adjs.Length)]} {name[_rnd.Next(0, name.Length)]}";
    }

    private int GenerateHealth(CardType cardType)
    {
        switch(cardType) {
            case CardType.Defense:
                return _rnd.Next(6, 11);
            case CardType.Offense:
                return _rnd.Next(1, 6);
            case CardType.Balanced:
                return _rnd.Next(4, 8);
            default:
                return _rnd.Next(4, 8);
        }
    }

    private int GenerateDamage(CardType cardType)
    {
        switch(cardType) {
            case CardType.Defense:
                return _rnd.Next(1, 5);
            case CardType.Offense:
                return _rnd.Next(7, 11);
            case CardType.Balanced:
                return _rnd.Next(4, 8);
            default:
                return _rnd.Next(4, 8);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model;
using TMPro;

public class CardFactory : MonoBehaviour
{
    [SerializeField]
    private TextAsset _cardAdjsFile;
    [SerializeField]
    private TextAsset _cardNameFile;
    [SerializeField]
    private bool _show;


    public TextMeshProUGUI defenseName;
    public TextMeshProUGUI defenseHealth;
    public TextMeshProUGUI defenseAttack;
    
    public TextMeshProUGUI offenseName;
    public TextMeshProUGUI offenseHealth;
    public TextMeshProUGUI offenseAttack;
    
    public TextMeshProUGUI balanceName;
    public TextMeshProUGUI balanceHealth;
    public TextMeshProUGUI balanceAttack;

    private System.Random _rnd;

    private List<Card> _cards;
    public List<Card> Cards { get { return _cards; } set { _cards = value; } }

    void Start()
    {
        _rnd = new ();
        if(_show) {
            _cards = new List<Card>();
            CardType[] types = new CardType[] { CardType.Defense, CardType.Offense, CardType.Balanced };
            foreach(CardType type in types) {
                string name = GenerateName();
                int health = GenerateHealth(type);
                int damage = GenerateDamage(type);
                _cards.Add(new Card(name, type, health, damage));
            }
            SetDefenseCard(_cards[0]);
            SetOffenseCard(_cards[1]);
            SetBalanceCard(_cards[2]);
        }
    }

    private void SetDefenseCard(Card card)
    {
        defenseName.text = card.Name;
        defenseHealth.text = card.Health.ToString();
        defenseAttack.text = card.Damage.ToString();
    }
    
    private void SetOffenseCard(Card card)
    {
        offenseName.text = card.Name;
        offenseHealth.text = card.Health.ToString();
        offenseAttack.text = card.Damage.ToString();
    }
    
    private void SetBalanceCard(Card card)
    {
        balanceName.text = card.Name;
        balanceHealth.text = card.Health.ToString();
        balanceAttack.text = card.Damage.ToString();
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

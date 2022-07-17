using System.Threading;
using Hud;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class HudController : MonoBehaviour
{
    public bool StartWithCard = true;
    public AttributeController attributes;
    public PlayerMovement PlayerMovement;
    
    public DiceController dice;

    public TextMeshProUGUI noKeyText;
    
    public HealthHudControl healthImage;
    
    public TextMeshProUGUI yourTurnText;
    public TextMeshProUGUI enemyTurnText;

    public CardFactory CardSelection;

    public GameObject charImage;

    private TurnController _turnController;
    
    // Start is called before the first frame update
    void Start()
    {
        _turnController = gameObject.GetComponent<TurnController>();
        
        if (!StartWithCard)
        {
            StartGame();
        }
        else
        {
            CardSelection.gameObject.SetActive(true);
        }
    }

    


    // Update is called once per frame
    void Update()
    {
        healthImage.UpdateHealth(attributes.health);
        // TODO: Update health, Damage, key existence, move count
        if (Input.GetButtonDown("Submit") && !_turnController.FinalizedRoll && _turnController.PlayerTurn)
        {
            // Animation should end here
            _turnController.FinalizedRoll = true;
            HideTurnText();
            RollDice();
        }
    }

    public void FadeScreen()
    {
        
    }
    
    public void WriteNoKey()
    {
        noKeyText.gameObject.SetActive(true);
    }

    public void HideNoKey()
    {
        noKeyText.gameObject.SetActive(false);
    }

    public void HideTurnText()
    {
        yourTurnText.gameObject.SetActive(false);
        enemyTurnText.gameObject.SetActive(false);
    }

    public void BeginPlayerTurn()
    {
        // show Message that it is your turn
        // show dice and wait for input to roll dice
        yourTurnText.gameObject.SetActive(true);
        //dice.SetAnimatorEnabled(true);
        dice.gameObject.SetActive(true);
        _turnController.FinalizedRoll = false;
    }

    public void BeginEnemyTurn()
    {
        // rolls the dice automatically, tells the player that it is the enemy turn
        // let the dice roll for a moment
        enemyTurnText.gameObject.SetActive(true);
        dice.gameObject.SetActive(true);
        //dice.SetAnimatorEnabled(true);
        Thread.Sleep(500);
        RollDiceEnemy();
    }

    public void RollDice()
    {
        var value  = dice.RollDice();

        PlayerMovement.moveCount = value;
    }

    public void RollDiceEnemy()
    {
        var value  = dice.RollDice();

        _turnController.EnemyMovements.ForEach(x => x.moveCount = value);
    }
    
    public void StartGame(int index = 0)
    {
        if (!StartWithCard)
        {
            attributes.health = 5;
            attributes.hitDamage = 5;
        }
        else
        {
            // read cards
            attributes.CardPicked(CardSelection.Cards[index].Health, CardSelection.Cards[index].Damage);
        }
        charImage.SetActive(true);
        healthImage.gameObject.SetActive(true);
        CardSelection.gameObject.SetActive(false);
        BeginPlayerTurn();
    }
}

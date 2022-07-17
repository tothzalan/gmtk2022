using System.Collections;
using System.Collections.Generic;
using Hud;
using TMPro;
using TMPro.Examples;
using UnityEngine;
using UnityEngine.UIElements;

public class HudController : MonoBehaviour
{
    public AttributeController attributes;
    public PlayerMovement PlayerMovement;
    
    public TurnController TurnController;
    public DiceController dice;

    public TextMeshProUGUI noKeyText;
    
    public HealthHudControl healthImage;

    public TextMeshProUGUI yourTurnText;
    public TextMeshProUGUI enemyTurnText;

    public Image Dice;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthImage.UpdateHealth(attributes.health);
        // TODO: Update health, Damage, key existence, move count
        if (Input.GetButtonDown("Submit") && !TurnController.FinalizedRoll && TurnController.PlayerTurn)
        {
            // Animation should end here
            TurnController.FinalizedRoll = true;
            RollDice();
        }
    }

    public void FadeScreen()
    {
        
    }
    
    public void WriteNoKey()
    {
        noKeyText.enabled = true;
    }

    public void HideNoKey()
    {
        noKeyText.enabled = false;
    }

    public void HideTurnText()
    {
        yourTurnText.enabled = false;
        enemyTurnText.enabled = false;
    }

    public void BeginPlayerTurn()
    {
        // show Message that it is your turn
        // show dice and wait for input to roll dice
        yourTurnText.enabled = true;
    }

    public void BeginEnemyTurn()
    {
        // rolls the dice automatically, tells the player that it is the enemy turn
        // let the dice roll for a moment
        enemyTurnText.enabled = true;
        
        
    }

    public void RollDice()
    {
        var value  = dice.RollDice();
        
        
    }

    public void RollDiceEnemy()
    {
        
    }
}

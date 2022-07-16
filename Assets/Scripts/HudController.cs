using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudController : MonoBehaviour
{
    public TurnController TurnController;
    public DiceController dice;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // TODO: Update health, Damage, key existence, move count
        if (Input.GetButtonDown("Submit") && !TurnController.FinalizedRoll && TurnController.PlayerTurn)
        {
            // Animation should end here
            TurnController.FinalizedRoll = true;
            TurnController.PlayerMovement.moveCount = dice.RollDice();
        }
    }

    public void FadeScreen()
    {
        
    }
    
    public void WriteNoKey()
    {
        
    }

    public void HideAllMessages()
    {
        
    }

    public void BeginPlayerTurn()
    {
        // show Message that it is your turn
        // show dice and wait for input to roll dice
    }

    public void BeginEnemyTurn()
    {
        // rolls the dice automatically, tells the player that it is the enemy turn
        // let the dice roll for a moment
        
    }

    public void RollDice()
    {
        
    }

    public void RollDiceEnemy()
    {
        
    }
}

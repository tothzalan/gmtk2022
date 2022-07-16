using System.Collections;
using System.Collections.Generic;
using Enemy;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    public PlayerMovement PlayerMovement;
    public List<EnemyMovement> EnemyMovements;
    public bool PlayerTurn = true;
    public bool FinalizedRoll = false;
    public HudController Hud;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.moveCount == 0 && PlayerTurn)
        {
            // end of player turn
            PlayerTurn = false;
            
            BeginEnemyTurn();
        }
    }

    private void BeginPlayerTurn()
    {
        FinalizedRoll = false;
        Hud.BeginPlayerTurn();
    }

    private void BeginEnemyTurn()
    {
        Hud.BeginEnemyTurn();

        int value = Hud.dice.RollDice();
        
        EnemyMovements.ForEach(x => x.moveCount = value);
    }

    
}

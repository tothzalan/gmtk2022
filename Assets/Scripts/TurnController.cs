using System.Collections.Generic;
using System.Linq;
using Enemy;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    public PlayerMovement PlayerMovement;
    public List<EnemyMovement> EnemyMovements;
    public bool PlayerTurn = true;
    public bool FinalizedRoll = false;
    private HudController _hud;

    // Start is called before the first frame update
    void Start()
    {
        _hud = gameObject.GetComponent<HudController>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.moveCount == 0 && PlayerTurn && FinalizedRoll)
        {
            // end of player turn
            PlayerTurn = false;
            _hud.HideTurnText();
            if(EnemyMovements.Count == 0)
                BeginPlayerTurn();
            else
                BeginEnemyTurn();
        }
        else if (!PlayerTurn && (EnemyMovements.Count == 0 || EnemyMovements.All(x => x.moveCount == 0)))
        {
            // end of enemy turn

            PlayerTurn = true;
            _hud.HideTurnText();
            BeginPlayerTurn();
        }
    }

    private void BeginPlayerTurn()
    {
        FinalizedRoll = false;
        _hud.HideTurnText();
        _hud.BeginPlayerTurn();
    }

    private void BeginEnemyTurn()
    {
        _hud.HideTurnText();
        _hud.BeginEnemyTurn();

        int value = _hud.dice.RollDice();
        
        EnemyMovements.ForEach(x => x.moveCount = x.Attributes.IsDead() ? 0 : value);
    }

    
}

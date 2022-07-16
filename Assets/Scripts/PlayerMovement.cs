using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public int moveCount = 0;
    public Tilemap movementGrid;
    public Tilemap blockedGrid;
    public FightControl FightControl;

    private Vector2? movementDirection;

    private bool isButtonDown = false;
    // Update is called once per frame
    void Update()
    {
        // input gather
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");


        if (horizontalMovement != 0 && !isButtonDown)
        {
            movementDirection = new Vector2(horizontalMovement, 0);
            isButtonDown = true;
        }
        else if (verticalMovement != 0 && !isButtonDown)
        {
            movementDirection = new Vector2(0, verticalMovement);
            isButtonDown = true;
        }
            
        if (horizontalMovement == 0 && verticalMovement == 0)
            isButtonDown = false;
    }

    private void FixedUpdate()
    {
        if (movementDirection != null)
        {
            if(moveCount > 0)
                OnMove(movementDirection);
            movementDirection = null;
        }
    }

    private void OnMove(Vector2? direction)
    {
        if (CanMove(direction))
        {
            if (direction != null)
            {
                moveCount--;
                if (FightControl.IsEnemyAtDirection(direction))
                {
                    FightControl.OnMoved();
                }
                else
                {
                    transform.position += (Vector3)direction;
                
                    // trigger animation here on move
                
                    FightControl.OnMoved();    
                }
                
            }
        }
    }

    private bool CanMove(Vector2? direction)
    {
        if (direction != null)
        {
            Vector3Int gridPos = movementGrid.WorldToCell(transform.position + (Vector3)direction);

            return !blockedGrid.HasTile(gridPos) && movementGrid.HasTile(gridPos);
        }

        return false;
    }
}

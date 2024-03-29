using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public int moveCount = 0;
    public float moveSpeed = 5;
    public Tilemap movementGrid;
    public Tilemap blockedGrid;
    public FightControl fightControl;
    public GatheringController gatheringController;
    public LevelComplete completeLevel;
    public AudioClip walkSound;

    private Vector2? movementDirection;


    
    private bool _isMoving;

    private bool isButtonDown = false;
    // Update is called once per frame
    void Update()
    {
        // input gather
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");


        if (horizontalMovement != 0 && !isButtonDown)
        {
            var renderer = gameObject.GetComponent<SpriteRenderer>();
            if (horizontalMovement == -1)
            {
                renderer.flipX = true;
            }
            else
            {
                renderer.flipX = false;
            }
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
            if (moveCount > 0)
            {   
                OnMove(movementDirection);
            }
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
                if (fightControl.IsEnemyAtDirection(direction))
                {
                    fightControl.HitAgain();
                }
                else
                {
                    AudioSource.PlayClipAtPoint(walkSound, transform.position);
                    transform.position += (Vector3)direction;
                    // trigger animation here on move
                
                    fightControl.OnMove(); 
                    gatheringController.OnMove();
                    completeLevel.OnMove();
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public int moveCount = 0;
    public Tilemap movementGrid;
    public Tilemap blockedGrid;

    private Vector2? movementDirection;
    // Update is called once per frame
    void Update()
    {
        if (movementDirection == null)
            return; // limit movement to one at a time
        // input gather
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        if (horizontalMovement != 0)
            movementDirection = new Vector2(horizontalMovement, 0);
        else if (verticalMovement != 0)
            movementDirection = new Vector2(0, verticalMovement);
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
                transform.position += (Vector3)direction;
                moveCount--;
                
                // trigger animation here on move
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

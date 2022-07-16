using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = System.Random;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        public int moveCount;
        public FightControl fightControl;
        public Tilemap blockedGrid;
        public Tilemap movementGrid;

        private Random _random = new ();
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (moveCount == 0)
                return;

            if (_random.Next(2) == 0)
            {
                float horizontal;
                horizontal = _random.Next(2) == 0 ? 1 : 0;
                
                OnMove(new Vector2(horizontal, 0));
            }
            else
            {
                float vertical;
                vertical = _random.Next(2) == 0 ? 1 : 0;
                
                OnMove(new Vector2(vertical, 0));
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
                        fightControl.OnMove();
                    }
                    else
                    {
                        transform.position += (Vector3)direction;
                
                        // trigger animation here on move
                
                        fightControl.OnMove(); 
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
}

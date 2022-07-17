using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = System.Random;
using System.Collections;
using System.Threading;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        public int moveCount;
        public FightControl fightControl;
        public Tilemap blockedGrid;
        public Tilemap movementGrid;

        private Random _random;

        private AttributeController _attributeController;
        private Animator animator;

        public AttributeController Attributes => _attributeController;

        void Start()
        {
            _attributeController = gameObject.GetComponent<AttributeController>();
            _random = new Random();
            animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            if (moveCount == 0)
                return;

            if (_random.Next() > (int.MaxValue / 2))
            {
                float horizontal;
                horizontal = _random.Next(2) == 0 ? 1 : -1;
                
                OnMove(new Vector2(horizontal, 0));
            }
            else
            {
                float vertical;
                vertical = _random.Next(2) == 0 ? 1 : -1;
                
                OnMove(new Vector2(0, vertical));
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

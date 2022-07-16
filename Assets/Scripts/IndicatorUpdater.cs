using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Util;

public class IndicatorUpdater : MonoBehaviour
{
    public Tilemap wallGrid;

    public PlayerMovement movementControl;
    
    public Sprite arrow;
    public Sprite attack;
    public Sprite collect;

    private SpriteRenderer _renderer;
    
    // Start is called before the first frame update
    void Start()
    {
        _renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        UpdateIndicator(movementControl.moveCount != 0);
    }

    public void UpdateIndicator(bool hasMoreMoves)
    {
        if (!hasMoreMoves)
        {
            _renderer.sprite = null;
            return;
        }
        
        if (IsEnemyAroundPosition(transform.position))
        {
            _renderer.sprite = attack;
            return;
        }
        if (IsRewardAtPosition(transform.position))
        {
            _renderer.sprite = collect;
            return;
        }
        if (!wallGrid.HasTileAtPosition(transform.position))
        {
            _renderer.sprite = arrow;
            return;
        }
        _renderer.sprite = null;
    }
    
    public static bool IsRewardAtPosition(Vector2 location)
    {
        var rew = Physics2D.Raycast(location, new Vector2(0, -1), 0.2f);

        if (rew.collider != null && (rew.collider.gameObject.CompareTag("Key") ||
            rew.collider.gameObject.CompareTag("HealthPoint") ||
            rew.collider.gameObject.CompareTag("HealthPointDouble")))
            return true;

        return false;
    }

    public static bool IsEnemyAroundPosition(Vector2 location)
    {
        var down = Physics2D.Raycast(location, new Vector2(0, -1), 1);
        var up = Physics2D.Raycast(location, new Vector2(0, 1), 1);
        var left = Physics2D.Raycast(location, new Vector2(-1, 0), 1);
        var right = Physics2D.Raycast(location, new Vector2(1, 0), 1);

        if (down.collider != null && down.collider.gameObject.CompareTag("Enemy"))
            return true;
        if (up.collider != null && up.collider.gameObject.CompareTag("Enemy"))
            return true;
        if (left.collider != null && left.collider.gameObject.CompareTag("Enemy"))
            return true;
        if (right.collider != null && right.collider.gameObject.CompareTag("Enemy"))
            return true;

        return false;
    }
}

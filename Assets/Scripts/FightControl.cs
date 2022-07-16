using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class FightControl : MonoBehaviour
{
    public AttributeController attributes;
    public Tilemap movementGrid;
    public List<Collider2D> directionHelpers;

    public bool IsPlayer = true;
    
    public void OnMoved()
    {
        var down = getEnemyFromPlayer(new Vector2(0, -1)); 
        var up = getEnemyFromPlayer(new Vector2(0, 1));
        var left = getEnemyFromPlayer(new Vector2(-1, 0));
        var right = getEnemyFromPlayer(new Vector2(1, 0));

        if (down != null)
            BeginFight(down);
        if (up != null)
            BeginFight(up);
        if(left != null)
            BeginFight(left);
        if(right != null)
            BeginFight(right);
    }
    
    [CanBeNull]
    private GameObject getEnemyFromPlayer(Vector2 direction)
    {
        var obj = Physics2D.Raycast(transform.position, direction, 1);

        if (obj.collider != null && obj.collider.gameObject.CompareTag(IsPlayer ? "Enemy" : "Player"))
            return obj.collider.gameObject;

        return null;
    }

    public bool IsEnemyAtDirection(Vector2? direction)
    {
        if (direction == null)
            return false;
        var obj = Physics2D.Raycast(transform.position, (Vector2)direction, 1);

        return obj.collider != null && obj.collider.gameObject.CompareTag(IsPlayer ? "Enemy" : "Player");
    }

    public void BeginFight(GameObject target)
    {
        // trigger animation
        var targetAttr = target.GetComponent<AttributeController>();
        
        targetAttr.OnHit(attributes.hitDamage);
        
        // return fire, trigger animation for it as well
        
        attributes.OnHit(targetAttr.hitDamage);
    }
}

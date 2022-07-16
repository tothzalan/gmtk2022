using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

public class FightControl : MonoBehaviour
{
    public AttributeController attributes;
    public Tilemap movementGrid;

    [FormerlySerializedAs("IsPlayer")] public bool isPlayer = true;
    
    public void OnMoved()
    {
        var down = GetEnemyFromPlayer(new Vector2(0, -1)); 
        var up = GetEnemyFromPlayer(new Vector2(0, 1));
        var left = GetEnemyFromPlayer(new Vector2(-1, 0));
        var right = GetEnemyFromPlayer(new Vector2(1, 0));

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
    private GameObject GetEnemyFromPlayer(Vector2 direction)
    {
        var obj = Physics2D.Raycast(transform.position, direction, 1);

        if (obj.collider != null && obj.collider.gameObject.CompareTag(isPlayer ? "Enemy" : "Player"))
            return obj.collider.gameObject;

        return null;
    }

    public bool IsEnemyAtDirection(Vector2? direction)
    {
        if (direction == null)
            return false;
        var obj = Physics2D.Raycast(transform.position, (Vector2)direction, 1);

        return obj.collider != null && obj.collider.gameObject.CompareTag(isPlayer ? "Enemy" : "Player");
    }

    public void BeginFight(GameObject target)
    {
        // trigger animation
        var targetAttr = target.GetComponent<AttributeController>();
        
        targetAttr.OnHit(attributes.hitDamage);
        
        // trigger isDeath
        
        // return fire, trigger animation for it as well
        
        attributes.OnHit(targetAttr.hitDamage);
        
        // trigger isDeath()
    }
}

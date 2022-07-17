using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;
using Random = System.Random;

public class FightControl : MonoBehaviour
{
    public AttributeController attributes;
    public Tilemap movementGrid;
#nullable enable
    public AudioClip[]? swingSounds;
#nullable disable

    private Random rnd;

    [FormerlySerializedAs("IsPlayer")] public bool isPlayer = true;

    void Start()
    {
        rnd = new Random();
    }
    
    public void OnMove()
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

    public void HitAgain()
    {
        RaycastHit2D[] objs = Physics2D.CircleCastAll(transform.position, 2.0f, new Vector2(0,0));
        foreach(var obj in objs) {
            if(obj.collider != null && obj.collider.gameObject.CompareTag(isPlayer ? "Enemy" : "Player"))
            {
                BeginFight(obj.collider.gameObject);
            }
        }
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
        var obj = Physics2D.Raycast((Vector2)(transform.position + direction), new Vector2(0, 1), 0.2f);

        return obj.collider != null && obj.collider.gameObject.CompareTag(isPlayer ? "Enemy" : "Player");
    }

    public void BeginFight(GameObject target)
    {

        // trigger animation
        var targetAttr = target.GetComponent<AttributeController>();

        if(swingSounds != null)
            AudioSource.PlayClipAtPoint(swingSounds[rnd.Next(0, swingSounds.Length)], transform.position);
        if (targetAttr.OnHit(attributes.hitDamage))
        {
            if(isPlayer) // not player death
                targetAttr.TriggerDeath(false); // TODO: Animation instead
            else
            {
                attributes.TriggerDeath(true);
                // Animation to kill player
                // Trigger Game Over Screen
            }

            return; // Don't want to continue if death occur
        }
        
        // return fire, trigger animation for it as well
        if(swingSounds != null)
            AudioSource.PlayClipAtPoint(swingSounds[rnd.Next(0, swingSounds.Length)], transform.position);
        if (attributes.OnHit(targetAttr.hitDamage))
        {
            if(!isPlayer) // not player death
                attributes.TriggerDeath(false); // TODO: Animation instead
            else
            {
                targetAttr.TriggerDeath(true);
                // Animation to kill player
                // Trigger Game Over Screen
            }
        }
        
        // trigger isDeath()
    }
}

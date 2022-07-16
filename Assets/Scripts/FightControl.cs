using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class FightControl : MonoBehaviour
{
    public AttributeController attributes;
    public Tilemap movementGrid;

    public bool IsPlayer = true;
    
    public void OnMoved()
    {
        var colls = Physics.OverlapSphere(transform.position, 1f);

        foreach (var coll in colls)
        {
            if (coll.gameObject.CompareTag((IsPlayer ? "Enemy" : "Player")))
            {
                BeginFight(coll.gameObject);
            }
        }
    }

    public bool IsAttackAgain(Vector3 position)
    {
        var colls = Physics.OverlapSphere(position, 0.5f);

        foreach (var coll in colls)
        {
            if (coll.gameObject.CompareTag((IsPlayer ? "Enemy" : "Player")))
            {
                return true;
            }
        }

        return false;
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

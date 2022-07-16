using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeController : MonoBehaviour
{
    public int health;
    public int hitDamage;

    public void CardPicked(int health, int damage)
    {
        this.health = health;
        hitDamage = damage;
    }
    
    public void OnHit(int damage)
    {
        health -= damage;
    }

    public bool IsDead()
    {
        return 0 >= health;
    }
}

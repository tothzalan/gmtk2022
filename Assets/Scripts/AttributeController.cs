using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributController : MonoBehaviour
{
    [SerializeField]
    private int _health;
    [SerializeField]
    private int _hitDamage;

    public AttributController(int health, int hitDamage)
    {
        _health = health;
        _hitDamage = hitDamage;
    }

    void GetDamage(int damage)
    {
        _health -= damage;
    }

}

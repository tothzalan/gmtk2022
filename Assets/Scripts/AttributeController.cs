using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributController : MonoBehaviour
{
    [SerializeField]
    private int _health;
    [SerializeField]
    private int _hitDamage;

    void GetDamage(int damage)
    {
        _health -= damage;
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatheringController : MonoBehaviour
{
    public AttributeController attributes;
    public LevelComplete LevelComplete;

    private bool hasKey = false;

    public bool HasKey => hasKey;
    
    public void OnMove()
    {
        if (IsItemUnderObject())
        {
            TryPickUp(GetItemUnderObject());
        }
    }

    private GameObject GetItemUnderObject()
    {
        var obj = Physics2D.Raycast(transform.position, (Vector2)new Vector2(0, 1), 0.2f);

        if (obj.collider == null)
            return null;

        return obj.collider.gameObject;
    }

    private bool IsItemUnderObject()
    {
        var obj = Physics2D.Raycast(transform.position, (Vector2)new Vector2(0, 1), 0.2f);

        return obj.collider != null;
    }
    
    // TODO: trigger animation for health or key
    // TODO: pickup animation
    private void TryPickUp(GameObject gameObject)
    {
        if (gameObject.CompareTag("Key"))
        {
            Destroy(gameObject);
            hasKey = true;

            LevelComplete.OnKeyPickup();
        }

        if (gameObject.CompareTag("HealthPoint"))
        {
            Destroy(gameObject);
            // TODO: Add health
        }

        if (gameObject.CompareTag("HealthPointDouble"))
        {
            // TODO: Add double health
        }
    }
}

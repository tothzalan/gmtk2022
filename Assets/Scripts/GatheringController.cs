using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatheringController : MonoBehaviour
{
    public AttributeController attributes;
    public AudioClip keySound;
    public AudioClip beerSound;
    public AudioClip doubleSound;


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
            AudioSource.PlayClipAtPoint(keySound, transform.position);
        }

        if (gameObject.CompareTag("HealthPoint"))
        {
            Destroy(gameObject);
            attributes.HealthPickedUp(1);
            AudioSource.PlayClipAtPoint(beerSound, transform.position);
            // TODO: Add health
        }

        if (gameObject.CompareTag("HealthPointDouble"))
        {
            Destroy(gameObject);
            attributes.HealthPickedUp(3);
            AudioSource.PlayClipAtPoint(doubleSound, transform.position);
            // TODO: Add double health
        }
    }
}

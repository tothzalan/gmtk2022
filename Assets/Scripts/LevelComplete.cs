using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class LevelComplete : MonoBehaviour
{
    public SceneAsset NextScene;
    public GatheringController GatheringController;
    public HudController HUD;
    
    public Sprite opened;

    private SpriteRenderer _renderer;

    private void Start()
    {
        _renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void OnMove()
    {
        if (IsPlayerOnExit())
        {
            if (GatheringController.HasKey)
            {
                // TODO: effect addition, animation
                SceneManager.LoadScene(NextScene.name);
                return;
            }

            HUD.WriteNoKey();
        }
    }
    
    public void OnKeyPickup()
    {
        _renderer.sprite = opened;
    }

    private bool IsPlayerOnExit()
    {
        var rew = Physics2D.Raycast(transform.position, new Vector2(0, -1), 0.2f);

        return rew.collider != null && rew.collider.gameObject.CompareTag("Player");
    }

    
}

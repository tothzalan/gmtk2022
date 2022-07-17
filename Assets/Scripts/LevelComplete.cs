using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class LevelComplete : MonoBehaviour
{
    public string NextScene;
 
    public GatheringController GatheringController;
    public HudController HUD;
    
    public Sprite opened;

    private SpriteRenderer _renderer;

    private void Start()
    {
        _renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (GatheringController.HasKey && _renderer.sprite != opened)
            _renderer.sprite = opened;
    }

    public void OnMove()
    {
        if (IsPlayerOnExit())
        {
            if (GatheringController.HasKey)
            {
                // TODO: effect addition, animation
                SceneManager.LoadScene(NextScene);
                return;
            }

            //HUD.WriteNoKey();
        }
        else
        {
            //HUD.HideAllMessages();
        }
    }

    private bool IsPlayerOnExit()
    {
        RaycastHit2D[] rews = Physics2D.CircleCastAll(transform.position, 1.0f, new Vector2(0, 0));
        foreach(var rew in rews) {
            if(rew.collider != null && rew.collider.gameObject.CompareTag("Player"))
                return true;
        }
        return false;
    }
}

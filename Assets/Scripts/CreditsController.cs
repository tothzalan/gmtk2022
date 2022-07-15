using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CreditsController : MonoBehaviour
{
    public TMP_Text Credits;

    private List<string> credits = new List<string>();

    void Start()
    {
        credits.Add("Semmi :D");
        credits.Add("Zoli :D");
        foreach(string val in credits)
        {
            Credits.text += $"{val}\n";
        }
    }

    void Update()
    {
        
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

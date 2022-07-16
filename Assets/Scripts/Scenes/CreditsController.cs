using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CreditsController : MonoBehaviour
{
    public TMP_Text Credits;

    private List<string> credits = new List<string>() { "Süveges Zoltán", "Tóth Zalán", "Kaiser László"};

    void Start()
    {
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SettingsController : MonoBehaviour
{
    public TMP_InputField UsernameField;

    void Start()
    {
        if(UsernameField != null && PlayerPrefs.HasKey("Username")) {
            UsernameField.text = PlayerPrefs.GetString("Username");
        }
    }

    void Update()
    {
        
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SaveButtonClick()
    {
        if(UsernameField.text.Length > 0) {
            PlayerPrefs.SetString("Username", UsernameField.text);
        }
    }
}
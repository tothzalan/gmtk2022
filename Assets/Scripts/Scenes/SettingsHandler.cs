using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsHandler : MonoBehaviour
{
    public TMP_InputField UsernameField;
    public Toggle Toggle;
    public TextAsset AdjectivesFile;
    public TextAsset NamesFile;

    void Start()
    {
        if(Toggle) {
            if(PlayerPrefs.HasKey("Fullscreen")) {
                if(PlayerPrefs.GetInt("Fullscreen") == 0) {
                   Toggle.isOn = false; 
                } else {
                    Toggle.isOn = true;
                }
            } else {
                Toggle.isOn = false;
                PlayerPrefs.SetInt("Fullscreen", 0);
            }
        }

        if(AdjectivesFile && NamesFile) {
            string[] adjs = AdjectivesFile.text.Split(',');
            string[] names = NamesFile.text.Split(',');
            var rnd = new System.Random();
            if(UsernameField != null && PlayerPrefs.HasKey("Username")) {
                UsernameField.text = PlayerPrefs.GetString("Username");
            }
            else if(UsernameField != null && !PlayerPrefs.HasKey("Username")) {
                UsernameField.text = $"{adjs[rnd.Next(0, adjs.Length)]} {names[rnd.Next(0, names.Length)]}";
            }
        }
    }

    void Update()
    {
        
    }

    public void SaveButtonClick()
    {
        if(UsernameField.text.Length > 0) {
            PlayerPrefs.SetString("Username", UsernameField.text);
        }
        Screen.fullScreen = Toggle.isOn;
        Debug.Log(Toggle.isOn);
        PlayerPrefs.SetInt("Fullscreen", Toggle.isOn ? 1 : 0);
    }
}

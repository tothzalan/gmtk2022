using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class CreditsController : MonoBehaviour
{
    public TMP_Text Credits;
    public TextAsset CreditsFile;

    void Start()
    {
        List<Credit> creditsList = new List<Credit>();
        if(CreditsFile != null) {
            string[] lines = CreditsFile.text.Split('\n');
            foreach(string line in lines) {
                if(line.Length > 0)
                    creditsList.Add(new Credit(line));
            }
        }
        foreach(Credit credit in creditsList) {
            Debug.Log(credit.ToString());

            Credits.text += credit.ToString();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScenController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        /*
            if (Input.GetKeyDown("q"))
                ExitGame()
        */
    }

    public void ClickStart(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        if(Application.isEditor)
            UnityEditor.EditorApplication.isPlaying = false;
        else
            Application.Quit();
    }
}

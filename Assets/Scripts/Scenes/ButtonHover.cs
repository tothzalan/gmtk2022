using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour
{
    Image shit;
    Color oldColor;

    void Start()
    {
        shit = gameObject.GetComponent<Image>();
        oldColor  = shit.color;
    }

    void Update()
    {
        
    }

    public void MouseEnters()
    {
        Color newColor = oldColor;
        newColor.a = 0.8f;
        shit.color = newColor;
    }

    public void MouseLeaves()
    {
        shit.color = oldColor;
    }
}

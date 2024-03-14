using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class DamageButton : MonoBehaviour
{
    public static bool isDamageMode = false;
    public static int damageAmount = 10;
    public Color activeColor = Color.red;
    public Color defaultColor = Color.white;    
    private TMP_Text buttonText;

    public void ToggleDamageMode()
    {
        isDamageMode = !isDamageMode;

        if (isDamageMode)
            buttonText.color = activeColor;
        else
            buttonText.color = defaultColor;
    }

    private void Start()
    {
        buttonText = GetComponentInChildren<TMP_Text>();        
        if(buttonText == null)
        {
            Debug.LogError("No TextMeshProUGUI text found as a child to the button!");
        }
    }
}

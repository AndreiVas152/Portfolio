using System.Collections;
using System.Collections.Generic;
using Auras;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AuraIcon : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI durationText;

    private Aura _associatedAura;

    public void Setup(Aura aura)
    {
        _associatedAura = aura;
        // iconImage.sprite = aura.IconSprite;
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        if (_associatedAura != null)
        {
            durationText.text = _associatedAura.Duration.ToString();
        }
    }
}

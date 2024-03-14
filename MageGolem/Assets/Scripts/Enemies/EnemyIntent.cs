using System.Collections;
using System.Collections.Generic;
using Enemies.Actions;
using Enemies.Actions.Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyIntent : MonoBehaviour
{
    public Image intentIcon;
    public TextMeshProUGUI descriptionText;

    public void SetIntent(IEnemyAction action)
    {
        intentIcon.sprite = action.ActionIcon;
        descriptionText.text = action.Damage > 0 ? action.Damage.ToString() : string.Empty;
    }
}
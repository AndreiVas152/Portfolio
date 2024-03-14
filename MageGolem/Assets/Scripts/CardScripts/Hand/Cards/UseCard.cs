using System;
using CardScripts.Database;
using Unity.VisualScripting;
using UnityEngine;

namespace Cards
{
    public class UseCard : MonoBehaviour
    {
        public event Action<Card, GameObject> OnCardUsed;
        
        public void UseCardFromHand(Card card, GameObject target)
        {
            OnCardUsed?.Invoke(card, target);
        }
    }
}
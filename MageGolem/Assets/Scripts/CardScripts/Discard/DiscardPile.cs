using System.Collections.Generic;
using CardScripts;
using CardScripts.Database;
using UnityEngine;
using UnityEngine.Serialization;

namespace Cards
{
    public class DiscardPile : MonoBehaviour
    {
        private List<Card> discardList = new();
        
        public void AddCardToDiscardPile(Card card)
        {
            discardList.Add(card);
        }        
    }
}
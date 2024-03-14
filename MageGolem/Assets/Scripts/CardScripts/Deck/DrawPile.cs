using System.Collections.Generic;
using CardScripts;
using CardScripts.Database;
using UnityEngine;
using UnityEngine.Serialization;


namespace Cards
{
    public class DrawPile : MonoBehaviour
    {
        private  List<Card> _drawList = new();

        // Populate the DrawPile from the CardDatabase
        private void Start()
        {
            RandomlyPopulateDeck();
            DeckMethods.Shuffle(_drawList);
        }
        
        public Card DrawCard()
        {
            var drawnCard = _drawList[0];
            _drawList.RemoveAt(0);
            return drawnCard;
        }

        public void RandomlyPopulateDeck()
        {
            for (int i = 0; i < 19; i++)
            {
                _drawList.Add(DatabaseManager.GetRandomCard());
            }
        }
    }
}


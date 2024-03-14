using System;
using System.Collections.Generic;
using CardScripts;
using CardScripts.Database;
using Unity.VisualScripting;
using UnityEngine;

namespace Cards
{
    public class HandManager : MonoBehaviour
    {
        public List<Card> hand = new();
        public DrawPile drawPile;
        public Initializer initializer;
        private List<GameObject> _cardsInHand = new();
        private List<Card> _cardList;

        
        

        private void Awake()
        {
            
        }

        private void Start()
        {
            _cardsInHand = initializer.GetCardList();
        }

        public void DrawCardToHand(Card card)
        {
            var drawnCard = drawPile.DrawCard();
            if (drawnCard != null)
            {
                hand.Add(drawnCard);
            }
        }
        
        
    }
}

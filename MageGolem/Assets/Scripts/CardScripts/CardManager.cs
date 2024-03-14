using System;
using System.Collections.Generic;
using Cards;
using CardScripts.Database;
using UnityEngine;

namespace CardScripts
{
    public class CardManager : MonoBehaviour
    {
        private bool canPlayCards = false;
        private List<GameObject> _cards;
        public CardExecutor cardExecutor;

        private void Start()
        {
            foreach (var card in _cards)
            {
                card.GetComponent<UseCard>().OnCardUsed += HandleCardUsed;
            }
        }
        
        //TODO: Implement this (handle playing cards on targets by first clicking card then target)
        // private void Update()
        // {
        //     
        //     if (!Input.GetMouseButtonDown(0)) return; 
        //
        //     
        //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //
        //     
        //     RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        //     if (hit.collider == null) return; 
        //
        //     
        //     Card clickedCard = hit.collider.GetComponent<Card>();
        //     if (clickedCard == null) return; 
        //     
        //     SelectCard(clickedCard);
        // }

        public void CanPlayCards()
        {
            canPlayCards = !canPlayCards;
        }
        
        public void HandleCardUsed(Card card, GameObject target)
        {
            if (canPlayCards)
            {
                Debug.Log("Card used: " + card.name);
                cardExecutor.PlayCard(card, target);
            }
        }
    }
}
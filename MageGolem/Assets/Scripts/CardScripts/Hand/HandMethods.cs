using System.Collections.Generic;
using CardScripts;
using CardScripts.Database;
using Unity.VisualScripting;
using UnityEngine;

namespace Cards
{
    public class HandMethods
    {
                
        
        public static void AddCardToHand(GameObject card, Card cardToAdd)
        {
            
        }
        
        //This should be called every time a card is modified (played, discarded, exhausted, whatever).
        //Params should be the hand list and the modified card's index, it returns the hand and the first inactive index for the purpose of adding new cards
        //This method will move all inactive cards to the right of the hand, and all active cards to the left of the hand maintaining their spatial positions
        
        public static (List<GameObject>, int) OrganizeHand(List<GameObject> hand, int modifiedCardPosition)
        {
            var firstInactiveIndex = modifiedCardPosition;
            
            //If the modified card is the last card or for some ungodly reason negative, return the hand as-is
            if (modifiedCardPosition <0 || modifiedCardPosition >= hand.Count-1) return (hand, firstInactiveIndex);            
            
            for (var i = modifiedCardPosition; i < hand.Count -1; i++)
            {
                // If the next card is also inactive, all of the cards after it are also inactive
                if (!hand[i].activeSelf && !hand[i + 1].activeSelf) break;
                
                // If the next card is active, swap the positions of the two cards, keeping all active cards on the left
                
                (hand[i].transform.position, hand[i + 1].transform.position) = (hand[i + 1].transform.position, hand[i].transform.position);
                (hand[i], hand[i + 1]) = (hand[i + 1], hand[i]);
                i++;
                firstInactiveIndex = i;                
            }

            return (hand, firstInactiveIndex);
        }
    }
}
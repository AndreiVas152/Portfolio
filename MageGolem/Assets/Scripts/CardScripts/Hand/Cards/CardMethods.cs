using System.Collections.Generic;
using Auras;
using CardScripts;
using CardScripts.Database;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Cards
{
    public class CardMethods : MonoBehaviour
    {
        private Card _displayCard;
        
        public TextMeshProUGUI cardNameText;
        public TextMeshProUGUI cardCostText;
        public TextMeshProUGUI cardPowerText;
        public TextMeshProUGUI cardDescriptionText;
        public Image cardArtImage;
        
        public void SetCard(Card card)
        {
            cardNameText.text = card.cardName;
            cardCostText.text = card.cost.ToString();
            cardPowerText.text = card.power.ToString();
            cardDescriptionText.text = card.cardDescription;
            cardArtImage.sprite = card.cardArt;
            
            _displayCard = card;
        }
        
        public void UseCardFromHand(GameObject target)
        {
            var useCard = GetComponent<UseCard>();
            useCard.UseCardFromHand(_displayCard, target);
        }        
    }
}

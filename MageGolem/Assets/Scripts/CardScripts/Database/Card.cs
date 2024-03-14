using System.Collections.Generic;
using Auras;
using UnityEngine;
using UnityEngine.Serialization;

namespace CardScripts.Database
{    
    [CreateAssetMenu(fileName = "Card", menuName = "ScriptableObjects/Card", order = 1)]
    public class Card : ScriptableObject
    {
        [SerializeField] public int cardId;

        public int CardId => cardId;
        
        public string cardName;
        public int cost;
        [FormerlySerializedAs("damage")] public int power;
        public string cardDescription;
        public Sprite cardArt;
        public List<AuraEffect> auraList;
        public CardTarget cardTarget;
        
        public void SetCardId(int id)
        {
            cardId = id;
        }
    }    
}

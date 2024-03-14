using System.Collections.Generic;
using UnityEngine;

namespace CardScripts.Database
{
    [CreateAssetMenu(fileName = "CardDatabase", menuName = "ScriptableObjects/CardDatabase", order = 2)]
    public class CardDatabase : ScriptableObject
    {
        public List<Card> allCards = new();
    }
}
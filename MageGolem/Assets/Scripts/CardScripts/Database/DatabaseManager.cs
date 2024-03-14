using System.Linq;

namespace CardScripts.Database
{
    public static class DatabaseManager
    {
        public static CardDatabase cardDatabase;
        
        public static Card GetCardById(int id)
        {
            return cardDatabase.allCards.FirstOrDefault(card => card.cardId == id);
        }

        public static Card GetRandomCard()
        {
            if (cardDatabase.allCards.Count == 0) return null;
            int randomIndex = UnityEngine.Random.Range(0, cardDatabase.allCards.Count);
            return cardDatabase.allCards[randomIndex];
        }
    }
}
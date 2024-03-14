using System.Collections.Generic;
using Cards;
using CardScripts.Database;

namespace CardScripts
{
    public class DeckMethods
    {
        public static void ResetDeck(List<Card> drawPile, List<Card> discardPile)
        {
            foreach (var card in discardPile)
            {
                drawPile.Add(card);
            }
            discardPile.Clear();
            Shuffle(drawPile);
        }
        
        public static void Shuffle(List<Card> cardPile)
        {
            var n = cardPile.Count;
            var randomizer = new System.Random();
            while (n > 1)
            {
                n--;
                var k = randomizer.Next(n + 1);
                (cardPile[k], cardPile[n]) = (cardPile[n], cardPile[k]);
            }
        }
    }
}
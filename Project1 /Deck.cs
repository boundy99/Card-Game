//Abdoulaye Boundy Djikine

using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    public class Deck
    {
        List<Card> cards = new List<Card>();

        public Deck()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    cards.Add(new Card(rank.ToString(), suit.ToString()));
                }
            }
        }

        public bool Empty
        {
            get { return cards.Count == 0; }
        }

        public int Count
        {
            get { return cards.Count; }
        }

        public Card TakeTopCard()
        {
            if (!Empty)
            {
                Card topCard = cards[cards.Count - 1];
                cards.RemoveAt(cards.Count - 1);
                return topCard;
            }
            else
                return null;
        }
        public void Shuffle()
        {
            int i, j;
            Card temp;
            Random randomNumber = new Random();
            for (i = cards.Count - 1; i > 1; i--)
            {
                j = randomNumber.Next((cards.Count - 1) + 1);
                temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
        }

        

    }
}

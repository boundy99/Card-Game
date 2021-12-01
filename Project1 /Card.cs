//Abdoulaye Boundy Djikine

using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    public class Card
    {
        string rank;
        string suit;
        bool Selected { get; set; }
        bool faceUp = false;

        public Card(string rank, string suit)
        {
            this.rank = rank;
            this.suit = suit;    
        }

        public string Rank
        {
            get { return rank; }
        }

        public string Suit
        {
            get { return suit; }
        }
        public void FlipOver()
        {
            faceUp = !faceUp;
        }
        public int getCardValue()
        {
            return (int)System.Enum.Parse(typeof(Rank), Rank) + 1;
        }
    }
}

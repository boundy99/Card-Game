//Abdoulaye Boundy Djikine

using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    abstract public class CardDealer
    {
        protected Deck deck;
        protected List<Card> CardList;
        protected int score;
        protected int ongoingGame;
        protected int sumRequirement;
        protected int c1, c2, c3, c4;
        public CardDealer()
        {
            deck = new Deck();
            CardList = new List<Card>();
            deck.Shuffle();
            score = 0;
            ongoingGame = 0;
            sumRequirement = 0;
        }

        public void Play(int gameChoice)
        {
            if (gameChoice == 1)
            {
                for (int i = 0; i < 13; i++)
                    CardList.Add(deck.TakeTopCard());

                sumRequirement = 10;
                ongoingGame = 13;
            }

            if (gameChoice == 2)
            {
                for (int i = 0; i < 9; i++)
                    CardList.Add(deck.TakeTopCard());

                sumRequirement = 11;
                ongoingGame = 9;
            }

            if (gameChoice == 3)
            {
                for (int i = 0; i < 10; i++)
                    CardList.Add(deck.TakeTopCard());

                sumRequirement = 13;
                ongoingGame = 10;
            }
        }

        public bool Win()
        {
            if (deck.Empty && CardList.Count == 0)
                return true;
            
            return false;
        }

        public void DisplayCards()
        {
            int index = 0;
            foreach (Card c in CardList)
            {
                Console.WriteLine("Card " + (index + 1) + " Rank : " + CardList[index].Rank +
                                   ", Value = " + CardList[index].getCardValue());
                index++;
            }

            Console.WriteLine("\nYou have " + CardsLeft + " remaining in your deck");
        }

        public bool ValidCard(int index, string rank)
        {
            if (CardList[index - 1].Rank == rank)
                return true;

            return false;
        }

        public virtual bool ValidSum(int c1, int c2)
        {
            int totalValue = 0;
            totalValue = CardList[c1 - 1].getCardValue() + CardList[c2 - 1].getCardValue();

            if (totalValue == sumRequirement)
                return true;

            return false;
        }

        public void RemoveCards(int index)
        {
            if (!deck.Empty)
                CardList[index - 1] = deck.TakeTopCard();

            else
                CardList.RemoveAt(index - 1);      
        }
        
        public int Score
        {
            get { return score; }
        }

        public bool Won()
        {
            return CardList.Count == 0;
        }

        public void GameReset()
        {
            score = 0;
            CardList.Clear();
            deck = new Deck();
            deck.Shuffle();

            Console.WriteLine("\nYour game has been reset.\nThis is your new list :\n");

            for (int index = 0; index < ongoingGame; index++)
                CardList.Add(deck.TakeTopCard());

            DisplayCards();
        }

        public bool pairExists()
        {

            int cardValue;
            for (int i = 0; i < CardList.Count; i++)
            {
                for (int j = i + 1; j < CardList.Count; j++)
                {
                    cardValue = 0;
                    cardValue += CardList[i].getCardValue();
                    cardValue += CardList[j].getCardValue();

                    // if two cards with total equals to sum required for game is found.
                    if (cardValue == sumRequirement)
                        return true;
                }
            }

            return false;
        }

        public int CardsLeft
        {
            get { return deck.Count; }
        }
    }
        
}

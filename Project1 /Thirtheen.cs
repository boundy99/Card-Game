//Abdoulaye Boundy Djikine

using System;
using System.Collections.Generic;
using System.Text;
namespace Project1
{
    public class Thirtheen : CardDealer
    {
        public Thirtheen()
        {
        }

        public bool KingValidation()
        {
            for (int i = 0; i < CardList.Count; i++)
            {
                // when King is found
                if (CardList[i].Rank == "King")
                    return true;
            }

            return false;
        }

        public void selectCards()
        {
            int cardValue = 0;

            do
            {
                Console.Write("\nPlease select card #1 : ");
                c1 = Convert.ToInt32(Console.ReadLine());
            } while (c1 < 1 || c1 >= CardList.Count + 1);

            cardValue += CardList[c1 - 1].getCardValue();

            if (cardValue == 13)
            {
                Console.WriteLine("\nWell done! This card was a King\n");
                RemoveCards(c1);
                DisplayCards();
            }

            else
            {
                Console.Write("\nPlease select card #2 : ");
                c2 = Convert.ToInt32(Console.ReadLine());

                while (c2 < 1 || c2 >= CardList.Count + 1 || c1 == c2)
                {
                    if (c1 == c2)
                    {
                        Console.Write("\nYou cannot select the same card twice. Try again: ");
                        c2 = Convert.ToInt32(Console.ReadLine());
                    }

                    else
                    {
                        Console.Write("\nWrong input. Try again : ");
                        c2 = Convert.ToInt32(Console.ReadLine());
                    }
                }

                cardValue += CardList[c2 - 1].getCardValue();

                if (ValidSum(c1, c2))
                {
                    score++;

                    if (c1 > c2)
                    {
                        RemoveCards(c1);
                        RemoveCards(c2);
                    }

                    else
                    {
                        RemoveCards(c2);
                        RemoveCards(c1);
                    }

                    Console.WriteLine("\nThe two cards selected add up to " + sumRequirement + ".\n");
                    DisplayCards();
                }

                else
                    Console.WriteLine("\nThe value of the selected cards is : " +
                                      (CardList[c1 - 1].getCardValue() + CardList[c2 - 1].getCardValue()));
            }
        }
    }
}

//Abdoulaye Boundy Djikine

using System;
using System.Collections.Generic;
using System.Text;
namespace Project1
{
    public class Eleven : CardDealer
    {
        public Eleven()
        {
        }
        public bool JQKValidation()
        {
            // boolean variables
            bool isKing, isQueen, isJack;
            isKing = isQueen = isJack = false;

            for (int i = 0; i < CardList.Count; i++)
            {
                // when King is found
                if (CardList[i].Rank == "King")
                    isKing = true;

                // when Queen is found
                if (CardList[i].Rank == "Queen")
                    isQueen = true;

                // when Jack is found
                if (CardList[i].Rank == "Jack")
                    isJack = true;
            }

            return isKing && isQueen && isJack;
        }
        public void selectCards()
        {
            int cardValue = 0;
            bool isJack, isQueen, isKing;
            isKing = isJack = isQueen = false;

            do
            {
                Console.Write("\nPlease select card #1 : ");
                c1 = Convert.ToInt32(Console.ReadLine());
            } while (c1 < 1 || c1 >= CardList.Count + 1);

            cardValue += CardList[c1 - 1].getCardValue();

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

            else if (cardValue > sumRequirement && JQKValidation())
            {
                Console.Write("\nPlease select card #3 : ");
                c3 = Convert.ToInt32(Console.ReadLine());

                while (c1 < 1 || c1 >= CardList.Count + 1 || c1 == c3 || c2 == c3)
                {
                    if (c1 == c3 || c2 == c3)
                    {
                        Console.Write("\nMake sure you select a card that" +
                                          " you have not selected before : ");
                        c3 = Convert.ToInt32(Console.ReadLine());
                    }

                    else
                    {
                        Console.Write("\nMake sure you select a card" +
                                          " within the range : ");
                        c3 = Convert.ToInt32(Console.ReadLine());
                    }
                }

                if (CardList[c1 - 1].Rank == "King" ||
                    CardList[c2 - 1].Rank == "King" ||
                    CardList[c3 - 1].Rank == "King")
                    isKing = true;

                if (CardList[c1 - 1].Rank == "Queen" ||
                    CardList[c2 - 1].Rank == "Queen" ||
                    CardList[c3 - 1].Rank == "Queen")
                    isQueen = true;

                if (CardList[c1 - 1].Rank == "Jack" ||
                    CardList[c2 - 1].Rank == "Jack" ||
                    CardList[c3 - 1].Rank == "Jack")
                    isJack = true;

                if (isKing && isQueen && isJack)
                {
                    Console.WriteLine("\nGreat job ! You just removed King, Queen, and Jack from the game\n");

                    int[] array = new int[] { c1, c2, c3 };
                    Array.Sort(array);
 
                    RemoveCards(array[2]);
                    RemoveCards(array[1]);
                    RemoveCards(array[0]);

                    DisplayCards();
                }

                else
                    Console.WriteLine("\nThe selected cards were not a " +
                                      "Combination of King, Queen an Jack");
            }

            else
            {
                Console.WriteLine("\nThe value of the selected cards is : " +
                                     (CardList[c1 - 1].getCardValue() + CardList[c2 - 1].getCardValue()));
            }

        }
    }  
}

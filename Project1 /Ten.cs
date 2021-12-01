//Abdoulaye Boundy Djikine

using System;
using System.Collections.Generic;
using System.Text;
namespace Project1
{
    public class Ten : CardDealer
    {
        public Ten()
        {
        }

        public bool JQKTValidation()
        {
            // boolean variables
            bool isKing, isQueen, isJack, isTen;
            isKing = isQueen = isJack = isTen = false;

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

                // when Ten is found
                if (CardList[i].Rank == "Ten")
                    isTen = true;
            }

            return isKing && isQueen && isJack && isTen;
        }
        public void selectCards()
        {
            int cardValue = 0;
            bool isTen, isJack, isQueen, isKing;
            isKing = isJack = isQueen = isTen = false;

            do
            {
                Console.Write("\nPlease select card #1 : ");
                c1 = Convert.ToInt32(Console.ReadLine());
            } while (c1 < 1 || c1 >= CardList.Count+1);

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

                if(c1 > c2)
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

            else if (cardValue > 10 && JQKTValidation())
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

                Console.Write("\nPlease select card #4 : ");
                c4 = Convert.ToInt32(Console.ReadLine());

                while (c1 < 1 || c1 >= CardList.Count + 1 || c1 == c4 || c2 == c4 || c3 == c4)
                {
                    if (c1 == c4 || c2 == c4 || c3 == c4)
                    {
                        Console.Write("\nMake sure you select a card that" +
                                          " you have not selected before : ");
                        c4 = Convert.ToInt32(Console.ReadLine());
                    }

                    else
                    {
                        Console.Write("\nMake sure you select a card" +
                                          " is within the range : ");
                        c4 = Convert.ToInt32(Console.ReadLine());
                    }
                }

                if (CardList[c1 - 1].Rank == "King" ||
                    CardList[c2 - 1].Rank == "King" ||
                    CardList[c3 - 1].Rank == "King" ||
                    CardList[c4 - 1].Rank == "King")
                    isKing = true;

                if (CardList[c1 - 1].Rank == "Queen" ||
                    CardList[c2 - 1].Rank == "Queen" ||
                    CardList[c3 - 1].Rank == "Queen" ||
                    CardList[c4 - 1].Rank == "Queen")
                    isQueen = true;

                if (CardList[c1 - 1].Rank == "Jack" ||
                    CardList[c2 - 1].Rank == "Jack" ||
                    CardList[c3 - 1].Rank == "Jack" ||
                    CardList[c4 - 1].Rank == "Jack")
                    isJack = true;

                if (CardList[c1 - 1].Rank == "Ten" ||
                    CardList[c2 - 1].Rank == "Ten" ||
                    CardList[c3 - 1].Rank == "Ten" ||
                    CardList[c4 - 1].Rank == "Ten")
                    isTen = true;

                if (isKing && isQueen && isJack & isTen)
                {
                    Console.WriteLine("\nGreat job ! You just removed King, Queen, Jack and Ten from the game\n");

                    int[] array = new int[] { c1, c2, c3, c4 };
                    Array.Sort(array);

                    RemoveCards(array[3]);
                    RemoveCards(array[2]);
                    RemoveCards(array[1]);
                    RemoveCards(array[0]);

                    DisplayCards();
                }

                else
                    Console.WriteLine("\nThe selected cards were not a " +
                                      "Combination of King, Queen, Jack and Ten");
            }

            else  
            {
                Console.WriteLine("\nThe value of the selected cards is : " +
                                     (CardList[c1 - 1].getCardValue() + CardList[c2 - 1].getCardValue()));
            }

        }


    }
}

//Abdoulaye Boundy Djikine

using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            int input;
            bool isReset;
            
            do
            {
                isReset = true;
                input = Menu();
                // TensGame
                if (input == 1)
                {
                    Console.WriteLine("\n-----------------\n" +
                                       " TENSBOARD GAME \n" +
                                       "-----------------\n");
                    Ten Game1 = new Ten();
                    Game1.Play(input);
                    Game1.DisplayCards();
                    do
                    {
                        Game1.selectCards();

                        if ((!Game1.pairExists() && !Game1.JQKTValidation()) && !Game1.Won())
                        {
                            Console.WriteLine("\nYou do not have any more combination to continue playing this game");
                            if (reset())
                                Game1.GameReset();

                            else
                                isReset = false;
                        }

                    } while (isReset && !Game1.Won());

                    if (Game1.Won())
                        Console.WriteLine("\nYou have won this game. Your score is " + Game1.Score + "\n");

                    if (!isReset)
                        Console.WriteLine("\nYou have lost the game.\n");
                    
                }

                // ElevensGame
                if (input == 2)
                {
                    Console.WriteLine("\n-------------------\n" +
                                       " ELEVENSBOARD GAME \n" +
                                       "-------------------\n");
                    Eleven Game2 = new Eleven();
                    Game2.Play(input);
                    Game2.DisplayCards();
                    do
                    {
                        Game2.selectCards();

                        if ((!Game2.pairExists() && !Game2.JQKValidation()) && !Game2.Won())
                        {
                            Console.WriteLine("\nYou do not have any more combination to continue playing this game");
                            if (reset())
                                Game2.GameReset();

                            else
                                isReset = false;
                        }

                    } while (isReset && !Game2.Won());

                    if (Game2.Won())
                        Console.WriteLine("\nYou have won this game. Your score is " + Game2.Score + "\n");

                    if (!isReset)
                        Console.WriteLine("\nYou have lost the game.\n");
                }

                // ThirteensGame
                if (input == 3)
                {
                    Console.WriteLine("\n--------------------\n" +
                                       " THIRTEENSBOARD GAME \n" +
                                       "--------------------\n");
                    Thirtheen Game3 = new Thirtheen();
                    Game3.Play(input);
                    Game3.DisplayCards();
                    do
                    {
                        Game3.selectCards();

                        if ((!Game3.pairExists() && !Game3.KingValidation()) && !Game3.Won())
                        {
                            Console.WriteLine("\nYou do not have any more combination to continue playing this game");
                            if (reset())
                                Game3.GameReset();

                            else
                                isReset = false;
                        }

                    } while (isReset && !Game3.Won());

                    if (Game3.Won())
                        Console.WriteLine("\nYou have won this game. Your score is " + Game3.Score + "\n");

                    if (!isReset)
                        Console.WriteLine("\nYou have lost the game.\n");
                }

            } while (input != 4);

            Console.WriteLine("\nYou have left the game.");
        }

        public static int Menu()
        {
            int option;

            Console.Write("What game would you like to play ?\n\n" +
                          "1. TensBoard Game\n" +
                          "2. ElevensBoard Game\n" +
                          "3. ThirteensBoard Game\n" +
                          "4. Quit\n" +
                          "\nSelect Option : ");

            option = Convert.ToInt32(Console.ReadLine());

            while (option < 1 || option >=5)
            {
                Console.WriteLine("\nWRONG INPUT !");
                
                Console.Write("\nWhat game would you like to play ?\n" +
                              "1. TensBoard Game\n" +
                              "2. ElevensBoard Game\n" +
                              "3. ThirteensBoard Game\n" +
                              "4. Quit\n" +
                              "\nSelect Option : ");
                option = Convert.ToInt32(Console.ReadLine());
            }

            return option;
        }

        public static bool reset()
        {
            string choice;

            Console.Write("\nWould you like to reset this game ?\n" +
                          "Enter 'Y' for Yes and 'N' for No : ");
            choice = Console.ReadLine();

            while (!(choice == "Y" || choice == "y" || choice == "n" || choice == "N"))
            {
                Console.WriteLine("WRONG INPUT !");
                Console.WriteLine("Would you like to reset the game ?");
                Console.Write("Enter 'Y' for Yes or 'N' for No : ");

                choice = Console.ReadLine();
            }

            if (choice == "Y" || choice == "y")
                return true;

            return false;
        }
    }
}

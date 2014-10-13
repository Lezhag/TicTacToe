using System;
using System.Text.RegularExpressions;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
            //main game menu
            while (true)
            {
                Console.WriteLine("For a new game choose-n or exit-e");
                string n = "";
                int? t = null;
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.N: //new game

                        #region Getting the players names and tokens
                        Console.WriteLine();

                        Console.WriteLine("Enter the name of the first player:");
                        n = GetName();
                        t = GetToken();
                        Player first = new Player(n, t);

                        Console.WriteLine("Enter the name of the second player:");
                        n = GetName();
                        //Second player token
                        t = (t == 0) ? t = 1 : t = 0;

                        Player second = new Player(n, t);
                        //init new game
                        Board Game = new Board();
                        BoardControl DrawingBoard = new BoardControl();
                        Console.Clear();
                        #endregion

                        DrawingBoard.Draw(Game);

                        Player CurrentPlayer = first;

                        //main game loop
                        while (!Game.EndGame) //while the game doesn't reach end conditions : either one of the players wins or no more turns
                        {
                            Game.MakeTurn(CurrentPlayer);
                            Console.Clear();
                            DrawingBoard.Draw(Game);
                            if (CurrentPlayer == first)
                            { CurrentPlayer = second; }
                            else
                            { CurrentPlayer = first; }
                        }
                        Console.WriteLine("This game is over!");
                        //game ends - we need the name of the winner
                        if (Game.WinnerToken != null) // if there's a winner
                        {
                            if (Game.WinnerToken == first.Token) //let's get to know him
                            {
                                Console.WriteLine("The winner is {0}", first.Name);
                            }
                            else
                            {
                                Console.WriteLine("The winner is {0}", second.Name);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No winner!");
                        }

                        break;
                    case ConsoleKey.E: //exit
                        return;

                    default:
                        Console.WriteLine("Enter 'e' or 'n' only");
                        break;
                }
            }
        }

        private static int? GetToken()
        {
            string TokenInput = "";
            int? t = null;
            Console.WriteLine("Choose O or X");

            while (t == null)
            {
                try
                {
                    TokenInput = Console.ReadLine();
                    if ((TokenInput.ToLower() == "o") || (TokenInput.ToLower() == "x"))
                    {
                        if (TokenInput.ToLower() == "o") t = 0;
                        else
                        {
                            t = 1;
                        }
                    }
                    else
                    {
                        t = null;
                        throw new FormatException();
                    }
                }
                catch (StackOverflowException e)
                {
                    Console.WriteLine("Error in input data:" + e.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Player must choose 'x' or 'o' only!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error in input data:" + e.Message);
                }
            }
            return t;
        }

        private static string GetName()
        {
            string n = "";
            while (n == "")
            {
                try
                {
                    n = Console.ReadLine();
                    if (!Regex.IsMatch(n, @"^[a-zA-Z]"))//wrong input - first character is not a letter!
                    {
                        n = "";
                        throw new FormatException();
                    }
                }
                catch (StackOverflowException e)
                {
                    Console.WriteLine("Error in input data:" + e.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Player name is in wrong format!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error in input data:" + e.Message);
                }
            }
            return n;
        }
    }
}

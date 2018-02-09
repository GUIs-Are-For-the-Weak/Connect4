using System;

namespace Connect4
{
    class Program
    {
        static void Main(string[] args)
        {
            DeterminePlayers(DeterminePlayerNumber());
            Game game = new Game(DeterminePlayerNumber(), 4); //2 players, 4 in a row to win
            Console.ReadLine(); //Needed to stop the console window from closing
        }

        //Determine the number of players that are in the game
        //TODO: Determine which players are AI and human.
        private static int DeterminePlayerNumber()
        {
            Console.WriteLine("How many players do you want?");
            int answer = 0;
            while (answer <= 1)
            {
                //Determine if the input is an integer, and store it in answer if it is.
                if (!(Int32.TryParse(Console.ReadLine(), out answer)))
                {
                    Console.WriteLine("Please enter an integer.");
                }
                else if(answer <= 1)
                {
                    Console.WriteLine("Please enter a number above 1.");
                }
            }
            Console.WriteLine("You have " + answer + " players in the game.");
            return answer;
        }

        private static Player[] DeterminePlayers(int numberOfPlayers)
        {
            Player[] players = new Player[numberOfPlayers];
            
            //Determine the main players name, and add them to the array.
            players[0] = new Human(ConsoleColor.Yellow, getName());

            //Determine the type of each other player.
            for(int i = 1; i < numberOfPlayers; i++)
            {
                Console.WriteLine("What should player" + (i + 1) + " be?");
                Console.WriteLine("1. A human player.");
                Console.WriteLine("2. An AI player.");
                int typeChoice = 0;
                do
                {
                    if (Int32.TryParse(Console.ReadLine(), out typeChoice))
                    {
                        if (typeChoice == 1)
                        {

                            players[i] = new Human(ConsoleColor.Red, getName());
                        }
                        else if (typeChoice == 2)
                        {
                            players[i] = new AI(ConsoleColor.Red, new Board(6, 7, (Board, column) => throw new NotImplementedException()));
                        }
                        else
                        {
                            Console.WriteLine("Please enter 1 or 2.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter an integer");
                    }
                } while (typeChoice == 0);
            }
            return players;
        }

        private static String getName()
        {
            Console.WriteLine("Enter a name:");
            return Console.ReadLine();
        }
    }
}

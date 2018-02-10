using System;

class Game
{
    private static readonly ConsoleColor[] _colours = {ConsoleColor.Red, ConsoleColor.Yellow};
    private Player[] _players; //Array of players
    private Func<Board, int, bool> _isGameWon; //The condition necassary to win
    private Board _gameBoard;

    //Constructor
    public Game(Func<Board, int, bool> winCondition)
    {
        //Determine player count, and types of players
        _players = DeterminePlayers();
        

        _isGameWon = winCondition;

        //Create the game board
        _gameBoard = new Board(6, 7, winCondition);
    }


    //Determine the number of players that are in the game
    //TODO: Determine which players are AI and human.
    private static int DeterminePlayerNumber()
    {
        Console.Write("Enter the number of players: ");

        //int answer = 0
        //while (answer <= 1)
        //{
        //    //Determine if the input is an integer, and store it in answer if it is.
        //    if (!(int.TryParse(Console.ReadLine(), out answer)))
        //    {
        //        Console.WriteLine("Please enter an integer.");
        //    }
        //    else if (answer <= 1)
        //    {
        //        Console.WriteLine("Please enter a number above 1.");
        //    }
        //}
        //Console.WriteLine("You have " + answer + " players in the game.");


        int answer;
        while (!int.TryParse(Console.ReadLine(), out answer) || answer < 2)
            Console.Write("Please enter an integer of at least 2.\nEnter the number of players: ");

        return answer;
    }

    private static Player[] DeterminePlayers()
    {
        Player[] players = new Player[DeterminePlayerNumber()];

        //Determine the main players name, and add them to the array.
        players[0] = new Human(_colours[0], GetPlayerName());

        //Determine the type of each other player.
        for (int i = 1; i < players.Length; i++)
        {
            Console.WriteLine($"What should player {i+1} be?");
            Console.WriteLine("1. A human player.");
            Console.WriteLine("2. An AI player.\n");
            Console.Write("Choice: ");


            //int typeChoice = 0;
            //do
            //{
            //    if (int.TryParse(Console.ReadLine(), out typeChoice))
            //    {
            //        if (typeChoice == 1)
            //        {

            //            players[i] = new Human(_colours[i], GetPlayerName());
            //        }
            //        else if (typeChoice == 2)
            //        {
            //            players[i] = new AI(_colours[i]);
            //        }
            //        else
            //        {
            //            Console.WriteLine("Please enter 1 or 2.");
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("Please enter an integer");
            //    }
            //} while (typeChoice == 0);

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2)
                Console.Write("Please enter either 1 or 2.\nChoice:  ");

            switch(choice)
            {
                case 1: players[i] = new Human(_colours[i], GetPlayerName());
                    break;
                case 2: players[i] = new AI(_colours[i]);
                    break;
            }

        }
        return players;
    }

    private static string GetPlayerName()
    {
        Console.Write("Enter player name: ");
        return Console.ReadLine();
    }

}

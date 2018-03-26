using System;

class Game
{
    //Player piece colours.
    private static readonly ConsoleColor[] _colours = { ConsoleColor.Yellow, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Blue };
    private Player[] _players; //Array of players
    private Board _gameBoard;


    //Constructor
    public Game(Func<Board, bool> winCondition, EndGame gameEndHandler = null)
    {
        if (gameEndHandler != null)
            GameEnded += gameEndHandler;

        //Determine player count, and types of players
        _players = DeterminePlayers();

        //Create the game board
        _gameBoard = CreateBoard();

        //Loop until the game is won
        int playerIndex = -1;
        bool gameState = false;
        while (!gameState)
        {
            playerIndex = ++playerIndex % _players.Length;

            _gameBoard.Draw();

            //Take the turn
            if (!_gameBoard.PlacePiece(_players[playerIndex], _players[playerIndex].TakeTurn(_gameBoard.ToArray())))
                throw new Exception("Column index out of bounds or column is full.");

            //Check if the game is won
            gameState = winCondition(_gameBoard);

            if (!gameState)
            {
                gameState = true;
                for (int i = 0; i < _gameBoard.Width; i++)
                {
                    if (_gameBoard[0, i] == null)
                    {
                        gameState = false;
                        break;
                    }
                }
                if (gameState)
                    playerIndex = -1;

            }
        }
        _gameBoard.Draw();

        GameEnded(playerIndex == -1 ? null : _players[playerIndex]);
    }


    //Determine the number of players that are in the game
    //TODO: Determine which players are AI and human.
    private static int DeterminePlayerNumber()
    {
        Console.Write("Enter the number of players: ");

        int answer;
        while (!int.TryParse(Console.ReadLine(), out answer) || answer < 2 || answer > 4)
            Console.Write("Please enter an integer of at least 2, and no more than 4.\nEnter the number of players: ");

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
            Console.WriteLine($"What should player {i + 1} be?");
            Console.WriteLine("1. A human player.");
            Console.WriteLine("2. An AI player.\n");
            Console.Write("Choice: ");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2)
                Console.Write("Please enter either 1 or 2.\nChoice:  ");

            switch (choice)
            {
                case 1:
                    players[i] = new Human(_colours[i], GetPlayerName());
                    break;
                case 2:
                    players[i] = new AI(_colours[i]);
                    break;
            }

        }
        return players;
    }

    //Gets the name of a player from the user.
    private static string GetPlayerName()
    {
        Console.Write("Enter player name: ");
        return Console.ReadLine();
    }

    private static Board CreateBoard()
    {
        int width, height;

        //Check if they want the default size
        Console.WriteLine("Would you like to use the default board size?");
        Console.Write("Y/N: ");
        string answer = Console.ReadLine();
        while (!(answer.ToLower() == "y" || answer.ToLower() == "n"))
        {
            Console.WriteLine("Please enter Y or N.");
            Console.Write("Y/N: ");
            answer = Console.ReadLine();
        }

        //Set default size
        if(answer.ToLower() == "y")
        {
            height = 6;
            width = 7;
        }
        else
        {
            //Get height and width
            Console.Write("Enter your height: ");
            while (!int.TryParse(Console.ReadLine(), out height) || height < 4)
            {
                Console.WriteLine("Please enter a number larger than 4.");
                Console.Write("Enter your height: ");
            }

            Console.Write("Enter your width: ");
            while (!int.TryParse(Console.ReadLine(), out width) || width < 4)
            {
                Console.WriteLine("Please enter a number larger than 4.");
                Console.Write("Enter your width: ");
            }
        }
            
        return new Board(height, width);
    }

    /// <summary>
    /// Invoked when the game has ended (either a player has won, or the board is full)
    /// </summary>
    public event EndGame GameEnded;

}

/// <summary>
/// Type of event handler to call when the game ends.
/// </summary>
/// <param name="winner">The winner of the game. Null if there was a draw.</param>
delegate void EndGame(/*null if draw*/Player winner);

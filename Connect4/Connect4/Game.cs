using System;

class Game
{
    private ConsoleColor[] colours = {ConsoleColor.Red, ConsoleColor.Yellow};

    private int _numberOfPlayers; //Number of players in the game TODO: Determine if AI or Human
    private int _gameType; //Number in a row needed for a win
    private Player[] players; //Array of players
    private Func<Board, int, bool> winCondition; //The condition necassary to win
    const int DEFAULT_WIN = 4; //TODO: Implement different win types

    //Constructor
    public Game()
    {
        //Determine player count, and types of players
        _numberOfPlayers = this.DeterminePlayerNumber();
        players = DeterminePlayers();
        _gameType = DEFAULT_WIN;
        

        winCondition = delegate(Board board, int column) 
        {
            int row = 0;
            int inlineCount = 0;
            Player currentToken, nextToken;
            bool changeDirection = false;
            //Get the position of the token that was just placed
            for (int i = 6; i >= 0; i--)
            {
                if(board[i, column] != null)
                {
                    row = i;
                    break;
                }
            }
            currentToken = board[row,column];
            for (int i = 0; i < _gameType; i++)
            {
                if(row-i > 0)
                {
                    nextToken = board[row-(i+1),column];
                    if(currentToken == nextToken)
                    {
                        inlineCount++;
                        currentToken = nextToken;
                    } 
                    else
                    {
                        break;    
                    }
                } 
                else
                {
                    break;
                }
            }
            do
            {
                
            } while (true);
            return true;
        };

        //Create the game board
        Board gameBoard = new Board(6, 7, (Board, column) => throw new NotImplementedException());
    }


    //Determine the number of players that are in the game
    //TODO: Determine which players are AI and human.
    private int DeterminePlayerNumber()
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
            else if (answer <= 1)
            {
                Console.WriteLine("Please enter a number above 1.");
            }
        }
        Console.WriteLine("You have " + answer + " players in the game.");
        return answer;
    }

    private Player[] DeterminePlayers()
    {
        Player[] players = new Player[_numberOfPlayers];

        //Determine the main players name, and add them to the array.
        players[0] = new Human(ConsoleColor.Yellow, getName());

        //Determine the type of each other player.
        for (int i = 1; i < _numberOfPlayers; i++)
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

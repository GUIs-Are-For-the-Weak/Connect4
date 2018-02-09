using System;

class Game
{

    private int _numberOfPlayers; //Number of players in the game TODO: Determine if AI or Human
    private int _gameType; //Number in a row needed for a win
    private Func<Board, int, bool> winCondition; //The condition necassary to win

    //Constructor
    public Game(int numberOfPlayers, int rowsToWin)
    {
        _numberOfPlayers = numberOfPlayers;
        _gameType = rowsToWin;
        winCondition = delegate(Board board, int column) 
        {
            int row = 0;
            int inlineCount = 0;
            Player currentToken, nextToken;
            bool changeDirection = false;
            //Get the position of the token that was just placed
            for (int i = 6; i >= 0; i--)
            {
                if(board[i, column] != '-')
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
        SetupBoard();
    }

    //Start the game
    public void SetupBoard()
    {
        //Create the board
        Board board = new Board(6, 7, (Board, column) => throw new NotImplementedException());
    }

}
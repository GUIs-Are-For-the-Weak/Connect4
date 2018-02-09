using System;

class Game
{

    private int _numberOfPlayers; //Number of players in the game TODO: Determine if AI or Human
    private int _gameType; //Number in a row needed for a win

    //Constructor
    public Game(int numberOfPlayers, int rowsToWin)
    {
        _numberOfPlayers = numberOfPlayers;
        _gameType = rowsToWin;
        SetupBoard();
    }

    //Start the game
    public void SetupBoard()
    {
        //Create the board
        Board board = new Board(6, 7, (Board, column) => throw new NotImplementedException());
    }

}
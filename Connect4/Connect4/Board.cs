using System;

class Board
{
    private Player[,] _board;

    /// <summary>
    /// Initialises a Connect4 game Board with the specified height, width and winning condition.
    /// </summary>
    /// <param name="height">The height of the game Board</param>
    /// <param name="width">The width of the game Board</param>
    /// <param name="winCheck">A function to run to check if the game has been won. 
    /// Takes the game Board and a zero-based column in which the last piece was placed. 
    /// Should return true if the game has been won, false otherwise.</param>
    public Board(int height, int width)
    {
        _board = new Player[height, width];
        Draw();

    }

    /// <summary>
    /// Places a piece in a column on the board, if there is space.
    /// </summary>
    /// <param name="column">The zero-based column on the board in which to place the piece</param>
    /// <returns>true if the piece was placed, false if the column was full</returns>
    public bool PlacePiece(Player player, int column)
    {
        if (IsColumnFull(column))
            return false;

        //Place a piece on the board - lowest possible location in the column
        for(int i = _board.GetLength(0)-1; i > 0; i--)
        {
            if(_board[i, column] == null)
            {
                _board[i, column] = player;
                return true;
            }
        }
        return true;
    }


    //Checks if the column in the board has space for a piece.
    private bool IsColumnFull(int column) => _board[0, column] != null;

    public void Draw()
    {
        Console.WriteLine(" 1 2 3 4 5 6");
        for (int i = 0; i < _board.GetLength(0); i++)
        {
            for (int j = 0; j < _board.GetLength(1); j++)
            {
                Console.Write('|');
                Console.Write(_board[i,j]);
            }
            Console.Write('|');
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Creates a 2D Array of Players, representing pieces on the board.
    /// </summary>
    /// <returns>The 2D Player Array</returns>
    public Player[,] ToArray() => (Player[,])_board.Clone();




    public Player this[int row, int column] => _board[row,column];
}

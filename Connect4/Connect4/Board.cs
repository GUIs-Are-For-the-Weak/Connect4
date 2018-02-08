using System;

class Board
{
    private ConsoleColor[] colours = {ConsoleColor.Red, ConsoleColor.Yellow};
    private char[,] _board;
    private Func<Board, int, bool> checkIfWon;
    public Board(int height, int width, Func<Board, int, bool> winCheck)
    {
        SetUp(height, width);
        Draw();
        checkIfWon = winCheck;

    }

    public void SetUp(int rows, int columns)
    {
        _board = new char[rows, columns];
        for (int i = 0; i < _board.GetLength(0); i++ )
        {
            for (int j = 0; j < _board.GetLength(1); j++)
            {
                _board[i,j] = '-';
            }
        }
    }

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
    public event EndGame GameEnded;


    public int this[int row, int column]
    {
        get
        {
            return _board[row, column];
        }
    }
}


delegate void EndGame(/*null if draw*/Player winner);

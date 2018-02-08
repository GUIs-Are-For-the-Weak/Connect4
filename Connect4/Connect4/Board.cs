using System;

class Board 
{
    private ConsoleColor[] colours = {ConsoleColor.Red, ConsoleColor.Yellow};
    private int _rows = 6;
    private int _columns = 7;
    private char[,] _board;

    public Board()
    {
        SetUp();
    }
    public Board(int rows, int columns)
    {
        _rows = rows;
        _columns = columns;
        SetUp();

    }

    public void SetUp()
    {
        _board = new char[_columns, _rows];
        for (int i = 0; i < _columns; i++ )  
        {
            for (int j = 0; j < _rows; j++)
            {
                _board[i,j] = '-';
            }
        }
    }

    public void Draw()
    {
        Console.WriteLine(" 1 2 3 4 5 6");
        for (int i = 0; i < _columns; i++)
        {
            for (int j = 0; j < _rows; j++)
            {
                Console.Write('|');
                Console.Write(_board[i,j]);
            }
            Console.Write('|');
            Console.WriteLine();
        }
    }
    public int this[int row, int column]
    {
        get
        {
            return _board[row, column];
        }
    }
}
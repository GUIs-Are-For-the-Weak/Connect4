using System;

class Board 
{
    private ConsoleColor[] colours = {ConsoleColor.Red, ConsoleColor.Yellow};
    private int rows = 6;
    private int columns = 7;
    private char[,] board;
    public Board(int rows, int columns)
    {
        this.rows = rows;
        this.columns = columns;

        for (int i = 0; i < rows; i++ )  
        {
            for (int j = 0; j < columns; j++)
            {
                board[i,j] = '-';
            }
        }

    }

    public int this[int row, int column]
    {
        get
        {
            return board[row, column];
        }
    }
}
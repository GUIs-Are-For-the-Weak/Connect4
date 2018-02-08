using System;

class Board 
{
    private ConsoleColor[] colours = {ConsoleColor.Red, ConsoleColor.Yellow};
    private int rows = 6;
    private int columns = 7;
    private char[,] board;
    private Func<Board, int, bool> checkIfWon;
    public Board(int rows, int columns, Func<Board, int, bool> winCheck)
    {
        this.rows = rows;
        this.columns = columns;

        checkIfWon = winCheck;

        for (int i = 0; i < rows; i++ )  
        {
            for (int j = 0; j < columns; j++)
            {
                board[i,j] = '-';
            }
        }

    }

    public event EndGame GameEnded;


    public int this[int row, int column]
    {
        get
        {
            return board[row, column];
        }
    }
}

delegate void EndGame(/*null if draw*/Player winner);
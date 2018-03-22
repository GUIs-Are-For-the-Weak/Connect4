using System;

class Human : Player
{
    public Human(ConsoleColor colour, string name) : base(colour, name)
    {
    }

    /// <summary>
    /// Gets the player to select a column to place their token into.
    /// </summary>
    /// <param name="board">The game board</param>
    /// <returns>The column number (zero-indexed) the player chose to place their piece</returns>
    public override int TakeTurn(Player[,] board)
    {
        int column;
        do
        {
            Console.Write("Enter column: ");
            while (!int.TryParse(Console.ReadLine(), out column) || column < 1 || column > board.GetLength(1))
                Console.Write($"Please enter an integer between 1 and {board.GetLength(1)}\nEnter column: ");

            if (board[0, column - 1] != null)
                Console.WriteLine("This column is full! Try again...");

        } while (board[0, column - 1] != null);
        return column - 1;
    }
}
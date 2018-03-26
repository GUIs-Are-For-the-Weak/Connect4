using System;
using System.Threading;

namespace Connect4
{
    static class Program
    {

        static void Main(string[] args)
        {
            //Game repeat loop
            bool loop = true;
            do
            {
                Console.Clear();
                Game game = new Game(StandardWinCondition, WinHandler);
                Console.WriteLine("Do you want to play another game? Y/N");
                bool check = true;
                do
                {
                    string answer = Console.ReadLine();
                    if (answer == "n")
                    {
                        Console.WriteLine("Press enter to close this window...");
                        loop = false;
                        check = false;
                    }
                    else if (answer == "y")
                    {
                        Console.WriteLine("Starting a new game...");
                        Thread.Sleep(2000); //2 second wait time
                        //Console.Clear();
                        check = false;
                    }
                    else
                    {
                        Console.WriteLine("Please enter Y or N.");
                    }
                } while (check);
            } while (loop);

            Console.ReadLine(); //Needed to stop the console window from closing
        }

        //Game win handler - print the winner to the console.
        public static void WinHandler(Player winner)
        {
            Console.WriteLine($"{winner?.ToString() ?? "No one"} won the game!");
        }

        //The normal Connect4 win condition - 4 in a row horizontally, vertically or diagonally.
        public static bool StandardWinCondition(Board board)
        {
            bool checkHorizontal()
            {
                for (int i = 0; i < board.Height; i++)
                {
                    for (int j = 0; j < board.Width - 3; j++)
                    {
                        if (board[i, j] == null)
                            continue;

                        if (board[i, j] == board[i, j + 1] && board[i, j] == board[i, j + 2] && board[i, j] == board[i, j + 3])
                            return true;
                    }
                }
                return false;
            }

            bool checkVertical()
            {
                for (int i = 0; i < board.Height - 3; i++)
                {
                    for (int j = 0; j < board.Width; j++)
                    {
                        if (board[i, j] == null)
                            continue;

                        if (board[i, j] == board[i + 1, j] && board[i, j] == board[i + 2, j] && board[i, j] == board[i + 3, j])
                            return true;
                    }
                }
                return false;
            }

            bool checkMainDiagonal()
            {
                for (int i = 0; i < board.Height - 3; i++)
                {
                    for (int j = 0; j < board.Width - 3; j++)
                    {
                        if (board[i, j] == null)
                            continue;

                        if (board[i, j] == board[i + 1, j + 1] && board[i, j] == board[i + 2, j + 2] && board[i, j] == board[i + 3, j + 3])
                            return true;
                    }
                }
                return false;
            }

            bool checkMinorDiagonal()
            {
                for (int i = 3; i < board.Height; i++)
                {
                    for (int j = 0; j < board.Width - 3; j++)
                    {
                        if (board[i, j] == null)
                            continue;

                        if (board[i, j] == board[i - 1, j + 1] && board[i, j] == board[i - 2, j + 2] && board[i, j] == board[i - 3, j + 3])
                            return true;
                    }
                }
                return false;
            }

            return checkMainDiagonal() || checkMinorDiagonal() || checkHorizontal() || checkVertical();
        }

    }
}

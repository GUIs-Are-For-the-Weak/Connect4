using System;
using System.Threading;

namespace Connect4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Game repeat loop
            bool loop = true;
            do
            {
                Console.Clear();
                Game game = new Game(StandardWinCondition);
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
                    } else if (answer == "y")
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

        //The normal Connect4 win condition.
        //TODO: Finish writing this method!
        public static bool StandardWinCondition(Board board, int column)
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
            for (int i = 0; i < 4; i++)
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
        }
       
    }
}

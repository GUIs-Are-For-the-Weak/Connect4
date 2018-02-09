using System;

namespace Connect4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Game repeat loop
            Console.Clear();
            bool loop = true;
            do
            {
                Game game = new Game(StandardWinCondition);
                Console.WriteLine("Do you want to play another game? Y/N");
                if(Console.ReadLine().ToLower() == "n")
                {
                    loop = false;
                }
            } while (loop);

            Console.ReadLine(); //Needed to stop the console window from closing
        }

        private static bool StandardWinCondition(Board board, int column)
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
       
    }
}

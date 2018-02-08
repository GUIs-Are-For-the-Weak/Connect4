using System;

namespace Connect4
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(DeterminePlayers(), 4); //2 players, 4 in a row to win
            Console.ReadLine(); //Needed to stop the console window from closing
        }

        //Determine the number of players that are in the game
        //TODO: Determine which players are AI and human.
        private static int DeterminePlayers()
        {
            Console.WriteLine("How many players do you want?");
            int answer = 0;
            while (answer <= 1)
            {
                //Determine if the input is an integer, and store it in answer if it is.
                if (!(Int32.TryParse(Console.ReadLine(), out answer)))
                {
                    Console.WriteLine("Please enter an integer.");
                }
                else if(answer <= 1)
                {
                    Console.WriteLine("Please enter a number above 1.");
                }
            }
            Console.WriteLine("You have " + answer + " players in the game.");
            return answer;
        }
    }
}

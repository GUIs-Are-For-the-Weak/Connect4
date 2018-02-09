using System;

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
                Game game = new Game();
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
                        System.Threading.Thread.Sleep(2000); //2 second wait time
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

       
    }
}

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
                Game game = new Game();
                Console.WriteLine("Do you want to play another game? Y/N");
                if(Console.ReadLine().ToLower() == "n")
                {
                    loop = false;
                }
            } while (loop);

            Console.ReadLine(); //Needed to stop the console window from closing
        }

       
    }
}

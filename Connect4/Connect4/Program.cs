using System;

namespace Connect4
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.Draw();
            Console.ReadLine();
        }
    }
}

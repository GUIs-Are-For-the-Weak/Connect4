using System;

class Human : Player
{
    public Human(ConsoleColor colour, string name) : base(colour, name)
    {
    }

    public override int TakeTurn(Player[,] board)
    {
        int columnChoice = 0;
        do
        {
            Console.Write("Column choice: ");
            if (int.TryParse(Console.ReadLine(), out columnChoice))
            {
                if(columnChoice >=1 && columnChoice <= 7)
                    return columnChoice - 1; //Zero index!
                columnChoice = 0;
                Console.WriteLine("Columns only number between 1 and 7");
            }
            else
            {
                Console.WriteLine("Please enter an integer");
            }
        } while (columnChoice == 0);
        return 0;
    }
}
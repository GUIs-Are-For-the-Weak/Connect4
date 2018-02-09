using System;

class Human : Player
{
    public Human(ConsoleColor colour, string name) : base(colour, name)
    {
    }

    public override int TakeTurn()
    {
        int columnChoice = 0;
        do
        {
            if (Int32.TryParse(Console.ReadLine(), out columnChoice))
            {
                if(columnChoice >=1 && columnChoice <= 7)
                    return columnChoice;
                columnChoice = 0;
                System.Console.WriteLine("Columns only number between 1 and 7");
            }
            else
            {
                System.Console.WriteLine("Please enter an integer");
            }
        } while (columnChoice == 0);
        return 0;
    }
}
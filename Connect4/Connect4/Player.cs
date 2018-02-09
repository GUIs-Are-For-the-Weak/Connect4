using System;

abstract class Player
{
    public string Name { get; }
    public ConsoleColor Colour { get; }

    public Player(ConsoleColor colour, string name)
    {
        Colour = colour;
        Name = name;
    }

    public abstract int TakeTurn();    
}

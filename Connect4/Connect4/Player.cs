using System;

abstract class Player
{
    public String Name { get; set; }
    public ConsoleColor Colour { get; }

    public Player(ConsoleColor colour)
    {
        Colour = colour;
        _name = name;
    }

    public abstract int TakeTurn();    
}

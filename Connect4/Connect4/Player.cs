using System;

abstract class Player
{
    private String _name;
    public ConsoleColor Colour { get; }
    public Player(ConsoleColor colour, String name)
    {
        Colour = colour;
        _name = name;
    }

    abstract public int TakeTurn();    
}
using System;

abstract class Player
{
    private String _name;
    private ConsoleColor _colour;
    public Player(ConsoleColor colour, String name)
    {
        _colour = colour;
        _name = name;
    }

    abstract public int TakeTurn();    
}
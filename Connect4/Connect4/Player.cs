using System;

abstract class Player
{
    private String _name;
    private ConsoleColor _colour;
    public Player(ConsoleColor colour)
    {
        _colour = colour;
       
    }

    public void SetName(String name)
    {
        _name = name;
    }

    public String GetName()
    {
        return _name;
    }

    abstract public int TakeTurn();    
}
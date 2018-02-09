using System;

class AI : Player
{

    private ConsoleColor _colour;
    private Board _board;

    //Constructor - take a colour and the board being played.
    public AI(ConsoleColor colour, Board board) : base(colour, name: "AI")
    {
        _colour = colour;
        _board = board; 
    }

    public override int TakeTurn()
    {
        throw new NotImplementedException();
    }
}
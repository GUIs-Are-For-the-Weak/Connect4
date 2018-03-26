using System;

class AI : Player
{

    //Constructor - take a colour and the board being played.
    public AI(ConsoleColor colour) : base(colour, name: "AI")
    {
    }

    public override int TakeTurn(Player[,] board)
    {
        throw new NotImplementedException();
    }
}
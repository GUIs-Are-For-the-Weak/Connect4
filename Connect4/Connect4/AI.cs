using System;
using System.Collections.Generic;

class AI : Player
{

    //Constructor - take a colour and the board being played.
    public AI(ConsoleColor colour) : base(colour, name: "AI")
    {

    }

    public override int TakeTurn(Player[,] board)
    {
        var columnOptions = new List<(int column, int sequenceLength)>();
        var bestPosition = (column: 0, sequenceLength: 0);
        for (int i = 0; i < board.GetLength(0); i++)
        {            
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[i,j] == this)
                {
                    columnOptions.Add(Test(i,j));
                }
            }
        }

        
        foreach (var position in columnOptions)
        {
            if(position.sequenceLength > bestPosition.sequenceLength){
                bestPosition = position;
            }
        }
        System.Console.WriteLine(bestPosition.column);
        return bestPosition.column;

        (int column, int sequenceLength) Test(int row, int column)
        {
            int positionsMoved, inRow, largestRow, bestColumn;
            bool horizontal, vertical;

            horizontal = true;
            vertical = false;
            largestRow = 1;
            inRow = 1;
            positionsMoved = 1;
            bestColumn = 1;

            //Checks to the right, the left, above, and below the given position
            //Looks for an unbroken sequence of itself on the board
            for (int i = 0; i <= 4; i++)
            {
                //After 2 iterations, the values reset and the orientation switches
                if(i%2==0)
                {
                    //Checks if the new sequence is the largest one found
                    if(inRow > largestRow)
                    {
                        largestRow = inRow;
                        bestColumn = column+positionsMoved;
                    }
                    positionsMoved = 1;
                    inRow = 1;
                    horizontal = !horizontal;
                    vertical = !vertical;
                }
                else
                {
                      if(inRow > largestRow)
                    {
                        largestRow = inRow;
                        bestColumn = column+positionsMoved;
                    }
                    positionsMoved = -1;
                }

                //Checks around the given position, looking for an unbroken sequence of itself
                for (int j = 1; j <= 3; j++)
                {
                    if(horizontal && row+positionsMoved>0 && row+positionsMoved<board.GetLength(0))
                    {
                        if(board[row+positionsMoved, column]!=this)
                        {
                            break;
                        }
                        inRow++;
                    }
                    else if(vertical && column+positionsMoved>0 && column+positionsMoved<board.GetLength(1))
                    {
                        if(board[row, column+positionsMoved]!=this)
                        {
                            break;
                        }
                        inRow++;
                    }
                    else
                    {
                        break;
                    }
                    positionsMoved = positionsMoved > 0 ? ++positionsMoved : --positionsMoved;
                }      
            }
            System.Console.WriteLine(bestColumn);
            System.Console.WriteLine("Hello");
            var bestOption = (bestColumn, largestRow);
            return bestOption;
        }  
    }
}
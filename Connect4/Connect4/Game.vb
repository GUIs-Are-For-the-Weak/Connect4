
Imports System

Class Game

    Private Shared ReadOnly _colours As ConsoleColor() = {ConsoleColor.Yellow, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Blue}

    Private _players As Player()

    Private _gameBoard As Board

    Public Sub New(ByVal winCondition As Func(Of Board, Boolean), ByVal Optional gameEndHandler As EndGame = Nothing)
        If gameEndHandler IsNot Nothing Then AddHandler GameEnded, gameEndHandler
        _players = DeterminePlayers()
        _gameBoard = CreateBoard()
        Dim playerIndex As Integer = -1
        Dim gameState As Boolean = False
        While Not gameState
            playerIndex = System.Threading.Interlocked.Increment(playerIndex) Mod _players.Length
            _gameBoard.Draw()
            If Not _gameBoard.PlacePiece(_players(playerIndex), _players(playerIndex).TakeTurn(_gameBoard.ToArray())) Then Throw New Exception("Column index out of bounds or column is full.")
            gameState = winCondition(_gameBoard)
            If Not gameState Then
                gameState = True
                For i As Integer = 0 To _gameBoard.Width - 1
                    If _gameBoard(0, i) Is Nothing Then
                        gameState = False
                        Exit For
                    End If
                Next

                If gameState Then playerIndex = -1
            End If
        End While

        _gameBoard.Draw()
        GameEnded(If(playerIndex = -1, Nothing, _players(playerIndex)))
    End Sub

    Private Shared Function DeterminePlayerNumber() As Integer
        Console.Write("Enter the number of players: ")
        Dim answer As Integer
        While Not Integer.TryParse(Console.ReadLine(), answer) OrElse answer < 2 OrElse answer > 4
            Console.Write("Please enter an integer of at least 2, and no more than 4." & vbLf & "Enter the number of players: ")
        End While

        Return answer
    End Function

    Private Shared Function DeterminePlayers() As Player()
        Dim players As Player() = New Player(DeterminePlayerNumber() - 1) {}
        players(0) = New Human(_colours(0), GetPlayerName())
        For i As Integer = 1 To players.Length - 1
            Console.WriteLine($"What should player {i + 1} be?")
            Console.WriteLine("1. A human player.")
            Console.WriteLine("2. An AI player." & vbLf)
            Console.Write("Choice: ")
            Dim choice As Integer
            While Not Integer.TryParse(Console.ReadLine(), choice) OrElse choice < 1 OrElse choice > 2
                Console.Write("Please enter either 1 or 2." & vbLf & "Choice:  ")
            End While

            Select Case choice
                Case 1
                    players(i) = New Human(_colours(i), GetPlayerName())
                Case 2
                    players(i) = New AI(_colours(i))
            End Select
        Next

        Return players
    End Function

    Private Shared Function GetPlayerName() As String
        Console.Write("Enter player name: ")
        Return Console.ReadLine()
    End Function

    Private Shared Function CreateBoard() As Board
        Dim width, height As Integer
        Console.WriteLine("Would you like to use the default board size?")
        Console.Write("Y/N: ")
        Dim answer As String = Console.ReadLine()
        While Not(answer.ToLower() = "y" OrElse answer.ToLower() = "n")
            Console.WriteLine("Please enter Y or N.")
            Console.Write("Y/N: ")
            answer = Console.ReadLine()
        End While

        If answer.ToLower() = "y" Then
            height = 6
            width = 7
        Else
            Console.Write("Enter your height: ")
            While Not Integer.TryParse(Console.ReadLine(), height) OrElse height < 4
                Console.WriteLine("Please enter a number larger than 4.")
                Console.Write("Enter your height: ")
            End While

            Console.Write("Enter your width: ")
            While Not Integer.TryParse(Console.ReadLine(), width) OrElse width < 4
                Console.WriteLine("Please enter a number larger than 4.")
                Console.Write("Enter your width: ")
            End While
        End If

        Return New Board(height, width)
    End Function

    Public Event GameEnded As EndGame
End Class

Delegate Sub EndGame(ByVal winner As Player)

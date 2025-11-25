using System.Text;

namespace BattleShips.Tests;

public class Player(Fleet fleet)
{
    private readonly string[,] _board = InitializeBoard();

    private static string[,] InitializeBoard()
    {
        var constructedBoard = new string[10, 10];
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                constructedBoard[x, y] = "|";
            }
        }

        return constructedBoard;
    }

    public void Init()
    {
        fleet.LocateFleets(_board);
    }

    public string PrintBoard()
    {
        var boardPrint = new StringBuilder("  0 1 2 3 4 5 6 7 8 9");
        for (int row = 0; row < _board.GetLength(0); row++)
        {
            boardPrint.AppendLine(" ");
            boardPrint.Append(row);
            for (int column = 0; column < _board.GetLength(1); column++)
            {
                boardPrint.Append($" {_board[row, column]}"); 
            }
        }
        
        return boardPrint.Append(' ').ToString();
    }
    public string ReceiveShot(Coord coord) => fleet.ReceiveShot(_board, coord);
    
}
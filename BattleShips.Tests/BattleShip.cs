using System.Text;

namespace BattleShips.Tests;

public class BattleShip
{
    private int _numberOfPlayers;
    private int _currentPlayer;
    private string[,] _board;
    

    public BattleShip()
    {
        _board = new string[10, 10];
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                _board[x, y] = "|";
            }
        }
    }

    public void AddPlayer(Fleet fleet)
    {
        if (_numberOfPlayers == 2)
            throw new NotSupportedException();
        _numberOfPlayers++;
    }

    public void Start()
    {
        if (_numberOfPlayers <= 1)
            throw new NotSupportedException();
        _board = new[,]
        {
            { "|", "|", "|", "|", "|", "|", "|", "|", "|", "g" },
            { "|", "|", "|", "|", "|", "|", "|", "|", "|", "g" },
            { "|", "|", "|", "|", "|", "|", "|", "|", "|", "g" },
            { "|", "|", "|", "|", "|", "|", "|", "|", "|", "g" },
            { "|", "|", "|", "|", "|", "|", "|", "d", "d", "d" },
            { "|", "|", "|", "|", "|", "|", "|", "d", "d", "d" },
            { "|", "|", "|", "|", "|", "|", "c", "c", "c", "c" },
            { "|", "|", "|", "|", "|", "|", "|", "|", "|", "|" },
            { "|", "|", "|", "|", "|", "|", "|", "|", "|", "|" },
            { "|", "|", "|", "|", "|", "|", "|", "|", "|", "|" }
        };
    }

    public string Print()
    {
        var boardPrint = new StringBuilder("  0 1 2 3 4 5 6 7 8 9");
        for (int x = 0; x < 10; x++)
        {
            boardPrint.AppendLine(" ");
            boardPrint.Append(x);
            for (int y = 0; y < 10; y++)
            {
                boardPrint.Append($" {_board[x, y]}"); 
            }
        }
        
        boardPrint.Append(" ");
        return boardPrint.ToString();
    }

    public void EndTurn()
    {
        _board = new[,]
        {
            { "g", "|", "|", "|", "|", "|", "|", "|", "|", "|" },
            { "g", "|", "|", "|", "|", "|", "|", "|", "|", "|" },
            { "g", "|", "|", "|", "|", "|", "|", "|", "|", "|" },
            { "g", "|", "|", "|", "|", "|", "|", "|", "|", "|" },
            { "d", "d", "d", "|", "|", "|", "|", "|", "|", "|" },
            { "d", "d", "d", "|", "|", "|", "|", "|", "|", "|" },
            { "c", "c", "c", "c", "|", "|", "|", "|", "|", "|" },
            { "|", "|", "|", "|", "|", "|", "|", "|", "|", "|" },
            { "|", "|", "|", "|", "|", "|", "|", "|", "|", "|" },
            { "|", "|", "|", "|", "|", "|", "|", "|", "|", "|" }
        };
    }
}
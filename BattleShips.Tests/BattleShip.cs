using System.Text;

namespace BattleShips.Tests;

public class BattleShip
{
    private int _numberOfPlayers;
    private string[,] _board;

    public BattleShip()
    {
        _board = new string[10, 10];
        IterateBoardWithAction((x, y) => _board[x, y] = "|");
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

    public string Print()
    {
        var boardPrint = new StringBuilder("  0 1 2 3 4 5 6 7 8 9");
        IterateBoardWithAction(x =>
            {
                boardPrint.AppendLine(" ");
                boardPrint.Append(x);
            },
            (x, y) => { boardPrint.Append($" {_board[x, y]}"); });


        boardPrint.Append(" ");
        return boardPrint.ToString();
    }

    private void IterateBoardWithAction(Action<int> actionInRowLoop, Action<int, int> actionInColumnLoop)
    {
        for (int x = 0; x < 10; x++)
        {
            actionInRowLoop.Invoke(x);
            for (int y = 0; y < 10; y++)
            {
                actionInColumnLoop.Invoke(x, y);
            }
        }
    }

    private void IterateBoardWithAction(Action<int, int> actionInColumnLoop)
    {
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                actionInColumnLoop.Invoke(x, y);
            }
        }
    }
}
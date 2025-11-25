using System.Text;

namespace BattleShips.Tests;

public class BattleShip
{
    private readonly List<Player> _players = [];
    private int _numberOfPlayers;
    private int _attackedPlayerPosition = 1;
    private string[,] CurrentBoard => _players[_attackedPlayerPosition].Board;

    public void AddPlayer(Fleet fleet)
    {
        if (_numberOfPlayers == 2)
            throw new NotSupportedException();
        _numberOfPlayers++;
        _players.Add(new Player(fleet));
    }

    public void Start()
    {
        if (_numberOfPlayers <= 1)
            throw new NotSupportedException();
        
        _players.ForEach(player => player.Init());
    }

    public string Print()
    {
        var boardPrint = new StringBuilder("  0 1 2 3 4 5 6 7 8 9");
        for (int x = 0; x < CurrentBoard.GetLength(0); x++)
        {
            boardPrint.AppendLine(" ");
            boardPrint.Append(x);
            for (int y = 0; y < CurrentBoard.GetLength(1); y++)
            {
                boardPrint.Append($" {CurrentBoard[x, y]}"); 
            }
        }
        
        boardPrint.Append(" ");
        return boardPrint.ToString();
    }

    public void EndTurn()
    {
        _attackedPlayerPosition = _attackedPlayerPosition == 0 ? 1 : 0;
    }

    public string Fire(Coord coord)
    {
        _players[_attackedPlayerPosition].RecieveShot(coord);
        return String.Empty;
    }
}
using System.Text;

namespace BattleShips.Tests;

public class BattleShip
{
    private readonly List<Player> _players = [];
    private int _numberOfPlayers;
    private int _attackedPlayerPosition = 1;
    private Coord _lastShotCoord;
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

    public string Print() => _players[_attackedPlayerPosition].PrintBoard();

    public void EndTurn()
    {
        _attackedPlayerPosition = _attackedPlayerPosition == 0 ? 1 : 0;
    }

    public string Fire(Coord coord)
    {
        if(_players[_attackedPlayerPosition].IsCoordHowWaterShot(_lastShotCoord))
            throw new InvalidOperationException("No puede seguir disparando porque su ultimo disparo fue al agua.");
        _lastShotCoord = coord;
        return _players[_attackedPlayerPosition].ReceiveShot(coord);
    }
}
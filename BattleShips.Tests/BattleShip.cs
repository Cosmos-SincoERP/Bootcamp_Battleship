namespace BattleShips.Tests;

public partial class BattleShip
{
    private int _cantidadJugadores;

    public void AddPlayer(Fleet fleet)
    {
        if (_cantidadJugadores == 2)
            throw new NotSupportedException();
        _cantidadJugadores++;
    }

    public void Start()
    {
        throw new NotSupportedException();
    }
}
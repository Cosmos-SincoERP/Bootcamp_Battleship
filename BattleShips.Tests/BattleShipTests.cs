
using AwesomeAssertions;

namespace BattleShips.Tests;

public class BattleShipTests
{
    [Fact]
    public void Cuando_AgregoUnJugador_NoDebe_ArrojarException()
    {
        var battleship = new BattleShip();

        var action = () => battleship.AddPlayer();

        action.Should().NotThrow();
    }

    [Fact]
    public void Cuando_AgregoTresJugadores_Debe_ArrojarException()
    {
        var battleShip = new BattleShip();
        battleShip.AddPlayer();
        battleShip.AddPlayer();
        
        var action = () => battleShip.AddPlayer();

        action.Should().ThrowExactly<ArgumentOutOfRangeException>();
    }
    
}

public class BattleShip
{
    private int _cantidadJugadores;
    public void AddPlayer()
    {
        if (_cantidadJugadores == 2)
            throw new ArgumentOutOfRangeException();
        _cantidadJugadores++;
        
    }
}
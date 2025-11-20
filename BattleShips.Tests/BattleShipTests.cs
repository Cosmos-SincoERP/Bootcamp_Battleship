
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

        action.Should().ThrowExactly<NotSupportedException>();
    }

    [Fact]
    public void Cuando_InicioElJuegoSinJugadores_Debe_ArrojarException()
    {
        var battleShip = new BattleShip();

        var action = () => battleShip.Start();

        action.Should().ThrowExactly<NotSupportedException>();
    }
    
}

public class BattleShip
{
    private int _cantidadJugadores;
    public void AddPlayer()
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

using AwesomeAssertions;

namespace BattleShips.Tests;

public class BattleShipTests
{
    [Fact]
    public void Cuando_AgregoUnJugador_NoDebe_ArrojarException()
    {
        var battleship = new BattleShip();

        var action = () => battleship.AddPlayer(["Cañonero"]);

        action.Should().NotThrow();
    }
    
    [Fact]
    public void Cuando_AgregoTresJugadores_Debe_ArrojarException()
    {
        var battleShip = new BattleShip();
        battleShip.AddPlayer(["Cañonero"]);
        battleShip.AddPlayer(["Cañonero"]);
        
        var action = () => battleShip.AddPlayer(["Cañonero"]);

        action.Should().ThrowExactly<NotSupportedException>();
    }

    [Fact]
    public void Cuando_InicioElJuegoSinJugadores_Debe_ArrojarException()
    {
        var battleShip = new BattleShip();

        var action = () => battleShip.Start();

        action.Should().ThrowExactly<NotSupportedException>();
    }

    [Fact]
    public void Cuando_AgregoUnJugadorSinBarcos_Debe_ArrojarExcepcion()
    {
        var battleship = new BattleShip();
        
        var action = () => battleship.AddPlayer([]);

        action.Should().ThrowExactly<ArgumentException>();
    }

    [Fact]
    public void Cuando_AgregoUnJugadorCon1Cañoneros_Debe_ArrojarExcepcion()
    {
        var battleship = new BattleShip();

        var action = () => battleship.AddPlayer(["Cañonero", "Cañonero", "Cañonero"]);

        action.Should().ThrowExactly<ArgumentException>();
    }
}

public class BattleShip
{
    private int _cantidadJugadores;
    public void AddPlayer(List<object> chips)
    {
        if (chips.Count is 0 or 3)
            throw new ArgumentException();
        if (_cantidadJugadores == 2)
            throw new NotSupportedException();
        _cantidadJugadores++;
        
    }

    public void Start()
    {
        throw new NotSupportedException();
    }
}
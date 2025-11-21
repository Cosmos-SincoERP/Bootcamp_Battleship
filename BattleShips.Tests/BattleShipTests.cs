
using AwesomeAssertions;

namespace BattleShips.Tests;

public class BattleShipTests
{
    [Fact]
    public void Cuando_AgregoUnJugador_NoDebe_ArrojarException()
    {
        var battleship = new BattleShip();

        var action = () => battleship.AddPlayer(["Cañonero", "Cañonero", "Cañonero", "Cañonero", "Destructor", "Destructor", "Portaavion"]);

        action.Should().NotThrow();
    }
    
    [Fact]
    public void Cuando_AgregoTresJugadores_Debe_ArrojarException()
    {
        var battleShip = new BattleShip();
        battleShip.AddPlayer(["Cañonero", "Cañonero", "Cañonero", "Cañonero", "Destructor", "Destructor", "Portaavion"]);
        battleShip.AddPlayer(["Cañonero", "Cañonero", "Cañonero", "Cañonero", "Destructor", "Destructor", "Portaavion"]);
        
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

        action.Should().ThrowExactly<ArgumentException>().WithMessage("Deben ser 4 cañoneros por jugador.");
    }

    [Fact]
    public void Cuando_AgregoUnJugadorCon3Cañoneros_Debe_ArrojarExcepcion()
    {
        var battleship = new BattleShip();

        var action = () => battleship.AddPlayer(["Cañonero", "Cañonero", "Cañonero"]);

        action.Should().ThrowExactly<ArgumentException>("Deben ser 4 cañoneros por jugador.");
    }

    [Fact]
    public void Cuando_AgregoUnJugadorCon5Cañoneros_Debe_ArrojarExcepcion()
    {
        var battleship = new BattleShip();

        var action = () => battleship.AddPlayer(["Cañonero", "Cañonero", "Cañonero", "Cañonero", "Cañonero"]);

        action.Should().ThrowExactly<ArgumentException>("Deben ser 4 cañoneros por jugador.");
    }

    [Fact]
    public void Cuando_AgregoUnJugadorCon5CañonerosY1Destructor_Debe_ArrojarExcepcion()
    {
        var battleship = new BattleShip();
        

        var action = () => battleship.AddPlayer([
            "Cañonero", "Cañonero", "Cañonero", "Cañonero",
            "Destructor"
        ]);

        action.Should().Throw<ArgumentException>().WithMessage("Deben ser 2 destructores por jugador.");
    }

    [Fact]
    public void Cuando_AgregoUnJugadorCon4CañonerosY3Destructores_Debe_ArrojarExcepcion()
    {
        var battleship = new BattleShip();
        
        var action = () => battleship.AddPlayer([
            "Cañonero","Cañonero","Cañonero","Cañonero", 
            "Destructor", "Destructor", "Destructor"
        ]);

        action.Should().ThrowExactly<ArgumentException>("Deben ser 2 destructores por jugador.");
    }

    [Fact]
    public void Cuando_AgregoUnJugadorSinNingunPortaavion_Debe_ArrojarExcepcion()
    {
        var battleship = new BattleShip();
        var action = () => battleship.AddPlayer([
            "Cañonero", "Cañonero", "Cañonero", "Cañonero",
            "Destructor", "Destructor"
        ]);

        action.Should().ThrowExactly<ArgumentException>("Debe ser 1 portaavion por jugador.");
    }

    [Fact]
    public void Cuando_AgregoUnJugadorCon2Portaaviones_Debe_ArrojarExcepcion()
    {
        var battleship = new BattleShip();
        
        var action = () => battleship.AddPlayer([
            "Cañonero", "Cañonero", "Cañonero", "Cañonero",
            "Destructor", "Destructor",
            "Portaavion", "Portaavion"
        ]);

        action.Should().ThrowExactly<ArgumentException>("Debe ser 1 portaavion por jugador.");
    }
}

public class BattleShip
{
    private int _cantidadJugadores;
    public void AddPlayer(List<object> ships)
    {
        if (_cantidadJugadores == 2)
            throw new NotSupportedException();
        if (ships.Count(ship => ship == "Cañonero") != 4)
            throw new ArgumentException("Deben ser 4 cañoneros por jugador.");
        if (ships.Count(ship => ship == "Destructor") != 2 )
            throw new ArgumentException("Deben ser 2 destructores por jugador.");
        if (ships.Count(ship => ship == "Portaavion") != 1)
            throw new ArgumentException("Debe ser 1 portaavion por jugador.");
        _cantidadJugadores++;
        
    }

    public void Start()
    {
        throw new NotSupportedException();
    }
}
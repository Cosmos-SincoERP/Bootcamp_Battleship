
using AwesomeAssertions;

namespace BattleShips.Tests;

public class BattleShipTests
{
    [Fact]
    public void Cuando_AgregoUnJugador_NoDebe_ArrojarException()
    {
        var battleship = new BattleShip();

        var action = () => battleship.AddPlayer(["Cañonero", "Cañonero", "Cañonero", "Cañonero", "Destructor", "Destructor"]);

        action.Should().NotThrow();
    }
    
    [Fact]
    public void Cuando_AgregoTresJugadores_Debe_ArrojarException()
    {
        var battleShip = new BattleShip();
        battleShip.AddPlayer(["Cañonero", "Cañonero", "Cañonero", "Cañonero", "Destructor", "Destructor"]);
        battleShip.AddPlayer(["Cañonero", "Cañonero", "Cañonero", "Cañonero", "Destructor", "Destructor"]);
        
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
            "Cañonero",
            "Cañonero",
            "Cañonero",
            "Cañonero",
            "Destructor"
        ]);

        action.Should().Throw<ArgumentException>().WithMessage("Deben ser 2 destructores por jugador.");
    }

    [Fact]
    public void Cuando_AgregoUnJugadorCon4CañonerosY3Destructores_Debe_ArrojarExcepcion()
    {
        var battleship = new BattleShip();
        
        var action = () => battleship.AddPlayer(["Cañonero","Cañonero","Cañonero","Cañonero", "Destructor", "Destructor", "Destructor"]);

        action.Should().ThrowExactly<ArgumentException>("Deben ser 2 destructores por jugador.");
    }
}

public class BattleShip
{
    private int _cantidadJugadores;
    public void AddPlayer(List<object> chips)
    {
        if (_cantidadJugadores == 2)
            throw new NotSupportedException();
        if (chips.Count(chip => chip == "Cañonero") != 4)
            throw new ArgumentException("Deben ser 4 cañoneros por jugador.");
        if (chips.Count(chip => chip == "Destructor") != 2 )
            throw new ArgumentException("Deben ser 2 destructores por jugador.");
        _cantidadJugadores++;
        
    }

    public void Start()
    {
        throw new NotSupportedException();
    }
}
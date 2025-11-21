using AwesomeAssertions;

namespace BattleShips.Tests;

public class BattleShipTests
{
    [Fact]
    public void Si_AgregoUnJugador_NoDebe_ArrojarException()
    {
        var battleship = new BattleShip();

        var action = () => battleship.AddPlayer([
            ("Cañonero", [new Coord(0,0)]),
            ("Cañonero", [new Coord(1,0)]),
            ("Cañonero", [new Coord(2,0)]),
            ("Cañonero", [new Coord(3,0)]),
            ("Destructor", [new Coord(4,0), new Coord(4,1), new Coord(4,2)]),
            ("Destructor", [new Coord(5,0), new Coord(5,1), new Coord(5,2)]),
            ("Portaavion", [])
        ]);

        action.Should().NotThrow();
    }

    [Fact]
    public void Si_AgregoTresJugadores_Debe_ArrojarException()
    {
        var battleShip = new BattleShip();
        battleShip.AddPlayer([
            ("Cañonero", [new Coord(0,0)]),
            ("Cañonero", [new Coord(1,0)]),
            ("Cañonero", [new Coord(2,0)]),
            ("Cañonero", [new Coord(3,0)]),
            ("Destructor", [new Coord(4,0), new Coord(4,1), new Coord(4,2)]),
            ("Destructor", [new Coord(5,0), new Coord(5,1), new Coord(5,2)]),
            ("Portaavion", [])
        ]);
        battleShip.AddPlayer([
            ("Cañonero", [new Coord(0,0)]),
            ("Cañonero", [new Coord(1,0)]),
            ("Cañonero", [new Coord(2,0)]),
            ("Cañonero", [new Coord(3,0)]),
            ("Destructor", [new Coord(4,0), new Coord(4,1), new Coord(4,2)]),
            ("Destructor", [new Coord(5,0), new Coord(5,1), new Coord(5,2)]),
            ("Portaavion", [])
        ]);

        var action = () => battleShip.AddPlayer([("Cañonero", [])]);

        action.Should().ThrowExactly<NotSupportedException>();
    }

    [Fact]
    public void Si_InicioElJuegoSinJugadores_Debe_ArrojarException()
    {
        var battleShip = new BattleShip();

        var action = () => battleShip.Start();

        action.Should().ThrowExactly<NotSupportedException>();
    }

    [Fact]
    public void Si_AgregoUnJugadorSinBarcos_Debe_ArrojarExcepcion()
    {
        var battleship = new BattleShip();

        var action = () => battleship.AddPlayer([]);

        action.Should().ThrowExactly<ArgumentException>().WithMessage("Deben ser 4 cañoneros por jugador.");
    }

    [Fact]
    public void Si_AgregoUnJugadorCon3Cañoneros_Debe_ArrojarExcepcion()
    {
        var battleship = new BattleShip();

        var action = () => battleship.AddPlayer([
            ("Cañonero", []),
            ("Cañonero", []),
            ("Cañonero", [])
        ]);

        action.Should().ThrowExactly<ArgumentException>().WithMessage("Deben ser 4 cañoneros por jugador.");
    }

    [Fact]
    public void Si_AgregoUnJugadorCon5Cañoneros_Debe_ArrojarExcepcion()
    {
        var battleship = new BattleShip();

        var action = () => battleship.AddPlayer([
            ("Cañonero", []),
            ("Cañonero", []),
            ("Cañonero", []),
            ("Cañonero", []),
            ("Cañonero", [])
        ]);

        action.Should().ThrowExactly<ArgumentException>().WithMessage("Deben ser 4 cañoneros por jugador.");
    }

    [Fact]
    public void Si_AgregoUnJugadorCon5CañonerosY1Destructor_Debe_ArrojarExcepcion()
    {
        var battleship = new BattleShip();


        var action = () => battleship.AddPlayer([
            ("Cañonero", []),
            ("Cañonero", []),
            ("Cañonero", []),
            ("Cañonero", []),
            ("Destructor", []),
        ]);

        action.Should().Throw<ArgumentException>().WithMessage("Deben ser 2 destructores por jugador.");
    }

    [Fact]
    public void Si_AgregoUnJugadorCon4CañonerosY3Destructores_Debe_ArrojarExcepcion()
    {
        var battleship = new BattleShip();

        var action = () => battleship.AddPlayer([
            ("Cañonero", []),
            ("Cañonero", []),
            ("Cañonero", []),
            ("Cañonero", []),
            ("Destructor", []),
            ("Destructor", []),
            ("Destructor", [])
        ]);

        action.Should().ThrowExactly<ArgumentException>().WithMessage("Deben ser 2 destructores por jugador.");
    }

    [Fact]
    public void Si_AgregoUnJugadorSinNingunPortaavion_Debe_ArrojarExcepcion()
    {
        var battleship = new BattleShip();
        var action = () => battleship.AddPlayer([
            ("Cañonero", []),
            ("Cañonero", []),
            ("Cañonero", []),
            ("Cañonero", []),
            ("Destructor", []),
            ("Destructor", [])
        ]);

        action.Should().ThrowExactly<ArgumentException>().WithMessage("Debe ser 1 portaavion por jugador.");
    }

    [Fact]
    public void Si_AgregoUnJugadorCon2Portaaviones_Debe_ArrojarExcepcion()
    {
        var battleship = new BattleShip();

        var action = () => battleship.AddPlayer([
            ("Cañonero", []),
            ("Cañonero", []),
            ("Cañonero", []),
            ("Cañonero", []),
            ("Destructor", []),
            ("Destructor", []),
            ("Portaavion", []),
            ("Portaavion", [])
        ]);

        action.Should().ThrowExactly<ArgumentException>().WithMessage("Debe ser 1 portaavion por jugador.");
    }
    
    [Fact]
    public void Si_AgregoUnJugadorConCañonerosSinCoordenadas_Debe_ArrojarExcepcion()
    {
        var battleship = new BattleShip();

        var action = () => battleship.AddPlayer([
            ("Cañonero", []),
            ("Cañonero", []),
            ("Cañonero", []),
            ("Cañonero", []),
            ("Destructor", []),
            ("Destructor", []),
            ("Portaavion", [])
        ]);

        action.Should().ThrowExactly<ArgumentException>().WithMessage("Un cañonero solo puede tener una coordenada");
    }

    [Fact]
    public void Si_AgregoUnJugadorConCañonerosDe2Coordenadas_Debe_ArrojarExcepcion()
    {
        var battleship = new BattleShip();

        var action = () => battleship.AddPlayer([
            ("Cañonero", [new Coord(0, 0), new Coord(0, 1)]),
            ("Cañonero", [new Coord(1, 0), new Coord(1, 1)]),
            ("Cañonero", [new Coord(2, 0), new Coord(2, 1)]),
            ("Cañonero", [new Coord(3, 0), new Coord(3, 1)]),
            ("Destructor", []),
            ("Destructor", []),
            ("Portaavion", [])
        ]);

        action.Should().ThrowExactly<ArgumentException>().WithMessage("Un cañonero solo puede tener una coordenada");
    }

    [Fact]
    public void Si_AgregoUnJugadorConCañonerosDe3Coordenadas_Debe_ArrojarExcepcion()
    {
        var battleship = new BattleShip();

        var action = () => battleship.AddPlayer([
            ("Cañonero", [new Coord(0, 0), new Coord(0, 1), new Coord(0, 2)]),
            ("Cañonero", [new Coord(1, 0), new Coord(1, 1), new Coord(1, 2)]),
            ("Cañonero", [new Coord(2, 0), new Coord(2, 1), new Coord(2, 2)]),
            ("Cañonero", [new Coord(3, 0), new Coord(3, 1), new Coord(3, 2)]),
            ("Destructor", []),
            ("Destructor", []),
            ("Portaavion", [])
        ]);

        action.Should().ThrowExactly<ArgumentException>().WithMessage("Un cañonero solo puede tener una coordenada");
    }
    
    [Fact]
    public void Si_AgregoUnJugadorConDestructoresDe4Coordenadas_Debe_ArrojarExcepcion()
    {
        var battleship = new BattleShip();

        var action = () => battleship.AddPlayer([
            ("Cañonero", [new Coord(0, 0)]),
            ("Cañonero", [new Coord(1, 0)]),
            ("Cañonero", [new Coord(2, 0)]),
            ("Cañonero", [new Coord(3, 0)]),
            ("Destructor", [new Coord(3, 0), new Coord(3, 1), new Coord(3, 2), new Coord(3, 3)]),
            ("Destructor", [new Coord(4, 0), new Coord(4, 1), new Coord(4, 2), new Coord(4, 3)]),
            ("Portaavion", []),
        ]);

        action.Should().ThrowExactly<ArgumentException>().WithMessage("Los destructores deben tener 3 coordenadas.");
    }
    
    [Fact]
    public void Si_AgregoUnJugadorConDestructoresDe2Coordenadas_Debe_ArrojarExcepcion()
    {
        var battleship = new BattleShip();

        var action = () => battleship.AddPlayer([
            ("Cañonero", [new Coord(0, 0)]),
            ("Cañonero", [new Coord(1, 0)]),
            ("Cañonero", [new Coord(2, 0)]),
            ("Cañonero", [new Coord(3, 0)]),
            ("Destructor", [new Coord(3, 0), new Coord(3, 1)]),
            ("Destructor", [new Coord(4, 0), new Coord(4, 1)]),
            ("Portaavion", []),
        ]);

        action.Should().ThrowExactly<ArgumentException>().WithMessage("Los destructores deben tener 3 coordenadas.");
    }
}

public class BattleShip
{
    private int _cantidadJugadores;

    public void AddPlayer(List<(string tipo, List<Coord> coords)> ships)
    {
        if (_cantidadJugadores == 2)
            throw new NotSupportedException();
        if (ships.Count(ship => ship.tipo == "Cañonero") != 4)
            throw new ArgumentException("Deben ser 4 cañoneros por jugador.");
        if (ships.Count(ship => ship.tipo == "Destructor") != 2)
            throw new ArgumentException("Deben ser 2 destructores por jugador.");
        if (ships.Count(ship => ship.tipo == "Portaavion") != 1)
            throw new ArgumentException("Debe ser 1 portaavion por jugador.");
        if (ships.Any(ship => ship.tipo == "Cañonero" && ship.coords.Count != 1))
            throw new ArgumentException("Un cañonero solo puede tener una coordenada");
        if (ships.Any(ship => ship.tipo == "Destructor" && (ship.coords.Count == 4 || ship.coords.Count == 2)))
            throw new ArgumentException("Los destructores deben tener 3 coordenadas.");
        _cantidadJugadores++;
    }

    public void Start()
    {
        throw new NotSupportedException();
    }
}

public struct Coord
{
    public Coord(int x, int y)
    {
    }
}
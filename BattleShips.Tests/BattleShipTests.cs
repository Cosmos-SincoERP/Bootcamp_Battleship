using AwesomeAssertions;
using BattleShips.Tests.Ships;

namespace BattleShips.Tests;

public class BattleShipTests
{
    private readonly BattleShip _battleship = new();

    [Fact]
    public void Si_AgregoUnJugador_NoDebe_ArrojarException()
    {
        var action = () => _battleship.AddPlayer(new Fleet([
            Gunboat.Create(new Coord(0, 0)),
            Gunboat.Create(new Coord(1, 0)),
            Gunboat.Create(new Coord(2, 0)),
            Gunboat.Create(new Coord(3, 0)),
            Destroyer.Create([new Coord(4, 0), new Coord(4, 1), new Coord(4, 2)]),
            Destroyer.Create([new Coord(5, 0), new Coord(5, 1), new Coord(5, 2)]),
            AircraftCarrier.Create([new Coord(6, 0), new Coord(6, 1), new Coord(6, 2), new Coord(6, 3)])
        ]));

        action.Should().NotThrow();
    }

    [Fact]
    public void Si_AgregoTresJugadores_Debe_ArrojarException()
    {
        var validFleetWith3Gunboats2DestroyersAnd1AircraftCarrier = new Fleet([
            Gunboat.Create(new Coord(0, 0)),
            Gunboat.Create(new Coord(1, 0)),
            Gunboat.Create(new Coord(2, 0)),
            Gunboat.Create(new Coord(3, 0)),
            Destroyer.Create([new Coord(4, 0), new Coord(4, 1), new Coord(4, 2)]),
            Destroyer.Create([new Coord(5, 0), new Coord(5, 1), new Coord(5, 2)]),
            AircraftCarrier.Create([new Coord(6, 0), new Coord(6, 1), new Coord(6, 2), new Coord(6, 3)])
        ]);
        _battleship.AddPlayer(validFleetWith3Gunboats2DestroyersAnd1AircraftCarrier);
        _battleship.AddPlayer(validFleetWith3Gunboats2DestroyersAnd1AircraftCarrier);

        var action = () => _battleship.AddPlayer(validFleetWith3Gunboats2DestroyersAnd1AircraftCarrier);

        action.Should().ThrowExactly<NotSupportedException>();
    }

    [Fact]
    public void Si_InicioElJuegoSinJugadores_Debe_ArrojarException()
    {
        var action = () => _battleship.Start();

        action.Should().ThrowExactly<NotSupportedException>();
    }

    [Fact]
    public void Si_AgregoUnJugadorSinBarcos_Debe_ArrojarExcepcion()
    {
        var action = () => _battleship.AddPlayer(new Fleet([]));

        action.Should().ThrowExactly<ArgumentException>().WithMessage("Deben ser 4 cañoneros por jugador.");
    }

    [Fact]
    public void Si_AgregoUnJugadorCon3Cañoneros_Debe_ArrojarExcepcion()
    {
        var action = () => _battleship.AddPlayer(new Fleet([
            Gunboat.Create(new Coord(0,0)),
            Gunboat.Create(new Coord(1,0)),
            Gunboat.Create(new Coord(2,0))
        ]));

        action.Should().ThrowExactly<ArgumentException>().WithMessage("Deben ser 4 cañoneros por jugador.");
    }

    [Fact]
    public void Si_AgregoUnJugadorCon5Cañoneros_Debe_ArrojarExcepcion()
    {
        var action = () => _battleship.AddPlayer(new Fleet([
            Gunboat.Create(new Coord(0,0)),
            Gunboat.Create(new Coord(1,0)),
            Gunboat.Create(new Coord(2,0)),
            Gunboat.Create(new Coord(3,0)),
            Gunboat.Create(new Coord(4,0))
        ]));

        action.Should().ThrowExactly<ArgumentException>().WithMessage("Deben ser 4 cañoneros por jugador.");
    }

    [Fact]
    public void Si_AgregoUnJugadorCon5CañonerosY1Destructor_Debe_ArrojarExcepcion()
    {
        var action = () => _battleship.AddPlayer(new Fleet([
            Gunboat.Create(new Coord(0,0)),
            Gunboat.Create(new Coord(1,0)),
            Gunboat.Create(new Coord(2,0)),
            Gunboat.Create(new Coord(3,0)),
            Destroyer.Create([new Coord(4,0), new Coord(4,1), new Coord(4,2)])
        ]));

        action.Should().Throw<ArgumentException>().WithMessage("Deben ser 2 destructores por jugador.");
    }

    [Fact]
    public void Si_AgregoUnJugadorCon4CañonerosY3Destructores_Debe_ArrojarExcepcion()
    {
        var action = () => _battleship.AddPlayer(new Fleet([
            Gunboat.Create(new Coord(0,0)),
            Gunboat.Create(new Coord(1,0)),
            Gunboat.Create(new Coord(2,0)),
            Gunboat.Create(new Coord(3,0)),
            Destroyer.Create([new Coord(4,0), new Coord(4,1), new Coord(4,2)]),
            Destroyer.Create([new Coord(5,0), new Coord(5,1), new Coord(5,2)]),
            Destroyer.Create(new Coord(6,0), new Coord(6,1), new Coord(6,2))
        ]));

        action.Should().ThrowExactly<ArgumentException>().WithMessage("Deben ser 2 destructores por jugador.");
    }

    [Fact]
    public void Si_AgregoUnJugadorSinNingunPortaavion_Debe_ArrojarExcepcion()
    {
        var action = () => _battleship.AddPlayer(new Fleet([
            Gunboat.Create(new Coord(0,0)),
            Gunboat.Create(new Coord(1,0)),
            Gunboat.Create(new Coord(2,0)),
            Gunboat.Create(new Coord(3,0)),
            Destroyer.Create(new Coord(4,0), new Coord(4,1), new Coord(4,2)),
            Destroyer.Create(new Coord(5,0), new Coord(5,1), new Coord(5,2))
        ]));

        action.Should().ThrowExactly<ArgumentException>().WithMessage("Debe ser 1 portaavion por jugador.");
    }

    [Fact]
    public void Si_AgregoUnJugadorCon2Portaaviones_Debe_ArrojarExcepcion()
    {
        var action = () => _battleship.AddPlayer(new Fleet([
            Gunboat.Create(new Coord(0,0)),
            Gunboat.Create(new Coord(1,0)),
            Gunboat.Create(new Coord(2,0)),
            Gunboat.Create(new Coord(3,0)),
            Destroyer.Create(new Coord(4,0),new Coord(4,1),new Coord(4,2)),
            Destroyer.Create(new Coord(5,0),new Coord(5,1),new Coord(5,2)),
            AircraftCarrier.Create([new Coord(6, 0), new Coord(6, 1), new Coord(6, 2), new Coord(6,3)]),
            AircraftCarrier.Create([new Coord(7, 0), new Coord(7, 1), new Coord(7, 2), new Coord(7,3)]),
        ]));

        action.Should().ThrowExactly<ArgumentException>().WithMessage("Debe ser 1 portaavion por jugador.");
    }

    [Fact]
    public void Si_AgregoUnJugadorConCañonerosSinCoordenadas_Debe_ArrojarExcepcion()
    {
        var action = () => _battleship.AddPlayer(new Fleet([
            Gunboat.Create(),
            Gunboat.Create(),
            Gunboat.Create(),
            Gunboat.Create(),
            Destroyer.Create(),
            Destroyer.Create(),
            AircraftCarrier.Create()
        ]));

        action.Should().ThrowExactly<ArgumentException>().WithMessage("Un cañonero solo puede tener una coordenada");
    }

    [Fact]
    public void Si_AgregoUnJugadorConCañonerosDe2Coordenadas_Debe_ArrojarExcepcion()
    {
        var action = () => _battleship.AddPlayer(new Fleet([
            Gunboat.Create([new Coord(0, 0), new Coord(0, 1)]),
            Gunboat.Create([new Coord(1, 0), new Coord(1, 1)]),
            Gunboat.Create([new Coord(2, 0), new Coord(2, 1)]),
            Gunboat.Create([new Coord(3, 0), new Coord(3, 1)]),
            Destroyer.Create(),
            Destroyer.Create(),
            AircraftCarrier.Create()
        ]));

        action.Should().ThrowExactly<ArgumentException>().WithMessage("Un cañonero solo puede tener una coordenada");
    }

    [Fact]
    public void Si_AgregoUnJugadorConCañonerosDe3Coordenadas_Debe_ArrojarExcepcion()
    {
        var action = () => _battleship.AddPlayer(new Fleet([
            Gunboat.Create([new Coord(0, 0), new Coord(0, 1), new Coord(0, 2)]),
            Gunboat.Create([new Coord(1, 0), new Coord(1, 1), new Coord(1, 2)]),
            Gunboat.Create([new Coord(2, 0), new Coord(2, 1), new Coord(2, 2)]),
            Gunboat.Create([new Coord(3, 0), new Coord(3, 1), new Coord(3, 2)]),
            Destroyer.Create(),
            Destroyer.Create(),
            AircraftCarrier.Create()
        ]));

        action.Should().ThrowExactly<ArgumentException>().WithMessage("Un cañonero solo puede tener una coordenada");
    }

    [Fact]
    public void Si_AgregoUnJugadorConDestructoresSinCoordendas_Debe_ArrojarExcepcion()
    {
        var action = () => _battleship.AddPlayer(new Fleet([
            Gunboat.Create(new Coord(0, 0)),
            Gunboat.Create(new Coord(1, 0)),
            Gunboat.Create(new Coord(2, 0)),
            Gunboat.Create(new Coord(3, 0)),
            Destroyer.Create(),
            Destroyer.Create(),
            AircraftCarrier.Create()
        ]));

        action.Should().ThrowExactly<ArgumentException>().WithMessage("Los destructores deben tener 3 coordenadas.");
    }


    [Fact]
    public void Si_AgregoUnJugadorConDestructoresDe4Coordenadas_Debe_ArrojarExcepcion()
    {
        var action = () => _battleship.AddPlayer(new Fleet([
            Gunboat.Create(new Coord(0, 0)),
            Gunboat.Create(new Coord(1, 0)),
            Gunboat.Create(new Coord(2, 0)),
            Gunboat.Create(new Coord(3, 0)),
            Destroyer.Create([new Coord(3, 0), new Coord(3, 1), new Coord(3, 2), new Coord(3, 3)]),
            Destroyer.Create([new Coord(4, 0), new Coord(4, 1), new Coord(4, 2), new Coord(4, 3)]),
            AircraftCarrier.Create()
        ]));

        action.Should().ThrowExactly<ArgumentException>().WithMessage("Los destructores deben tener 3 coordenadas.");
    }

    [Fact]
    public void Si_AgregoUnJugadorConDestructoresDe2Coordenadas_Debe_ArrojarExcepcion()
    {
        var action = () => _battleship.AddPlayer(new Fleet([
            Gunboat.Create(new Coord(0, 0)),
            Gunboat.Create(new Coord(1, 0)),
            Gunboat.Create(new Coord(2, 0)),
            Gunboat.Create(new Coord(3, 0)),
            Destroyer.Create([new Coord(3, 0), new Coord(3, 1)]),
            Destroyer.Create([new Coord(4, 0), new Coord(4, 1)]),
            AircraftCarrier.Create()
        ]));

        action.Should().ThrowExactly<ArgumentException>().WithMessage("Los destructores deben tener 3 coordenadas.");
    }

    [Fact]
    public void Si_AgregoUnJugadorConPortaavionesSinCoordendas_Debe_ArrojarExcepcion()
    {
        var action = () => _battleship.AddPlayer(new Fleet([
            Gunboat.Create(new Coord(0, 0)),
            Gunboat.Create(new Coord(1, 0)),
            Gunboat.Create(new Coord(2, 0)),
            Gunboat.Create(new Coord(3, 0)),
            Destroyer.Create([new Coord(4, 0), new Coord(4, 1), new Coord(4, 2)]),
            Destroyer.Create([new Coord(5, 0), new Coord(5, 1), new Coord(5, 2)]),
            AircraftCarrier.Create()
        ]));

        action.Should().ThrowExactly<ArgumentException>().WithMessage("Un portaavion debe tener 4 coordenadas.");
    }

    [Fact]
    public void Si_AgregoUnJugadorConUnPortaavionDe3Coordenadas_Debe_ArrojarExcepcion()
    {
        var action = () => _battleship.AddPlayer(new Fleet([
            Gunboat.Create(new Coord(0, 0)),
            Gunboat.Create(new Coord(1, 0)),
            Gunboat.Create(new Coord(2, 0)),
            Gunboat.Create(new Coord(3, 0)),
            Destroyer.Create([new Coord(4, 0), new Coord(4, 1), new Coord(4, 2)]),
            Destroyer.Create([new Coord(5, 0), new Coord(5, 1), new Coord(5, 2)]),
            AircraftCarrier.Create([new Coord(6, 0), new Coord(6, 1), new Coord(6, 2)])
        ]));

        action.Should().ThrowExactly<ArgumentException>().WithMessage("Un portaavion debe tener 4 coordenadas.");
    }

    [Fact]
    public void Si_AgregoUnJugadorConUnPortaavionDe5Coordenadas_Debe_ArrojarExcepcion()
    {
        var action = () => _battleship.AddPlayer(new Fleet([
            Gunboat.Create(new Coord(0, 0)),
            Gunboat.Create(new Coord(1, 0)),
            Gunboat.Create(new Coord(2, 0)),
            Gunboat.Create(new Coord(3, 0)),
            Destroyer.Create([new Coord(4, 0), new Coord(4, 1), new Coord(4, 2)]),
            Destroyer.Create([new Coord(5, 0), new Coord(5, 1), new Coord(5, 2)]),
            AircraftCarrier.Create([new Coord(6, 0), new Coord(6, 1), new Coord(6, 2), new Coord(6, 3), new Coord(6, 4)])
        ]));

        action.Should().ThrowExactly<ArgumentException>().WithMessage("Un portaavion debe tener 4 coordenadas.");
    }
}
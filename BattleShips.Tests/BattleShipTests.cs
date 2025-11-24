using System.Text;
using AwesomeAssertions;
using BattleShips.Tests.Ships;

namespace BattleShips.Tests;

public class BattleShipTests
{
    private readonly BattleShip _battleship = new();

    private readonly Fleet _defaultFleetWithValidPositions = new([
        Gunboat.Create(new Coord(0,0)),
        Gunboat.Create(new Coord(1,0)),
        Gunboat.Create(new Coord(2,0)),
        Gunboat.Create(new Coord(3,0)),
        Destroyer.Create([new Coord(4,0), new Coord(4,1), new Coord(4,2)]),
        Destroyer.Create([new Coord(5,0),new Coord(5,1), new Coord(5,2)]),
        AircraftCarrier.Create([new Coord(6,0), new Coord(6,1), new Coord(6,2), new Coord(6,3)])
    ]);

    [Fact]
    public void Si_AgregoUnJugador_NoDebe_ArrojarException()
    {
        var action = () => _battleship.AddPlayer(_defaultFleetWithValidPositions);

        action.Should().NotThrow();
    }

    [Fact]
    public void Si_AgregoTresJugadores_Debe_ArrojarException()
    {
        _battleship.AddPlayer(_defaultFleetWithValidPositions);
        _battleship.AddPlayer(_defaultFleetWithValidPositions);

        var action = () => _battleship.AddPlayer(_defaultFleetWithValidPositions);

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
    
    [Fact]
    public void Si_InicioElJuegoSinJugadores_Debe_ArrojarException()
    {
        var action = () => _battleship.Start();

        action.Should().ThrowExactly<NotSupportedException>();
    }

    [Fact]
    public void Si_ImprimoElTableroSinIniciarPartida_Debe_MostrarVacio()
    {
        _battleship.AddPlayer(_defaultFleetWithValidPositions);
        _battleship.AddPlayer(_defaultFleetWithValidPositions);

        var board = _battleship.Print();

        var expectedBoardInArray = new[]
        {
            "  0 1 2 3 4 5 6 7 8 9 ",
            "0 | | | | | | | | | | ",
            "1 | | | | | | | | | | ",
            "2 | | | | | | | | | | ",
            "3 | | | | | | | | | | ",
            "4 | | | | | | | | | | ",
            "5 | | | | | | | | | | ",
            "6 | | | | | | | | | | ",
            "7 | | | | | | | | | | ",
            "8 | | | | | | | | | | ",
            "9 | | | | | | | | | | ",
        };

        var boardExpected = string.Join(Environment.NewLine, expectedBoardInArray);
        board.Should().Be(boardExpected);
    }

    [Fact]
    public void Si_ImprimenElTableroDespuesDeIniciarPartidaConDosJugadoresDeIgualTablero_Debe_MostrarLaPosicionDeLosBarcosDelPrimerJugador()
    {
        _battleship.AddPlayer(_defaultFleetWithValidPositions);
        _battleship.AddPlayer(_defaultFleetWithValidPositions);
        _battleship.Start();

        var board = _battleship.Print();
        
        var boardExpected = string.Join(Environment.NewLine, new[]
        {
            "  0 1 2 3 4 5 6 7 8 9 ",
            "0 g | | | | | | | | | ",
            "1 g | | | | | | | | | ",
            "2 g | | | | | | | | | ",
            "3 g | | | | | | | | | ",
            "4 d d d | | | | | | | ",
            "5 d d d | | | | | | | ",
            "6 c c c c | | | | | | ",
            "7 | | | | | | | | | | ",
            "8 | | | | | | | | | | ",
            "9 | | | | | | | | | | ",
        });

        board.Should().Be(boardExpected);
    }

    [Fact]
    public void Si_ElPrimerJugadorTerminaElTurnoYSeImprimeElTablero_Debe_MostrarElTableroDelSegundoJugador()
    {
        _battleship.AddPlayer(_defaultFleetWithValidPositions);
        _battleship.AddPlayer(new Fleet([
            Gunboat.Create(new Coord(0,9)),
            Gunboat.Create(new Coord(1,9)),
            Gunboat.Create(new Coord(2,9)),
            Gunboat.Create(new Coord(3,9)),
            Destroyer.Create([new Coord(4,7), new Coord(4,8), new Coord(4,9)]),
            Destroyer.Create([new Coord(5,7),new Coord(5,8), new Coord(5,9)]),
            AircraftCarrier.Create([new Coord(6,6), new Coord(6,7), new Coord(6,8), new Coord(6,9)])
        ]));
        _battleship.Start();
        _battleship.EndTurn();
        var currentBoard = _battleship.Print();
    
        var expectedBoardSecondPlayer = string.Join(Environment.NewLine, new[]
        {
            "  0 1 2 3 4 5 6 7 8 9 ",
            "0 | | | | | | | | | g ",
            "1 | | | | | | | | | g ",
            "2 | | | | | | | | | g ",
            "3 | | | | | | | | | g ",
            "4 | | | | | | | d d d ",
            "5 | | | | | | | d d d ",
            "6 | | | | | | c c c c ",
            "7 | | | | | | | | | | ",
            "8 | | | | | | | | | | ",
            "9 | | | | | | | | | | ",
        });

        currentBoard.Should().Be(expectedBoardSecondPlayer);
    }
}
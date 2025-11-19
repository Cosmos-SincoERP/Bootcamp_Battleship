using AwesomeAssertions;

namespace Test.BattleShip;

public class AcorazadosTest
{
    private static string TableroEsperado(char[,] tablero)
    {
        var tableroEsperado = string.Empty;
        for (var x = 0; x < tablero.GetLength(0); x++)
        {
            for (int y = 0; y < tablero.GetLength(1); y++)
            {
                tableroEsperado += tablero[x, y];
            }

            tableroEsperado += '\n';
        }

        return tableroEsperado;
    }

    [Fact]
    public void Si_SeAgregaJugador_Debe_ContenerJugador1()
    {
        var juegoAcorazado = new JuegoAcorazado();

        juegoAcorazado.AgregarJugador();

        juegoAcorazado.MostrarJugadores().Should().Contain("Jugador 1");
    }

    [Fact]
    public void Si_SeAgrega2Jugadores_Debe_ContenerJugador1YJugador2()
    {
        var juegoAcorazado = new JuegoAcorazado();

        juegoAcorazado.AgregarJugador();
        juegoAcorazado.AgregarJugador();

        juegoAcorazado.MostrarJugadores().Should().Contain("Jugador 1").And.Contain("Jugador 2");
    }

    [Fact]
    public void Si_SeIniciaElJuegoCon1Jugador_Debe_LanzarExcepcion()
    {
        var juegoAcorazado = new JuegoAcorazado();
        juegoAcorazado.AgregarJugador();

        var iniciarJuego = () => juegoAcorazado.Iniciar();

        iniciarJuego.Should().Throw<Exception>()
            .WithMessage("El juego no puede iniciarse hasta que se hayan agregado 2 jugadores");
    }

    [Fact]
    public void Si_SeIniciaElJuegoCon2Jugador_NoDebe_LanzarExcepcionPorCantidadDeJugadores()
    {
        var juegoAcorazado = new JuegoAcorazado();
        juegoAcorazado.AgregarJugador();
        juegoAcorazado.AgregarJugador();

        var iniciarJuego = () => juegoAcorazado.Iniciar();

        iniciarJuego.Should().NotThrow();
    }

    [Fact]
    public void Si_SeIniciaElJuegoConDosJugadoresElJugador1_Debe_ColocarUnCañoneroEnLaPosicion0_0()
    {
        var tamañoTablero = 10;
        var tablero = new char[tamañoTablero, tamañoTablero];
        tablero[0, 0] = 'g';
        var tableroEsperado = TableroEsperado(tablero);
        var juegoAcorazado = new JuegoAcorazado();
        juegoAcorazado.AgregarJugador();
        juegoAcorazado.AgregarJugador();

        List<(int, int)> coordenadasCañonero = new()
        {
            new(0, 0)
        };

        juegoAcorazado.Iniciar(coordenadasCañonero);

        juegoAcorazado.Imprimir().Should().Be(tableroEsperado);
    }

    [Fact]
    public void Si_SeIniciaElJuegoConDosJugadoresElJugador1_Debe_ColocarUnCañoneroEnLaPosicion4_5()
    {
        var tamañoTablero = 10;
        var tablero = new char[tamañoTablero, tamañoTablero];
        tablero[4, 5] = 'g';
        var tableroEsperado = TableroEsperado(tablero);
        var juegoAcorazado = new JuegoAcorazado();
        juegoAcorazado.AgregarJugador();
        juegoAcorazado.AgregarJugador();

        List<(int, int)> coordenadasCañonero = new()
        {
            new(4, 5)
        };

        juegoAcorazado.Iniciar(coordenadasCañonero);

        juegoAcorazado.Imprimir().Should().Be(tableroEsperado);
    }

    [Fact]
    public void
        Si_SeIniciaElJuegoConDosJugadoresElJugador1_Debe_ColocarUnCañoneroEnLaPosicion2_3_Y_OtroEnLaPosicion3_3()
    {
        var tamañoTablero = 10;
        var tablero = new char[tamañoTablero, tamañoTablero];
        tablero[2, 3] = 'g';
        tablero[3, 3] = 'g';
        var tableroEsperado = TableroEsperado(tablero);
        var juegoAcorazado = new JuegoAcorazado();
        juegoAcorazado.AgregarJugador();
        juegoAcorazado.AgregarJugador();

        List<(int, int)> coordenadasCañonero = new()
        {
            new(2, 3),
            new(3, 3)
        };

        juegoAcorazado.Iniciar(coordenadasCañonero);

        juegoAcorazado.Imprimir().Should().Be(tableroEsperado);
    }


    [Fact]
    public void Si_SeIniciaElJuegoConDosJugadoresElJugador1_Debe_ColocarUnPortavionesHorizontakEnLaPosicionInicial2_3()
    {
        var tamañoTablero = 10;
        var tablero = new char[tamañoTablero, tamañoTablero];
        tablero[2, 3] = 'c';
        tablero[2, 4] = 'c';
        tablero[2, 5] = 'c';
        tablero[2, 6] = 'c';

        var tableroEsperado = TableroEsperado(tablero);
        var juegoAcorazado = new JuegoAcorazado();
        juegoAcorazado.AgregarJugador();
        juegoAcorazado.AgregarJugador();

        List<(int, int)> coordenadasPortaAvion = new()
        {
            new(2, 3)
        };

        juegoAcorazado.Iniciar(coordenadasPortaAvion);

        juegoAcorazado.Imprimir().Should().Be(tableroEsperado);
    }
}

public class JuegoAcorazado
{
    private List<string> _jugadores = new();
    private char[,] _tablero = new char[10, 10];

    public void AgregarJugador()
    {
        _jugadores.Add(_jugadores.Count == 1 ? "Jugador 2" : "Jugador 1");
    }

    public List<string> MostrarJugadores()
    {
        return _jugadores;
    }

    public void Iniciar(List<(int, int)>? cañoneros = null)
    {
        if (_jugadores.Count != 2)
            throw new Exception("El juego no puede iniciarse hasta que se hayan agregado 2 jugadores");

        if (cañoneros != null)
            foreach (var cañon in cañoneros)
            {
                _tablero[cañon.Item1, cañon.Item2] = 'g';
            }
    }

    public string Imprimir()
    {
        var tablero = string.Empty;
        for (var x = 0; x < _tablero.GetLength(0); x++)
        {
            for (int y = 0; y < _tablero.GetLength(1); y++)
            {
                tablero += _tablero[x, y];
            }

            tablero += '\n';
        }

        return tablero;
    }
}
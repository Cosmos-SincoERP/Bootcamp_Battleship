using AwesomeAssertions;

namespace Test.BattleShip;

public class AcorazadosTest
{
    [Fact]
    public void Si_NoHayJugadoresYSeIniciaElJuego_Debe_LanzarUnaExcepcionPorCantidadDeJugadores()
    {
        var juegoAcorazado = new JuegoAcorazados();
        var iniciar = () => juegoAcorazado.Iniciar([]);

        iniciar.Should().Throw<Exception>()
            .WithMessage("No se puede iniciar el juego, debe haber al menos 2 jugadores");
    }

    [Fact]
    public void Si_HaySoloUnJugadoreYSeIniciaElJuego_Debe_LanzarUnaExcepcionPorCantidadDeJugadores()
    {
        var juegoAcorazado = new JuegoAcorazados();
        juegoAcorazado.AgregarJugador("Jugador 1");
        var iniciar = () => juegoAcorazado.Iniciar([]);

        iniciar.Should().Throw<Exception>()
            .WithMessage("No se puede iniciar el juego, debe haber al menos 2 jugadores");
    }

    [Fact]
    public void Si_TresJugadoreYSeIniciaElJuego_Debe_LanzarUnaExcepcionPorCantidadDeJugadores()
    {
        var juegoAcorazado = new JuegoAcorazados();
        juegoAcorazado.AgregarJugador("Jugador 1");
        juegoAcorazado.AgregarJugador("Jugador 2");
        juegoAcorazado.AgregarJugador("Jugador 3");
        var iniciar = () => juegoAcorazado.Iniciar([]);

        iniciar.Should().Throw<Exception>()
            .WithMessage("No se puede iniciar el juego, debe haber al menos 2 jugadores");
    }

    [Fact]
    public void Si_SeIniciaJuegoConDosJugadores_Debe_ImprimirElTableroDelJugadorUnoYDos()
    {
        var juegoAcorazado = new JuegoAcorazados();
        juegoAcorazado.AgregarJugador("Jugador 1");
        juegoAcorazado.AgregarJugador("Jugador 2");
        juegoAcorazado.Iniciar([]);

        string tableroEsperado = "\n" +
                         "   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | \n" +
                         "-------------------------------------------| \n" +
                         " 0 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 1 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 2 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 3 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 4 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 5 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 6 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 7 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 8 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 9 |   |   |   |   |   |   |   |   |   |   | \n" +
                         "-------------------------------------------| \n";

        string tableroJugador1 = juegoAcorazado.Imprimir("Jugador 1");
        string tableroJugador2 = juegoAcorazado.Imprimir("Jugador 2");



        tableroJugador1.Should().Be(tableroEsperado);
        tableroJugador2.Should().Be(tableroEsperado);

    }

    [Fact]
    public void Si_SeIniciaJuegoYElJugador1PosicionaElPortavionesHorizontalDesdeLaPosicion00_Debe_ImprimirTableroDelJugador1ConElPortavionesPosicionadoDesde00Hasta03()
    {
        var juegoAcorazado = new JuegoAcorazados();
        juegoAcorazado.AgregarJugador("Jugador 1");
        juegoAcorazado.AgregarJugador("Jugador 2");

        List<(int x, int y, char barco, int cantidadPosiciones)> barcosJugador1 = new()
        {
            (0, 0, 'c',4)
        };

        juegoAcorazado.Iniciar(barcosJugador1);

        string tableroEsperado = "\n" +
                         "   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | \n" +
                         "-------------------------------------------| \n" +
                         " 0 | c | c | c | c |   |   |   |   |   |   | \n" +
                         " 1 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 2 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 3 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 4 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 5 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 6 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 7 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 8 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 9 |   |   |   |   |   |   |   |   |   |   | \n" +
                         "-------------------------------------------| \n";

        string tableroJugador1 = juegoAcorazado.Imprimir("Jugador 1");

        tableroJugador1.Should().Be(tableroEsperado);
    }

    [Fact]
    public void Si_SeIniciaJuegoYElJugador1PosicionaElPortavionesHorizontalDesdeLaPosicion10_Debe_ImprimirTableroDelJugador1ConElPortavionesPosicionadoDesde00Hasta13()
    {
        var juegoAcorazado = new JuegoAcorazados();
        juegoAcorazado.AgregarJugador("Jugador 1");
        juegoAcorazado.AgregarJugador("Jugador 2");

        List<(int x, int y, char barco, int cantidadPosiciones)> barcosJugador1 = new()
        {
            (1, 0, 'c',4)
        };

        juegoAcorazado.Iniciar(barcosJugador1);

        string tableroEsperado = "\n" +
                         "   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | \n" +
                         "-------------------------------------------| \n" +
                         " 0 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 1 | c | c | c | c |   |   |   |   |   |   | \n" +
                         " 2 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 3 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 4 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 5 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 6 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 7 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 8 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 9 |   |   |   |   |   |   |   |   |   |   | \n" +
                         "-------------------------------------------| \n";

        string tableroJugador1 = juegoAcorazado.Imprimir("Jugador 1");

        tableroJugador1.Should().Be(tableroEsperado);
    }


    [Fact]
    public void Si_SeIniciaJuegoYElJugador1PosicionaElPortavionesVerticalDesdeLaPosicion00_Debe_ImprimirTableroDelJugador1ConElPortavionesPosicionadoDesde00Hasta30()
    {
        var juegoAcorazado = new JuegoAcorazados();
        juegoAcorazado.AgregarJugador("Jugador 1");
        juegoAcorazado.AgregarJugador("Jugador 2");

        List<(int x, int y, char barco, int cantidadPosiciones)> barcosJugador1 = new()
        {
            (1, 0, 'c',4)
        };

        juegoAcorazado.Iniciar(barcosJugador1);

        string tableroEsperado = "\n" +
                         "   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | \n" +
                         "-------------------------------------------| \n" +
                         " 0 | c |   |   |   |   |   |   |   |   |   | \n" +
                         " 1 | c |   |   |   |   |   |   |   |   |   | \n" +
                         " 2 | c |   |   |   |   |   |   |   |   |   | \n" +
                         " 3 | c |   |   |   |   |   |   |   |   |   | \n" +
                         " 4 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 5 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 6 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 7 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 8 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 9 |   |   |   |   |   |   |   |   |   |   | \n" +
                         "-------------------------------------------| \n";

        string tableroJugador1 = juegoAcorazado.Imprimir("Jugador 1");

        tableroJugador1.Should().Be(tableroEsperado);
    }


}

public class JuegoAcorazados
{
    public List<(string, char[,])> _jugadores { get; } = new();
    public void Iniciar(List<(int x, int y, char valor, int cantidadPosiciones)> barcosJugador1)
    {
        var tableroJugador1 = _jugadores[0].Item2;

        foreach (var barco in barcosJugador1)
        {
            for (int i = 0; i < barco.cantidadPosiciones; i++)
            {
                tableroJugador1[barco.x, barco.y + i] = barco.valor;
            }
        }


        if (_jugadores.Count != 2)
            throw new Exception("No se puede iniciar el juego, debe haber al menos 2 jugadores");
    }

    public void AgregarJugador(string nombre)
    {
        _jugadores.Add((nombre, new char[10, 10]));
    }

    public string Imprimir(string nombreJugador)
    {
        var tablero = _jugadores.FirstOrDefault(jugador => jugador.Item1 == nombreJugador).Item2;
        var visualizarTablero = string.Empty;

        visualizarTablero += "\n";

        visualizarTablero += "   |";
        for (int i = 0; i < tablero.GetLength(1); i++)
        {
            visualizarTablero += $" {i} |";
        }
        visualizarTablero += " \n";


        visualizarTablero += "-------------------------------------------| \n";

        for (var x = 0; x < tablero.GetLength(0); x++)
        {
            visualizarTablero += $" {x} |";
            for (int y = 0; y < tablero.GetLength(1); y++)
            {
                char valorAMostar = tablero[x, y] == '\0' ? ' ' : tablero[x, y];
                visualizarTablero += $" {valorAMostar} |";
            }
            visualizarTablero += " \n";
        }

        visualizarTablero += "-------------------------------------------| \n";

        return visualizarTablero;
    }
}
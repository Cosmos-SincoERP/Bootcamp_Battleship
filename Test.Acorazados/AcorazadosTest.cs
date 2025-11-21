using AwesomeAssertions;

namespace Test.BattleShip;

public class AcorazadosTest
{
    [Fact]
    public void Si_NoHayJugadoresYSeIniciaElJuego_Debe_LanzarUnaExcepcionPorCantidadDeJugadores()
    {
        var juegoAcorazado = new JuegoAcorazados();
        var iniciar = () => juegoAcorazado.Iniciar([], []);

        iniciar.Should().Throw<Exception>()
            .WithMessage("No se puede iniciar el juego, debe haber al menos 2 jugadores");
    }

    [Fact]
    public void Si_HaySoloUnJugadoreYSeIniciaElJuego_Debe_LanzarUnaExcepcionPorCantidadDeJugadores()
    {
        var juegoAcorazado = new JuegoAcorazados();
        juegoAcorazado.AgregarJugador("Jugador 1");
        var iniciar = () => juegoAcorazado.Iniciar([], []);

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
        var iniciar = () => juegoAcorazado.Iniciar([], []);

        iniciar.Should().Throw<Exception>()
            .WithMessage("No se puede iniciar el juego, debe haber al menos 2 jugadores");
    }

    [Fact]
    public void Si_SeIniciaJuegoConDosJugadores_Debe_ImprimirElTableroDelJugadorUnoYDos()
    {
        var juegoAcorazado = new JuegoAcorazados();
        juegoAcorazado.AgregarJugador("Jugador 1");
        juegoAcorazado.AgregarJugador("Jugador 2");
        juegoAcorazado.Iniciar([], []);

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

        List<(Coordenada, Barco, OrientacionBarco orientacion)> barcosJugador1 = new()
        {
            (new Coordenada (0, 0), new BarcoPortaviones(),OrientacionBarco.Horizontal)
        };

        juegoAcorazado.Iniciar(barcosJugador1, []);

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

        List<(Coordenada, Barco, OrientacionBarco orientacion)> barcosJugador1 = new()
        {
            (new Coordenada(1, 0), new BarcoPortaviones(),OrientacionBarco.Horizontal)
        };

        juegoAcorazado.Iniciar(barcosJugador1, []);

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

        List<(Coordenada, Barco, OrientacionBarco orientacion)> barcosJugador1 = new()
        {
            (new Coordenada(0, 0), new BarcoPortaviones(),OrientacionBarco.Vertical)
        };

        juegoAcorazado.Iniciar(barcosJugador1, []);

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


    [Fact]
    public void Si_SeIniciaJuegoYElJugador1PosicionaElPortavionesVerticalDesdeLaPosicion10_Debe_ImprimirTableroDelJugador1ConElPortavionesPosicionadoDesde00Hasta40()
    {
        var juegoAcorazado = new JuegoAcorazados();
        juegoAcorazado.AgregarJugador("Jugador 1");
        juegoAcorazado.AgregarJugador("Jugador 2");

        List<(Coordenada, Barco, OrientacionBarco orientacion)> barcosJugador1 = new()
        {
            (new Coordenada(1, 0), new BarcoPortaviones(),OrientacionBarco.Vertical)
        };

        juegoAcorazado.Iniciar(barcosJugador1, []);

        string tableroEsperado = "\n" +
                         "   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | \n" +
                         "-------------------------------------------| \n" +
                         " 0 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 1 | c |   |   |   |   |   |   |   |   |   | \n" +
                         " 2 | c |   |   |   |   |   |   |   |   |   | \n" +
                         " 3 | c |   |   |   |   |   |   |   |   |   | \n" +
                         " 4 | c |   |   |   |   |   |   |   |   |   | \n" +
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
    public void Si_SeIniciaJuegoConDosJugadoresYPosicionaLasNaves_Debe_ImprimirTableroDeLosJugadoresConLosBarcosPosicionado()
    {
        var juegoAcorazado = new JuegoAcorazados();
        juegoAcorazado.AgregarJugador("Jugador 1");
        juegoAcorazado.AgregarJugador("Jugador 2");

        List<(Coordenada, Barco, OrientacionBarco orientacion)> barcosJugador1 = new()
        {
            (new Coordenada(0, 0), new BarcoCañonero(),OrientacionBarco.Vertical),
            (new Coordenada(5, 5), new BarcoCañonero(),OrientacionBarco.Vertical),
        };

        List<(Coordenada, Barco, OrientacionBarco orientacion)> barcosJugador2 = new()
        {
            (new Coordenada(5, 0), new BarcoCañonero(),OrientacionBarco.Vertical),
            (new Coordenada(8, 8), new BarcoCañonero(),OrientacionBarco.Vertical),
        };

        juegoAcorazado.Iniciar(barcosJugador1, barcosJugador2);

        string tableroEsperadoJugador1 = "\n" +
                         "   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | \n" +
                         "-------------------------------------------| \n" +
                         " 0 | g |   |   |   |   |   |   |   |   |   | \n" +
                         " 1 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 2 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 3 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 4 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 5 |   |   |   |   |   | g |   |   |   |   | \n" +
                         " 6 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 7 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 8 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 9 |   |   |   |   |   |   |   |   |   |   | \n" +
                         "-------------------------------------------| \n";

        string tableroEsperadoJugador2 = "\n" +
                 "   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | \n" +
                 "-------------------------------------------| \n" +
                 " 0 |   |   |   |   |   |   |   |   |   |   | \n" +
                 " 1 |   |   |   |   |   |   |   |   |   |   | \n" +
                 " 2 |   |   |   |   |   |   |   |   |   |   | \n" +
                 " 3 |   |   |   |   |   |   |   |   |   |   | \n" +
                 " 4 |   |   |   |   |   |   |   |   |   |   | \n" +
                 " 5 | g |   |   |   |   |   |   |   |   |   | \n" +
                 " 6 |   |   |   |   |   |   |   |   |   |   | \n" +
                 " 7 |   |   |   |   |   |   |   |   |   |   | \n" +
                 " 8 |   |   |   |   |   |   |   |   | g |   | \n" +
                 " 9 |   |   |   |   |   |   |   |   |   |   | \n" +
                 "-------------------------------------------| \n";

        string tableroJugador1 = juegoAcorazado.Imprimir("Jugador 1");
        string tableroJugador2 = juegoAcorazado.Imprimir("Jugador 2");

        tableroJugador1.Should().Be(tableroEsperadoJugador1);

        tableroJugador2.Should().Be(tableroEsperadoJugador2);
    }
}

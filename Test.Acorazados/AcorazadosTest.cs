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
    public void Si_SeAgregaUnJugador_Debe_ColocarUnCañoneroEnLaPosicion0_0()
    {
        var tamañoTablero = 10;
        var tablero = new char[tamañoTablero, tamañoTablero];
        tablero[0, 0] = 'g';
        var tableroEsperado = TableroEsperado(tablero);
        var juegoAcorazado = new JuegoAcorazado();
        List<Coordenada> coordenadasCañonero = new()
        {
            new(0, 0, Nave.Cañonero, null)
        };

        juegoAcorazado.AgregarJugador(coordenadasCañonero);

        juegoAcorazado.Imprimir().Should().Be(tableroEsperado);
    }

    [Fact]
    public void Si_SeAgregaUnJugador_Debe_ColocarUnCañoneroEnLaPosicion4_5()
    {
        var tamañoTablero = 10;
        var tablero = new char[tamañoTablero, tamañoTablero];
        tablero[4, 5] = 'g';
        var tableroEsperado = TableroEsperado(tablero);
        var juegoAcorazado = new JuegoAcorazado();

        List<Coordenada> coordenadasCañonero = new()
        {
            new(4, 5, Nave.Cañonero, null)
        };

        juegoAcorazado.AgregarJugador(coordenadasCañonero);

        juegoAcorazado.Imprimir().Should().Be(tableroEsperado);
    }

    [Fact]
    public void Si_SeAgregaUnJugador_Debe_ColocarUnCañoneroEnLaPosicion2_3_Y_OtroEnLaPosicion3_3()
    {
        var tamañoTablero = 10;
        var tablero = new char[tamañoTablero, tamañoTablero];
        tablero[2, 3] = 'g';
        tablero[3, 3] = 'g';
        var tableroEsperado = TableroEsperado(tablero);
        var juegoAcorazado = new JuegoAcorazado();
        List<Coordenada> coordenadasCañonero = new()
        {
            new(2, 3, Nave.Cañonero, null),
            new(3, 3, Nave.Cañonero, null)
        };

        juegoAcorazado.AgregarJugador(coordenadasCañonero);

        juegoAcorazado.Imprimir().Should().Be(tableroEsperado);
    }

    [Fact]
    public void
        Si_SeAgregaUnJugadorYColocaUnPortavionesConOrientacionHorizontalEnLaPosicionInicial2_3_Debe_LaPosicionFinalSer5_3()
    {
        var tamañoTablero = 10;
        var tablero = new char[tamañoTablero, tamañoTablero];
        tablero[2, 3] = 'c';
        tablero[3, 3] = 'c';
        tablero[4, 3] = 'c';
        tablero[5, 3] = 'c';
        var tableroEsperado = TableroEsperado(tablero);
        var juegoAcorazado = new JuegoAcorazado();

        List<Coordenada> coordenadasPortaAvion = new()
        {
            new(2, 3, Nave.PortaAviones, "Horizontal")
        };
        juegoAcorazado.AgregarJugador(coordenadasPortaAvion);

        juegoAcorazado.Imprimir().Should().Be(tableroEsperado);
    }

    [Fact]
    public void
        Si_SeAgregaUnJugadorYColocaUnPortavionesConOrientacionHorizontalEnLaPosicionInicial5_2_Debe_LaPosicionFinalSer8_2()
    {
        var tamañoTablero = 10;
        var tablero = new char[tamañoTablero, tamañoTablero];
        tablero[5, 2] = 'c';
        tablero[6, 2] = 'c';
        tablero[7, 2] = 'c';
        tablero[8, 2] = 'c';
        var tableroEsperado = TableroEsperado(tablero);
        var juegoAcorazado = new JuegoAcorazado();
        List<Coordenada> coordenadasPortaAvion = new()
        {
            new(5, 2, Nave.PortaAviones, "Horizontal")
        };

        juegoAcorazado.AgregarJugador(coordenadasPortaAvion);

        juegoAcorazado.Imprimir().Should().Be(tableroEsperado);
    }

    [Fact]
    public void
        Si_SeAgregaUnJugadorYColocaUnPortavionesConOrientacionVerticalEnLaPosicionInicial5_2_Debe_LaPosicionFinalSer5_5()
    {
        var tamañoTablero = 10;
        var tablero = new char[tamañoTablero, tamañoTablero];
        tablero[5, 2] = 'c';
        tablero[5, 3] = 'c';
        tablero[5, 4] = 'c';
        tablero[5, 5] = 'c';
        var tableroEsperado = TableroEsperado(tablero);
        var juegoAcorazado = new JuegoAcorazado();
        List<Coordenada> coordenadasPortaAvion = new()
        {
            new(5, 2, Nave.PortaAviones, "Vertical")
        };

        juegoAcorazado.AgregarJugador(coordenadasPortaAvion);

        juegoAcorazado.Imprimir().Should().Be(tableroEsperado);
    }


    [Fact]
    public void
        Si_SeAgregaUnJugadorYColocaUnDestructorConOrientacionHorizontalEnLaPosicionInicial_2_2_Debe_LaPosicionFinalSer4_2()
    {
        var tamañoTablero = 10;
        var tablero = new char[tamañoTablero, tamañoTablero];
        tablero[2, 2] = 'd';
        tablero[3, 2] = 'd';
        tablero[4, 2] = 'd';
        var tableroEsperado = TableroEsperado(tablero);
        var juegoAcorazado = new JuegoAcorazado();

        List<Coordenada> coordenadasDetructor = new()
        {
            new(2, 2, Nave.Destructor, "Horizontal")
        };

        juegoAcorazado.AgregarJugador(coordenadasDetructor);

        juegoAcorazado.Imprimir().Should().Be(tableroEsperado);
    }


    [Fact]
    public void
        Si_SeAgregaUnJugadorYColocaUnDestructorConOrientacionHorizontalEnLaPosicionInicial_1_1_Debe_LaPosicionFinalSer4_1()
    {
        var tamañoTablero = 10;
        var tablero = new char[tamañoTablero, tamañoTablero];
        tablero[1, 1] = 'd';
        tablero[2, 1] = 'd';
        tablero[3, 1] = 'd';
        var tableroEsperado = TableroEsperado(tablero);
        var juegoAcorazado = new JuegoAcorazado();

        List<Coordenada> coordenadasDetructor = new()
        {
            new(1, 1, Nave.Destructor, "Horizontal")
        };

        juegoAcorazado.AgregarJugador(coordenadasDetructor);

        juegoAcorazado.Imprimir().Should().Be(tableroEsperado);
    }

    [Fact]
    public void
        Si_SeAgregaUnJugadorYColocaUnDestructorConOrientacionVerticalEnLaPosicionInicial_1_1_Debe_LaPosicionFinalSer4_1()
    {
        var tamañoTablero = 10;
        var tablero = new char[tamañoTablero, tamañoTablero];
        tablero[1, 2] = 'd';
        tablero[1, 3] = 'd';
        tablero[1, 4] = 'd';
        var tableroEsperado = TableroEsperado(tablero);
        var juegoAcorazado = new JuegoAcorazado();

        List<Coordenada> coordenadasDetructor = new()
        {
            new(1, 2, Nave.Destructor, "Vertical")
        };

        juegoAcorazado.AgregarJugador(coordenadasDetructor);

        juegoAcorazado.Imprimir().Should().Be(tableroEsperado);
    }

    [Fact]
    public void
        Si_SeAgregaUnJugadorYColocaUnDestructorConOrientacionVerticalEnLaPosicionInicial_1_1_YColocaUnCañoneroEnLaPosicion1_2_Debe_()
    {
        var tamañoTablero = 10;
        var tablero = new char[tamañoTablero, tamañoTablero];
        tablero[1, 2] = 'd';
        tablero[1, 3] = 'd';
        tablero[1, 4] = 'd';
        var tableroEsperado = TableroEsperado(tablero);
        var juegoAcorazado = new JuegoAcorazado();

        List<Coordenada> coordenadasDetructor = new()
        {
            new(1, 2, Nave.Destructor, "Vertical")
        };

        juegoAcorazado.AgregarJugador(coordenadasDetructor);

        juegoAcorazado.Imprimir().Should().Be(tableroEsperado);
    }

    [Fact]
    public void
        Si_AgregoUnJugadorYColocoUnCañoneroEnLaPosicion0_0_LuegoAgregoJugador2ConCañoneroEnLaPosicion_1_1_Debe_MostrarElTableroDelJugador1ConElCañoneroAsignado()
    {
        var tamañoTablero = 10;
        var tableroJugador1 = new char[tamañoTablero, tamañoTablero];
        tableroJugador1[0, 0] = 'g';
        var tableroEsperado = TableroEsperado(tableroJugador1);

        var juegoAcorazado = new JuegoAcorazado();

        List<Coordenada> coordenadasDetructorJugador1 = new()
        {
            new(0, 0, Nave.Cañonero, null)
        };

        juegoAcorazado.AgregarJugador(coordenadasDetructorJugador1);

        List<Coordenada> coordenadasDetructorJugador2 = new()
        {
            new(1, 1, Nave.Cañonero, null)
        };

        juegoAcorazado.AgregarJugador(coordenadasDetructorJugador2);

        juegoAcorazado.Imprimir().Should().Be(tableroEsperado);
    }

    [Fact]
    public void Si_AgregoUnJugadorYPosicionSoloUnCañonero_Debe_LanzarExcepcionFaltaPosicionarLosTresCañoneros()
    {
        var juegoAcorazado = new JuegoAcorazado();

        List<Coordenada> coordenadasDetructorJugador1 = new()
        {
            new(0, 0, Nave.Cañonero, null)
        };

        juegoAcorazado.AgregarJugador(coordenadasDetructorJugador1);

        var iniciar = () => juegoAcorazado.Iniciar();

        iniciar.Should().Throw<Exception>().WithMessage("El jugador 1 le faltana pocisionar 3 cañoneros");
    }
}
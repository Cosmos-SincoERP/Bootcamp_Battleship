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
        List<Nave> coordenadasCañonero = new()
        {
            new(0, 0, "Cañonero")
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

        List<Nave> coordenadasCañonero = new()
        {
            new(4, 5, "Cañonero")
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
        List<Nave> coordenadasCañonero = new()
        {
            new(2, 3, "Cañonero"),
            new(3, 3, "Cañonero")
        };

        juegoAcorazado.AgregarJugador(coordenadasCañonero);

        juegoAcorazado.Imprimir().Should().Be(tableroEsperado);
    }


    [Fact]
    public void Si_SeAgregaUnJugador_Debe_ColocarUnPortavionesEnLaPosicionInicial2_3()
    {
        var tamañoTablero = 10;
        var tablero = new char[tamañoTablero, tamañoTablero];
        tablero[2, 3] = 'c';

        var tableroEsperado = TableroEsperado(tablero);
        var juegoAcorazado = new JuegoAcorazado();
        List<Nave> coordenadasPortaAvion = new()
        {
            new(2, 3, "Portaviones")
        };

        juegoAcorazado.AgregarJugador(coordenadasPortaAvion);

        juegoAcorazado.Imprimir().Should().Be(tableroEsperado);
    }

    [Fact]
    public void Si_SeAgregaUnJugador_Debe_ColocarUnDestructorEnLaPosicionInicial4_5()
    {
        var tamañoTablero = 10;
        var tablero = new char[tamañoTablero, tamañoTablero];
        tablero[4, 5] = 'd';
        var tableroEsperado = TableroEsperado(tablero);
        var juegoAcorazado = new JuegoAcorazado();
        List<Nave> coordenadasDestructor = new()
        {
            new(4, 5, "Destructor")
        };

        juegoAcorazado.AgregarJugador(coordenadasDestructor);

        juegoAcorazado.Imprimir().Should().Be(tableroEsperado);
    }

    [Fact]
    public void
        Si_SeAgregaUnJugadoYColocaUnPortavionesConOrientacionHorizontalEnLaPosicionInicial2_3_Debe_LaPosicionFinalSer5_3()
    {
        var tamañoTablero = 10;
        var tablero = new char[tamañoTablero, tamañoTablero];
        tablero[2, 3] = 'c';
        tablero[3, 3] = 'c';
        tablero[4, 3] = 'c';
        tablero[5, 3] = 'c';
        var tableroEsperado = TableroEsperado(tablero);
        var juegoAcorazado = new JuegoAcorazado();

        List<Nave> coordenadasPortaAvion = new()
        {
            new(2, 3, "Portaviones")
        };

        juegoAcorazado.AgregarJugador(coordenadasPortaAvion);

        juegoAcorazado.Imprimir().Should().Be(tableroEsperado);
    }

    [Fact]
    public void
        Si_SeAgregaUnJugadoYColocaUnPortavionesConOrientacionHorizontalEnLaPosicionInicial5_2_Debe_LaPosicionFinalSer8_2()
    {
        var tamañoTablero = 10;
        var tablero = new char[tamañoTablero, tamañoTablero];
        tablero[5, 2] = 'c';
        tablero[6, 2] = 'c';
        tablero[7, 2] = 'c';
        tablero[8, 2] = 'c';
        var tableroEsperado = TableroEsperado(tablero);
        var juegoAcorazado = new JuegoAcorazado();

        List<Nave> coordenadasPortaAvion = new()
        {
            new(5, 2, "Portaviones")
        };

        juegoAcorazado.AgregarJugador(coordenadasPortaAvion);

        juegoAcorazado.Imprimir().Should().Be(tableroEsperado);
    }

    [Fact]
    public void
        Si_SeAgregaUnJugadoYColocaUnPortavionesConOrientacionVerticalEnLaPosicionInicial5_2_Debe_LaPosicionFinalSer5_5()
    {
        var tamañoTablero = 10;
        var tablero = new char[tamañoTablero, tamañoTablero];
        tablero[5, 2] = 'c';
        tablero[5, 3] = 'c';
        tablero[5, 4] = 'c';
        tablero[5, 5] = 'c';
        var tableroEsperado = TableroEsperado(tablero);
        var juegoAcorazado = new JuegoAcorazado();

        List<Nave> coordenadasPortaAvion = new()
        {
            new(5, 2, "Portaviones")
        };

        juegoAcorazado.AgregarJugador(coordenadasPortaAvion);

        juegoAcorazado.Imprimir().Should().Be(tableroEsperado);
    }
}
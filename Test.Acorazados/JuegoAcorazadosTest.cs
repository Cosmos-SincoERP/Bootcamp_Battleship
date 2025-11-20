using AwesomeAssertions;

namespace Test.BattleShip;

public class JuegoAcorazadosTest
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
    public static IEnumerable<object[]> DatosPortaAviones => new List<object[]>
    {
        new object[] { 0, 0, Orientacion.Vertical, new[] { new[] { 0, 0 }, new[] { 0, 1 }, new[] { 0, 2 }, new[] { 0, 3 } } },
        new object[] { 0, 0, Orientacion.Horizontal, new[] { new[] { 0, 0 }, new[] { 1, 0 }, new[] { 2, 0 }, new[] { 3, 0 } } },
        new object[] { 3, 4, Orientacion.Vertical, new[] { new[] { 3, 4 }, new[] { 3, 5 }, new[] { 3, 6 }, new[] { 3, 7 } } },
        new object[] { 6, 2, Orientacion.Horizontal, new[] { new[] { 6, 2 }, new[] { 7, 2 }, new[] { 8, 2 }, new[] { 9, 2 } } }
    };

    public static IEnumerable<object[]> DatosIncorrectosPortaAviones => new List<object[]>
    {
        new object[] { 9, 9, Orientacion.Vertical },
        new object[] { 9, 5, Orientacion.Horizontal },
        new object[] { 1, 9, Orientacion.Vertical },
        new object[] { 9, 4, Orientacion.Horizontal }
    };

    public static IEnumerable<object[]> DatosDestructores => new List<object[]>
    {
        new object[] { 2, 2, Orientacion.Vertical, new[] { new[] { 2, 2 }, new[] { 2, 3 }, new[] { 2, 4 } } },
        new object[] { 2, 2, Orientacion.Horizontal, new[] { new[] { 2, 2 }, new[] { 3, 2 }, new[] { 4, 2 } } },
        new object[] { 5, 6, Orientacion.Vertical, new[] { new[] { 5, 6 }, new[] { 5, 7 }, new[] { 5, 8 } } },
        new object[] { 3, 8, Orientacion.Horizontal, new[] { new[] { 3, 8 }, new[] { 4, 8 }, new[] { 5, 8 } } }
    };

    public static IEnumerable<object[]> DatosIncorrectosDestructores => new List<object[]>
    {
        new object[] { 9, 8, Orientacion.Vertical},
        new object[] { 8, 5, Orientacion.Horizontal },
        new object[] { 3, 8, Orientacion.Vertical },
        new object[] { 8, 4, Orientacion.Horizontal }
    };
    
    [Fact]
    public void Si_SeInciaUnTableroUnTamaño0_0_Debe_MostrarUnaExcepcion()
    {
        var juegoAcorazado = () => new JuegoAcorazado(0);

        juegoAcorazado.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void Si_SeIniciaUnTableroUnTamaño10_10_NoDebe_LanzarExcepcion()
    {
        var juegoAcorazado = () => new JuegoAcorazado(10);

        juegoAcorazado.Should().NotThrow();
    }

    [Fact]
    public void Si_SeIniciaUnTableroConUnTamañoMenorA0_Debe_LanzarExcepcion()
    {
        var juegoAcorazado = () => new JuegoAcorazado(-1);

        juegoAcorazado.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Theory]
    [MemberData(nameof(DatosPortaAviones))]
    public void Si_SeAgregaUnPortaAvionEnElTablero_Debe_PodersePosicionar(int posicionXInicial, int posicionYInicial,
        Orientacion orientacion, int[][] posicionesEsperadas)
    {
        var tablero = new char[10, 10];
        foreach (var posicionEsperada in posicionesEsperadas)
        {
            tablero[posicionEsperada[0], posicionEsperada[1]] = 'c';
        }
        var tableroEsperado = TableroEsperado(tablero);
        var juegoAcorazado = new JuegoAcorazado();
        juegoAcorazado.AgregarBarco(new PosicionarBarco(
            (posicionXInicial, posicionYInicial), new PortaAviones(orientacion))
        );

        juegoAcorazado.Imprimir().Should().BeEquivalentTo(tableroEsperado);
    }

    [Theory]
    [MemberData(nameof(DatosIncorrectosPortaAviones))]
    public void Si_AgregoUnPortavionesEnUnPosicionIncorrecta_Debe_LanzarExcepcion(int posicionXInicial,
        int posicionYInicial,
        Orientacion orientacion)
    {
        var juegoAcorazado = new JuegoAcorazado();

        var agregarPortaviones = () =>
            juegoAcorazado.AgregarBarco(new PosicionarBarco(
                (posicionXInicial, posicionYInicial), new PortaAviones(orientacion))
            );

        agregarPortaviones.Should().Throw<Exception>()
            .WithMessage("La posicion del PortaAviones debe estar dentro del tablero");
    }

    [Theory]
    [MemberData(nameof(DatosDestructores))]
    public void Si_AgregoUnDestructorEnElTablero_De_PodersePosicionar(int posicionXInicial, int posicionYInicial,
        Orientacion orientacion, int[][] posicionesEsperadas)
    {
        var tablero = new char[10, 10];
        foreach (var posicionEsperada in posicionesEsperadas)
        {
            tablero[posicionEsperada[0], posicionEsperada[1]] = 'd';
        }
        var juegoAcorazado = new JuegoAcorazado();
        var tableroEsperado = TableroEsperado(tablero);
        juegoAcorazado.AgregarBarco(new PosicionarBarco(
            (posicionXInicial, posicionYInicial), new Destructor(orientacion))
        );

        juegoAcorazado.Imprimir().Should().BeEquivalentTo(tableroEsperado);
    }

    [Theory]
    [MemberData(nameof(DatosIncorrectosDestructores))]
    public void Si_AgregoUnDestructorEnUnPosicionIncorrecta_Debe_LanzarExcepcion(int posicionXInicial,
        int posicionYInicial,
        Orientacion orientacion)
    {
        var juegoAcorazado = new JuegoAcorazado();

        var agregarDestructores = () =>
            juegoAcorazado.AgregarBarco(new PosicionarBarco(
                (posicionXInicial, posicionYInicial), new Destructor(orientacion))
            );

        agregarDestructores.Should().Throw<Exception>()
            .WithMessage("La posicion del Destructor debe estar dentro del tablero");
    }

    [Fact]
    public void Si_AgregoUnCañoneroEnPosicion_7_6_Debe_PosicionarseEn_7_6()
    {
        var tablero = new char[10, 10];
        tablero[7, 6] = 'g';
        var tableroEsperado = TableroEsperado(tablero);
        var juegoAcorazado = new JuegoAcorazado();
        juegoAcorazado.AgregarBarco(
            new PosicionarBarco(( 7, 6), new Cañonero())
        );

        juegoAcorazado.Imprimir().Should().BeEquivalentTo(tableroEsperado);
    }

    [Fact]
    public void Si_AgregoUnCañoneroEnPosicion_8_1_Debe_PosicionarseEn_8_1()
    {
        var tablero = new char[10, 10];
        tablero[8, 1] = 'g';
        var tableroEsperado = TableroEsperado(tablero);
        var juegoAcorazado = new JuegoAcorazado();
        juegoAcorazado.AgregarBarco(
            new PosicionarBarco((8, 1), new Cañonero())
        );

        juegoAcorazado.Imprimir().Should().BeEquivalentTo(tableroEsperado);
    }

    [Fact]
    public void Si_AgregoUnCañoneroEnLaPosicion_11_11_Debe_LanzarExcepcion()
    {
        var juegoAcorazado = new JuegoAcorazado();

        var cañonero = () => juegoAcorazado.AgregarBarco(
            new PosicionarBarco((11, 11), new Cañonero())
        );
        cañonero.Should().Throw<Exception>().WithMessage("La posicion del Cañonero debe estar dentro del tablero");
    }
    
    [Fact]
    public void Si_SeAgregaJugador_Debe_ContenerJugador1()
    {
        var juegoAcorazado = new JuegoAcorazado();

        juegoAcorazado.AgregarJugador();

        juegoAcorazado.ReporteBatalla().Should().Contain("Jugador 1");
    }
    
    [Fact]
    public void Si_SeAgregaJugadorYNoHaPosicionadoNingunBarco_NoDebe_PermitirAgregarAlSegundoJugador()
    {
        var juegoAcorazado = new JuegoAcorazado();
        juegoAcorazado.AgregarJugador();
        var jugador2 = () => juegoAcorazado.AgregarJugador();

        jugador2.Should().Throw<Exception>();
    }
    
    [Fact]
    public void Si_SeAgregaJugadorYHaPosicionadoUnPortaAvionesPeroNoHaPosicionadoLosDemasBarcos_NoDebe_PermitirAgregarAlSegundoJugador()
    {
        var juegoAcorazado = new JuegoAcorazado();
        juegoAcorazado.AgregarJugador();
        juegoAcorazado.AgregarBarco(
            new PosicionarBarco((0, 0), new PortaAviones(Orientacion.Vertical))
        );
        
        var jugador2 = () => juegoAcorazado.AgregarJugador();

        jugador2.Should().Throw<Exception>();
    }
    
    [Fact]
    public void Si_SeAgregaJugadorYHaPosicionadoUnDesctructorPeroNoHaPosicionadoLosDemasBarcos_NoDebe_PermitirAgregarAlSegundoJugador()
    {
        var juegoAcorazado = new JuegoAcorazado();
        juegoAcorazado.AgregarJugador();
        juegoAcorazado.AgregarBarco(
            new PosicionarBarco((2, 0), new Destructor(Orientacion.Vertical))
        );
        juegoAcorazado.AgregarBarco(
            new PosicionarBarco((2, 0), new Destructor(Orientacion.Vertical))
        );
        
        var jugador2 = () => juegoAcorazado.AgregarJugador();

        jugador2.Should().Throw<Exception>();
    }
}
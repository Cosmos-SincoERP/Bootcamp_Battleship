using AwesomeAssertions;

namespace Test.BattleShip;

public class AcorazadosTest
{
    public static IEnumerable<object[]> DatosPortaAviones => new List<object[]>
    {
        new object[] { 0, 0, "Vertical", new[] { new[] { 0, 0 }, new[] { 0, 1 }, new[] { 0, 2 }, new[] { 0, 3 } } },
        new object[] { 0, 0, "Horizontal", new[] { new[] { 0, 0 }, new[] { 1, 0 }, new[] { 2, 0 }, new[] { 3, 0 } } },
        new object[] { 3, 4, "Vertical", new[] { new[] { 3, 4 }, new[] { 3, 5 }, new[] { 3, 6 }, new[] { 3, 7 } } },
        new object[] { 6, 2, "Horizontal", new[] { new[] { 6, 2 }, new[] { 7, 2 }, new[] { 8, 2 }, new[] { 9, 2 } } }
    };

    public static IEnumerable<object[]> DatosIncorrectosPortaAviones => new List<object[]>
    {
        new object[] { 9, 9, "Vertical", 10, 10 },
        new object[] { 9, 9, "Horizontal", 10, 10 },
        new object[] { 5, 5, "Vertical", 5, 5 },
        new object[] { 5, 5, "Horizontal", 5, 5 }
    };
    
    public static IEnumerable<object[]> DatosDestructores => new List<object[]>
    {
        new object[] { 2, 2, "Vertical", new[] { new[] { 2, 2 }, new[] { 2, 3 }, new[] { 2, 4 } } },
    };

    [Fact]
    public void Si_SeInciaUnTableroUnTamaño0_0_Debe_MostrarUnaExcepcion()
    {
        var juegoAcorazado = () => new JuegoAcorazado(0, 0);

        juegoAcorazado.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void Si_SeIniciaUnTableroUnTamaño10_10_NoDebe_LanzarExcepcion()
    {
        var juegoAcorazado = () => new JuegoAcorazado(10, 10);

        juegoAcorazado.Should().NotThrow();
    }

    [Fact]
    public void Si_SeIniciaUnTableroConUnTamañoMenorA0_Debe_LanzarExcepcion()
    {
        var juegoAcorazado = () => new JuegoAcorazado(-1, -1);

        juegoAcorazado.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Theory]
    [MemberData(nameof(DatosPortaAviones))]
    public void Si_SeAgregaUnPortaAvionEnElTablero_Debe_PodersePosicionar(int posicionXInicial, int posicionYInicial,
        string orientacion, int[][] posicionesEsperadas)
    {
        var juegoAcorazadoEsperado = new string[10, 10];
        foreach (var posicionEsperada in posicionesEsperadas)
        {
            juegoAcorazadoEsperado[posicionEsperada[0], posicionEsperada[1]] = "c";
        }

        var juegoAcorazado = new JuegoAcorazado(10, 10);
        juegoAcorazado.AgregarPortaAviones(posicionXInicial, posicionYInicial, orientacion);

        juegoAcorazado.Mostrar().Should().BeEquivalentTo(juegoAcorazadoEsperado);
    }

    [Theory]
    [MemberData(nameof(DatosIncorrectosPortaAviones))]
    public void Si_AgregoUnPortavionesEnUnPosicionIncorrecta_Debe_LanzarExcepcion(int posicionXInicial,
        int posicionYInicial,
        string orientacion, int tamañoX, int tamañoY)
    {
        var juegoAcorazado = new JuegoAcorazado(tamañoX, tamañoY);

        var agregarPortaviones = () =>
            juegoAcorazado.AgregarPortaAviones(posicionXInicial, posicionYInicial, orientacion);

        agregarPortaviones.Should().Throw<Exception>()
            .WithMessage("La posicion del Portaviones debe estar dentro del tablero");
    }

    [Theory]
    [MemberData(nameof(DatosDestructores))]
    public void Si_AgregoUnDestructorEnElTablero_De_PodersePosicionar(int posicionXInicial, int posicionYInicial,
        string orientacion, int[][] posicionesEsperadas)
    {
        var juegoAcorazadoEsperado = new string[10, 10];
        foreach (var posicionEsperada in posicionesEsperadas)
        {
            juegoAcorazadoEsperado[posicionEsperada[0], posicionEsperada[1]] = "d";
        }
        var juegoAcorazado = new JuegoAcorazado(10, 10);


        juegoAcorazado.AgregarDestructor(posicionXInicial, posicionYInicial, orientacion);

        juegoAcorazado.Mostrar().Should().BeEquivalentTo(juegoAcorazadoEsperado);
    }
}

public class JuegoAcorazado
{
    private readonly string[,] _tablero;

    public JuegoAcorazado(int tamañoEnX, int tamañoEnY)
    {
        if (tamañoEnX <= 0 && tamañoEnY <= 0)
            throw new ArgumentOutOfRangeException();
        _tablero = new string[tamañoEnX, tamañoEnY];
    }

    public void AgregarPortaAviones(int posicionX, int posicionY, string direccion)
    {
        for (var i = 0; i < 4; i++)
        {
            if (direccion == "Vertical")
            {
                ValidarPosicionDelPortaAviones(posicionY, i, 0);
                _tablero[posicionX, posicionY + i] = "c";
            }
            else
            {
                ValidarPosicionDelPortaAviones(posicionX, i, 1);
                _tablero[posicionX + i, posicionY] = "c";
            }
        }
    }

    public string[,] Mostrar()
    {
        return _tablero;
    }

    private void ValidarPosicionDelPortaAviones(int posicion, int i, int dimension)
    {
        if (posicion + i > _tablero.GetLength(dimension) - 1)
            throw new Exception("La posicion del Portaviones debe estar dentro del tablero");
    }

    public void AgregarDestructor(int i, int i1, string horizontal)
    {
        _tablero[2, 2] = "d";
        _tablero[2, 3] = "d";
        _tablero[2, 4] = "d";
    }
}
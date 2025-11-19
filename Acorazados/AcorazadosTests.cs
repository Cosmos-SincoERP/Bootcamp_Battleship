using AwesomeAssertions;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace Acorazados;

public class AcorazadosTests
{
    Jugador jugador;
    string[,] tableroInicial;
    private Cañonero _cañonero;
    private Destructor _destructor;
    private PortaAviones _portaAviones;

    public AcorazadosTests()
    {
        jugador = new Jugador("Jugador 1");
        tableroInicial = new string[,]
        {
            { null, null, null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null, null, null },
        };
        _cañonero = new Cañonero();
        _destructor = new Destructor();
        _portaAviones = new PortaAviones();
    }

    [Fact]
    public void Si_CreoUnJugador1_Debe_JugadorNombreSerJugador1()
    {
        jugador = new Jugador("Jugador 1");

        jugador.Nombre.Should().Be("Jugador 1");
    }

    [Fact]
    public void Si_CreoUnJugador_Debe_TenerUnTableroDe10x10()
    {
        jugador.ObtenerLongitudTablero(0).Should().Be(10);
        jugador.ObtenerLongitudTablero(1).Should().Be(10);
    }

    [Fact]
    public void Si_CreoUnCañoneroEnLaPosicion11_Debe_LaCasilla11Tenerg()
    {
        tableroInicial[1, 1] = "g";

        jugador.AgregarAcorazado(new Cañonero(), 1, 1);

        jugador.ObtenerTablero().Should().BeEquivalentTo(tableroInicial);
    }

    [Fact]
    public void Si_CreoUnCañoneroEnLaPosicion11YvueloAcrearuncañoneroenlaMismaPosicion_Debe_LanzarUnaExcepcion()
    {
    
        jugador.AgregarAcorazado(_cañonero, 1, 1);

        Action act = () => jugador.AgregarAcorazado(_cañonero, 1, 1);
        act.Should().Throw<ArgumentException>().WithMessage("*Ya existe un acorazado en esa posicion*");
    }

    [Fact]
    public void Si_CreoUnCañoneroEnLaPosicion1111_Debe_LanzarUnaExcepcionDeFueraDeRango()
    {
        Action act = () => jugador.AgregarAcorazado(new Cañonero(), 11, 11);

        act.Should().Throw<ArgumentOutOfRangeException>()
            .WithMessage("*No es posible ubicar el acorazado en esa direccion*");
    }

    [Fact]
    public void Si_CreoUnCañoneroEnLaPosicionmenos1menos1_Debe_LanzarUnaExcepcionDeFueraDeRango()
    {
        Action act = () => jugador.AgregarAcorazado(_cañonero, -1, -1);

        act.Should().Throw<ArgumentOutOfRangeException>()
            .WithMessage("*No es posible ubicar el acorazado en esa direccion*");
    }

    [Fact]
    public void Si_CreoUnDestructorEnLaPosicion21_Debe_LasCasilla11_12_13_Tenerd()
    {
        tableroInicial[2, 1] = "d";
        tableroInicial[1, 1] = "d";
        tableroInicial[0, 1] = "d";

        jugador.AgregarAcorazado(_destructor, 2, 1, Direccion.Arriba);

        jugador.ObtenerTablero().Should().BeEquivalentTo(tableroInicial);
    }

    [Fact]
    public void Si_CreoUnDestructorEnLaPosicion11ConDireccionDerecha_Debe_LasCasillas11_21_31_Tenerd()
    {
        tableroInicial[1, 1] = "d";
        tableroInicial[1, 2] = "d";
        tableroInicial[1, 3] = "d";

        jugador.AgregarAcorazado(_destructor, 1, 1, Direccion.Derecha);

        jugador.ObtenerTablero().Should().BeEquivalentTo(tableroInicial);
    }

    [Fact]
    public void Si_CreoUnDestructorEnLaPosicion21ConDireccionIzquierda_Debe_LasCasillas12_11_10_Tenerd()
    {
        tableroInicial[1, 2] = "d";
        tableroInicial[1, 1] = "d";
        tableroInicial[1, 0] = "d";

        jugador.AgregarAcorazado(_destructor, 1, 2, Direccion.Izquierda);

        jugador.ObtenerTablero().Should().BeEquivalentTo(tableroInicial);
    }

    [Fact]
    public void Si_CreoUnDestructorEnLaPosicion13ConDireccionAbajo_Debe_LasCasillas13_23_33_Tenerd()
    {
        tableroInicial[1, 3] = "d";
        tableroInicial[2, 3] = "d";
        tableroInicial[3, 3] = "d";
        jugador.AgregarAcorazado(_destructor, 1, 3, Direccion.Abajo);

        jugador.ObtenerTablero().Should().BeEquivalentTo(tableroInicial);
    }

    [Fact]
    public void Si_CreoUnDestructorEnLaPosicion99ConDireccionDerecha_Debe_LanzarUnaExcepcionDeFueraDeRango()
    {
        Action act = () => jugador.AgregarAcorazado(_destructor, 9, 9, Direccion.Derecha);
        act.Should().Throw<ArgumentOutOfRangeException>()
            .WithMessage("*No es posible ubicar el acorazado en esa direccion*");
    }

    [Theory]
    [InlineData(0, 0, Direccion.Arriba)]
    [InlineData(9, 9, Direccion.Derecha)]
    [InlineData(9, 9, Direccion.Abajo)]
    [InlineData(0, 0, Direccion.Izquierda)]
    [InlineData(1, 0, Direccion.Arriba)]
    [InlineData(0, 8, Direccion.Derecha)]
    [InlineData(8, 8, Direccion.Abajo)]
    [InlineData(5, 1, Direccion.Izquierda)]
    public void Si_CreoUnDestructorEnAlgunaPosicionFueraDelTablero_Debe_LanzarUnaExcepcionDeFueraDeRango(int fila,
        int columna, Direccion direccion)
    {
        Action act = () => jugador.AgregarAcorazado(_destructor, fila, columna, direccion);

        act.Should().Throw<ArgumentOutOfRangeException>()
            .WithMessage("*No es posible ubicar el acorazado en esa direccion*");
    }

    [Fact]
    public void
        Si_CreoUnDestructorEnPosicion11DireccionDerechayCreoOtroEnPosicion01DireccionAbajo_Debe_LanzarUnaArgumentException()
    {
        jugador.AgregarAcorazado(_destructor, 1, 1, Direccion.Derecha);
        Action act = () => jugador.AgregarAcorazado(_destructor, 0, 1, Direccion.Abajo);

        act.Should().Throw<ArgumentException>().WithMessage("*Ya existe un acorazado en esa posicion*");
    }

    [Fact]
    public void Si_CreoUnPortaavionesEnPosicion11DireccionDerecha_Debe_LasCasillas11_12_13_14_Tenerc()
    {
        tableroInicial[1, 1] = "c";
        tableroInicial[1, 2] = "c";
        tableroInicial[1, 3] = "c";
        tableroInicial[1, 4] = "c";
        jugador.AgregarAcorazado(_portaAviones,1, 1, Direccion.Derecha);

        jugador.ObtenerTablero().Should().BeEquivalentTo(tableroInicial);
    }

    [Fact]
    public void Si_CreoUnPortaavionesEnPosicion11DireccionAbajo_Debe_LasCasillas11_21_31_41_Tenerc()
    {
        tableroInicial[1, 1] = "c";
        tableroInicial[2, 1] = "c";
        tableroInicial[3, 1] = "c";
        tableroInicial[4, 1] = "c";

        jugador.AgregarAcorazado(_portaAviones, 1, 1, Direccion.Abajo);

        jugador.ObtenerTablero().Should().BeEquivalentTo(tableroInicial);
    }

    [Fact]
    public void Si_CreoUnPortaavionesEnPosicion13DireccionIzquierda_Debe_LasCasillas13_12_11_10_TenercC()
    {
        tableroInicial[1, 3] = "c";
        tableroInicial[1, 2] = "c";
        tableroInicial[1, 1] = "c";
        tableroInicial[1, 0] = "c";

        jugador.AgregarAcorazado(_portaAviones, 1, 3, Direccion.Izquierda);

        jugador.ObtenerTablero().Should().BeEquivalentTo(tableroInicial);
    }

    [Fact]
    public void Si_CreoUnPortaavionesEnPosicion31DireccionArriba_Debe_LasCasillas31_21_11_01_TenercC()
    {
        tableroInicial[3, 1] = "c";
        tableroInicial[2, 1] = "c";
        tableroInicial[1, 1] = "c";
        tableroInicial[0, 1] = "c";
        jugador.AgregarAcorazado(_portaAviones, 3, 1, Direccion.Arriba);


        jugador.ObtenerTablero().Should().BeEquivalentTo(tableroInicial);
    }

    [Theory]
    [InlineData(0, 0, Direccion.Arriba)]
    [InlineData(9, 9, Direccion.Derecha)]
    [InlineData(9, 9, Direccion.Abajo)]
    [InlineData(0, 0, Direccion.Izquierda)]
    [InlineData(1, 0, Direccion.Arriba)]
    [InlineData(0, 8, Direccion.Derecha)]
    [InlineData(8, 8, Direccion.Abajo)]
    [InlineData(5, 1, Direccion.Izquierda)]
    [InlineData(2, 0, Direccion.Arriba)]
    [InlineData(0, 7, Direccion.Derecha)]
    [InlineData(7, 8, Direccion.Abajo)]
    [InlineData(5, 2, Direccion.Izquierda)]
    public void Si_CreoUnPortaavionesEnAlgunaPosicionFueraDelTablero_Debe_LanzarUnaExcepcionDeFueraDeRango(int fila,
        int columna, Direccion direccion)
    {
        Action act = () => jugador.AgregarAcorazado(_portaAviones, fila, columna, direccion);

        act.Should().Throw<ArgumentOutOfRangeException>()
            .WithMessage("*No es posible ubicar el acorazado en esa direccion*");
    }

    [Fact]
    public void Si_CreoUnCañoneroTeniendoCuatroEnMiTablero_Debe_LanzarUnaArgumentException()
    {
        jugador.AgregarAcorazado(_cañonero, 1, 1);
        jugador.AgregarAcorazado(_cañonero, 3, 3);
        jugador.AgregarAcorazado(_cañonero, 5, 5);
        jugador.AgregarAcorazado(_cañonero, 7, 7);

        Action act = () => jugador.AgregarAcorazado(_cañonero, 9, 9);

        act.Should().Throw<ArgumentException>().WithMessage("*Se supero el maximo de acorazados de este tipo*");
    }

    [Fact]
    public void Si_CreoUnDestructorTeniendoDosEnMiTablero_Debe_LanzarUnaArgumentException()
    {
        jugador.AgregarAcorazado(_destructor, 1, 1, Direccion.Derecha);
        jugador.AgregarAcorazado(_destructor, 3, 3, Direccion.Derecha);

        Action act = () => jugador.AgregarAcorazado(_destructor, 5, 5, Direccion.Derecha);

        act.Should().Throw<ArgumentException>().WithMessage("*Se supero el maximo de acorazados de este tipo*");
    }

    [Fact]
    public void Si_CreoUnPortaavionesTeniendoUnPortaavionesEnMiTablero_Debe_LanzarUnaArgumentException()
    {
        jugador.AgregarAcorazado(_portaAviones, 1, 1, Direccion.Derecha);

        Action act = () => jugador.AgregarAcorazado(_portaAviones, 3, 3, Direccion.Derecha);

        act.Should().Throw<ArgumentException>().WithMessage("*Se supero el maximo de acorazados de este tipo*");
    }

    [Fact]
    public void Si_CreoUnPortaavionesYluegoUnCañonero_Debe_lacasilla31Tenerg()
    {
        tableroInicial[3, 1] = "g";

        tableroInicial[1, 1] = "c";
        tableroInicial[1, 2] = "c";
        tableroInicial[1, 3] = "c";
        tableroInicial[1, 4] = "c";


        jugador.AgregarAcorazado(_portaAviones, 1, 1, Direccion.Derecha);
        jugador.AgregarAcorazado(_cañonero, 3, 1, Direccion.Derecha);

        jugador.ObtenerTablero().Should().BeEquivalentTo(tableroInicial);
    }

    [Fact]
    public void Si_CreoUnCañoneroYTengoDosDestructoresEnMiTablero_Debe_LaCasilla31Tener_g()
    {
        tableroInicial[3, 1] = "g";

        tableroInicial[1, 1] = "d";
        tableroInicial[1, 2] = "d";
        tableroInicial[1, 3] = "d";

        tableroInicial[2, 1] = "d";
        tableroInicial[2, 2] = "d";
        tableroInicial[2, 3] = "d";

        jugador.AgregarAcorazado(_destructor, 1, 1, Direccion.Derecha);
        jugador.AgregarAcorazado(_destructor, 2, 1, Direccion.Derecha);

        jugador.AgregarAcorazado(_cañonero, 3, 1, Direccion.Derecha);

        jugador.ObtenerTablero().Should().BeEquivalentTo(tableroInicial);
    }

    [Fact]
    public void Si_CreoUnPortaavionesYTengoCuatroCañonerosEnMiTablero_Debe_LaCasilla31_Tener_c()
    {
        tableroInicial[1, 1] = "g";
        tableroInicial[2, 1] = "g";
        tableroInicial[4, 1] = "g";
        tableroInicial[5, 1] = "g";
        tableroInicial[3, 1] = "c";
        tableroInicial[3, 2] = "c";
        tableroInicial[3, 3] = "c";
        tableroInicial[3, 4] = "c";
        
        jugador.AgregarAcorazado(_cañonero, 1, 1, Direccion.Derecha);
        jugador.AgregarAcorazado(_cañonero, 2, 1, Direccion.Derecha);
        jugador.AgregarAcorazado(_cañonero, 4, 1, Direccion.Derecha);
        jugador.AgregarAcorazado(_cañonero, 5, 1, Direccion.Derecha);
        jugador.AgregarAcorazado(_portaAviones, 3, 1, Direccion.Derecha);
        
        jugador.ObtenerTablero().Should().BeEquivalentTo(tableroInicial);
    }
}
using AwesomeAssertions;
using Microsoft.VisualStudio.TestPlatform.Utilities;

namespace Acorazados;

public class PrepararJuegoAcorazadosTests
{
    JuegoAcorazados _juego;
    string[,] tableroInicial;
    private Cañonero _cañonero;
    private Destructor _destructor;
    private PortaAviones _portaAviones;

    public PrepararJuegoAcorazadosTests()
    {
        _juego = new JuegoAcorazados();
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
        tableroInicial[0, 0] = _cañonero.Letra;

        var acorazados = new List<AcorazadoAcuatizado>()
        {
            new(_cañonero, 0, 0, Direccion.Derecha)
        };
        _juego.AgregarJugador("Jugador 1", acorazados);
        _juego.ImprimirTablero().Should().BeEquivalentTo(tableroInicial);
    }

    [Fact]
    public void Si_inicioUnJuegoSinJugadores_Debe_LanzarExcepcion()
    {
        Action act =() => _juego.Iniciar();
        
        act.Should().Throw<ArgumentException>().WithMessage("*Debe tener jugadores para iniciar el juego*");
    }

    [Fact]
    public void Si_CreoTresJugadores_Debe_LanzarExcepcion()
    {
        var acorazados = new List<AcorazadoAcuatizado>()
        {
            new(_cañonero, 0, 0, Direccion.Derecha)
        };
        _juego.AgregarJugador("Jugador 1", acorazados);
        _juego.AgregarJugador("Jugador 2", acorazados);
        
        Action act = () => _juego.AgregarJugador("Jugador 3", acorazados);

        act.Should().Throw<ArgumentException>().WithMessage("*No puede agregar mas de dos jugadores*");
    }

    [Fact]
    public void Si_InicioUnJuegoDosVeces_Debe_LanzarExcepcion()
    {
        var acorazados = new List<AcorazadoAcuatizado>()
        {
            new(_cañonero, 0, 0, Direccion.Derecha)
        };
        _juego.AgregarJugador("Jugador 1", acorazados);
        _juego.Iniciar();
        
        Action act = () => _juego.Iniciar();

        act.Should().Throw<Exception>().WithMessage("*Ya hay un juego en curso*");
    }

    [Fact]
    public void Si_CreoUnCañoneroEnLaPosicion11_Debe_LaCasilla11Tenerg()
    {
        tableroInicial[1, 1] = _cañonero.Letra;

        var acorazados = new List<AcorazadoAcuatizado>()
        {
            new(_cañonero, 1, 1, Direccion.Derecha)
        };
        _juego.AgregarJugador("Jugador 1", acorazados);

        _juego.ImprimirTablero().Should().BeEquivalentTo(tableroInicial);
    }

    [Fact]
    public void Si_CreoUnCañoneroEnLaPosicion11YvueloAcrearuncañoneroenlaMismaPosicion_Debe_LanzarUnaExcepcion()
    {
        var acorazados = new List<AcorazadoAcuatizado>()
        {
            new(_cañonero, 1, 1, Direccion.Derecha),
            new(_cañonero, 1, 1, Direccion.Derecha)
        };

        Action act = () => _juego.AgregarJugador("Jugador 1", acorazados);
        act.Should().Throw<ArgumentException>().WithMessage("*Ya existe un acorazado en esa posicion*");
    }

    [Fact]
    public void Si_CreoUnCañoneroEnLaPosicion1111_Debe_LanzarUnaExcepcionDeFueraDeRango()
    {
        var acorazados = new List<AcorazadoAcuatizado>()
        {
            new(_cañonero, 11, 11, Direccion.Derecha)
        };

        Action act = () => _juego.AgregarJugador("Jugador 1", acorazados);

        act.Should().Throw<ArgumentOutOfRangeException>()
            .WithMessage("*No es posible ubicar el acorazado en esa direccion*");
    }

    [Fact]
    public void Si_CreoUnCañoneroEnLaPosicionmenos1menos1_Debe_LanzarUnaExcepcionDeFueraDeRango()
    {
        var acorazados = new List<AcorazadoAcuatizado>()
        {
            new(_cañonero, -1, -1, Direccion.Derecha)
        };

        Action act = () => _juego.AgregarJugador("Jugador 1", acorazados);

        act.Should().Throw<ArgumentOutOfRangeException>()
            .WithMessage("*No es posible ubicar el acorazado en esa direccion*");
    }

    [Fact]
    public void Si_CreoUnDestructorEnLaPosicion21_Debe_LasCasilla11_12_13_Tenerd()
    {
        tableroInicial[2, 1] = _destructor.Letra;
        tableroInicial[1, 1] = _destructor.Letra;
        tableroInicial[0, 1] = _destructor.Letra;

        var acorazados = new List<AcorazadoAcuatizado>()
        {
            new(_destructor, 2, 1, Direccion.Arriba)
        };
        _juego.AgregarJugador("Jugador 1", acorazados);

        _juego.ImprimirTablero().Should().BeEquivalentTo(tableroInicial);
    }

    [Fact]
    public void Si_CreoUnDestructorEnLaPosicion11ConDireccionDerecha_Debe_LasCasillas11_21_31_Tenerd()
    {
        tableroInicial[1, 1] = _destructor.Letra;
        tableroInicial[1, 2] = _destructor.Letra;
        tableroInicial[1, 3] = _destructor.Letra;

        var acorazados = new List<AcorazadoAcuatizado>()
        {
            new(_destructor, 1, 1, Direccion.Derecha)
        };
        _juego.AgregarJugador("Jugador 1", acorazados);

        _juego.ImprimirTablero().Should().BeEquivalentTo(tableroInicial);
    }

    [Fact]
    public void Si_CreoUnDestructorEnLaPosicion21ConDireccionIzquierda_Debe_LasCasillas12_11_10_Tenerd()
    {
        tableroInicial[1, 2] = _destructor.Letra;
        tableroInicial[1, 1] = _destructor.Letra;
        tableroInicial[1, 0] = _destructor.Letra;

        var acorazados = new List<AcorazadoAcuatizado>()
        {
            new(_destructor, 1, 2, Direccion.Izquierda)
        };
        _juego.AgregarJugador("Jugador 1", acorazados);

        _juego.ImprimirTablero().Should().BeEquivalentTo(tableroInicial);
    }

    [Fact]
    public void Si_CreoUnDestructorEnLaPosicion13ConDireccionAbajo_Debe_LasCasillas13_23_33_Tenerd()
    {
        tableroInicial[1, 3] = _destructor.Letra;
        tableroInicial[2, 3] = _destructor.Letra;
        tableroInicial[3, 3] = _destructor.Letra;
        var acorazados = new List<AcorazadoAcuatizado>()
        {
            new(_destructor, 1, 3, Direccion.Abajo)
        };
        _juego.AgregarJugador("Jugador 1", acorazados);

        _juego.ImprimirTablero().Should().BeEquivalentTo(tableroInicial);
    }

    [Fact]
    public void Si_CreoUnDestructorEnLaPosicion99ConDireccionDerecha_Debe_LanzarUnaExcepcionDeFueraDeRango()
    {
        var acorazados = new List<AcorazadoAcuatizado>()
        {
            new(_destructor, 9, 9, Direccion.Derecha)
        };

        Action act = () => _juego.AgregarJugador("Jugador 1", acorazados);

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
        var acorazados = new List<AcorazadoAcuatizado>()
        {
            new(_destructor, fila, columna, direccion)
        };

        Action act = () => _juego.AgregarJugador("Jugador 1", acorazados);

        act.Should().Throw<ArgumentOutOfRangeException>()
            .WithMessage("*No es posible ubicar el acorazado en esa direccion*");
    }

    [Fact]
    public void
        Si_CreoUnDestructorEnPosicion11DireccionDerechayCreoOtroEnPosicion01DireccionAbajo_Debe_LanzarUnaArgumentException()
    {
        var acorazados = new List<AcorazadoAcuatizado>()
        {
            new(_destructor, 1, 1, Direccion.Derecha),
            new(_destructor, 0, 1, Direccion.Abajo)
        };

        Action act = () => _juego.AgregarJugador("Jugador 1", acorazados);

        act.Should().Throw<ArgumentException>().WithMessage("*Ya existe un acorazado en esa posicion*");
    }

    [Fact]
    public void Si_CreoUnPortaavionesEnPosicion11DireccionDerecha_Debe_LasCasillas11_12_13_14_Tenerc()
    {
        tableroInicial[1, 1] = _portaAviones.Letra;
        tableroInicial[1, 2] = _portaAviones.Letra;
        tableroInicial[1, 3] = _portaAviones.Letra;
        tableroInicial[1, 4] = _portaAviones.Letra;
        var acorazados = new List<AcorazadoAcuatizado>()
        {
            new(_portaAviones, 1, 1, Direccion.Derecha)
        };
        _juego.AgregarJugador("Jugador 1", acorazados);

        _juego.ImprimirTablero().Should().BeEquivalentTo(tableroInicial);
    }

    [Fact]
    public void Si_CreoUnPortaavionesEnPosicion11DireccionAbajo_Debe_LasCasillas11_21_31_41_Tenerc()
    {
        tableroInicial[1, 1] = _portaAviones.Letra;
        tableroInicial[2, 1] = _portaAviones.Letra;
        tableroInicial[3, 1] = _portaAviones.Letra;
        tableroInicial[4, 1] = _portaAviones.Letra;

        var acorazados = new List<AcorazadoAcuatizado>()
        {
            new(_portaAviones, 1, 1, Direccion.Abajo)
        };
        _juego.AgregarJugador("Jugador 1", acorazados);

        _juego.ImprimirTablero().Should().BeEquivalentTo(tableroInicial);
    }

    [Fact]
    public void Si_CreoUnPortaavionesEnPosicion13DireccionIzquierda_Debe_LasCasillas13_12_11_10_TenercC()
    {
        tableroInicial[1, 3] = _portaAviones.Letra;
        tableroInicial[1, 2] = _portaAviones.Letra;
        tableroInicial[1, 1] = _portaAviones.Letra;
        tableroInicial[1, 0] = _portaAviones.Letra;

        var acorazados = new List<AcorazadoAcuatizado>()
        {
            new(_portaAviones, 1, 3, Direccion.Izquierda)
        };
        _juego.AgregarJugador("Jugador 1", acorazados);

        _juego.ImprimirTablero().Should().BeEquivalentTo(tableroInicial);
    }

    [Fact]
    public void Si_CreoUnPortaavionesEnPosicion31DireccionArriba_Debe_LasCasillas31_21_11_01_TenercC()
    {
        tableroInicial[3, 1] = _portaAviones.Letra;
        tableroInicial[2, 1] = _portaAviones.Letra;
        tableroInicial[1, 1] = _portaAviones.Letra;
        tableroInicial[0, 1] = _portaAviones.Letra;
        var acorazados = new List<AcorazadoAcuatizado>()
        {
            new(_portaAviones, 3, 1, Direccion.Arriba)
        };
        _juego.AgregarJugador("Jugador 1", acorazados);

        _juego.ImprimirTablero().Should().BeEquivalentTo(tableroInicial);
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
        var acorazados = new List<AcorazadoAcuatizado>()
        {
            new(_portaAviones, fila, columna, direccion)
        };
        Action act = () => _juego.AgregarJugador("Jugador 1", acorazados);

        act.Should().Throw<ArgumentOutOfRangeException>()
            .WithMessage("*No es posible ubicar el acorazado en esa direccion*");
    }

    [Fact]
    public void Si_CreoUnCañoneroTeniendoCuatroEnMiTablero_Debe_LanzarUnaArgumentException()
    {
        var acorazados = new List<AcorazadoAcuatizado>()
        {
            new(_cañonero, 1, 1, Direccion.Derecha),
            new(_cañonero, 2, 1, Direccion.Derecha),
            new(_cañonero, 3, 1, Direccion.Derecha),
            new(_cañonero, 4, 1, Direccion.Derecha),
            new(_cañonero, 5, 1, Direccion.Derecha),
        };

        Action act = () => _juego.AgregarJugador("Jugador 1", acorazados);

        act.Should().Throw<ArgumentException>().WithMessage("*Se supero el maximo de acorazados de este tipo*");
    }

    [Fact]
    public void Si_CreoUnDestructorTeniendoDosEnMiTablero_Debe_LanzarUnaArgumentException()
    {
        var acorazados = new List<AcorazadoAcuatizado>()
        {
            new(_destructor, 1, 1, Direccion.Derecha),
            new(_destructor, 2, 2, Direccion.Derecha),
            new(_destructor, 3, 3, Direccion.Derecha)
        };

        Action act = () => _juego.AgregarJugador("Jugador 1", acorazados);

        act.Should().Throw<ArgumentException>().WithMessage("*Se supero el maximo de acorazados de este tipo*");
    }

    [Fact]
    public void Si_CreoUnPortaavionesTeniendoUnPortaavionesEnMiTablero_Debe_LanzarUnaArgumentException()
    {
        var acorazados = new List<AcorazadoAcuatizado>()
        {
            new(_portaAviones, 1, 1, Direccion.Derecha),
            new(_portaAviones, 2, 2, Direccion.Derecha)
        };

        Action act = () => _juego.AgregarJugador("Jugador 1", acorazados);

        act.Should().Throw<ArgumentException>().WithMessage("*Se supero el maximo de acorazados de este tipo*");
    }

    [Fact]
    public void Si_CreoUnPortaavionesYluegoUnCañonero_Debe_lacasilla31Tenerg()
    {
        tableroInicial[3, 1] = _cañonero.Letra;
        tableroInicial[1, 1] = _portaAviones.Letra;
        tableroInicial[1, 2] = _portaAviones.Letra;
        tableroInicial[1, 3] = _portaAviones.Letra;
        tableroInicial[1, 4] = _portaAviones.Letra;
        var acorazados = new List<AcorazadoAcuatizado>()
        {
            new(_portaAviones, 1, 1, Direccion.Derecha),
            new(_cañonero, 3, 1, Direccion.Derecha)
        };

        _juego.AgregarJugador("Jugador 1", acorazados);

        _juego.ImprimirTablero().Should().BeEquivalentTo(tableroInicial);
    }

    [Fact]
    public void Si_CreoUnCañoneroYTengoDosDestructoresEnMiTablero_Debe_LaCasilla31Tener_g()
    {
        tableroInicial[3, 1] = _cañonero.Letra;
        tableroInicial[1, 1] = _destructor.Letra;
        tableroInicial[1, 2] = _destructor.Letra;
        tableroInicial[1, 3] = _destructor.Letra;
        tableroInicial[2, 1] = _destructor.Letra;
        tableroInicial[2, 2] = _destructor.Letra;
        tableroInicial[2, 3] = _destructor.Letra;
        var acorazados = new List<AcorazadoAcuatizado>()
        {
            new(_destructor, 1, 1, Direccion.Derecha),
            new(_destructor, 2, 1, Direccion.Derecha),
            new(_cañonero, 3, 1, Direccion.Derecha),
        };

        _juego.AgregarJugador("Jugador 1", acorazados);

        _juego.ImprimirTablero().Should().BeEquivalentTo(tableroInicial);
    }

    [Fact]
    public void Si_CreoUnPortaavionesYTengoCuatroCañonerosEnMiTablero_Debe_LaCasilla31_Tener_c()
    {
        tableroInicial[1, 1] = _cañonero.Letra;
        tableroInicial[2, 1] = _cañonero.Letra;
        tableroInicial[4, 1] = _cañonero.Letra;
        tableroInicial[5, 1] = _cañonero.Letra;
        tableroInicial[3, 1] = _portaAviones.Letra;
        tableroInicial[3, 2] = _portaAviones.Letra;
        tableroInicial[3, 3] = _portaAviones.Letra;
        tableroInicial[3, 4] = _portaAviones.Letra;
        var acorazados = new List<AcorazadoAcuatizado>()
        {
            new(_cañonero, 1, 1, Direccion.Derecha),
            new(_cañonero, 2, 1, Direccion.Derecha),
            new(_cañonero, 4, 1, Direccion.Derecha),
            new(_cañonero, 5, 1, Direccion.Derecha),
            new(_portaAviones, 3, 1, Direccion.Derecha)
        };

        _juego.AgregarJugador("Jugador 1", acorazados);

        _juego.ImprimirTablero().Should().BeEquivalentTo(tableroInicial);
    }
    
}
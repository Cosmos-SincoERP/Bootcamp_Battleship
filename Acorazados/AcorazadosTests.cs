using AwesomeAssertions;

namespace Acorazados;

public class AcorazadosTests
{
    Jugador jugador;
    public AcorazadosTests()
    {
        jugador = new Jugador("Jugador 1");
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
        jugador.AgregarAcorazado(Acorazado.Cañonero, 1, 1);

        jugador.ObtenerCasilla(1, 1).Should().Be("g");
    }

    [Fact]
    public void Si_CreoUnCañoneroEnLaPosicion11YvueloAcrearuncañoneroenlaMismaPosicion_Debe_LanzarUnaExcepcion()
    {
        jugador.AgregarAcorazado(Acorazado.Cañonero, 1, 1);
        
        Action act =()=> jugador.AgregarAcorazado(Acorazado.Cañonero, 1, 1);
        act.Should().Throw<ArgumentException>().WithMessage("*Ya existe un acorazado en esa posicion*");
    }

    [Fact]
    public void Si_CreoUnCañoneroEnLaPosicion1111_Debe_LanzarUnaExcepcionDeFueraDeRango()
    {
        Action act =()=>  jugador.AgregarAcorazado(Acorazado.Cañonero, 11, 11);
        
        act.Should().Throw<ArgumentOutOfRangeException>().WithMessage("*No es posible ubicar el acorazado en esa direccion*");
    }
    
    [Fact]
    public void Si_CreoUnCañoneroEnLaPosicionmenos1menos1_Debe_LanzarUnaExcepcionDeFueraDeRango()
    {
        Action act =()=>  jugador.AgregarAcorazado(Acorazado.Cañonero, -1, -1);
        
        act.Should().Throw<ArgumentOutOfRangeException>().WithMessage("*No es posible ubicar el acorazado en esa direccion*");
    }

    [Fact]
    public void Si_CreoUnDestructorEnLaPosicion21_Debe_LasCasilla11_12_13_Tenerd()
    {
        jugador.AgregarAcorazado(Acorazado.Destructor, 2, 1, Direccion.Arriba);

        jugador.ObtenerCasilla(2, 1).Should().Be("d");
        jugador.ObtenerCasilla(1, 1).Should().Be("d");
        jugador.ObtenerCasilla(0, 1).Should().Be("d");
    }

    [Fact]
    public void Si_CreoUnDestructorEnLaPosicion11ConDireccionDerecha_Debe_LasCasillas11_21_31_Tenerd()
    {
        jugador.AgregarAcorazado(Acorazado.Destructor, 1, 1, Direccion.Derecha);

        jugador.ObtenerCasilla(1, 1).Should().Be("d");
        jugador.ObtenerCasilla(1, 2).Should().Be("d");
        jugador.ObtenerCasilla(1, 3).Should().Be("d");
    }

    [Fact]
    public void Si_CreoUnDestructorEnLaPosicion21ConDireccionIzquierda_Debe_LasCasillas12_11_10_Tenerd()
    {
        jugador.AgregarAcorazado(Acorazado.Destructor, 1, 2, Direccion.Izquierda);

        jugador.ObtenerCasilla(1, 2).Should().Be("d");
        jugador.ObtenerCasilla(1, 1).Should().Be("d");
        jugador.ObtenerCasilla(1, 0).Should().Be("d");
    }

    [Fact]
    public void Si_CreoUnDestructorEnLaPosicion13ConDireccionAbajo_Debe_LasCasillas13_23_33_Tenerd()
    {
        jugador.AgregarAcorazado(Acorazado.Destructor, 1, 3, Direccion.Abajo);

        jugador.ObtenerCasilla(1, 3).Should().Be("d");
        jugador.ObtenerCasilla(2, 3).Should().Be("d");
        jugador.ObtenerCasilla(3, 3).Should().Be("d");
    }

    [Fact]
    public void Si_CreoUnDestructorEnLaPosicion99ConDireccionDerecha_Debe_LanzarUnaExcepcionDeFueraDeRango()
    {
        Action act = ()=> jugador.AgregarAcorazado(Acorazado.Destructor, 9, 9, Direccion.Derecha);
        act.Should().Throw<ArgumentOutOfRangeException>().WithMessage("*No es posible ubicar el acorazado en esa direccion*");
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
    public void Si_CreoUnDestructorEnAlgunaPosicionFueraDelTablero_Debe_LanzarUnaExcepcionDeFueraDeRango(int fila, int columna, Direccion direccion)
    {
        Action act = () => jugador.AgregarAcorazado(Acorazado.Destructor, fila, columna, direccion);
        
        act.Should().Throw<ArgumentOutOfRangeException>().WithMessage("*No es posible ubicar el acorazado en esa direccion*");
    }

    [Fact]
    public void Si_CreoUnDestructorEnPosicion11DireccionDerechayCreoOtroEnPosicion01DireccionAbajo_Debe_LanzarUnaArgumentException()
    {
        jugador.AgregarAcorazado(Acorazado.Destructor, 1, 1, Direccion.Derecha);
        Action act = () => jugador.AgregarAcorazado(Acorazado.Destructor, 0, 1, Direccion.Abajo);

        act.Should().Throw<ArgumentException>().WithMessage("*Ya existe un acorazado en esa posicion*");
    }

    [Fact]
    public void Si_CreoUnPortaavionesEnPosicion11DireccionDerecha_Debe_LasCasillas11_12_13_14_Tenerc()
    {
        jugador.AgregarAcorazado(Acorazado.Portaaviones, 1,1,Direccion.Derecha);
        
        jugador.ObtenerCasilla(1, 1).Should().Be("c");
        jugador.ObtenerCasilla(1, 2).Should().Be("c");
        jugador.ObtenerCasilla(1, 3).Should().Be("c");
        jugador.ObtenerCasilla(1, 4).Should().Be("c");
    }

    [Fact]
    public void Si_CreoUnPortaavionesEnPosicion11DireccionAbajo_Debe_LasCasillas11_21_31_41_Tenerc()
    {
        jugador.AgregarAcorazado(Acorazado.Portaaviones, 1,1,Direccion.Abajo);
        
        jugador.ObtenerCasilla(1, 1).Should().Be("c");
        jugador.ObtenerCasilla(2, 1).Should().Be("c");
        jugador.ObtenerCasilla(3, 1).Should().Be("c");
        jugador.ObtenerCasilla(4, 1).Should().Be("c");
    }
    
    [Fact]
    public void Si_CreoUnPortaavionesEnPosicion13DireccionIzquierda_Debe_LasCasillas13_12_11_10_TenercC()
    {
        jugador.AgregarAcorazado(Acorazado.Portaaviones, 1,3,Direccion.Izquierda);
        
        jugador.ObtenerCasilla(1, 3).Should().Be("c");
        jugador.ObtenerCasilla(1, 2).Should().Be("c");
        jugador.ObtenerCasilla(1, 1).Should().Be("c");
        jugador.ObtenerCasilla(1, 0).Should().Be("c");
    } 
    
    [Fact]
    public void Si_CreoUnPortaavionesEnPosicion31DireccionArriba_Debe_LasCasillas31_21_11_01_TenercC()
    {
        jugador.AgregarAcorazado(Acorazado.Portaaviones, 3,1,Direccion.Arriba);
        
        jugador.ObtenerCasilla(3, 1).Should().Be("c");
        jugador.ObtenerCasilla(2, 1).Should().Be("c");
        jugador.ObtenerCasilla(1, 1).Should().Be("c");
        jugador.ObtenerCasilla(0, 1).Should().Be("c");
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
    public void Si_CreoUnPortaavionesEnAlgunaPosicionFueraDelTablero_Debe_LanzarUnaExcepcionDeFueraDeRango(int fila, int columna, Direccion direccion)
    {
        Action act = () => jugador.AgregarAcorazado(Acorazado.Portaaviones, fila, columna, direccion);
        
        act.Should().Throw<ArgumentOutOfRangeException>().WithMessage("*No es posible ubicar el acorazado en esa direccion*");
    }

    [Fact]
    public void Si_CreoUnCañoneroTeniendoCuatroEnMiTablero_Debe_LanzarUnaArgumentException()
    {
        jugador.AgregarAcorazado(Acorazado.Cañonero, 1, 1);
        jugador.AgregarAcorazado(Acorazado.Cañonero, 3, 3);
        jugador.AgregarAcorazado(Acorazado.Cañonero, 5, 5);
        jugador.AgregarAcorazado(Acorazado.Cañonero, 7, 7);
        
        Action act = () => jugador.AgregarAcorazado(Acorazado.Cañonero, 9, 9);

        act.Should().Throw<ArgumentException>().WithMessage("*Se supero el maximo de acorazados de este tipo*");
    }
}
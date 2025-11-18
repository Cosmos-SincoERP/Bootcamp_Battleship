using AwesomeAssertions;

namespace Acorazados;

public class AcorazadosTests
{
    [Fact]
    public void Si_CreoUnJugador1_Debe_JugadorNombreSerJugador1()
    {
        var jugador = new Jugador("Jugador 1");
        
        jugador.Nombre.Should().Be("Jugador 1");
    }

    [Fact]
    public void Si_CreoUnJugador_Debe_TenerUnTableroDe10x10()
    {
        var jugador = new Jugador("Jugador 1");
        
        jugador.ObtenerLongitudTablero(0).Should().Be(10);
        jugador.ObtenerLongitudTablero(1).Should().Be(10);
    }

    [Fact]
    public void Si_CreoUnCañoneroEnLaPosicion11_Debe_LaCasilla11Tenerg()
    {
        var jugador = new Jugador("Jugador 1");

        jugador.AgregarAcorazado("Cañonero", 1, 1);

        jugador.ObtenerCasilla(1, 1).Should().Be("g");
    }

    [Fact]
    public void Si_CreoUnCañoneroEnLaPosicion11YvueloAcrearuncañoneroenlaMismaPosicion_Debe_LanzarUnaExcepcion()
    {
        var jugador = new Jugador("Jugador 1");
        jugador.AgregarAcorazado("Cañonero", 1, 1);
        
        Action act =()=> jugador.AgregarAcorazado("Cañonero", 1, 1);
        act.Should().Throw<ArgumentException>().WithMessage("*Ya existe un acorazado en esa posicion*");
    }

    [Fact]
    public void Si_CreoUnCañoneroEnLaPosicion1111_Debe_LanzarUnaExcepcionDeFueraDeRango()
    {
        var jugador = new Jugador("Jugador 1");
        
        Action act =()=>  jugador.AgregarAcorazado("Cañonero", 11, 11);
        
        act.Should().Throw<ArgumentOutOfRangeException>().WithMessage("*La posicion no existe en el tablero*");
    }
    
    [Fact]
    public void Si_CreoUnCañoneroEnLaPosicionmenos1menos1_Debe_LanzarUnaExcepcionDeFueraDeRango()
    {
        var jugador = new Jugador("Jugador 1");
        
        Action act =()=>  jugador.AgregarAcorazado("Cañonero", -1, -1);
        
        act.Should().Throw<ArgumentOutOfRangeException>().WithMessage("*La posicion no existe en el tablero*");
    }

    [Fact]
    public void Si_CreoUnDestructorEnLaPosicion11_Debe_LasCasilla11_12_13_Tenerd()
    {
        var jugador = new Jugador("Jugador 1");

        jugador.AgregarAcorazado("Destructor", 1, 1);

        jugador.ObtenerCasilla(1, 1).Should().Be("d");
        jugador.ObtenerCasilla(1, 2).Should().Be("d");
        jugador.ObtenerCasilla(1, 3).Should().Be("d");
    }

    [Fact]
    public void Si_CreoUnDestructorEnLaPosicion11ConDireccionDerecha_Debe_LasCasillas11_21_31_Tenerd()
    {
        var jugador = new Jugador("Jugador 1");

        jugador.AgregarAcorazado("Destructor", 1, 1, "Derecha");

        jugador.ObtenerCasilla(1, 1).Should().Be("d");
        jugador.ObtenerCasilla(2, 1).Should().Be("d");
        jugador.ObtenerCasilla(3, 1).Should().Be("d");
    }
}
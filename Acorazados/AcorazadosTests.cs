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
        
        jugador.Tablero.GetLength(0).Should().Be(10);
        jugador.Tablero.GetLength(1).Should().Be(10);
    }

    [Fact]
    public void Si_CreoUnCañoneroEnLaPosicion11_Debe_LaCasilla11Tenerg()
    {
        var jugador = new Jugador("Jugador 1");

        jugador.AgregarAcorazado("Cañonero", 1, 1);

        jugador.ObtenerCasilla(1, 1).Should().Be("g");
    }
}

public class Jugador
{
    public string Nombre { get; private set; }
    public string[,] Tablero { get; set; }

    public Jugador(string player)
    {
       Nombre = player;
       Tablero = new string[10,10];
    }

    public void AgregarAcorazado(string tipoBarco, int x, int y)
    {
        Tablero[x, y] = "g";
    }

    public object ObtenerCasilla(int x, int y)
    {
        return  Tablero[x, y];
    }
}
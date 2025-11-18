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
}
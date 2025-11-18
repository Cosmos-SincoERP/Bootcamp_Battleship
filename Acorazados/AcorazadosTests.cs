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
}

public class Jugador
{
    public Jugador(string player)
    {
        throw new NotImplementedException();
    }

    public object Nombre { get; set; }
}
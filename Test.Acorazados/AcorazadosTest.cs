using AwesomeAssertions;

namespace Test.BattleShip;

public class AcorazadosTest
{
    [Fact]
    public void Si_SeAgregaJugador_Debe_MostrarJugador1()
    {
        var juegoAcorazado =  new JuegoAcorazado();
        
        juegoAcorazado.AgregarJugador();
        
        juegoAcorazado.MostrarJugadores()[0].Should().Be("Jugador 1");
    }
}

public class JuegoAcorazado
{
    private List<string> _jugadores = new();
    public void AgregarJugador()
    {
        _jugadores.Add("Jugador 1");
    }

    public List<string> MostrarJugadores()
    {
        return _jugadores;
    }
}
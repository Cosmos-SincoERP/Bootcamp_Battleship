using AwesomeAssertions;

namespace Test.BattleShip;

public class AcorazadosTest
{
    [Fact]
    public void Si_SeAgregaJugador_Debe_ContenerJugador1()
    {
        var juegoAcorazado =  new JuegoAcorazado();
        
        juegoAcorazado.AgregarJugador();
        
        juegoAcorazado.MostrarJugadores().Should().Contain("Jugador 1");
    }
    
    [Fact]
    public void Si_SeAgrega2Jugadores_Debe_ContenerJugador1YJugador2()
    {
        var juegoAcorazado =  new JuegoAcorazado();
        
        juegoAcorazado.AgregarJugador();
        juegoAcorazado.AgregarJugador();
        
        juegoAcorazado.MostrarJugadores().Should().Contain("Jugador 1").And.Contain("Jugador 2");
    }
    
}

public class JuegoAcorazado
{
    private List<string> _jugadores = new();
    public void AgregarJugador()
    {
        if(_jugadores.Count == 1)
            _jugadores.Add("Jugador 2");
        else
            _jugadores.Add("Jugador 1");
    }

    public List<string> MostrarJugadores()
    {
        return _jugadores;
    }
}
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

    [Fact]
    public void Si_SeIniciaElJuegoConUnJugador_Debe_LanzarExcepcion()
    {
        var juegoAcorazado =  new JuegoAcorazado();
        juegoAcorazado.AgregarJugador();

        var iniciarJuego = () => juegoAcorazado.Iniciar();
        
        iniciarJuego.Should().Throw<Exception>().WithMessage("El juego no puede iniciarse hasta que se hayan agregado 2 jugadores");
    }
}

public class JuegoAcorazado
{
    private List<string> _jugadores = new();
    public void AgregarJugador()
    {
        _jugadores.Add(_jugadores.Count == 1 ? "Jugador 2" : "Jugador 1");
    }

    public List<string> MostrarJugadores()
    {
        return _jugadores;
    }

    public void Iniciar()
    {
        throw new NotImplementedException();
    }
}
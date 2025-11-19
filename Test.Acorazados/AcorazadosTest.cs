using AwesomeAssertions;

namespace Test.BattleShip;

public class AcorazadosTest
{
    [Fact]
    public void Si_SeAgregaJugador_Debe_MostrarJugador1()
    {
        var juegoAcorazado =  new JuegoAcorazado();
        
        juegoAcorazado.AgregarJugador();
        
        juegoAcorazado.Jugadores[0].Should().NotBeNull();
    }
}

public class JuegoAcorazado
{
    public List<string> Jugadores { get; private set; }
    public void AgregarJugador()
    {
        throw new NotImplementedException();
    }

}
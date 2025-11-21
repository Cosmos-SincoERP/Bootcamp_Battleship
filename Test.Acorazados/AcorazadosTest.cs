using AwesomeAssertions;

namespace Test.BattleShip;

public class AcorazadosTest
{
    [Fact]
    public void Si_NoHayJugadoresYseIniciaElJuego_Debe_LanzarUnaExcepcionPorCantidadDeJugadores()
    {
        var juegoAcorazado = new JuegoAcorazados();
        var iniciar = () => juegoAcorazado.Iniciar();

        iniciar.Should().Throw<Exception>().WithMessage("No se puede iniciar el juego, debe haber al menos 2 jugadores");
    }
}

public class JuegoAcorazados
{
    public object Iniciar()
    {
        throw new Exception("No se puede iniciar el juego, debe haber al menos 2 jugadores");
    }
}

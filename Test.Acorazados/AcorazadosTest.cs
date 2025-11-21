using AwesomeAssertions;

namespace Test.BattleShip;

public class AcorazadosTest
{
    [Fact]
    public void Si_NoHayJugadoresYSeIniciaElJuego_Debe_LanzarUnaExcepcionPorCantidadDeJugadores()
    {
        var juegoAcorazado = new JuegoAcorazados();
        var iniciar = () => juegoAcorazado.Iniciar();

        iniciar.Should().Throw<Exception>()
            .WithMessage("No se puede iniciar el juego, debe haber al menos 2 jugadores");
    }

    [Fact]
    public void Si_HaySoloUnJugadoreYSeIniciaElJuego_Debe_LanzarUnaExcepcionPorCantidadDeJugadores()
    {
        var juegoAcorazado = new JuegoAcorazados();
        juegoAcorazado.AgregarJugador("Diego");
        var iniciar = () => juegoAcorazado.Iniciar();

        iniciar.Should().Throw<Exception>()
            .WithMessage("No se puede iniciar el juego, debe haber al menos 2 jugadores");
    }

}

public class JuegoAcorazados
{
    public List<string> _jugadores { get; } = new();
    public void Iniciar()
    {
        if (!_jugadores.Any())
            throw new Exception("No se puede iniciar el juego, debe haber al menos 2 jugadores");
    }

    public void AgregarJugador(string nombre)
    {
        throw new NotImplementedException();
    }
}
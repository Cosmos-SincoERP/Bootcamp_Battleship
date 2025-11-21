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
        juegoAcorazado.AgregarJugador("Jugador 1");
        var iniciar = () => juegoAcorazado.Iniciar();

        iniciar.Should().Throw<Exception>()
            .WithMessage("No se puede iniciar el juego, debe haber al menos 2 jugadores");
    }

    [Fact]
    public void Si_TresJugadoreYSeIniciaElJuego_Debe_LanzarUnaExcepcionPorCantidadDeJugadores()
    {
        var juegoAcorazado = new JuegoAcorazados();
        juegoAcorazado.AgregarJugador("Jugador 1");
        juegoAcorazado.AgregarJugador("Jugador 2");
        juegoAcorazado.AgregarJugador("Jugador 3");
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
        if (_jugadores.Count != 2)
            throw new Exception("No se puede iniciar el juego, debe haber al menos 2 jugadores");
    }

    public void AgregarJugador(string nombre)
    {
        _jugadores.Add(nombre);
    }
}
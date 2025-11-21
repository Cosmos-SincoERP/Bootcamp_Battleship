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

    [Fact]
    public void Si_SeIniciaJuegoConDosJugadores_Debe_ImprimirElTableroDelJugadorUnoYDos()
    {
        var juegoAcorazado = new JuegoAcorazados();
        juegoAcorazado.AgregarJugador("Jugador 1");
        juegoAcorazado.AgregarJugador("Jugador 2");
        juegoAcorazado.Iniciar();

        string tableroEsperado = "\n" +
                         "   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | \n" +
                         "-------------------------------------------| \n" +
                         " 0 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 1 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 2 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 3 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 4 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 5 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 6 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 7 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 8 |   |   |   |   |   |   |   |   |   |   | \n" +
                         " 9 |   |   |   |   |   |   |   |   |   |   | \n" +
                         "-------------------------------------------| \n";

        string tableroJugador1 = juegoAcorazado.Imprimir("Jugador 1");
        string tableroJugador2 = juegoAcorazado.Imprimir("Jugador 2");



        tableroJugador1.Should().Be(tableroEsperado);
        tableroJugador2.Should().Be(tableroEsperado);

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

    public string Imprimir(string nombreJugador)
    {
      throw new NotImplementedException();
    }
}
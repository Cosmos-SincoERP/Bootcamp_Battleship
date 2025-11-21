using AwesomeAssertions;

namespace Test.BattleShip;

public class AcorazadosTest
{
    [Fact]
    public void Si_NoHayJugadoresYseIniciaElJuego_Debe_LanzarUnaExcepcionPorCantidadDeJugadores()
    {
        var juegoAcorazado = new JuegoAcorazados();
        var iniciar = () => juegoAcorazado.Iniciar([], []);

        iniciar.Should().Throw<Exception>()
            .WithMessage("No se puede iniciar el juego, debe haber al menos 2 jugadores");
    }

    [Fact]
    public void Si_HayUnSoloJugadorYseIniciaElJuego_Debe_LanzarUnaExcepcionPorCantidadDeJugadores()
    {
        var juegoAcorazado = new JuegoAcorazados();
        juegoAcorazado.AgregarJugador();
        var iniciar = () => juegoAcorazado.Iniciar([], []);

        iniciar.Should().Throw<Exception>()
            .WithMessage("No se puede iniciar el juego, debe haber al menos 2 jugadores");
    }

    [Fact]
    public void Si_AgregoUnTercerJugadorYseIniciaElJuego_Debe_LanzarUnaExcepcionPorCantidadDeJugadores()
    {
        var juegoAcorazado = new JuegoAcorazados();
        juegoAcorazado.AgregarJugador();
        juegoAcorazado.AgregarJugador();
        juegoAcorazado.AgregarJugador();
        var iniciar = () => juegoAcorazado.Iniciar([], []);

        iniciar.Should().ThrowExactly<Exception>()
            .WithMessage("No se puede iniciar el juego, debe haber al menos 2 jugadores");
    }

    [Fact]
    public void Si_IniciaELJuegoSinEnviarBarcosParaPosicionarDelJugador1_Debe_LanzarUnaExcepcionPorNoEnviarBarcos()
    {
        var juegoAcorazado = new JuegoAcorazados();
        juegoAcorazado.AgregarJugador();
        juegoAcorazado.AgregarJugador();
        var iniciar = () => juegoAcorazado.Iniciar([], []);

        iniciar.Should().ThrowExactly<Exception>()
            .WithMessage("El jugador 1, no ha enviado los barcos para posicionar");
    }

    [Fact]
    public void
        Si_IniciaELJuegoYElJugador1SoloEnviaUnCañonerParaPosicionar_Debe_LanzarUnaExcepcionPorFaltaDePosicionamientoBarcos()
    {
        var juegoAcorazado = new JuegoAcorazados();
        juegoAcorazado.AgregarJugador();
        juegoAcorazado.AgregarJugador();

        List<(string tipo, int x, int y, string orientacion)> posicionesJugador1 = new()
        {
            new("Cañonero", 0, 0, "Vertical")
        };

        var iniciar = () => juegoAcorazado.Iniciar(posicionesJugador1, []);

        iniciar.Should().ThrowExactly<Exception>()
            .WithMessage("El jugador 1, no ha enviado todos los cañoneros para posicionar");
    }

    [Fact]
    public void
        Si_IniciaELJuegoYElJugador1SoloEnviaUnDestructorParaPosicionar_Debe_LanzarUnaExcepcionPorFaltaDePosicionamientoBarcos()
    {
        var juegoAcorazado = new JuegoAcorazados();
        juegoAcorazado.AgregarJugador();
        juegoAcorazado.AgregarJugador();

        List<(string tipo, int x, int y, string orientacion)> posicionesJugador1 = new()
        {
            new("Cañonero", 0, 0, "Vertical"),
            new("Cañonero", 0, 0, "Vertical"),
            new("Cañonero", 0, 0, "Vertical"),
            new("Cañonero", 0, 0, "Vertical"),
            new("Destructor", 0, 0, "Vertical")
        };

        var iniciar = () => juegoAcorazado.Iniciar(posicionesJugador1, []);

        iniciar.Should().ThrowExactly<Exception>()
            .WithMessage("El jugador 1, no ha enviado todos los destructores para posicionar");
    }

    [Fact]
    public void
        Si_IniciaELJuegoYElJugador1NoEnviaUnPortavionesParaPosicionar_Debe_LanzarUnaExcepcionPorFaltaDePosicionamientoBarcos()
    {
        var juegoAcorazado = new JuegoAcorazados();
        juegoAcorazado.AgregarJugador();
        juegoAcorazado.AgregarJugador();

        List<(string tipo, int x, int y, string orientacion)> posicionesJugador1 = new()
        {
            new("Cañonero", 0, 0, "Vertical"),
            new("Cañonero", 0, 0, "Vertical"),
            new("Cañonero", 0, 0, "Vertical"),
            new("Cañonero", 0, 0, "Vertical"),
            new("Destructor", 0, 0, "Vertical"),
            new("Destructor", 0, 0, "Vertical"),
        };

        var iniciar = () => juegoAcorazado.Iniciar(posicionesJugador1, []);

        iniciar.Should().ThrowExactly<Exception>()
            .WithMessage("El jugador 1, no ha enviado todos los portaviones para posicionar");
    }


    [Fact]
    public void
        Si_IniciaELJuegoYElJugador1TienePosicionadoTodosLosBarcoYElJugador2NoTieneNinguno_Debe_LanzarUnaExcepcionPorFaltaDePosicionamientoBarcosDelJugador2()
    {
        var juegoAcorazado = new JuegoAcorazados();
        juegoAcorazado.AgregarJugador();
        juegoAcorazado.AgregarJugador();

        List<(string tipo, int x, int y, string orientacion)> posicionesJugador1 = new()
        {
            new("Cañonero", 0, 0, "Vertical"),
            new("Cañonero", 0, 0, "Vertical"),
            new("Cañonero", 0, 0, "Vertical"),
            new("Cañonero", 0, 0, "Vertical"),
            new("Destructor", 0, 0, "Vertical"),
            new("Destructor", 0, 0, "Vertical"),
            new("Portaviones", 0, 0, "Vertical"),
        };

        var iniciar = () => juegoAcorazado.Iniciar(posicionesJugador1, []);

        iniciar.Should().ThrowExactly<Exception>()
            .WithMessage("El jugador 2, no ha enviado los barcos para posicionar");
    }

    [Fact]
    public void
        Si_IniciaELJuegoYElJugador1TienePosicionadoTodosLosBarcoYElJugador2NoTieneTodosLosCañonero_Debe_LanzarUnaExcepcionPorFaltaDeCañoneros()
    {
        var juegoAcorazado = new JuegoAcorazados();
        juegoAcorazado.AgregarJugador();
        juegoAcorazado.AgregarJugador();

        List<(string tipo, int x, int y, string orientacion)> posicionesJugador1 = new()
        {
            new("Cañonero", 0, 0, "Vertical"),
            new("Cañonero", 0, 0, "Vertical"),
            new("Cañonero", 0, 0, "Vertical"),
            new("Cañonero", 0, 0, "Vertical"),
            new("Destructor", 0, 0, "Vertical"),
            new("Destructor", 0, 0, "Vertical"),
            new("Portaviones", 0, 0, "Vertical"),
        };

        List<(string tipo, int x, int y, string orientacion)> posicionesJugador2 = new()
        {
            new("Cañonero", 0, 0, "Vertical")
        };

        var iniciar = () => juegoAcorazado.Iniciar(posicionesJugador1, posicionesJugador2);

        iniciar.Should().ThrowExactly<Exception>()
            .WithMessage("El jugador 2, no ha enviado los barcos para posicionar");
    }
}

public class JuegoAcorazados
{
    private List<string> _jugadores = new();

    public void Iniciar(List<(string tipo, int x, int y, string orientacion)> posicionesBarcosJugador1,
        List<(string tipo, int x, int y, string orientacion)> posicionesBarcosJugador2)
    {
        ValidarCantidadBarcosJugadores(posicionesBarcosJugador1, posicionesBarcosJugador2);
    }

    private void ValidarCantidadBarcosJugadores(
        List<(string tipo, int x, int y, string orientacion)> posicionesBarcosJugador1,
        List<(string tipo, int x, int y, string orientacion)> posicionesBarcosJugador2)
    {
        const int posicionesCañoneros = 4;
        const int posicionesDestructor = 2;


        var FaltanTodosLosBarco = "El jugador {0}, no ha enviado los barcos para posicionar";
        var FaltanLosCañoneros = "El jugador {0}, no ha enviado todos los cañoneros para posicionar";
        var FaltanLosDestructores = "El jugador {0}, no ha enviado todos los destructores para posicionar";
        var FaltanLosPortaviones = "El jugador {0}, no ha enviado todos los portaviones para posicionar";

        if (_jugadores.Count != 2)
            throw new Exception("No se puede iniciar el juego, debe haber al menos 2 jugadores");

        if (posicionesBarcosJugador1.Count == 0)
            throw new Exception(string.Format(FaltanTodosLosBarco, "1"));

        if (posicionesBarcosJugador1.Count(x => x.tipo == "Cañonero") < posicionesCañoneros)
            throw new Exception(string.Format(FaltanLosCañoneros, "1"));

        if (posicionesBarcosJugador1.Count(x => x.tipo == "Destructor") < posicionesDestructor)
            throw new Exception(string.Format(FaltanLosDestructores, "1"));

        if (posicionesBarcosJugador1.Count(x => x.tipo == "Portaviones") < 1)
            throw new Exception(string.Format(FaltanLosPortaviones, "1"));

        if (posicionesBarcosJugador2.Count == 0)
            throw new Exception(string.Format(FaltanTodosLosBarco, "2"));

        if (posicionesBarcosJugador2.Count(x => x.tipo == "Cañonero") < posicionesCañoneros)
            throw new Exception(string.Format(FaltanTodosLosBarco, "2"));
    }

    public void AgregarJugador()
    {
        _jugadores.Add("Jugador 1");
    }
}
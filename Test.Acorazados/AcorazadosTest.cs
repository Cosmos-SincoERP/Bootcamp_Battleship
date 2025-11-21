using AwesomeAssertions;

namespace Test.BattleShip;

public class AcorazadosTest
{
    public static string TableroEsperado(char[,] tablero)
    {
        var tableroEsperado = string.Empty;
        for (var x = 0; x < tablero.GetLength(0); x++)
        {
            for (int y = 0; y < tablero.GetLength(1); y++)
            {
                tableroEsperado += tablero[x, y];
            }

            tableroEsperado += '\n';
        }

        return tableroEsperado;
    }
    
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
        var tercerJugador = () => juegoAcorazado.AgregarJugador();
        
        tercerJugador.Should().ThrowExactly<Exception>()
            .WithMessage("No se permite agregar mas jugadores al juego");
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
            .WithMessage("El jugador 2, no ha enviado todos los cañoneros para posicionar");
    }

    [Fact]
    public void Si_Eljugador1DisparaUnTorpedoEnLaPosicion0_0YNoImpactaUnBarco_Debe_ImprimirElTableroDelJugador2Con_o_EnLaPosicion0_0()
    {
        var tablero = new char[10, 10];
        tablero[0, 0] = 'o';
        var tableroEsperado = TableroEsperado(tablero);
        var juegoAcorazado = new JuegoAcorazados();
        juegoAcorazado.AgregarJugador();
        juegoAcorazado.AgregarJugador();
        var posicionesJugador1 = new List<(string tipo, int x, int y, string orientacion)>()
        {
            new("Cañonero", 2, 1, ""),
            new("Cañonero", 1, 3, ""),
            new("Cañonero", 5, 2, ""),
            new("Cañonero", 7, 6, ""),
            new("Destructor", 1, 5, "Horizontal"),
            new("Destructor", 7, 2, "Vertical"),
            new("Portaviones", 2, 7, "Horizontal"),
        };
        var posicionesJugador2 = new List<(string tipo, int x, int y, string orientacion)>()
        {
            new("Cañonero", 1, 8, ""),
            new("Cañonero", 1, 3, ""),
            new("Cañonero", 2, 5, ""),
            new("Cañonero", 4, 5, ""),
            new("Destructor", 7, 4, "Horizontal"),
            new("Destructor", 4, 7, "Vertical"),
            new("Portaviones", 0, 4, "Vertical"),
        };
        
        juegoAcorazado.Iniciar(posicionesJugador1, posicionesJugador2);
        
        juegoAcorazado.Disparar(0, 0);

        juegoAcorazado.Imprimir().Should().Be(tableroEsperado);
    }
    
    [Fact]
    public void Si_Eljugador1DisparaUnTorpedoEnLaPosicion0_1YNoImpactaUnBarco_Debe_ImprimirElTableroDelJugador2Con_o_EnLaPosicion0_1()
    {
        var tablero = new char[10, 10];
        tablero[0, 1] = 'o';
        var tableroEsperado = TableroEsperado(tablero);
        var juegoAcorazado = new JuegoAcorazados();
        juegoAcorazado.AgregarJugador();
        juegoAcorazado.AgregarJugador();
        var posicionesJugador1 = new List<(string tipo, int x, int y, string orientacion)>()
        {
            new("Cañonero", 2, 1, ""),
            new("Cañonero", 1, 3, ""),
            new("Cañonero", 5, 2, ""),
            new("Cañonero", 7, 6, ""),
            new("Destructor", 1, 5, "Horizontal"),
            new("Destructor", 7, 2, "Vertical"),
            new("Portaviones", 2, 7, "Horizontal"),
        };
        var posicionesJugador2 = new List<(string tipo, int x, int y, string orientacion)>()
        {
            new("Cañonero", 1, 8, ""),
            new("Cañonero", 1, 3, ""),
            new("Cañonero", 2, 5, ""),
            new("Cañonero", 4, 5, ""),
            new("Destructor", 7, 4, "Horizontal"),
            new("Destructor", 4, 7, "Vertical"),
            new("Portaviones", 0, 4, "Vertical"),
        };
        
        juegoAcorazado.Iniciar(posicionesJugador1, posicionesJugador2);
        
        juegoAcorazado.Disparar(0, 1);

        juegoAcorazado.Imprimir().Should().Be(tableroEsperado);
    }

    
}

public class JuegoAcorazados
{
    private List<string> _jugadores = new();
    private char[,] _tablero = new char[10, 10];

    public void AgregarJugador()
    {
        if(_jugadores.Count == 2)
            throw new Exception("No se permite agregar mas jugadores al juego");

        _jugadores.Add(_jugadores.Count == 1 ? "2" : "1");
    }
    
    public void Iniciar(List<(string tipo, int x, int y, string orientacion)> posicionesBarcosJugador1,
        List<(string tipo, int x, int y, string orientacion)> posicionesBarcosJugador2)
    {
        if (_jugadores.Count != 2)
            throw new Exception("No se puede iniciar el juego, debe haber al menos 2 jugadores");

        ValidarCantidadBarcos(posicionesBarcosJugador1, _jugadores[0]);
        ValidarCantidadBarcos(posicionesBarcosJugador2, _jugadores[1]);
        
    }
    
    public void Disparar(int x, int y)
    {
        _tablero[x, y] = 'o';
    }
    
    public string Imprimir()
    {
        var visualizarTablero = string.Empty;
        for (var x = 0; x < _tablero.GetLength(0); x++)
        {
            for (int y = 0; y < _tablero.GetLength(1); y++)
            {
                visualizarTablero += _tablero[x, y];
            }
            visualizarTablero += '\n';
        }
        return visualizarTablero;
    }

    private void ValidarCantidadBarcos(
        List<(string tipo, int x, int y, string orientacion)> posicionesBarcosJugador, string nombreJugador)
    {
        const int cantidadCañoneros = 4;
        const int cantidadDestructores = 2;
        const int cantidadPortaAviones = 1;
        
        const string faltanTodosLosBarco = "El jugador {0}, no ha enviado los barcos para posicionar";
        const string faltanLosCañoneros = "El jugador {0}, no ha enviado todos los cañoneros para posicionar";
        const string faltanLosDestructores = "El jugador {0}, no ha enviado todos los destructores para posicionar";
        const string faltanLosPortaviones = "El jugador {0}, no ha enviado todos los portaviones para posicionar";


        if (posicionesBarcosJugador.Count == 0)
            throw new Exception(string.Format(faltanTodosLosBarco, nombreJugador));

        if (posicionesBarcosJugador.Count(barco => barco.tipo == "Cañonero") < cantidadCañoneros)
            throw new Exception(string.Format(faltanLosCañoneros, nombreJugador));

        if (posicionesBarcosJugador.Count(barco => barco.tipo == "Destructor") < cantidadDestructores)
            throw new Exception(string.Format(faltanLosDestructores, nombreJugador));

        if (posicionesBarcosJugador.Count(barco => barco.tipo == "Portaviones") < cantidadPortaAviones)
            throw new Exception(string.Format(faltanLosPortaviones, nombreJugador));
    }
}
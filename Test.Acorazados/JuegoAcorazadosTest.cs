using AwesomeAssertions;
using Test.BattleShip.Dominio;
using Test.BattleShip.Dominio.Barcos;

namespace Test.BattleShip;

public class JuegoAcorazadosTest
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

        var posicionesJugador1 = new List<Barco>
        {
            new Cañonero(new (0, 0)),
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

        var posicionesJugador1 = new List<Barco>
        {
            new Cañonero(new (0, 0)),
            new Cañonero( new (0, 0)),
            new Cañonero( new (0, 0)),
            new Cañonero( new (0, 0)),
            new Destructor(new( 0, 0), OrientacionBarco.Vertical),
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

        var posicionesJugador1 = new List<Barco>
        {
            new Cañonero(new (0, 0)),
            new Cañonero( new (0, 0)),
            new Cañonero( new (0, 0)),
            new Cañonero( new (0, 0)),
            new Destructor(new( 0, 0), OrientacionBarco.Vertical),
            new Destructor(new( 0, 0), OrientacionBarco.Vertical),
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

        var posicionesJugador1 = new List<Barco>
        {
            new Cañonero(new (0, 0)),
            new Cañonero( new (0, 0)),
            new Cañonero( new (0, 0)),
            new Cañonero( new (0, 0)),
            new Destructor(new( 0, 0), OrientacionBarco.Vertical),
            new Destructor(new( 0, 0), OrientacionBarco.Vertical),
            new PortaAviones(new(0, 0), OrientacionBarco.Horizontal),
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

        var posicionesJugador1 = new List<Barco>
        {
            new Cañonero(new (0, 0)),
            new Cañonero( new (0, 0)),
            new Cañonero( new (0, 0)),
            new Cañonero( new (0, 0)),
            new Destructor(new( 0, 0), OrientacionBarco.Vertical),
            new Destructor(new( 0, 0), OrientacionBarco.Vertical),
            new PortaAviones(new(0, 0), OrientacionBarco.Horizontal),
        };

        var posicionesJugador2 = new List<Barco>
        {
            new Cañonero(new(0, 0))
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
        var juegoAcorazado = Mocks.MockIniciarJuego();

        juegoAcorazado.Disparar(0, 0);

        juegoAcorazado.Imprimir().Should().Be(tableroEsperado);
    }

    [Fact]
    public void Si_Eljugador1DisparaUnTorpedoEnLaPosicion0_1YNoImpactaUnBarco_Debe_ImprimirElTableroDelJugador2Con_o_EnLaPosicion0_1()
    {
        var tablero = new char[10, 10];
        tablero[0, 1] = 'o';
        var tableroEsperado = TableroEsperado(tablero);
        var juegoAcorazado = Mocks.MockIniciarJuego();

        juegoAcorazado.Disparar(0, 1);

        juegoAcorazado.Imprimir().Should().Be(tableroEsperado);
    }

    [Fact]
    public void Si_Eljugador1DisparaUnTorpedoEnLaPosicion0_4YGolpeaUnBarco_Debe_ImprimirElTableroDelJugador2Con_x_EnLaPosicion0_4()
    {
        var tablero = new char[10, 10];
        tablero[0, 4] = 'x';
        var tableroEsperado = TableroEsperado(tablero);
        var juegoAcorazado = Mocks.MockIniciarJuego();

        juegoAcorazado.Disparar(0, 4);

        juegoAcorazado.Imprimir().Should().Be(tableroEsperado);
    }
    
    [Fact]
    public void Si_Eljugador2DisparaUnTorpedoEnLaPosicion1_1YNoImpactaUnBarco_Debe_ImprimirElTableroDelJugador1Con_o_EnLaPosicion1_1()
    {
        var tablero = new char[10, 10];
        tablero[1, 1] = 'o';
        var tableroEsperado = TableroEsperado(tablero);
        var juegoAcorazado = Mocks.MockIniciarJuego();
    
        juegoAcorazado.Disparar(0, 4);
        juegoAcorazado.FinalizarTurno();
        juegoAcorazado.Disparar(1, 1);

        juegoAcorazado.Imprimir().Should().Be(tableroEsperado);
    }
    
    [Fact]
    public void Si_Eljugador2DisparaUnTorpedoEnLaPosicion2_1YHundeUnBarco_Debe_ImprimirElTableroDelJugador1Con_X_EnLaPosicion2_1()
    {
        var tablero = new char[10, 10];
        tablero[2, 1] = 'X';
        var tableroEsperado = TableroEsperado(tablero);
        var juegoAcorazado = Mocks.MockIniciarJuego();
    
        juegoAcorazado.Disparar(0, 4);
        juegoAcorazado.FinalizarTurno();
        juegoAcorazado.Disparar(2, 1);

        juegoAcorazado.Imprimir().Should().Be(tableroEsperado);
    }
    
    [Fact]
    public void Si_Eljugador2DisparaUnTorpedoEnLaPosicion2_1YHundeUnBarco_Debe_NotificarQueElBarcoDelJugador1_SeHundio()
    {
        var juegoAcorazado = Mocks.MockIniciarJuego();
    
        juegoAcorazado.Disparar(0, 4);
        juegoAcorazado.FinalizarTurno();
        var barcoHundido = juegoAcorazado.Disparar(2, 1);

        barcoHundido.Should().Be("Se hundio un barco en la coordenada (2,1)");
    }
    
    [Fact]
    public void Si_Eljugador1DisparaUnTorpedoEnLaPosicion4_7YHundeUnBarco_Debe_ImprimirElTableroDelJugador2Con_X_EnLaPosicion4_7()
    {
        var tablero = new char[10, 10];
        tablero[4, 7] = 'X';
        var tableroEsperado = TableroEsperado(tablero);
        var juegoAcorazado = Mocks.MockIniciarJuego();
    
        juegoAcorazado.Disparar(4, 7);

        juegoAcorazado.Imprimir().Should().Be(tableroEsperado);
    }
    
    
    [Fact]
    public void Si_Eljugador1DisparaUnTorpedoEnLaPosicion4_7YHundeUnBarco_Debe_NotificarQueElBarcoDelJugador1_SeHundio()
    {
        var juegoAcorazado = Mocks.MockIniciarJuego();
    
        var barcoHundido = juegoAcorazado.Disparar(4, 7);

        barcoHundido.Should().Be("Se hundio un barco en la coordenada (4,7)");
    }
    
    
    [Fact]
    public void Si_Eljugador1DisparaUnTorpedoEnLaPosicion8_1YHundeUnBarco_Debe_NotificarQueElBarcoDelJugador1_SeHundio()
    {
        var juegoAcorazado = Mocks.MockIniciarJuego();
    
        var barcoHundido = juegoAcorazado.Disparar(4, 7);

        barcoHundido.Should().Be("Se hundio un barco en la coordenada (8,1)");
    }
}
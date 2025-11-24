using AwesomeAssertions;
using Test.BattleShip.Dominio;
using Test.BattleShip.Dominio.Barcos;

namespace Test.BattleShip;

public class JuegoAcorazadosTest
{
    [Fact]
    public void Si_NoHayJugadoresYseIniciaElJuego_Debe_LanzarUnaExcepcionPorCantidadDeJugadores()
    {
        var juegoAcorazado = new Juego();
        var iniciar = () => juegoAcorazado.Iniciar([]);

        iniciar.Should().Throw<Exception>()
            .WithMessage("No se puede iniciar el juego, debe haber al menos 2 jugadores");
    }

    [Fact]
    public void Si_HayUnSoloJugadorYseIniciaElJuego_Debe_LanzarUnaExcepcionPorCantidadDeJugadores()
    {
        var juegoAcorazado = new Juego();
        juegoAcorazado.AgregarJugador();
        var iniciar = () => juegoAcorazado.Iniciar([]);

        iniciar.Should().Throw<Exception>()
            .WithMessage("No se puede iniciar el juego, debe haber al menos 2 jugadores");
    }

    [Fact]
    public void Si_AgregoUnTercerJugadorYseIniciaElJuego_Debe_LanzarUnaExcepcionPorCantidadDeJugadores()
    {
        var juegoAcorazado = new Juego();
        juegoAcorazado.AgregarJugador();
        juegoAcorazado.AgregarJugador();
        var tercerJugador = () => juegoAcorazado.AgregarJugador();

        tercerJugador.Should().ThrowExactly<Exception>()
            .WithMessage("No se permite agregar mas jugadores al juego");
    }

    [Fact]
    public void
        Si_IniciaELJuegoYElJugador1SoloEnviaUnCañonerParaPosicionar_Debe_LanzarUnaExcepcionPorFaltaDePosicionamientoBarcos()
    {
        var juegoAcorazado = new Juego();
        juegoAcorazado.AgregarJugador();
        juegoAcorazado.AgregarJugador();

        var posicionesJugador1 = new List<Barco>
        {
            new Cañonero(new(0, 0)),
        };

        var iniciar = () => juegoAcorazado.Iniciar([(0, posicionesJugador1)]);

        iniciar.Should().ThrowExactly<Exception>()
            .WithMessage("El jugador 1, no ha enviado todos los cañoneros para posicionar");
    }

    [Fact]
    public void
        Si_IniciaELJuegoYElJugador1SoloEnviaUnDestructorParaPosicionar_Debe_LanzarUnaExcepcionPorFaltaDePosicionamientoBarcos()
    {
        var juegoAcorazado = new Juego();
        juegoAcorazado.AgregarJugador();
        juegoAcorazado.AgregarJugador();

        var posicionesJugador1 = new List<Barco>
        {
            new Cañonero(new(1, 0)),
            new Cañonero(new(2, 0)),
            new Cañonero(new(3, 0)),
            new Cañonero(new(4, 0)),
            new Destructor(new(5, 5), OrientacionBarco.Vertical),
        };

        var iniciar = () => juegoAcorazado.Iniciar([(0, posicionesJugador1)]);

        iniciar.Should().ThrowExactly<Exception>()
            .WithMessage("El jugador 1, no ha enviado todos los destructores para posicionar");
    }

    [Fact]
    public void
        Si_IniciaELJuegoYElJugador1NoEnviaUnPortavionesParaPosicionar_Debe_LanzarUnaExcepcionPorFaltaDePosicionamientoBarcos()
    {
        var juegoAcorazado = new Juego();
        juegoAcorazado.AgregarJugador();
        juegoAcorazado.AgregarJugador();

        var posicionesJugador1 = new List<Barco>
        {
            new Cañonero(new(1, 0)),
            new Cañonero(new(2, 0)),
            new Cañonero(new(3, 0)),
            new Cañonero(new(4, 0)),
            new Destructor(new(5, 4), OrientacionBarco.Vertical),
            new Destructor(new(6, 5), OrientacionBarco.Vertical),
        };

        var iniciar = () => juegoAcorazado.Iniciar([(0, posicionesJugador1)]);

        iniciar.Should().ThrowExactly<Exception>()
            .WithMessage("El jugador 1, no ha enviado todos los portaviones para posicionar");
    }

    [Fact]
    public void
        Si_IniciaELJuegoYElJugador1TienePosicionadoTodosLosBarcoYElJugador2NoTieneTodosLosCañonero_Debe_LanzarUnaExcepcionPorFaltaDeCañoneros()
    {
        var juegoAcorazado = new Juego();
        juegoAcorazado.AgregarJugador();
        juegoAcorazado.AgregarJugador();

        var posicionesJugador1 = new List<Barco>
        {
            new Cañonero(new(1, 0)),
            new Cañonero(new(2, 0)),
            new Cañonero(new(3, 0)),
            new Cañonero(new(4, 0)),
            new Destructor(new(5, 4), OrientacionBarco.Vertical),
            new Destructor(new(6, 5), OrientacionBarco.Vertical),
            new PortaAviones(new(7, 2), OrientacionBarco.Horizontal),
        };

        var posicionesJugador2 = new List<Barco>
        {
            new Cañonero(new(0, 0))
        };


        var iniciar = () => juegoAcorazado.Iniciar([(0, posicionesJugador1), (1, posicionesJugador2)]);

        iniciar.Should().ThrowExactly<Exception>()
            .WithMessage("El jugador 2, no ha enviado todos los cañoneros para posicionar");
    }

    [Fact]
    public void
        Si_Eljugador1DisparaUnTorpedoEnLaPosicion0_0YNoImpactaUnBarco_Debe_ImprimirElTableroDelJugador2Con_o_EnLaPosicion0_0()
    {
        var tablero = new char[10, 10];
        tablero[0, 0] = 'o';
        var tableroEsperado = Mocks.TableroEsperado(tablero);
        var juegoAcorazado = Mocks.MockIniciarJuego();

        juegoAcorazado.Disparar(new Coordenada(0, 0));

        juegoAcorazado.Imprimir().Should().Be(tableroEsperado);
    }

    [Fact]
    public void
        Si_Eljugador1DisparaUnTorpedoEnLaPosicion0_1YNoImpactaUnBarco_Debe_ImprimirElTableroDelJugador2Con_o_EnLaPosicion0_1()
    {
        var tablero = new char[10, 10];
        tablero[0, 1] = 'o';
        var tableroEsperado = Mocks.TableroEsperado(tablero);
        var juegoAcorazado = Mocks.MockIniciarJuego();

        juegoAcorazado.Disparar(new Coordenada(0, 1));

        juegoAcorazado.Imprimir().Should().Be(tableroEsperado);
    }

    [Fact]
    public void
        Si_Eljugador1DisparaUnTorpedoEnLaPosicion0_4YGolpeaUnBarco_Debe_ImprimirElTableroDelJugador2Con_x_EnLaPosicion0_4()
    {
        var tablero = new char[10, 10];
        tablero[4, 0] = 'x';
        var tableroEsperado = Mocks.TableroEsperado(tablero);
        var juegoAcorazado = Mocks.MockIniciarJuego();

        juegoAcorazado.Disparar(new Coordenada(4, 0));

        juegoAcorazado.Imprimir().Should().Be(tableroEsperado);
    }

    [Fact]
    public void
        Si_Eljugador2DisparaUnTorpedoEnLaPosicion1_1YNoImpactaUnBarco_Debe_ImprimirElTableroDelJugador1Con_o_EnLaPosicion1_1()
    {
        var tablero = new char[10, 10];
        tablero[1, 1] = 'o';
        var tableroEsperado = Mocks.TableroEsperado(tablero);
        var juegoAcorazado = Mocks.MockIniciarJuego();

        juegoAcorazado.Disparar(new Coordenada(0, 4));
        juegoAcorazado.FinalizarTurno();
        juegoAcorazado.Disparar(new Coordenada(1, 1));

        juegoAcorazado.Imprimir().Should().Be(tableroEsperado);
    }

    [Fact]
    public void
        Si_Eljugador2DisparaUnTorpedoEnLaPosicion2_1YHundeUnBarco_Debe_ImprimirElTableroDelJugador1Con_X_EnLaPosicion2_1()
    {
        var tablero = new char[10, 10];
        tablero[2, 1] = 'X';
        var tableroEsperado = Mocks.TableroEsperado(tablero);
        var juegoAcorazado = Mocks.MockIniciarJuego();

        juegoAcorazado.Disparar(new Coordenada(0, 4));
        juegoAcorazado.FinalizarTurno();
        juegoAcorazado.Disparar(new Coordenada(2, 1));

        juegoAcorazado.Imprimir().Should().Be(tableroEsperado);
    }

    [Fact]
    public void Si_Eljugador2DisparaUnTorpedoEnLaPosicion2_1YHundeUnBarco_Debe_NotificarQueElBarcoDelJugador1_SeHundio()
    {
        var juegoAcorazado = Mocks.MockIniciarJuego();

        juegoAcorazado.Disparar(new Coordenada(0, 4));
        juegoAcorazado.FinalizarTurno();
        var barcoHundido = juegoAcorazado.Disparar(new Coordenada(2, 1));

        barcoHundido.Should().Be("Se hundio un barco en la coordenada (2,1)");
    }

    [Fact]
    public void
        Si_Eljugador1DisparaUnTorpedoEnLaPosicion4_7YHundeUnBarco_Debe_ImprimirElTableroDelJugador2Con_X_EnLaPosicion4_7()
    {
        var tablero = new char[10, 10];
        tablero[4, 7] = 'X';
        tablero[4, 8] = 'X';
        tablero[4, 9] = 'X';
        var tableroEsperado = Mocks.TableroEsperado(tablero);
        var juegoAcorazado = Mocks.MockIniciarJuego();

        juegoAcorazado.Disparar(new Coordenada(4, 9));
        juegoAcorazado.FinalizarTurno();
        juegoAcorazado.Disparar(new Coordenada(0, 0));
        juegoAcorazado.FinalizarTurno();
        juegoAcorazado.Disparar(new Coordenada(4, 8));
        juegoAcorazado.FinalizarTurno();
        juegoAcorazado.Disparar(new Coordenada(1, 0));
        juegoAcorazado.FinalizarTurno();
        juegoAcorazado.Disparar(new Coordenada(4, 7));

        juegoAcorazado.Imprimir().Should().Be(tableroEsperado);
    }


    [Fact]
    public void Si_Eljugador1DisparaUnTorpedoEnLaPosicion4_7YHundeUnBarco_Debe_NotificarQueElBarcoDelJugador2_SeHundio()
    {
        var juegoAcorazado = Mocks.MockIniciarJuego();

        juegoAcorazado.Disparar(new Coordenada(4, 9));
        juegoAcorazado.FinalizarTurno();
        juegoAcorazado.Disparar(new Coordenada(0, 0));
        juegoAcorazado.FinalizarTurno();
        juegoAcorazado.Disparar(new Coordenada(4, 8));
        juegoAcorazado.FinalizarTurno();
        juegoAcorazado.Disparar(new Coordenada(1, 0));
        juegoAcorazado.FinalizarTurno();

        var barcoHundido = juegoAcorazado.Disparar(new Coordenada(4, 7));

        barcoHundido.Should().Be("Se hundio un barco en la coordenada (4,7)");
    }


    [Fact]
    public void Si_Eljugador1DisparaUnTorpedoEnLaPosicion1_8YHundeUnBarco_Debe_NotificarQueElBarcoDelJugador2_SeHundio()
    {
        var juegoAcorazado = Mocks.MockIniciarJuego();

        var barcoHundido = juegoAcorazado.Disparar(new Coordenada(1, 8));

        barcoHundido.Should().Be("Se hundio un barco en la coordenada (1,8)");
    }

    [Fact]
    public void Si_Eljugador1DisparaUnTorpedoEnLaPosicion7_4YHundeUnBarco_Debe_NotificarQueElBarcoDelJugador2_SeHundio()
    {
        var juegoAcorazado = Mocks.MockIniciarJuego();
        juegoAcorazado.Disparar(new Coordenada(9, 4));
        juegoAcorazado.FinalizarTurno();
        juegoAcorazado.Disparar(new Coordenada(0, 0));
        juegoAcorazado.FinalizarTurno();
        juegoAcorazado.Disparar(new Coordenada(8, 4));
        juegoAcorazado.FinalizarTurno();
        juegoAcorazado.Disparar(new Coordenada(0, 1));
        juegoAcorazado.FinalizarTurno();

        var barcoHundido = juegoAcorazado.Disparar(new Coordenada(7, 4));

        barcoHundido.Should().Be("Se hundio un barco en la coordenada (7,4)");
    }

    [Fact]
    public void
        Si_Eljugador1DisparaUnTorpedoEnLaPosicion4_2YHundeUnBarco_Debe_NotificarQueElBarcoDelJugador2_SeHundioEnLaPosicion4_0()
    {
        var juegoAcorazado = Mocks.MockIniciarJuego();
        juegoAcorazado.Disparar(new Coordenada(4, 3));
        juegoAcorazado.FinalizarTurno();
        juegoAcorazado.Disparar(new Coordenada(0, 0));
        juegoAcorazado.FinalizarTurno();
        juegoAcorazado.Disparar(new Coordenada(4, 1));
        juegoAcorazado.FinalizarTurno();
        juegoAcorazado.Disparar(new Coordenada(0, 1));
        juegoAcorazado.FinalizarTurno();
        juegoAcorazado.Disparar(new Coordenada(4, 0));
        juegoAcorazado.FinalizarTurno();
        juegoAcorazado.Disparar(new Coordenada(0, 2));
        juegoAcorazado.FinalizarTurno();

        var barcoHundido = juegoAcorazado.Disparar(new Coordenada(4, 2));

        barcoHundido.Should().Be("Se hundio un barco en la coordenada (4,0)");
    }

    [Fact]
    public void Si_Eljugador2HundeTodosLosBarcos_Debe_MostrarInformeDeBatallaConElTotalDisparos14Jugador2()
    {
        var juegoAcorazado = Mocks.MockIniciarJuego(true);

        juegoAcorazado.Imprimir().Should().Contain("Total de disparos: 14");
    }

    [Fact]
    public void Si_Eljugador2HundeTodosLosBarcos_Debe_MostrarInformeDeBatallaConDisparosFallidos0()
    {
        var juegoAcorazado = Mocks.MockIniciarJuego(true);

        juegoAcorazado.Imprimir().Should().Contain("Disparos fallidos: 0");
    }

    [Fact]
    public void Si_Eljugador2HundeTodosLosBarcos_Debe_MostrarInformeDeBatallaConDisparosAcertados14()
    {
        var juegoAcorazado = Mocks.MockIniciarJuego(true);

        juegoAcorazado.Imprimir().Should().Contain("Disparos acertados: 14");
    }
}
using AwesomeAssertions;
using Test.BattleShip.Dominio;

namespace Test.BattleShip;

public class JuegoAcorazadosTestBorde
{
    [Fact]
    public void
    Si_IniciaElJuegoYSePosicionanBarcoEnUnaCoordenadaEnXMayorA10_Debe_LanzarExcepcion()
    {
        var juegoAcorazado = () => Mocks.MockIniciarJuegoConBarcoEnCoordenadaXMayorA10();

        juegoAcorazado.Should().ThrowExactly<Exception>().WithMessage("El jugador 1 ha enviado un barco con coordenadas invalidas, Cañonero(11,1)");
    }

    [Fact]
    public void Si_IniciaElJuegoYSePosicionanBarcoEnUnaCoordenadaEnXMenoA0_Debe_LanzarExcepcion()
    {
        var juegoAcorazado = () => Mocks.MockIniciarJuegoConBarcoEnCoordenadaXMenorA0();

        juegoAcorazado.Should().ThrowExactly<Exception>().WithMessage("El jugador 1 ha enviado un barco con coordenadas invalidas, Cañonero(-1,1)");
    }


    [Fact]
    public void Si_IniciaElJuegoYSePosicionanBarcoEnUnaCoordenadaEnYMayorA10_Debe_LanzarExcepcion()
    {
        var juegoAcorazado = () => Mocks.MockIniciarJuegoConBarcoEnCoordenadaYMayorA10();

        juegoAcorazado.Should().ThrowExactly<Exception>().WithMessage("El jugador 1 ha enviado un barco con coordenadas invalidas, Cañonero(1,11)");
    }

    [Fact]
    public void Si_IniciaElJuegoYSePosicionanBarcoEnUnaCoordenadaEnYMenorA0_Debe_LanzarExcepcion()
    {
        var juegoAcorazado = () => Mocks.MockIniciarJuegoConBarcoEnCoordenadaYMenorA0();

        juegoAcorazado.Should().ThrowExactly<Exception>().WithMessage("El jugador 1 ha enviado un barco con coordenadas invalidas, Cañonero(1,-1)");
    }

    [Fact]
    public void Si_IniciaElJuegoYSePosicionanBarcosEnCoordenadasNoValidas_Debe_LanzarExcepcionConLosBarcoQueEstanMalPosicionado()
    {
        var juegoAcorazado = () => Mocks.MockIniciarJuegoConBarcoEnCoordenadaNoValidas();

        juegoAcorazado.Should().ThrowExactly<Exception>().WithMessage("El jugador 1 ha enviado un barco con coordenadas invalidas, Cañonero(-1,1), Destructor(1,15)");
    }


    [Fact]
    public void
    Si_Eljugador1PosionaUnBarcoDondeYaPosicionanorOtroBarcoEnLaMismaPosicion_Debe_LanzarExcepcion()
    {
        var tablero = new char[10, 10];
        tablero[0, 0] = 'o';
        var tableroEsperado = Mocks.TableroEsperado(tablero);
        var juegoAcorazado = () => Mocks.MockIniciarJuegoConBarcoEnPosicionesOcupadas();

        juegoAcorazado.Should().ThrowExactly<Exception>().WithMessage("El jugador 1 ha enviado barcos que existen en la coordenada:(2,2)");
    }

    [Fact]
    public void Si_Eljugador1PosionaDosBarcoDondeYaPosicionanorOtrosBarcoEnLaMismaPosicion_Debe_LanzarExcepcion()
    {
        var tablero = new char[10, 10];
        tablero[0, 0] = 'o';
        var tableroEsperado = Mocks.TableroEsperado(tablero);
        var juegoAcorazado = () => Mocks.MockIniciarJuegoConBarcoDeDiferentesTipoEnPosicionesOcupadas();

        juegoAcorazado.Should().ThrowExactly<Exception>().WithMessage("El jugador 1 ha enviado barcos que existen en la coordenada:(2,2), (1,5)");
    }

    [Fact]
    public void Si_Eljugador1DisparaDosTorpedosEnElMismoTurno_Debe_LanzarExcepcion()
    {
        var juegoAcorazado = Mocks.MockIniciarJuego();

        juegoAcorazado.Disparar(new Coordenada(0, 4));
        var barcoHundido = () => juegoAcorazado.Disparar(new Coordenada(2, 1));

        barcoHundido.Should().ThrowExactly<Exception>().WithMessage("El jugador ya ha realizado un disparo en este turno");
    }

    [Fact]
    public void Si_Eljugador1DisparaDosTorpedosAlMarEnLaMismaPosicion_Debe_LanzarExcepcion()
    {
        var juegoAcorazado = Mocks.MockIniciarJuego();

        juegoAcorazado.Disparar(new Coordenada(0, 4));
        juegoAcorazado.FinalizarTurno();
        juegoAcorazado.Disparar(new Coordenada(1, 5));
        juegoAcorazado.FinalizarTurno();
        var barcoHundido = () => juegoAcorazado.Disparar(new Coordenada(0, 4));

        barcoHundido.Should().ThrowExactly<Exception>().WithMessage("El jugador ya lanzo un disparo en la coordenada (0,4)");
    }

    [Fact]
    public void Si_Eljugador1DisparaDosTorpedosEnLaMismaPosicionYEsteYaEstaHundido_Debe_LanzarExcepcion()
    {
        var juegoAcorazado = Mocks.MockIniciarJuego();

        juegoAcorazado.Disparar(new Coordenada(1, 8));
        juegoAcorazado.FinalizarTurno();
        juegoAcorazado.Disparar(new Coordenada(1, 5));
        juegoAcorazado.FinalizarTurno();
        var barcoHundido = () => juegoAcorazado.Disparar(new Coordenada(1, 8));

        barcoHundido.Should().ThrowExactly<Exception>().WithMessage("El jugador ya lanzo un disparo en la coordenada (1,8)");
    }

    [Fact]
    public void Si_Eljugador1DisparaDosTorpedosEnLaMismaPosicionALaQueaYaImpactoParteDelBarco_Debe_LanzarExcepcion()
    {
        var juegoAcorazado = Mocks.MockIniciarJuego();

        juegoAcorazado.Disparar(new Coordenada(7, 4));
        juegoAcorazado.FinalizarTurno();
        juegoAcorazado.Disparar(new Coordenada(1, 5));
        juegoAcorazado.FinalizarTurno();
        var barcoHundido = () => juegoAcorazado.Disparar(new Coordenada(7, 4));

        barcoHundido.Should().ThrowExactly<Exception>().WithMessage("El jugador ya lanzo un disparo en la coordenada (7,4)");
    }

    [Fact]
    public void Si_JuegoNoEstaIniciadoYSeDispara_Debe_LanzarExcepcion()
    {
        var juegoAcorazado = new Juego();

        var disparar = () => juegoAcorazado.Disparar(new(0, 0));

        disparar.Should().ThrowExactly<Exception>().WithMessage("El juego no ha sido iniciado");
    }

    [Fact]
    public void Si_JuegoNoEstaIniciadoYSeImprime_Debe_LanzarExcepcion()
    {
        var juegoAcorazado = new Juego();

        var disparar = () => juegoAcorazado.Imprimir();

        disparar.Should().ThrowExactly<Exception>().WithMessage("El juego no ha sido iniciado");
    }

    [Fact]
    public void Si_JuegoNoEstaIniciadoYFinalizaTurno_Debe_LanzarExcepcion()
    {
        var juegoAcorazado = new Juego();

        var disparar = () => juegoAcorazado.FinalizarTurno();

        disparar.Should().ThrowExactly<Exception>().WithMessage("El juego no ha sido iniciado");
    }

    [Fact]
    public void Si_JuegoEstaIniciadoYFinalizoTurno_Debe_LanzarExcepcion()
    {
        var juegoAcorazado = Mocks.MockIniciarJuego();

        var disparar = () => juegoAcorazado.FinalizarTurno();

        disparar.Should().ThrowExactly<Exception>().WithMessage("No se puede finalizar el turno si no se ha realizado un disparo");
    }


    [Fact]
    public void Si_Eljugador1DisparaEnUnaPosicionEnX_18_Debe_LanzarExcepcion()
    {
        var juegoAcorazado = Mocks.MockIniciarJuego();

        var barcoHundido = () => juegoAcorazado.Disparar(new Coordenada(18, 5));

        barcoHundido.Should().ThrowExactly<Exception>().WithMessage("La coordenada del disparo excede el tamaño del tablero (18,5)");
    }

    [Fact]
    public void Si_Eljugador1DisparaEnUnaPosicionEnX_Menos_1_Debe_LanzarExcepcion()
    {
        var juegoAcorazado = Mocks.MockIniciarJuego();

        var barcoHundido = () => juegoAcorazado.Disparar(new Coordenada(-1, 5));

        barcoHundido.Should().ThrowExactly<Exception>().WithMessage("La coordenada del disparo excede el tamaño del tablero (-1,5)");
    }
}
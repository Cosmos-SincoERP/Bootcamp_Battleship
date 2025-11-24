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
    Si_Eljugador1PosionaUnBarcoDondeYaHayUnBarco_Debe_LanzarExcepcion()
    {
        var tablero = new char[10, 10];
        tablero[0, 0] = 'o';
        var tableroEsperado = Mocks.TableroEsperado(tablero);
        var juegoAcorazado = () => Mocks.MockIniciarJuegoConBarcoEnPosicionesOcupadas();



        juegoAcorazado.Should().ThrowExactly<Exception>().WithMessage("El jugador 1 ha enviado un barco en una posicion que ya esta ocupada");
    }
}
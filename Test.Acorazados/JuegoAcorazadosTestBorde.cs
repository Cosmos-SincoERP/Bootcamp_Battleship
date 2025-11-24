using AwesomeAssertions;

namespace Test.BattleShip;

public class JuegoAcorazadosTestBorde
{
    [Fact]
    public void
    Si_IniciaElJuegoYSePosicionanBarcoEnUnaCoordenadaEnXMayorA10_Debe_LanzarExcepcion()
    {
        var tablero = new char[10, 10];
        tablero[0, 0] = 'o';
        var tableroEsperado = Mocks.TableroEsperado(tablero);
        var juegoAcorazado = () => Mocks.MockIniciarJuegoConBarcoEnCoordenadaXMayorA10Invalida();

        juegoAcorazado.Should().ThrowExactly<Exception>().WithMessage("El jugador 1, ha enviado un barco con coordenadas invalidas (11,1)");
    }
}
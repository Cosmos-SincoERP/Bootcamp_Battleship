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
        var juegoAcorazado = () => Mocks.MockIniciarJuegoConBarcoEnCoordenadaInvalida();

        juegoAcorazado.Should().ThrowExactly<Exception>().WithMessage("La coordenada no es valida");
    }
}
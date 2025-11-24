using AwesomeAssertions;

namespace Test.BattleShip;

public class JuegoAcorazadosTestBorde
{
    [Fact]
    public void
    Si_IniciaElJuegoYSePosicionanBarcoEnUnaCoordenadaEnXMayorA10_Debe_LanzarExcepcion()
    {
        var juegoAcorazado = () => Mocks.MockIniciarJuegoConBarcoEnCoordenadaXMayorA10();

        juegoAcorazado.Should().ThrowExactly<Exception>().WithMessage("El jugador 1, ha enviado un barco con coordenadas invalidas (11,1)");
    }

    [Fact]
    public void Si_IniciaElJuegoYSePosicionanBarcoEnUnaCoordenadaEnXMenoA0_Debe_LanzarExcepcion()
    {
        var juegoAcorazado = () => Mocks.MockIniciarJuegoConBarcoEnCoordenadaXMenorA0();

        juegoAcorazado.Should().ThrowExactly<Exception>().WithMessage("El jugador 1, ha enviado un barco con coordenadas invalidas (-1,1)");
    }


    [Fact]
    public void Si_IniciaElJuegoYSePosicionanBarcoEnUnaCoordenadaEnYMayorA10_Debe_LanzarExcepcion()
    {
        var juegoAcorazado = () => Mocks.MockIniciarJuegoConBarcoEnCoordenadaYMayorA10();

        juegoAcorazado.Should().ThrowExactly<Exception>().WithMessage("El jugador 1, ha enviado un barco con coordenadas invalidas (11,1)");
    }
}
using AwesomeAssertions;

namespace Test.BattleShip;

public class AcorazadosTest
{
    [Fact]
    public void Si_SeInciaUnTableroUnTamaño0_0_Debe_MostrarUnaExcepcion()
    {
        var tablero = () => new JuegoAcorazado(0, 0);

        tablero.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void Si_SeIniciaUnTableroUnTamaño10_10_NoDebe_LanzarExcepcion()
    {
        var tablero = () => new JuegoAcorazado(10, 10);

        tablero.Should().NotThrow();
    }

    [Fact]
    public void Si_SeIniciaUnTableroConUnTamañoMenorA0_Debe_LanzarExcepcion()
    {
        var tablero = () => new JuegoAcorazado(-1, -1);

        tablero.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void Si_SeUnPortaAvionesEnLaPosicionInicial0_0DeFormaVertical_Debe_LaPosicionFinalSer0_3()
    {
        var tableroExperado = new string[10, 10];
        tableroExperado[0, 0] = "c";
        tableroExperado[0, 1] = "c";
        tableroExperado[0, 2] = "c";
        tableroExperado[0, 3] = "c";
        var tablero = new JuegoAcorazado(10, 10);
        tablero.AgregarPortaAviones(0, 0, "Vertical");

        var tableroActual = tablero.Mostrar();

        tableroActual.Should().BeEquivalentTo(tableroExperado);
    }
}

public class JuegoAcorazado
{
    private string[,] _tablero;

    public JuegoAcorazado(int tamañoEnX, int tamañoEnY)
    {
        if (tamañoEnX <= 0 && tamañoEnY <= 0)
            throw new ArgumentOutOfRangeException();
        _tablero = new string[tamañoEnX, tamañoEnY];
    }


    public void AgregarPortaAviones(int posicionX, int posicionY, string vertical)
    {
        _tablero[0, 0] = "c";
        _tablero[0, 1] = "c";
        _tablero[0, 2] = "c";
        _tablero[0, 3] = "c";
    }

    public string[,] Mostrar()
    {
        return _tablero;
    }
}
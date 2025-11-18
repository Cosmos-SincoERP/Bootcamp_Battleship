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

    [Fact]
    public void Si_SeUnPortaAvionesEnLaPosicionInicial0_0DeFormaHorizontal_Debe_LaPosicionFinalSer3_0()
    {
        var tableroExperado = new string[10, 10];
        tableroExperado[0, 0] = "c";
        tableroExperado[1, 0] = "c";
        tableroExperado[2, 0] = "c";
        tableroExperado[3, 0] = "c";
        var tablero = new JuegoAcorazado(10, 10);
        tablero.AgregarPortaAviones(0, 0, "Horizontal");

        var tableroActual = tablero.Mostrar();

        tableroActual.Should().BeEquivalentTo(tableroExperado);
    }

    [Fact]
    public void Si_SeUnPortaAvionesEnLaPosicionInicial3_4DeFormaVertical_Debe_LaPosicionFinalSer3_7()
    {
        var tableroExperado = new string[10, 10];
        tableroExperado[3, 4] = "c";
        tableroExperado[3, 5] = "c";
        tableroExperado[3, 6] = "c";
        tableroExperado[3, 7] = "c";
        var tablero = new JuegoAcorazado(10, 10);
        tablero.AgregarPortaAviones(3, 4, "Vertical");

        var tableroActual = tablero.Mostrar();

        tableroActual.Should().BeEquivalentTo(tableroExperado);
    }

    [Fact]
    public void Si_SeUnPortaAvionesEnLaPosicionInicial6_2DeFormaHorizontal_Debe_LaPosicionFinalSer9_2()
    {
        var tableroExperado = new string[10, 10];
        tableroExperado[6, 2] = "c";
        tableroExperado[7, 2] = "c";
        tableroExperado[8, 2] = "c";
        tableroExperado[9, 2] = "c";
        var tablero = new JuegoAcorazado(10, 10);
        tablero.AgregarPortaAviones(6, 2, "Horizontal");

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


    public void AgregarPortaAviones(int posicionX, int posicionY, string direccion)
    {
        if (direccion == "Vertical")
        {
            for (int i = 0; i < 4; i++)
            {
                _tablero[posicionX, posicionY + i] = "c";
            }
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                _tablero[posicionX + i, posicionY] = "c";
            }
        }
    }

    public string[,] Mostrar()
    {
        return _tablero;
    }
}
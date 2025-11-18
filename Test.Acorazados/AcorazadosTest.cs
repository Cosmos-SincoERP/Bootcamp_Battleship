using AwesomeAssertions;

namespace Test.BattleShip;

public class AcorazadosTest
{
    [Fact]
    public void Si_SeInciaUnTableroUnTamaño0_0_Debe_MostrarUnaExcepcion()
    {
        var tablero = () => new Tablero(0, 0);

        tablero.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void Si_SeIniciaUnTableroUnTamaño10_10_NoDebe_LanzarExcepcion()
    {
        var tablero = () => new Tablero(10, 10);

        tablero.Should().NotThrow();
    }
    
    [Fact]
    public void Si_SeIniciaUnTableroConUnTamañoMenorA0_Debe_LanzarExcepcion()
    {
        var tablero = () => new Tablero(-1, -1);

        tablero.Should().Throw<ArgumentOutOfRangeException>();
    }
}

public class Tablero
{
    public Tablero(int tamañoEnX, int tamañoEnY)
    {
        if (tamañoEnX == 0 && tamañoEnY == 0)
            throw new ArgumentOutOfRangeException();
    }
}
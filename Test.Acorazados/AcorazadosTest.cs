using AwesomeAssertions;

namespace Test.BattleShip;

public class AcorazadosTest
{
    [Fact]
    public void Si_SeInciaUnTableroUnTamaño00_Debe_MostrarUnaExcepcion()
    {
        var tablero = () => new Tablero(0, 0);

        tablero.Should().Throw<ArgumentOutOfRangeException>();
    }
}

public class Tablero
{
    public Tablero(int i, int i1)
    {
        throw new ArgumentOutOfRangeException();
    }
}
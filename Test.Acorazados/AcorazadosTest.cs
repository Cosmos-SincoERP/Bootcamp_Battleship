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
    public void Si_SeInciaUnTableroUnTamaño10_10_Debe_ExistirUnTablero10_10()
    {
        var tablero = new Tablero(10, 10);

        var existeTablero = tablero.Existe(10, 10);
        
        existeTablero.Should().BeTrue();
    }
}

public class Tablero
{
    public Tablero(int i, int i1)
    {
        throw new ArgumentOutOfRangeException();
    }

    public bool Existe(int i, int i1)
    {
        throw new NotImplementedException();
    }
}

using AwesomeAssertions;

namespace BattleShips.Tests;

public class BattleShipTests
{
    [Fact]
    public void Cuando_AgregoUnJugador_Debe_QuedarAgregado()
    {
        var battleship = new BattleShip();

        var action = () => battleship.AddPlayer();

        action.Should().NotThrow();
    }
}

public class BattleShip
{
    public void AddPlayer()
    {
        
    }
}
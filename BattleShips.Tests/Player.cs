namespace BattleShips.Tests;

public class Player(Fleet fleet)
{
    public readonly string[,] Board = InitializeBoard();

    private static string[,] InitializeBoard()
    {
        var constructedBoard = new string[10, 10];
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                constructedBoard[x, y] = "|";
            }
        }

        return constructedBoard;
    }

    public void Init()
    {
        fleet.LocateFleets(Board);
    }
}
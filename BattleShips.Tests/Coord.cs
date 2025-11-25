namespace BattleShips.Tests;

public record struct Coord(int x, int y)
{
    public int X { get; } = x;
    public int Y { get; } = y;

    public bool IsNeighbour(Coord coordEvaluate)
    {
        var differenceInX = Math.Abs(X - coordEvaluate.X);
        var differenceInY = Math.Abs(Y - coordEvaluate.Y);

        return differenceInX <= 1 && differenceInY <= 1;
    }

    public bool IsNeighbourInDiagonal(Coord coordEvaluate)
    {
        var differenceInX = Math.Abs(X - coordEvaluate.X);
        var differenceInY = Math.Abs(Y - coordEvaluate.Y);

        return differenceInX == 1 && differenceInY == 1;
    }
}
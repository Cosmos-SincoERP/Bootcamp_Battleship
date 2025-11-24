namespace BattleShips.Tests;

public record struct Coord(int x, int y)
{
    public int PositionX { get; } = x;
    public int PositionY { get; } = y;

    public bool IsNeighbour(Coord coordEvaluate)
    {
        var differenceInX = Math.Abs(PositionX - coordEvaluate.PositionX);
        var differenceInY = Math.Abs(PositionY - coordEvaluate.PositionY);

        return differenceInX <= 1 && differenceInY <= 1;
    }

    public bool IsNeighbourInDiagonal(Coord coordEvaluate)
    {
        var differenceInX = Math.Abs(PositionX - coordEvaluate.PositionX);
        var differenceInY = Math.Abs(PositionY - coordEvaluate.PositionY);

        return differenceInX == 1 && differenceInY == 1;
    }
}
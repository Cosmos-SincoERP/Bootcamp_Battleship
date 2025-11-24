namespace BattleShips.Tests;

public struct Coord(int x, int y)
{
    public int PositionX { get; } = x;
    public int PositionY { get; } = y;
}
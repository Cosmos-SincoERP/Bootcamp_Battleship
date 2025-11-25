namespace BattleShips.Tests.Ships;

public abstract class Ship(List<Coord> coords)
{
    public readonly IReadOnlyCollection<Coord> Coords = coords;
    private protected abstract char Abbreviation { get; }
    public void LocateInBoard(string[,] board)
    {
        foreach (var coord in coords)
        {
            board[coord.PositionX, coord.PositionY] = Abbreviation.ToString();
        }
    }

    public abstract bool IsShotAt(Coord coord);
}
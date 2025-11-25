namespace BattleShips.Tests.Ships;

public abstract class Ship(List<Coord> coords)
{
    public readonly IReadOnlyCollection<Coord> Coords = coords;
    private protected abstract char Abbreviation { get; }
    public abstract bool IsSunken { get; set; }

    public void LocateInBoard(string[,] board)
    {
        foreach (var coord in coords)
        {
            board[coord.X, coord.Y] = Abbreviation.ToString();
        }
    }

    public abstract bool IsShotAt(Coord coordEvaluate);

    public void MarkAsSunken(string[,] board)
    {
        foreach (var coord in coords)
        {
            board[coord.X, coord.Y] = "X";
        }
    }
}
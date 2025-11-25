namespace BattleShips.Tests.Ships;

public abstract class Ship(List<Coord> coords)
{
    public readonly IReadOnlyCollection<Coord> Coords = coords;
    private protected abstract char Abbreviation { get; }
    public abstract bool IsSunken { get; protected set; }
    
    private readonly List<Coord> _receivedShots = []; 
    
    public void LocateInBoard(string[,] board)
    {
        foreach (var coord in coords)
        {
            board[coord.X, coord.Y] = Abbreviation.ToString();
        }
    }

    public bool IsShotAt(Coord coordEvaluate)
    {
        var isShotInAnyCoordOfShip = coords.Any(coord => coord == coordEvaluate);
        
        AddToReceivedShotsIfIsInAnyCoord(coordEvaluate, isShotInAnyCoordOfShip);
        MarkAsSunkenIfShotCountsIsEqualsToCoordsCount();
        
        return isShotInAnyCoordOfShip;
    }

    private void MarkAsSunkenIfShotCountsIsEqualsToCoordsCount()
    {
        if (_receivedShots.Count == coords.Count)
            IsSunken = true;
    }

    private void AddToReceivedShotsIfIsInAnyCoord(Coord coordEvaluate, bool isShotInAnyCoordOfShip)
    {
        if (isShotInAnyCoordOfShip)
            _receivedShots.Add(coordEvaluate);
    }

    public void MarkAsSunken(string[,] board)
    {
        foreach (var coord in coords)
        {
            board[coord.X, coord.Y] = "X";
        }
    }
}
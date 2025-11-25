namespace BattleShips.Tests.Ships;

public class Gunboat(List<Coord> coords) : Ship(coords)
{
    private Coord UniqueCoord => coords.First();
    private const string LosCañonerosDebenTener1Coordenada = "Un cañonero solo puede tener una coordenada";
    private protected override char Abbreviation => 'g';

    public static Ship Create(params List<Coord> coords)
    {
        if (coords.Count != 1)
            throw new ArgumentException(LosCañonerosDebenTener1Coordenada);
        
        return new Gunboat(coords);
    }

    public override bool IsShotAt(Coord coord) 
        => coord.PositionX == UniqueCoord.PositionX && coord.PositionY == UniqueCoord.PositionY;
}
namespace BattleShips.Tests.Ships;

public class Gunboat(List<Coord> coords) : Ship(coords)
{
    private Coord GunboatCoord => coords.First();
    private const string LosCañonerosDebenTener1Coordenada = "Un cañonero solo puede tener una coordenada";
    private protected override char Abbreviation => 'g';
    public override bool IsSunken { get; protected set; }

    public static Ship Create(params List<Coord> coords)
    {
        if (coords.Count != 1)
            throw new ArgumentException(LosCañonerosDebenTener1Coordenada);
        
        return new Gunboat(coords);
    }

}
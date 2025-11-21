namespace BattleShips.Tests.Ships;

public class Gunboat(Coord coord) : Ship
{
    private const string LosCañonerosDebenTener1Coordenada = "Un cañonero solo puede tener una coordenada";

    public static Ship Create(params List<Coord> coords)
    {
        if (coords.Count != 1)
            throw new ArgumentException(LosCañonerosDebenTener1Coordenada);
        
        return new Gunboat(coords[0]);
    }
}
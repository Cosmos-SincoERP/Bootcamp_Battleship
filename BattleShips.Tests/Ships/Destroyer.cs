namespace BattleShips.Tests.Ships;

public class Destroyer(List<Coord> coords) : Ship
{
    private const string LosDestructoresDebenTener3Coordenadas = "Los destructores deben tener 3 coordenadas.";
    
    public static Ship Create(params List<Coord> coords)
    {
        if (coords.Count != 3)
            throw new ArgumentException(LosDestructoresDebenTener3Coordenadas);

        return new Destroyer(coords);
    }
}
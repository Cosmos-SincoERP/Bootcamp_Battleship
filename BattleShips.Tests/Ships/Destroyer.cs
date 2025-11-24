namespace BattleShips.Tests.Ships;

public class Destroyer(List<Coord> coords) : Ship(coords)
{
    private const string LosDestructoresDebenTener3Coordenadas = "Los destructores deben tener 3 coordenadas.";
    private protected override char Abbreviation => 'd';

    public static Ship Create(params List<Coord> coords)
    {
        ThrowExcepcionIfCoordsIsDifferentOfThree(coords);
        ThrowExceptionIfCoordsAreNotSequential(coords);

        return new Destroyer(coords);
    }

    private static void ThrowExcepcionIfCoordsIsDifferentOfThree(List<Coord> coords)
    {
        if (coords.Count != 3)
            throw new ArgumentException(LosDestructoresDebenTener3Coordenadas);
    }

    private static void ThrowExceptionIfCoordsAreNotSequential(List<Coord> coords)
    {
        coords.Aggregate((old, newest) => 
            newest.IsNeighbour(old)
                ? newest
                : throw new ArgumentException("Los destructores deben tener sus coordenadas secuenciales.")
        );
    }
}
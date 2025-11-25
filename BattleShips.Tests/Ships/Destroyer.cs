namespace BattleShips.Tests.Ships;

public class Destroyer(List<Coord> coords) : Ship(coords)
{
    private const string LosDestructoresDebenTener3Coordenadas = "Los destructores deben tener 3 coordenadas.";
    private const string LosDestructoresDebenTenerSusCoordenadasSecuenciales = "Los destructores deben tener sus coordenadas secuenciales.";
    private protected override char Abbreviation => 'd';
    private readonly List<Coord> _recievedShots = []; 
    
    public override bool IsSunken { get; protected set; }

    public static Ship Create(params List<Coord> coords)
    {
        ThrowExcepcionIfCoordsCountIsDifferentOfThree(coords);
        ThrowExceptionIfCoordsAreNotSequential(coords);
        ThrowExceptionIfCoordsIsInDiagonal(coords);
        
        return new Destroyer(coords);
    }

    private static void ThrowExcepcionIfCoordsCountIsDifferentOfThree(List<Coord> coords)
    {
        if (coords.Count != 3)
            throw new ArgumentException(LosDestructoresDebenTener3Coordenadas);
    }

    private static void ThrowExceptionIfCoordsAreNotSequential(List<Coord> coords)
    {
        coords.Aggregate((old, newest) => 
            newest.IsNeighbour(old)
                ? newest
                : throw new ArgumentException(LosDestructoresDebenTenerSusCoordenadasSecuenciales)
        );
    }   
    
    private static void ThrowExceptionIfCoordsIsInDiagonal(List<Coord> coords)
    {
        coords.Aggregate((old, newest) => 
            newest.IsNeighbourInDiagonal(old)
                ? throw new ArgumentException("Los barcos solo pueden posicionarse en vertical o horizontal") 
                : newest);
    }
}
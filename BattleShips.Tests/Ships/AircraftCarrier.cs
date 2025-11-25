namespace BattleShips.Tests.Ships;

public class AircraftCarrier(List<Coord> coords) : Ship(coords)
{
    private const string UnPortaavionDebeTener4Coordenadas = "Un portaavion debe tener 4 coordenadas.";
    private const string LosPortaavionesDebenTenerSusCoordenadasSecuenciales = "Los portaaviones deben tener sus coordenadas secuenciales.";
    private protected override char Abbreviation => 'c';
    private readonly List<Coord> _recievedShots = []; 
    public override bool IsSunken { get; protected set; }
    
    public static Ship Create(params List<Coord> coords)
    {
        ThrowExcepcionIfCoordsCountIsDifferentOfFour(coords);
        ThrowExceptionIfCoordsAreNotSequential(coords);
        ThrowExceptionIfCoordsIsInDiagonal(coords);
        
        return new AircraftCarrier(coords);
    }

    private static void ThrowExcepcionIfCoordsCountIsDifferentOfFour(List<Coord> coords)
    {
        if (coords.Count != 4)
            throw new ArgumentException(UnPortaavionDebeTener4Coordenadas);
    }

    private static void ThrowExceptionIfCoordsAreNotSequential(List<Coord> coords)
    {
        coords.Aggregate((old, newest) => 
            newest.IsNeighbour(old)
                ? newest
                : throw new ArgumentException(LosPortaavionesDebenTenerSusCoordenadasSecuenciales)
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
namespace BattleShips.Tests.Ships;

public class AircraftCarrier(List<Coord> coords) : Ship(coords)
{
    private const string UnPortaavionDebeTener4Coordenadas = "Un portaavion debe tener 4 coordenadas.";
    private protected override char Abbreviation => 'c';
    
    public static Ship Create(params List<Coord> coords)
    {
        if (coords.Count != 4)
            throw new ArgumentException(UnPortaavionDebeTener4Coordenadas);
        
        return new AircraftCarrier(coords);
    }

}
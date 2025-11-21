using BattleShips.Tests.Ships;

namespace BattleShips.Tests;

public class Fleet
{
    private const string DebeSerUnPortaavionPorJugador = "Debe ser 1 portaavion por jugador.";
    private const string DebenSer2DestructoresPorJugador = "Deben ser 2 destructores por jugador.";
    private const string DebenSer4CañonerosPorJugador = "Deben ser 4 cañoneros por jugador.";
    
    public Fleet(List<Ship> ships)
    {
        if (ships.Count(ship => ship is Gunboat) != 4)
            throw new ArgumentException(DebenSer4CañonerosPorJugador);
        if (ships.Count(ship => ship is Destroyer) != 2)
            throw new ArgumentException(DebenSer2DestructoresPorJugador);
        if (ships.Count(ship => ship is AircraftCarrier) != 1)
            throw new ArgumentException(DebeSerUnPortaavionPorJugador);
        
    }
}
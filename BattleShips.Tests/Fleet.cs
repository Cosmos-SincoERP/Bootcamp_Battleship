using BattleShips.Tests.Ships;

namespace BattleShips.Tests;

public class Fleet
{
    private const string DebeSerUnPortaavionPorJugador = "Debe ser 1 portaavion por jugador.";
    private const string DebenSer2DestructoresPorJugador = "Deben ser 2 destructores por jugador.";
    private const string DebenSer4CañonerosPorJugador = "Deben ser 4 cañoneros por jugador.";
    private readonly List<Ship> _ships;
    public Fleet(List<Ship> ships)
    {
        ThrowIfGunboatsCountIsDifferentOfFour(ships);
        ThrowIfDestroyersCountIsDifferentOfTwo(ships);
        ThrowIfAircraftCarrierCountIsDifferentOfOne(ships);
        ThrowIfCoordsOfShipsCollide(ships);
        _ships = ships;
    }

    private static void ThrowIfCoordsOfShipsCollide(List<Ship> ships)
    {
        if (ships.SelectMany(ship => ship.Coords).CountBy(coord => coord).Any(count => count.Value > 1))
            throw new ArgumentException("No se pueden posicionar diferentes barcos en la misma coordenada.");
    }

    private static void ThrowIfAircraftCarrierCountIsDifferentOfOne(List<Ship> ships)
    {
        if (ships.Count(ship => ship is AircraftCarrier) != 1)
            throw new ArgumentException(DebeSerUnPortaavionPorJugador);
    }

    private static void ThrowIfDestroyersCountIsDifferentOfTwo(List<Ship> ships)
    {
        if (ships.Count(ship => ship is Destroyer) != 2)
            throw new ArgumentException(DebenSer2DestructoresPorJugador);
    }

    private static void ThrowIfGunboatsCountIsDifferentOfFour(List<Ship> ships)
    {
        if (ships.Count(ship => ship is Gunboat) != 4)
            throw new ArgumentException(DebenSer4CañonerosPorJugador);
    }

    public void LocateFleets(string[,] currentBoard) => 
        _ships.ForEach(ship => ship.LocateInBoard(currentBoard));
}
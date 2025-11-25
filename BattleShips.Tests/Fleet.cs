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

    public void LocateFleets(string[,] board) =>
        _ships.ForEach(ship => ship.LocateInBoard(board));

    public void ReceiveShot(string[,] board, Coord coord)
    {
        var shipImpacted = _ships.FirstOrDefault(ship => ship.IsShotAt(coord));
        if (shipImpacted != null)
        {
            MarkShotInShip(board, coord, shipImpacted);
            MarkShipSunkenInBoardIfIsSunken(board, shipImpacted);
        }
        else
            MarkWaterShotInBoard(board, coord);
    }

    private static void MarkShotInShip(string[,] board, Coord coord, Ship shipImpacted)
    {
        if(shipImpacted is Gunboat)
            board[coord.X, coord.Y] = "X";
        if(shipImpacted is AircraftCarrier)
            board[coord.X, coord.Y] = "x";
    }


    private static void MarkShipSunkenInBoardIfIsSunken(string[,] board, Ship shipImpacted)
    {
        if (shipImpacted.IsSunken)
            shipImpacted.MarkAsSunken(board);
    }
    
    private static void MarkWaterShotInBoard(string[,] board, Coord coord)
    {
        board[coord.X, coord.Y] = "o";
    }
}
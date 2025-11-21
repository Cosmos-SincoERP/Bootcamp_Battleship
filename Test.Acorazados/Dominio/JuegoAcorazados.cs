using Test.BattleShip.Dominio.Barcos;

namespace Test.BattleShip.Dominio;

public class JuegoAcorazados
{
    private List<Jugador> _jugadores = new();
    private List<Barco> _listaPosicionesBarcos = new();

    public void AgregarJugador()
    {
        if (_jugadores.Count == 2)
            throw new Exception("No se permite agregar mas jugadores al juego");

        var nombreJugador = _jugadores.Count == 1 ? "2" : "1"; 
        _jugadores.Add(new Jugador(nombreJugador, new char[10, 10]));
    }

    public void Iniciar(List<Barco> barcosJugador1,
        List<Barco> barcosJugador2)
    {
        if (_jugadores.Count != 2)
            throw new Exception("No se puede iniciar el juego, debe haber al menos 2 jugadores");

        ValidarCantidadBarcos(barcosJugador1, _jugadores[0].Nombre);
        ValidarCantidadBarcos(barcosJugador2, _jugadores[1].Nombre);

        _listaPosicionesBarcos.AddRange(barcosJugador2);
    }

    public void Disparar(int x, int y)
    {

        var tablero = _jugadores[1].Tablero;

        if (_listaPosicionesBarcos.Any(barco => barco.Posicion.X == x && barco.Posicion.Y == y))
            tablero[x, y] = 'x';
        else
            tablero[x, y] = 'o';
    }

    public string Imprimir()
    {
        var tablero = _jugadores[1].Tablero;

        var visualizarTablero = string.Empty;
        for (var x = 0; x < tablero.GetLength(0); x++)
        {
            for (int y = 0; y < tablero.GetLength(1); y++)
            {
                visualizarTablero += tablero[x, y];
            }
            visualizarTablero += '\n';
        }
        return visualizarTablero;
    }

    private void ValidarCantidadBarcos(
        List<Barco> barcos, string nombreJugador)
    {
        const int cantidadCañoneros = 4;
        const int cantidadDestructores = 2;
        const int cantidadPortaAviones = 1;

        const string faltanTodosLosBarco = "El jugador {0}, no ha enviado los barcos para posicionar";
        const string faltanLosCañoneros = "El jugador {0}, no ha enviado todos los cañoneros para posicionar";
        const string faltanLosDestructores = "El jugador {0}, no ha enviado todos los destructores para posicionar";
        const string faltanLosPortaviones = "El jugador {0}, no ha enviado todos los portaviones para posicionar";


        if (barcos.Count == 0)
            throw new Exception(string.Format(faltanTodosLosBarco, nombreJugador));

        if (barcos.Count(barco => barco.GetType().Name == "Cañonero") < cantidadCañoneros)
            throw new Exception(string.Format(faltanLosCañoneros, nombreJugador));

        if (barcos.Count(barco => barco.GetType().Name == "Destructor") < cantidadDestructores)
            throw new Exception(string.Format(faltanLosDestructores, nombreJugador));

        if (barcos.Count(barco => barco.GetType().Name == "PortaAviones") < cantidadPortaAviones)
            throw new Exception(string.Format(faltanLosPortaviones, nombreJugador));
    }
}

public record Jugador(string Nombre, char[,] Tablero);
using Test.BattleShip.Dominio.Barcos;

namespace Test.BattleShip.Dominio;

public class JuegoAcorazados
{
    private List<Jugador> _jugadores = [];
    private List<Barco> _listaBarcosJugador1 = [];
    private List<Barco> _listaBarcosJugador2 = [];
    private int _jugadorActivo = 0;
    private int _jugadorContrincante = 1;

    public void AgregarJugador()
    {
        if (_jugadores.Count == 2)
            throw new Exception("No se permite agregar mas jugadores al juego");

        _jugadores.Add(new Jugador(AsignarNombreJugadorPredeterminado()));
    }

    public void Iniciar(List<Barco> barcosJugador1, List<Barco> barcosJugador2)
    {
        if (_jugadores.Count != 2)
            throw new Exception("No se puede iniciar el juego, debe haber al menos 2 jugadores");

        ValidarCantidadBarcos(barcosJugador1, _jugadores[0].Nombre);
        ValidarCantidadBarcos(barcosJugador2, _jugadores[1].Nombre);

        _listaBarcosJugador1.AddRange(barcosJugador1);
        _listaBarcosJugador2.AddRange(barcosJugador2);
    }

    public string Disparar(int x, int y)
    {
        var mensaje = string.Empty;
        var tablero = _jugadores[_jugadorContrincante].Tablero;
        var _listaBarcosJugadorContrincante = _jugadorContrincante == 0 ? _listaBarcosJugador1 : _listaBarcosJugador2;

        var buscarBarco = _listaBarcosJugadorContrincante.FirstOrDefault(barco => barco.Coordenada.X == x && barco.Coordenada.Y == y);
        if (buscarBarco != null )
        {
            if (buscarBarco.GetType().Name == "Cañonero")
            {
                tablero[x, y] = 'X';
                mensaje = $"Se hundio un barco en la coordenada ({x},{y})";
            }
            else if (buscarBarco.GetType().Name == "Destructor")
            {
                tablero[x, y] = 'X';
                mensaje = $"Se hundio un barco en la coordenada ({x},{y})";
            }
            else
                tablero[x, y] = 'x';
        }
            
        else
            tablero[x, y] = 'o';
        
        return mensaje;
    }

    public void FinalizarTurno()
    {
        _jugadorActivo = _jugadorActivo == 0 ? 1 : 0;
        _jugadorContrincante = _jugadorContrincante == 0 ? 1 : 0;
    }

    public string Imprimir()
    {
        var tablero = _jugadores[_jugadorContrincante].Tablero;

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

    private string AsignarNombreJugadorPredeterminado()
    {
        return _jugadores.Count == 1 ? "2" : "1";
    }
    
    private void ValidarCantidadBarcos(List<Barco> barcos, string nombreJugador)
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

public class Jugador(string nombre)
{
    public string Nombre { get; } = nombre;
    public char[,] Tablero { get; } = new char[10, 10];

}
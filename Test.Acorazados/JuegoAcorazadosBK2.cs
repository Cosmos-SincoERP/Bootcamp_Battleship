namespace Test.BattleShip;

public class JuegoAcorazadosBK2
{
    private List<(string, char[,])> _jugadores = new();
    private char[,] _tablero = new char[10, 10];

    public void AgregarJugador()
    {
        _jugadores.Add(new(_jugadores.Count == 1 ? "Jugador 2" : "Jugador 1", _tablero));
    }

    public List<string> MostrarJugadores()
    {
        return _jugadores.Select(jugador => jugador.Item1).ToList();
    }

    public void Iniciar(List<PosicionarBarco>? coordenadas = null)
    {
        if (_jugadores.Count < 2)
            throw new Exception("El juego no puede iniciarse hasta que se hayan agregado 2 jugadores");
        
        _tablero = new char[10, 10];
        if (coordenadas != null)
        {
            foreach (var coordenada in coordenadas)
            {
                for (int i = 0; i < coordenada.Barco.Tamaño; i++)
                {
                    if (coordenada.Orientacion == "Horizontal")
                        AsignarPosicionDeLaNave(coordenada.X + i, coordenada.Y, coordenada.Barco.Valor);
                    else
                        AsignarPosicionDeLaNave(coordenada.X, coordenada.Y + i, coordenada.Barco.Valor);
                }
            }
        }
    }

    public string Imprimir(string nombreJugador = "Jugador 1")
    {
        var tablero = _jugadores.FirstOrDefault(jugador => jugador.Item1 == nombreJugador).Item2;
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


    private void AsignarPosicionDeLaNave(int posicionX, int posicionY, char valorNave)
    {
        _tablero[posicionX, posicionY] = valorNave;
    }
}

public record PosicionarBarco(int X, int Y, Barco Barco, string? Orientacion);

public class Barco
{
    public int Tamaño { get; private set; }
    public char Valor { get; private set; }

    private Barco(int tamaño, char valor)
    {
        Tamaño = tamaño;
        Valor = valor;
    }

    public static Barco Cañonero => new(1, 'g');
    public static Barco Destructor => new(3, 'd');
    public static Barco PortaAviones => new(4, 'c');
}
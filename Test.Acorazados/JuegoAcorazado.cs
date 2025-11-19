namespace Test.BattleShip;

public class JuegoAcorazado
{
    private List<string> _jugadores = new();
    private char[,] _tablero = new char[10, 10];

    public void AgregarJugador(List<Coordenada>? coordenadas = null)
    {
        if (coordenadas != null)
        {
            foreach (var coordenada in coordenadas)
            {
                for (int i = 0; i < coordenada.Nave.Tamaño; i++)
                {
                    if (coordenada.Orientacion == "Horizontal")
                        AsignarPosicionDeLaNave(coordenada.X + i, coordenada.Y, coordenada.Nave.Valor);
                    else
                        AsignarPosicionDeLaNave(coordenada.X, coordenada.Y + i, coordenada.Nave.Valor);
                }
            }
        }

        _jugadores.Add(_jugadores.Count == 1 ? "Jugador 2" : "Jugador 1");
    }

    public List<string> MostrarJugadores()
    {
        return _jugadores;
    }

    public void Iniciar()
    {
        if (_jugadores.Count != 2)
            throw new Exception("El juego no puede iniciarse hasta que se hayan agregado 2 jugadores");
    }

    public string Imprimir()
    {
        var tablero = string.Empty;
        for (var x = 0; x < _tablero.GetLength(0); x++)
        {
            for (int y = 0; y < _tablero.GetLength(1); y++)
            {
                tablero += _tablero[x, y];
            }

            tablero += '\n';
        }

        return tablero;
    }


    private void AsignarPosicionDeLaNave(int posicionX, int posicionY, char valorNave)
    {
        _tablero[posicionX, posicionY] = valorNave;
    }
}

public record Coordenada(int X, int Y, Nave Nave, string? Orientacion);

public class Nave
{
    public int Tamaño { get; private set; }
    public char Valor { get; private set; }

    private Nave( int tamaño, char valor)
    {

        Tamaño = tamaño;
        Valor = valor;
    }

    public static Nave Cañonero => new( 1, 'g');
    public static Nave Destructor => new( 3, 'd');
    public static Nave PortaAviones => new( 4, 'c');
}

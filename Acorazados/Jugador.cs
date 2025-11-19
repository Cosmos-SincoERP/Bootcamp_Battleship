namespace Acorazados;

public enum Acorazado
{
    Cañonero = 1,
    Destructor = 3,
    Portaaviones = 4
}

public enum Direccion
{
    Arriba, 
    Derecha,
    Izquierda,
    Abajo
}

public class Jugador
{
    public string Nombre { get; private set; }
    private string[,] Tablero;
    private Dictionary<Acorazado, string> LetraAcozados = new Dictionary<Acorazado, string>
    {
        { Acorazado.Cañonero, "g" },
        { Acorazado.Destructor, "d" },
        { Acorazado.Portaaviones, "c" }
    };

    public Jugador(string player)
    {
        Nombre = player;
        Tablero = new string[10,10];
    }

    public void AgregarAcorazado(Acorazado tipoAcorazado, int fila, int columna, Direccion? direccion = null)
    {
        for (int i = 0; i < (int)tipoAcorazado; i++)
        {
            switch (direccion)
            {
                case Direccion.Derecha:
                    ValidacionesTablero(fila, columna+i);
                    Tablero[fila, columna+i] = LetraAcozados[tipoAcorazado];
                    break;
                case Direccion.Abajo:
                    ValidacionesTablero(fila+i, columna);
                    Tablero[fila+i, columna] = LetraAcozados[tipoAcorazado];
                    break;
                case Direccion.Izquierda:
                    ValidacionesTablero(fila, columna-i);
                    Tablero[fila, columna-i] = LetraAcozados[tipoAcorazado];
                    break;
                default:
                    ValidacionesTablero(fila-i, columna);
                    Tablero[fila-i, columna] = LetraAcozados[tipoAcorazado];
                    break;
            }
        }
    }

    private void ValidacionesTablero(int x, int y)
    {
        if (ObtenerLongitudTablero(0) - 1 < x || ObtenerLongitudTablero(1) - 1 < y || x < 0 || y < 0)
        {
            throw new ArgumentOutOfRangeException("No es posible ubicar el acorazado en esa direccion");
        }

        if (!string.IsNullOrEmpty(ObtenerCasilla(x, y)))
        {
            throw new ArgumentException("Ya existe un acorazado en esa posicion");
        }
    }

    public string ObtenerCasilla(int x, int y)
    {
        return  Tablero[x, y];
    }

    public int ObtenerLongitudTablero(int dimension)
    {
        return Tablero.GetLength(dimension);
    }
}
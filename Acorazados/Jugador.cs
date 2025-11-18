namespace Acorazados;

public enum Acorazado
{
    Cañonero,
    Destructor
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

    public Jugador(string player)
    {
        Nombre = player;
        Tablero = new string[10,10];
    }

    public void AgregarAcorazado(Acorazado tipoAcorazado, int fila, int columna, Direccion? direccion = null)
    {
        ValidacionesTablero(fila, columna);
        if(tipoAcorazado.Equals(Acorazado.Cañonero))
            Tablero[fila, columna] = "g";
        else
        {
            if (direccion.Equals(Direccion.Derecha))
            {
                Tablero[fila, columna] = "d";
                ValidacionesTablero(fila, columna+1);
                Tablero[fila, columna+1] = "d";
                ValidacionesTablero(fila, columna+2);
                Tablero[fila, columna+2] = "d";
            }
            else if (direccion.Equals(Direccion.Izquierda))
            {
                Tablero[fila, columna] = "d";
                ValidacionesTablero(fila, columna-1);
                Tablero[fila, columna-1] = "d";
                Tablero[fila, columna-2] = "d";
            }
            else if (direccion.Equals(Direccion.Abajo))
            {
                Tablero[fila, columna] = "d";
                ValidacionesTablero(fila+1, columna);
                Tablero[fila+1, columna] = "d";
                ValidacionesTablero(fila+2, columna);
                Tablero[fila+2, columna] = "d";
            }
            else
            {
                Tablero[fila, columna] = "d";
                ValidacionesTablero(fila-1, columna);
                Tablero[fila-1, columna] = "d";
                ValidacionesTablero(fila-2, columna);
                Tablero[fila-2, columna] = "d";
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
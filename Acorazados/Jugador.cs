namespace Acorazados;

public enum Acorazado
{
    Cañonero,
    Destructor,
    Portaaviones
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
        if (tipoAcorazado.Equals(Acorazado.Cañonero))
        {
            ValidacionesTablero(fila, columna);
            Tablero[fila, columna] = "g";
        }
        else if (tipoAcorazado.Equals(Acorazado.Portaaviones))
        {
            if (direccion == Direccion.Derecha)
            {
                for (int i = 0; i < 4; i++)
                {
                    ValidacionesTablero(fila, columna+i);
                    Tablero[fila, columna+i] = "c";
                }
            } 
            else if (direccion == Direccion.Abajo)
            {
                for (int i = 0; i < 4; i++)
                {
                    ValidacionesTablero(fila+i, columna);
                    Tablero[fila+i, columna] = "c";
                }
            }
            else if (direccion == Direccion.Izquierda)
            {
                for (int i = 0; i < 4; i++)
                {
                    ValidacionesTablero(fila, columna-i);
                    Tablero[fila, columna-i] = "c";
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    ValidacionesTablero(fila-i, columna);
                    Tablero[fila-i, columna] = "c";
                }
            }
        }
        else
        {
            if (direccion.Equals(Direccion.Derecha))
            {
                for (int i = 0; i < 3; i++)
                {
                    ValidacionesTablero(fila, columna+i);
                    Tablero[fila, columna+i] = "d";
                }
            }
            else if (direccion.Equals(Direccion.Izquierda))
            {
                for (int i = 0; i < 3; i++)
                {
                    ValidacionesTablero(fila, columna-i);
                    Tablero[fila, columna-i] = "d";
                }
            }
            else if (direccion.Equals(Direccion.Abajo))
            {
                for (int i = 0; i < 3; i++)
                {
                    ValidacionesTablero(fila+i, columna);
                    Tablero[fila+i, columna] = "d";
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    ValidacionesTablero(fila-i, columna);
                    Tablero[fila-i, columna] = "d";
                }
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
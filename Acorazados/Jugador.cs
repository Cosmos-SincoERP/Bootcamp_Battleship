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

    public void AgregarAcorazado(Acorazado tipoAcorazado, int x, int y, Direccion? direccion = null)
    {
        ValidacionesTablero(x, y);
        if(tipoAcorazado.Equals(Acorazado.Cañonero))
            Tablero[x, y] = "g";
        else
        {
            if (direccion.Equals(Direccion.Derecha))
            {
                Tablero[x, y] = "d";
                Tablero[x+1, y] = "d";
                Tablero[x+2, y] = "d";
            }
            else if (direccion.Equals(Direccion.Izquierda))
            {
                Tablero[x, y] = "d";
                Tablero[x-1, y] = "d";
                Tablero[x-2, y] = "d";
            }
            else if (direccion.Equals(Direccion.Abajo))
            {
                Tablero[x, y] = "d";
                Tablero[x, y-1] = "d";
                Tablero[x, y-2] = "d";
            }
            else
            {
                Tablero[x, y] = "d";
                Tablero[x, y+1] = "d";
                Tablero[x, y+2] = "d";
            }
        }
    }

    private void ValidacionesTablero(int x, int y)
    {
        if (ObtenerLongitudTablero(0) < x || ObtenerLongitudTablero(1) < y || x < 0 || y < 0)
        {
            throw new ArgumentOutOfRangeException("La posicion no existe en el tablero");
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
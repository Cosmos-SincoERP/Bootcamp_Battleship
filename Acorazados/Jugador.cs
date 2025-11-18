namespace Acorazados;

public class Jugador
{
    public string Nombre { get; private set; }
    private string[,] Tablero;

    public Jugador(string player)
    {
        Nombre = player;
        Tablero = new string[10,10];
    }

    public void AgregarAcorazado(string tipoBarco, int x, int y)
    {
        Tablero[x, y] = "g";
    }

    public object ObtenerCasilla(int x, int y)
    {
        return  Tablero[x, y];
    }

    public int ObtenerLongitudTablero(int dimension)
    {
        return Tablero.GetLength(dimension);
    }
}
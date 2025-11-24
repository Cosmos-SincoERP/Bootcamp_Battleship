namespace BattleshipsTDD;

public class Tablero
{
    private char[,] _tablero;
    public string TableroSerializado { get; private set; }

    public Tablero(int filasTablero, int columnasTablero)
    {
        _tablero = InicializarTableroVacio(filasTablero, columnasTablero);
        Serializar();
    }

    private char[,] InicializarTableroVacio(int filasTablero, int columnasTablero)
    {
        char[,] tablero = new char[filasTablero, columnasTablero];

        for (int i = 0; i < tablero.GetLength(1); i++)
        {
            for (int j = 0; j < tablero.GetLength(0); j++)
            {
                tablero[i, j] = ' ';
            }
        }

        return tablero;
    }

    public char ObtenerCaracterDeTablero(Coordenada coordenada)
    {
        return _tablero[coordenada.Fila, coordenada.Columna];
    }

    public void AsignarCaracterEnTablero(Coordenada coordenada, char valor)
    {
        _tablero[coordenada.Fila,coordenada.Columna] = valor;
        Serializar();
    }

    private void Serializar()
    {
        TableroSerializado = Serializador.SerializarTablero(_tablero);
    }
}
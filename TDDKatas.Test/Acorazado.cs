namespace TDDKatas;

public class Acorazado
{
    private string _barco = " ";
    private int _posicionX;
    private int _posicionY;
    private string[,] _tablero = new string[10, 10];

    public string Imprimir()
    {
        const string separador = "  +---+---+---+---+---+---+---+---+---+---+";
        string resultado = "    0   1   2   3   4   5   6   7   8   9\n";
        for (int i = 0; i < _tablero.GetLength(0); i++)
        {
            resultado += $"{separador}\n";
            resultado += $"{i} |";

            for (int j = 0; j < _tablero.GetLength(1); j++)
            {
                if (!string.IsNullOrEmpty(_tablero[i, j]))
                    resultado += $" {_tablero[i, j]} |";
                else
                    resultado += "   |";
            }

            resultado += "\n";
        }

        resultado += separador;

        return resultado;
    }

    public void PosicionarNave(int posicionX, int posicionY, TiposNave nave, Orientacion orientacion)
    {
        _posicionY = posicionY;
        _posicionX = posicionX;
        _tablero[posicionX, posicionY] = ((char)nave).ToString();

        if (nave == TiposNave.Destructor)
        {
            _tablero[posicionX, posicionY+1] = ((char)nave).ToString();
            _tablero[posicionX, posicionY+2] = ((char)nave).ToString();

        }

        if (nave == TiposNave.PortaAviones)
        {
            _tablero[posicionX, posicionY+1] = ((char)nave).ToString();
            _tablero[posicionX, posicionY+2] = ((char)nave).ToString();
            _tablero[posicionX, posicionY+3] = ((char)nave).ToString();
        }
            
    }
}
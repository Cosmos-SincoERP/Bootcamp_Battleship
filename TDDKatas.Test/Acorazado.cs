namespace TDDKatas;

public class Acorazado
{
    private string _barco = " ";
    private int _posicionX;
    private int _posicionY;
    private string [,] _tablero = new string[10,10];

    public string Imprimir()
    {

        string resultado = "    0   1   2   3   4   5   6   7   8   9\n";
        for (int i = 0; i < _tablero.GetLength(0); i++)
        {
            resultado += "  +---+---+---+---+---+---+---+---+---+---+\n";
            
            resultado += $"{i} |";
            
            for (int j = 0; j < _tablero.GetLength(1); j++)
            {
                if (_tablero[i, j] == "" || _tablero[i,j] == null) _tablero[i, j] = " ";
                resultado += $" {_tablero[i,j]} |";
                
            }
            resultado += "\n";
            
        }

        resultado += "  +---+---+---+---+---+---+---+---+---+---+";
        
        return resultado;
        
    }

    public void PosicionarNave(int posicionX, int posicionY)
    {
        _posicionY = posicionY;
        _posicionX = posicionX;
        _tablero[posicionX, posicionY]="c";
    }
}
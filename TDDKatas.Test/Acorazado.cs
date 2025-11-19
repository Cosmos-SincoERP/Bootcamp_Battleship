namespace TDDKatas;

public class Acorazado
{
    private string[,] _tablero = new string[10, 10];

    private List<string> _jugadores = [];

    private Dictionary<string, List<TiposNave>> _estrategia = new();

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

    public void PosicionarNave(int posicionX, int posicionY, TiposNave tipoNave, Orientacion orientacion)
    {
        var nave = Nave.Crear(tipoNave);
        if (_estrategia["Player 1"].Count(tipo => tipo == nave.Tipo) ==  nave.CantidadPermitida &&
              tipoNave == nave.Tipo)
            throw new InvalidOperationException($"No es posible agregar mas de {nave.CantidadPermitida} nave(s) de tipo {nave.Descripcion}");
     
        _estrategia[_jugadores[0]].Add(tipoNave);

        if (orientacion == Orientacion.Derecha)
        {
            OrientarAlaDerecha(posicionX, posicionY, nave);
        }
        else if (orientacion == Orientacion.Arriba)
        {
            OrientarHaciaArriba(posicionX, posicionY, nave);
        }
        else if (orientacion == Orientacion.Abajo)
        {
            OrientarHaciaAbajo(posicionX, posicionY, nave);
        }
        else
        {
            OrientarAlaIzquierda(posicionX, posicionY, nave);
        }
    }

    private void OrientarAlaIzquierda(int posicionX, int posicionY, Nave nave)
    {
        for (int i = 0; i < nave.Tamanio; i++)
            _tablero[posicionX, posicionY - i] = ((char)nave.Tipo).ToString();
    }

    private void OrientarHaciaArriba(int posicionX, int posicionY, Nave nave)
    {
        for (int i = 0; i < nave.Tamanio; i++)
            _tablero[posicionX - i, posicionY] = ((char)nave.Tipo).ToString();
    }

    private void OrientarHaciaAbajo(int posicionX, int posicionY, Nave nave)
    {
        for (int i = 0; i < nave.Tamanio; i++)
            _tablero[posicionX + i, posicionY] = ((char)nave.Tipo).ToString();
    }

    private void OrientarAlaDerecha(int posicionX, int posicionY, Nave nave)
    {
        for (int i = 0; i < nave.Tamanio; i++)
            _tablero[posicionX, posicionY + i] = ((char)nave.Tipo).ToString();
    }

    public object Iniciar()
    {
        if (_jugadores.Count == 0)
            throw new InvalidOperationException("Deben haber minimo 2 jugadores para iniciar la partida");

        throw new InvalidOperationException("Jugador 1 no ha posicionado naves");
    }


    public void AgregarJugador(string player)
    {
        _jugadores.Add(player);
        _estrategia.Add(player, new List<TiposNave>());
    }
}
namespace TDDKatas;

public class Acorazado
{
    private string[,] _tablero = new string[10, 10];

    private List<string> _jugadores = [];


    private Dictionary<TiposNave, int> _nave = new()
    {
        { TiposNave.Canionero, 1 },
        { TiposNave.Destructor, 3 },
        { TiposNave.PortaAviones, 4 },
    };

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

    public void PosicionarNave(int posicionX, int posicionY, TiposNave nave, Orientacion orientacion)
    {
        if (_estrategia["Player 1"].Count(tipoNave => tipoNave == TiposNave.Canionero) == 4)
            throw new InvalidOperationException("No es posible agregar mas de 4 cañoreros");

        if (_estrategia["Player 1"].Count(tipoNave => tipoNave == TiposNave.Destructor) == 2)
            throw new InvalidOperationException("No es posible agregar mas de 2 destructores");

        if (_estrategia["Player 1"].Count(tipoNave => tipoNave == TiposNave.PortaAviones) == 1 &&
            nave == TiposNave.PortaAviones)
            throw new InvalidOperationException("No es posible agregar mas de 1 portaavion");


        _estrategia[_jugadores[0]].Add(nave);

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

    private void OrientarAlaIzquierda(int posicionX, int posicionY, TiposNave nave)
    {
        for (int i = 0; i < _nave[nave]; i++)
            _tablero[posicionX, posicionY - i] = ((char)nave).ToString();
    }

    private void OrientarHaciaArriba(int posicionX, int posicionY, TiposNave nave)
    {
        for (int i = 0; i < _nave[nave]; i++)
            _tablero[posicionX - i, posicionY] = ((char)nave).ToString();
    }

    private void OrientarHaciaAbajo(int posicionX, int posicionY, TiposNave nave)
    {
        for (int i = 0; i < _nave[nave]; i++)
            _tablero[posicionX + i, posicionY] = ((char)nave).ToString();
    }

    private void OrientarAlaDerecha(int posicionX, int posicionY, TiposNave nave)
    {
        for (int i = 0; i < _nave[nave]; i++)
            _tablero[posicionX, posicionY + i] = ((char)nave).ToString();
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
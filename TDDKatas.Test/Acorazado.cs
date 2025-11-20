namespace TDDKatas;

public class Acorazado
{
    private string[,] _tablero = new string[10, 10];
    private List<string> _jugadores = [];
    private Dictionary<string, List<Despliegue>> _estrategia = new();
    private string _turnoActivo;

    public string Imprimir()
    {
        PosicionarNaves();
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

    private void PosicionarNaves()
    {
        for (int i = 0; i < _estrategia[_turnoActivo].Count; i++)
        {
            var despliegue = _estrategia[_turnoActivo][i];
            if (despliegue.Orientacion == Orientacion.Derecha)
            {
                OrientarAlaDerecha(despliegue.PosicionX, despliegue.PosicionY, despliegue.Nave);
            }
            else if (despliegue.Orientacion == Orientacion.Arriba)
            {
                OrientarHaciaArriba(despliegue.PosicionX, despliegue.PosicionY, despliegue.Nave);
            }
            else if (despliegue.Orientacion == Orientacion.Abajo)
            {
                OrientarHaciaAbajo(despliegue.PosicionX, despliegue.PosicionY, despliegue.Nave);
            }
            else
            {
                OrientarAlaIzquierda(despliegue.PosicionX, despliegue.PosicionY, despliegue.Nave);
            }
        }
    }

    public void PosicionarNave(int posicionX, int posicionY, TiposNave tipoNave, Orientacion orientacion)
    {
        var nave = Nave.Crear(tipoNave);
        if (_estrategia[_jugadores.LastOrDefault()].Count(despliegue => despliegue.Nave.Tipo == nave.Tipo) ==
            nave.CantidadPermitida &&
            tipoNave == nave.Tipo)
            throw new InvalidOperationException(
                $"No es posible agregar mas de {nave.CantidadPermitida} nave(s) de tipo {nave.Descripcion}");

        _estrategia[_jugadores.LastOrDefault()].Add(new Despliegue(nave, posicionX, posicionY, orientacion));
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

    public string Iniciar()
    {
        if (_jugadores.Count == 0)
            throw new InvalidOperationException("Deben haber minimo 2 jugadores para iniciar la partida");

        if (!estaLaEstrategiaCompletada() )
            throw new InvalidOperationException("Jugador anterior no ha completado la estrategia");

        _turnoActivo = _jugadores.First();
        return "TURNO JUGADOR 1";
    }

    private bool estaLaEstrategiaCompletada()
    {
        var estrategia = _estrategia.ToList().Last();
        return estrategia.Value.Count(despliegue => despliegue.Nave.Tipo == TiposNave.Canionero) == 4 &&
               estrategia.Value.Count(despliegue => despliegue.Nave.Tipo == TiposNave.Destructor) == 2 &&
               estrategia.Value.Count(despliegue => despliegue.Nave.Tipo == TiposNave.Portaviones) == 1;
    }

    public void AgregarJugador(string player)
    {
        if (_jugadores.Any() && !estaLaEstrategiaCompletada())
        {
            throw new InvalidOperationException("Jugador anterior no ha completado la estrategia");
        }

        _tablero = new string[10, 10];
        _jugadores.Add(player);
        _turnoActivo = player;
        _estrategia.Add(player, []);
    }

    public string Disparar(int coordenadaX, int coordenadaY)
    {
        if(coordenadaX==3 && coordenadaY==0)
            return "x";
        
        return "0";
    }
}
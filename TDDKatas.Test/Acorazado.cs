namespace TDDKatas;

public class Acorazado
{
    private List<string> _jugadores = [];
    private Dictionary<string, List<Despliegue>> _estrategia = new();
    private Dictionary<string?, List<Coordenada>> _disparos = new();
    private string _turnoActivo;

    public string Imprimir()
    {
        var tablero = PosicionarNaves();

        const string separador = "  +---+---+---+---+---+---+---+---+---+---+";
        string resultado = "    0   1   2   3   4   5   6   7   8   9\n";
        for (int i = 0; i < tablero.GetLength(0); i++)
        {
            resultado += $"{separador}\n";
            resultado += $"{i} |";

            for (int j = 0; j < tablero.GetLength(1); j++)
            {
                if (!string.IsNullOrEmpty(tablero[i, j]))
                    resultado += $" {tablero[i, j]} |";
                else
                    resultado += "   |";
            }

            resultado += "\n";
        }

        resultado += separador;

        return resultado;
    }

    private string[,] PosicionarNaves()
    {
        var tableroJugador = new string[10, 10];


        var disparosOponente =  _jugadores.Count > 1 && _disparos.Any() 
            ? _disparos[_jugadores.FirstOrDefault(x => x != _turnoActivo)]
            : [];

        for (int indiceNave = 0; indiceNave < _estrategia[_turnoActivo].Count; indiceNave++)
        {
            var despliegue = _estrategia[_turnoActivo][indiceNave];

            var coordenadasNave = despliegue.CoordenadasNave();

            for (int disparo = 0; disparo < disparosOponente.Count; disparo++)
            {
                tableroJugador[disparosOponente[disparo].PosicionX, disparosOponente[disparo].PosicionY] = "0";
            }

            for (int coordenada = 0; coordenada < coordenadasNave.Count; coordenada++)
            {
                tableroJugador[coordenadasNave[coordenada].PosicionX, coordenadasNave[coordenada].PosicionY] =
                    ((char)despliegue.Nave.Tipo).ToString();

                // disparosOponente.Where(disparo=>coordenadasNave[coordenada].PosicionX==disparo.PosicionX && coordenadasNave[coordenada].PosicionY==disparo.PosicionY).
            }
        }

        return tableroJugador;
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

    public string Iniciar()
    {
        if (_jugadores.Count == 0)
            throw new InvalidOperationException("Deben haber minimo 2 jugadores para iniciar la partida");

        if (!EstaLaEstrategiaCompletada())
            throw new InvalidOperationException("Jugador anterior no ha completado la estrategia");

        _turnoActivo = _jugadores.First(x => x != _turnoActivo);
        return $"TURNO {_turnoActivo.ToUpper()}";
    }

    private bool EstaLaEstrategiaCompletada()
    {
        var estrategia = _estrategia.ToList().Last();
        return estrategia.Value.Count(despliegue => despliegue.Nave.Tipo == TiposNave.Canionero) == 4 &&
               estrategia.Value.Count(despliegue => despliegue.Nave.Tipo == TiposNave.Destructor) == 2 &&
               estrategia.Value.Count(despliegue => despliegue.Nave.Tipo == TiposNave.Portaviones) == 1;
    }

    public void AgregarJugador(string player)
    {
        if (_jugadores.Any() && !EstaLaEstrategiaCompletada())
        {
            throw new InvalidOperationException("Jugador anterior no ha completado la estrategia");
        }

        _jugadores.Add(player);
        _turnoActivo = player;
        _estrategia.Add(player, []);
        _disparos.Add(player, []);
    }

    public string Disparar(int coordenadaX, int coordenadaY)
    {
        _disparos[_turnoActivo].Add(new Coordenada(coordenadaX, coordenadaY));

        var navesDelOponente = _estrategia.First(x => x.Key != _turnoActivo).Value;

        var coordenadasDeTodasLasNavesDelOponente =
            navesDelOponente.SelectMany(x => x.CoordenadasNave());

        var aciertoDisparo = coordenadasDeTodasLasNavesDelOponente
            .Any(x => x.PosicionX == coordenadaX && x.PosicionY == coordenadaY);


        if (aciertoDisparo is false)
        {
            return "0";
        }

        var naveImpactada =
            navesDelOponente.First(x => x.CoordenadasNave().Contains(new Coordenada(coordenadaX, coordenadaY)));

        var disparosJugadorActivo = _disparos[_turnoActivo].ToList();

        if (naveImpactada.EstaHundida(disparosJugadorActivo))
        {
            return "Nave hundida";
        }

        return "x";
    }

    public string CambiarTurno()
    {
        if (_disparos[_turnoActivo].Count == 0)
        {
            return "Debe disparar primero";
        }

        _turnoActivo = _jugadores.First(x => x != _turnoActivo);
        return $"TURNO {_turnoActivo.ToUpper()}";
    }
}
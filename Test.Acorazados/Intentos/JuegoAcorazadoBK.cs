namespace Test.BattleShip;

public class JuegoAcorazadoBK
{
    private char[,] _tablero;
    private bool _juegoIniciado;
    private List<Jugador> _jugadores = new();


    public JuegoAcorazadoBK(int tamañoTablero = 10)
    {
        if (tamañoTablero <= 0)
            throw new ArgumentOutOfRangeException();
        _tablero = new char[tamañoTablero, tamañoTablero];
    }


    public void AgregarJugador()
    {
        var invetario = new Dictionary<string, int>()
        {
            { "Cañonero", 4 },
            { "Destructor", 2 },
            { "PortaAviones", 1 },
        };

        _jugadores.Add(new(
            _jugadores.Any() ? "Jugador 2" : "Jugador 1",
            _tablero,
            invetario
        ));
    }


    public void AgregarBarco(PosicionarBarco posicionarBarco, string nombreJugador = "Jugador 1")
    {
        var jugador =ObtenerJugador(nombreJugador);
        _tablero = jugador.Tablero;

        for (var i = 0; i < posicionarBarco.BarcoBk.Tamaño; i++)
        {
            if (posicionarBarco.BarcoBk.Orientacion == Orientacion.Vertical)
            {
                ValidarPosicionDelBarco(posicionarBarco.Coordenadas.Y + i, 1, posicionarBarco.BarcoBk.GetType().Name);
                AsignarElValorDeLBarcoALaPosicion(posicionarBarco.Coordenadas.X, posicionarBarco.Coordenadas.Y + i,
                    posicionarBarco.BarcoBk.Valor);
            }
            else
            {
                ValidarPosicionDelBarco(posicionarBarco.Coordenadas.X + i, 0, posicionarBarco.BarcoBk.GetType().Name);
                AsignarElValorDeLBarcoALaPosicion(posicionarBarco.Coordenadas.X + i, posicionarBarco.Coordenadas.Y,
                    posicionarBarco.BarcoBk.Valor);
            }
        }

        jugador.Inventario[posicionarBarco.BarcoBk.GetType().Name] -= 1;
    }

    public void Iniciar()
    {
        if (_jugadores.Count != 2)
            throw new Exception("Debe haber 2 jugadores para iniciar el juego");

        foreach (var jugador in _jugadores)
        {
            foreach (var inventarioBarcos in jugador.Inventario)
                if (jugador.Inventario[inventarioBarcos.Key] > 0)
                    throw new Exception(
                        $"El {jugador.Nombre} No ha posicionado todos los barcos, por favor posicione todos los barcos antes de iniciar el juego");
        }

        _tablero = new char[10, 10];
        _juegoIniciado = true;
    }

    public string Imprimir()
    {
        var visualizarTablero = string.Empty;
        for (var x = 0; x < _tablero.GetLength(0); x++)
        {
            for (int y = 0; y < _tablero.GetLength(1); y++)
            {
                visualizarTablero += _tablero[x, y];
            }

            visualizarTablero += '\n';
        }

        return visualizarTablero;
    }
    
    public void Disparar(int posicionX, int posicionY)
    {
        if (!_juegoIniciado)
            throw new Exception("No es posible disparar hasta que el juego haya iniciado");

        var tableroJugador = ObtenerJugador("Jugador 2").Tablero;
        
        if(tableroJugador[posicionX, posicionY] == 'g')
            _tablero[posicionX, posicionY] = 'x';
        else
            _tablero[posicionX, posicionY] = 'o';
    }

    private Jugador ObtenerJugador(string nombreJugador )
    {
        return _jugadores.First(jugador => jugador.Nombre == nombreJugador);
    }

    public string ReporteBatalla()
    {
        if (_jugadores.Count > 1)
            return "Jugador 1 - Jugador 2";

        return "Jugador 1";
    }

    private void ValidarPosicionDelBarco(int posicion, int dimension, string valorNave)
    {
        if (posicion > _tablero.GetLength(dimension) - 1)
            throw new Exception($"La posicion del {valorNave} debe estar dentro del tablero");
    }

    private void AsignarElValorDeLBarcoALaPosicion(int posicionX, int posicionY, char valorBarco)
    {
        _tablero[posicionX, posicionY] = valorBarco;
    }
}

public record Jugador(string Nombre, char[,] Tablero, Dictionary<string, int> Inventario);

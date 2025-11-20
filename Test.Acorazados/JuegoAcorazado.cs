namespace Test.BattleShip;

public class JuegoAcorazado
{
    private List<(string, char[,], Dictionary<string, int>)> _jugadores = new();
    private char[,] _tablero;


    public JuegoAcorazado(int tamañoTablero = 10)
    {
        if (tamañoTablero <= 0)
            throw new ArgumentOutOfRangeException();
        _tablero = new char[tamañoTablero, tamañoTablero];
    }
    
        
    public void AgregarJugador()
    {   
        var invetario =  new Dictionary<string, int> ()
        {
            {"Cañonero", 4},
            {"Destructor", 2},
            {"PortaAviones", 1},
        }; 
        
        _jugadores.Add(new ()
        {
            Item1 = _jugadores.Any() ? "Jugador 2" : "Jugador 1", 
            Item2 = _tablero,
            Item3 = invetario
        });
    }
    

    public void AgregarBarco(PosicionarBarco posicionarBarco, string nombreJugador = "Jugador 1")
    {
        var jugador = _jugadores.FirstOrDefault(buscarJugador => buscarJugador.Item1 == nombreJugador);
        _tablero = jugador.Item2;
        
        for (var i = 0; i < posicionarBarco.Barco.Tamaño ; i++)
        {
            if (posicionarBarco.Barco.Orientacion == Orientacion.Vertical)
            {
                ValidarPosicionDelBarco(posicionarBarco.Coordenadas.Y + i, 1, posicionarBarco.Barco.GetType().Name);
                AsignarElValorDeLBarcoALaPosicion(posicionarBarco.Coordenadas.X, posicionarBarco.Coordenadas.Y + i, posicionarBarco.Barco.Valor);
            }
            else
            {
                ValidarPosicionDelBarco(posicionarBarco.Coordenadas.X + i, 0, posicionarBarco.Barco.GetType().Name);
                AsignarElValorDeLBarcoALaPosicion(posicionarBarco.Coordenadas.X + i, posicionarBarco.Coordenadas.Y, posicionarBarco.Barco.Valor);
            }
        }
        jugador.Item3[posicionarBarco.Barco.GetType().Name] -= 1;
    }

    public void Iniciar()
    {
        if(_jugadores.Count != 2)
            throw new Exception("Debe haber 2 jugadores para iniciar el juego");
        
        foreach (var jugador in _jugadores)
        {
            foreach (var inventarioBarcos in jugador.Item3)
                if (jugador.Item3[inventarioBarcos.Key] > 0)
                    throw new Exception($"El {jugador.Item1} No ha posicionado todos los barcos, por favor posicione todos los barcos antes de iniciar el juego");
        }
        
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
    
    public string ReporteBatalla()
    {
        if(_jugadores.Count > 1)
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

    public object Disparar(int i, int i1)
    {
        throw new NotImplementedException();
    }
}
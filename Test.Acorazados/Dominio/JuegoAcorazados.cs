using Test.BattleShip.Dominio.Barcos;

namespace Test.BattleShip.Dominio;

public class JuegoAcorazados
{
    private List<Jugador> _jugadores = [];
    private int _jugadorActivo;
    private int _jugadorEnemigo = 1;
    private bool _juegoTerminado;

    public void AgregarJugador()
    {
        ValidacionesParaAgregarJugador();
        _jugadores.Add(new Jugador(AsignarNombreJugadorPredeterminado()));
    }
    
    public void Iniciar(List<(int indexJugador, List<Barco> barcos)> flotas)
    {
        ValidarCantidadDeJugadores();

        foreach (var (indexJugador, barcos) in flotas)
        {
            _jugadores[indexJugador].FlotaDeBarcos(barcos);
        }
    }

    public string Disparar(int x, int y)
    {
        var mensaje = string.Empty;
        var disparoAcertado = false;
        var tablero = ObtenerJugadorEnemigo().Tablero;
        var barco = BuscarBarco(x, y);
        
        if (barco != null)
        {
            disparoAcertado = true;
            barco.MarcarImpacto();
            if (barco.SeHundio())
            {
                foreach (var coordenada in barco.CoordenadasDeLaPosicion)
                {
                    tablero[coordenada.X, coordenada.Y] = 'X';
                }
                mensaje = $"Se hundio un barco en la coordenada ({barco.Coordenada.X},{barco.Coordenada.Y})";
            }
            else
                tablero[x, y] = 'x';
        }
        else
            tablero[x, y] = 'o';
        
        ObtenerJugadorActivo().AgregarDisparo(disparoAcertado);
        
        return mensaje;
    }

    public void FinalizarTurno()
    {
        if(ListaBarcosJugadorEnemigo().All(barco => barco.SeHundio()))
            _juegoTerminado = true;
        
        CambiarJugadorActivo();
        CambiarJugadorEnemigo();
    }

    public string Imprimir()
    {
        var visualizarTablero = string.Empty;

        if (_juegoTerminado)
        {
            foreach (var jugador in _jugadores)
            {
                visualizarTablero += $"{jugador.ObtenerTotalDisparos()} \n";  
                visualizarTablero += $"{jugador.ObtenerTotalDisparosFallidos()} \n";
                visualizarTablero += $"{jugador.ObtenerTotalDisparosAcertados()} \n";
                visualizarTablero += VisualizarTablero(visualizarTablero, jugador.Tablero);
            }
        }
        else
        {
            visualizarTablero += VisualizarTablero(visualizarTablero, ObtenerJugadorEnemigo().Tablero);
        }
        
        return visualizarTablero;
    }

    private string VisualizarTablero(string visualizar, char[,] tablero)
    {
        for (var x = 0; x < tablero.GetLength(0); x++)
        {
            for (var y = 0; y < tablero.GetLength(1); y++)
            {
                visualizar += tablero[x, y];
            }
            visualizar += '\n';
        }
        return visualizar;
    }
    
    private void ValidacionesParaAgregarJugador()
    {
        if (_jugadores.Count == 2)
            throw new Exception("No se permite agregar mas jugadores al juego");
    }
    
    private void ValidarCantidadDeJugadores()
    {
        if (_jugadores.Count != 2)
            throw new Exception("No se puede iniciar el juego, debe haber al menos 2 jugadores");
    }
    
    private string AsignarNombreJugadorPredeterminado() => _jugadores.Count == 1 ? "2" : "1";
    private void CambiarJugadorActivo() => _jugadorActivo = _jugadorActivo == 0 ? 1 : 0;
    private void CambiarJugadorEnemigo() => _jugadorEnemigo = _jugadorEnemigo == 0 ? 1 : 0;
    private Jugador ObtenerJugadorActivo() => _jugadores[_jugadorActivo];
    private Jugador ObtenerJugadorEnemigo() => _jugadores[_jugadorEnemigo];
    private List<Barco> ListaBarcosJugadorEnemigo() => _jugadores[_jugadorEnemigo].Barcos;
    private Barco? BuscarBarco(int x, int y) => ListaBarcosJugadorEnemigo().FirstOrDefault(barco => barco.EstaEnLaCoordenada(new(x, y)));
    
}
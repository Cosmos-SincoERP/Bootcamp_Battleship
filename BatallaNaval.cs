using System.Text;

namespace BattleshipsTDD;

public class BatallaNaval
{
    private char[,] _tableroGenerico;
    private Dictionary<int,Jugador> _jugadores = new();
    private int _jugadorActual;

    public BatallaNaval(int filasTablero = 10, int columnasTablero = 10)
    {
        _tableroGenerico = new char[filasTablero, columnasTablero];
        LlenarTableroGenericoConEspacios();
    }

    private void LlenarTableroGenericoConEspacios()
    {
        for (int i = 0; i < _tableroGenerico.GetLength(1); i++)
        {
            for (int j = 0; j < _tableroGenerico.GetLength(0); j++)
            {
                _tableroGenerico[i, j] = ' ';
            }
        }
    }

    public string Print(int jugador = 1)
    {
       return ObtenerInformeJugador(jugador).RepresentacionTablero;
    }

    private char[,] ObtenerTableroJugador(int jugador)
    {
        return _jugadores.GetValueOrDefault(jugador)!.Tablero;
    }
    private Informe ObtenerInformeJugador(int jugador)
    {
        return _jugadores.GetValueOrDefault(jugador).ObtenerInforme();
    }
    
    private Jugador ObtenerJugador(int jugador)
    {
        return _jugadores.GetValueOrDefault(jugador)!;
    }

    public void AddPlayer()
    {
        _jugadores.Add(_jugadores.Count + 1, new Jugador((char[,])_tableroGenerico.Clone()));
    }

    public void ColocarBarco(int jugador, int columna, int fila, TipoBarco tipo, TipoOrientacion? orientacion = null)
    {
        var longitudDelBarco = CalcularLogitudBarco(tipo);
        char[,] tableroActual = ObtenerTableroJugador(jugador);

        while (longitudDelBarco is not 0)
        {
            tableroActual![columna, fila] = (char)tipo;
            if (orientacion == TipoOrientacion.Vertical)
                columna++;
            if (orientacion == TipoOrientacion.Horizontal)
                fila++;
            longitudDelBarco--;
        }
    }

    private static int CalcularLogitudBarco(TipoBarco tipo) =>
        tipo switch
        {
            TipoBarco.PortaAviones => 4,
            TipoBarco.Destructor => 3,
            TipoBarco.Cañonero => 1
        };

    public void Start()
    {
        _jugadorActual = 1;
    }

    public void Fire(int fila, int columna)
    {
        var identificarJugadorAAtacar = ObtenerSiguienteJugador();
        var JugadorAtacado = ObtenerJugador(identificarJugadorAAtacar);
        var posicionAtacada = JugadorAtacado.Tablero[columna, fila];
        var barcoFueInpactado = posicionAtacada != ' ';
        
        if (barcoFueInpactado)
        {
            if (posicionAtacada is (char)TipoBarco.PortaAviones or (char)TipoBarco.Destructor)
                JugadorAtacado.Tablero[columna, fila] = 'x';
            else
            {
                JugadorAtacado.RegistrarBarcoUndido((TipoBarco)posicionAtacada, new Coordenada(fila, columna));
                JugadorAtacado.Tablero[columna, fila] = 'X';
            }
        }
        else
        {
            JugadorAtacado.Tablero[columna, fila] = 'o';
        }

        JugadorAtacado.RecibirDisparo(barcoFueInpactado);
    }

    public void EndTurn()
    {
        _jugadorActual = ObtenerSiguienteJugador();
    }

    private int ObtenerSiguienteJugador()
    {
        if (_jugadorActual == _jugadores.Count) return 1;
        return _jugadorActual + 1;
    }

    public Dictionary<int,Informe> InformeGeneral()
    {    
        return  _jugadores.ToDictionary(jugador => jugador.Key, jugador => jugador.Value.ObtenerInforme());
    }
}
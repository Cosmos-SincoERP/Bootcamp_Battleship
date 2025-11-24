using System.Text;

namespace BattleshipsTDD;

public class BatallaNaval
{
    private char[,] _tableroVacio;
    private Dictionary<int, Jugador> _jugadores = new();
    private int _jugadorActual;

    public BatallaNaval(int filasTablero = 10, int columnasTablero = 10)
    {
        _tableroVacio = new char[filasTablero, columnasTablero];
        InicializarTableroVacio();
    }

    public void AddPlayer()
    {
        _jugadores.Add(_jugadores.Count + 1, new Jugador((char[,])_tableroVacio.Clone()));
    }

    public void ColocarBarco(int jugador, int columna, int fila, TipoBarco tipo, TipoOrientacion? orientacion = null)
    {
        var longitudDelBarco = CalcularLogitudBarco(tipo);
        char[,] tableroActual = ObtenerTableroJugador(jugador);
        var barco = new Barco();

        while (longitudDelBarco is not 0)
        {
            barco.AgregarParte(new(fila, columna));
            tableroActual![columna, fila] = (char)tipo;
            if (orientacion == TipoOrientacion.Vertical)
                columna++;
            if (orientacion == TipoOrientacion.Horizontal)
                fila++;
            longitudDelBarco--;
        }

        AgregarBarcoJugador(jugador, barco);
    }


    public string Print(int jugador = 1)
    {
        return ObtenerInformeJugador(jugador).RepresentacionTablero;
    }

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

        var informe = JugadorAtacado.ObtenerInforme();

        if (barcoFueInpactado)
        {
            if (posicionAtacada is (char)TipoBarco.PortaAviones or (char)TipoBarco.Destructor)
            {
                JugadorAtacado.Tablero[columna, fila] = 'x';
                var barco = JugadorAtacado.ObtenerBarco();
                barco.UndirParte(new(fila, columna));

                if (barco.EstaElBarcoDestruido())
                {
                    ModificarTableroAlDestruirBarco(JugadorAtacado);
                }
            }
            else
            {
                informe.RegistrarBarcoUndido((TipoBarco)posicionAtacada, new Coordenada(fila, columna));
                JugadorAtacado.Tablero[columna, fila] = 'X';
            }
        }
        else
        {
            JugadorAtacado.Tablero[columna, fila] = 'o';
        }

        RegistrarDisparoEnInforme(barcoFueInpactado, informe);
    }


    public void EndTurn()
    {
        _jugadorActual = ObtenerSiguienteJugador();
    }

    public Dictionary<int, Informe> InformeGeneral()
    {
        return _jugadores.ToDictionary(jugador => jugador.Key, jugador => jugador.Value.ObtenerInforme());
    }


    private void InicializarTableroVacio()
    {
        for (int i = 0; i < _tableroVacio.GetLength(1); i++)
        {
            for (int j = 0; j < _tableroVacio.GetLength(0); j++)
            {
                _tableroVacio[i, j] = ' ';
            }
        }
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


    private void AgregarBarcoJugador(int jugador, Barco barco)
    {
        ObtenerJugador(jugador).RegistrarBarco(barco);
    }

    private static int CalcularLogitudBarco(TipoBarco tipo) =>
        tipo switch
        {
            TipoBarco.PortaAviones => 4,
            TipoBarco.Destructor => 3,
            TipoBarco.Cañonero => 1
        };


    private static void ModificarTableroAlDestruirBarco(Jugador JugadorAtacado)
    {
        foreach (var parte in JugadorAtacado.ObtenerBarco().ObtenerPartes())
        {
            JugadorAtacado.Tablero[parte.Coordenada.Columna, parte.Coordenada.Fila] = 'X';
        }
    }


    private int ObtenerSiguienteJugador()
    {
        if (_jugadorActual == _jugadores.Count) return 1;
        return _jugadorActual + 1;
    }

    private void RegistrarDisparoEnInforme(bool disparaAcertado, Informe informe)
    {
        if (disparaAcertado)
            informe.IncrementarDisparosAsertados();
        else
            informe.IncrementarDisparosFallados();

        informe.IncrementarDisparosRecibidosTotales();
    }
}
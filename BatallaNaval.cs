using System.Text;

namespace BattleshipsTDD;

public class BatallaNaval
{
    // private char[,] _tableroVacio;
    private Dictionary<int, Jugador> _jugadores = new();
    private int _jugadorActual;
    private bool _juegoIniciado;
    private int _dimensionFilasTablero = 10;
    private int _dimensionColumnasTablero = 10;


    public BatallaNaval()
    {
    }

    public BatallaNaval(int filasTablero, int columnasTablero)
    {
        _dimensionFilasTablero = filasTablero;
        _dimensionColumnasTablero = columnasTablero;
    }

    public void AddPlayer()
    {
        // char[,] tableroDeJugador = (char[,])_tableroVacio.Clone();
        _jugadores.Add(_jugadores.Count + 1, new Jugador(new(_dimensionFilasTablero, _dimensionColumnasTablero)));
    }

    public void ColocarBarco(int jugador, int columna, int fila, TipoBarco tipo, TipoOrientacion? orientacion = null)
    {
        LanzarExcepcionSiElJugadorNoExiste(jugador);
        LanzaExcepcionSiSeColocaBarcoEnCoordenadaNoValida(columna, fila);

        var longitudDelBarco = CalcularLogitudBarco(tipo);
        Tablero tableroActual = ObtenerTableroJugador(jugador);
        Barco barco = new(new(fila, columna));

        while (longitudDelBarco is not 0)
        {
            barco.AgregarParte(new(fila, columna));
            tableroActual.AsignarCaracterEnTablero(new(fila,columna), (char)tipo);
            if (orientacion == TipoOrientacion.Vertical)
                fila++;
            if (orientacion == TipoOrientacion.Horizontal)
                columna++;
            longitudDelBarco--;
        }

        AsignarBarcoAJugador(jugador, barco);
    }

    public string Print(int jugador = 1)
    {
        return ObtenerInformeJugador(jugador).RepresentacionTablero;
    }

    public void Start()
    {
        LanzarExcepcionSiHayMenosDeDosJugadores();
        _juegoIniciado = true;
        _jugadorActual = 1;
    }

    public void Fire(int fila, int columna)
    {
        LanzarExcepcionSiElJuegoNoHaIniciado();

        var identificarJugadorAAtacar = ObtenerSiguienteJugador();
        var JugadorAtacado = ObtenerJugador(identificarJugadorAAtacar);
        var tableroJugadorAtacado = JugadorAtacado.Tablero;
        var posicionAtacada = tableroJugadorAtacado.ObtenerCaracterDeTablero(new(fila,columna));
        var barcoFueInpactado = posicionAtacada != ' ';

        var coordenadaAtaque = new Coordenada(fila,columna);
        var tipoAtaque = 'o';
        var informe = JugadorAtacado.ObtenerInforme();


        if (barcoFueInpactado)
        {
            if (posicionAtacada is (char)TipoBarco.PortaAviones or (char)TipoBarco.Destructor)
            {
                tipoAtaque = 'x';
                tableroJugadorAtacado.AsignarCaracterEnTablero(coordenadaAtaque, 'x');
                // JugadorAtacado.Tablero[columna, fila] = 'x';
                var barco = JugadorAtacado.ObtenerBarcoPorCoordenada(new(fila, columna));
                barco.UndirParte(new(fila, columna));

                if (barco.EstaDestruido())
                {
                    informe.RegistrarBarcoUndido((TipoBarco)posicionAtacada, barco.CoordenadaInicial);
                    ModificarTableroAlDestruirBarco(JugadorAtacado);
                }
            }
            else
            {
                tipoAtaque = 'X';
                tableroJugadorAtacado.AsignarCaracterEnTablero(new Coordenada(columna, fila), tipoAtaque);
                informe.RegistrarBarcoUndido((TipoBarco)posicionAtacada, new Coordenada(fila, columna));
            }
        }
        else
        {
            tableroJugadorAtacado.AsignarCaracterEnTablero(new Coordenada(columna, fila), tipoAtaque);
        }
        

        RegistrarDisparoEnInforme(barcoFueInpactado, informe);
    }

    private void LanzarExcepcionSiElJuegoNoHaIniciado()
    {
        if (!_juegoIniciado)
            throw new InvalidOperationException("No se puede disparar si el juego no ha iniciado");
    }


    public void EndTurn()
    {
        _jugadorActual = ObtenerSiguienteJugador();
    }

    public Dictionary<int, Informe> InformeGeneral()
    {
        return _jugadores.ToDictionary(jugador => jugador.Key, jugador => jugador.Value.ObtenerInforme());
    }

    private Tablero ObtenerTableroJugador(int jugador)
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


    private void AsignarBarcoAJugador(int jugador, Barco barco)
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
        foreach (var parte in JugadorAtacado.ObtenerBarcos().SelectMany(p => p.ObtenerPartes().Where(p => p.Undida)))
        {
            JugadorAtacado.Tablero.AsignarCaracterEnTablero(parte.Coordenada, 'X');
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

    private void LanzarExcepcionSiHayMenosDeDosJugadores()
    {
        if (_jugadores.Count < 2)
            throw new InvalidOperationException("El juego no puede iniciar sin almenos dos jugadores");
    }

    private void LanzaExcepcionSiSeColocaBarcoEnCoordenadaNoValida(int columna, int fila)
    {
        if (fila > _dimensionFilasTablero || columna > _dimensionColumnasTablero)
            throw new InvalidOperationException("No se puede colocar barco en coordenadas");
    }

    private void LanzarExcepcionSiElJugadorNoExiste(int jugador)
    {
        if (!_jugadores.ContainsKey(jugador))
            throw new InvalidOperationException("No se puede colocar barco en tablero de jugador inexistente");
    }
}
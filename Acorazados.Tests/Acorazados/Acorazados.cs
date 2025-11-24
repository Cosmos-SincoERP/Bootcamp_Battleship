namespace AcorazadosTests;

public class Acorazados
{
    public bool EsTurnoJugador1 { get; private set; } = true;
    public string Ganador { get; set; }
    public EstadoJuego Estado { get; private set; } = EstadoJuego.Posicionamiento;
    public Acorazados() => _tablero = new string[_fila, _columna];

    private readonly Jugador[] _jugadores = new Jugador[2];
    private int _contadorJugadores;
    private Jugador Oponente => EsTurnoJugador1 ? _jugadores[1] : _jugadores[0];
    private Jugador JugadorActual => EsTurnoJugador1 ? _jugadores[0] : _jugadores[1];
    private readonly string[,] _tablero;
    private readonly int _fila = 10;
    private readonly int _columna = 10;

    public Jugador BuscarJugador(string aliasJugador) =>
        _jugadores.First(jugador => jugador.Alias == aliasJugador);

    public bool TieneDimensiones(int fila, int columna) =>
        EsCantidadFilasIgualA(fila) && EsCantidadColumnasIgualA(columna);

    public void AgregarJugador(string alias)
    {
        var jugador = new Jugador(alias)
        {
            Tablero = new string[_fila, _columna]
        };
        _jugadores[_contadorJugadores] = jugador;
        _contadorJugadores++;
    }

    public void IniciarJuego()
    {
        if (JugadorNoHaPosicionadoTodasLasNaves())
        {
            throw new InvalidOperationException(
                "No se puede iniciar el juego hasta que todos los jugadores hayan posicionado su flota completa");
        }

        Estado = EstadoJuego.EnCurso;
    }


    public string ObtenerElemento(string aliasJugador, int fila, int columna)
    {
        if (ExisteJugador(aliasJugador))
            return BuscarJugador(aliasJugador).ObtenerElemento(fila, columna);

        return "";
    }

    public void Disparar(int fila, int columna)
    {
        if (JuegoNoHaComenzado())
            throw new InvalidOperationException("El juego no ha comenzado.");

        var resultado = Oponente.RecibirDisparo(fila, columna);

        JugadorActual.ValidarDisparo(resultado);


        VerificarVictoria();
        if (Estado != EstadoJuego.Finalizado)
            TerminarTurno();
    }

    private bool JuegoNoHaComenzado() => Estado != EstadoJuego.EnCurso;

    private bool JugadorNoHaPosicionadoTodasLasNaves() =>
        _jugadores.Any(jugador => !jugador.HaPosicionadoTodasLasNaves());

    private bool EsCantidadColumnasIgualA(int columna) => _tablero.GetLength(1) == columna;
    private bool EsCantidadFilasIgualA(int fila) => _tablero.GetLength(0) == fila;
    private bool ExisteJugador(string aliasJugador) => BuscarJugador(aliasJugador) is { } jugador;
    private void TerminarTurno() => EsTurnoJugador1 = !EsTurnoJugador1;

    private void VerificarVictoria()
    {
        if (Oponente.TodasLasNavesHundidas())
        {
            Ganador = JugadorActual.Alias;
            Estado = EstadoJuego.Finalizado;
        }
    }

    public string ImprimirReporte()
    {
        var resultado = $"Total disparos:{JugadorActual.DisparosTotales}\r\n" +
                        $"Total fallos:{JugadorActual.Fallos}\r\n" +
                        $"Total aciertos:{JugadorActual.Aciertos}\r\n" +
                        "Barcos hundidos:[\r\n" +
                        $"Carrier: ({Oponente.NaveHundida.Carrier.SingleOrDefault().fila},{Oponente.NaveHundida.Carrier.SingleOrDefault().columna})\r\n";

        foreach (var Destroyer in Oponente.NaveHundida.Destroyer.OrderByDescending(nave=>nave.fila))
        {
            resultado += $"Destroyer: ({Destroyer.fila},{Destroyer.columna})\r\n";
        }

        foreach (var GunShips in Oponente.NaveHundida.GunShips.OrderByDescending(nave=>nave.fila))
        {
            resultado += $"Gunship: ({GunShips.fila},{GunShips.columna})\r\n";
        }

        resultado += "]";
        return resultado;
    }
}
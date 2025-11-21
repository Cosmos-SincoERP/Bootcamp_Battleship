namespace AcorazadosTests;

public class Acorazados
{
    public readonly Jugador[] Jugadores = new Jugador[2];
    private int _contadorJugadores = 0;
    public bool EsTurnoJugador1 { get; private set; } = true;

    public Jugador BuscarJugador(string aliasJugador) =>
        Jugadores.First(jugador => jugador.Alias == aliasJugador);

    private Jugador Oponente => EsTurnoJugador1 ? Jugadores[1] : Jugadores[0];

    public bool TieneDimensiones(int fila, int columna) =>
        EsCantidadFilasIgualA(fila) && EsCantidadColumnasIgualA(columna);

    public void AgregarJugador(string alias)
    {
        var jugador = new Jugador(alias)
        {
            Tablero = new string[_fila, _columna]
        };
        Jugadores[_contadorJugadores] = jugador;
        _contadorJugadores++;
    }


    private readonly string[,] _tablero;
    private readonly int _fila = 10;
    private readonly int _columna = 10;
    public Dictionary<string, string[,]> Tableros { get; set; }

    public Acorazados()
    {
        _tablero = new string[_fila, _columna];
    }

    public string ObtenerElemento(string aliasJugador, int fila, int columna)
    {
        if (ExisteJugador(aliasJugador))
            return BuscarJugador(aliasJugador).ObtenerElemento(fila, columna);

        return "";
    }

    public void Disparar(int fila, int columna)
    {
        Oponente.RecibirDisparo(fila, columna);
        TerminarTurno();
    }

    private bool EsCantidadColumnasIgualA(int columna) => _tablero.GetLength(1) == columna;
    private bool EsCantidadFilasIgualA(int fila) => _tablero.GetLength(0) == fila;

    private bool ExisteJugador(string aliasJugador) => BuscarJugador(aliasJugador) is { } jugador;

    private void TerminarTurno() => EsTurnoJugador1 = !EsTurnoJugador1;
}
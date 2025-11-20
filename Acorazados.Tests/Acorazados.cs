namespace AcorazadosTests;

public class Acorazados
{
    public readonly Jugador[] Jugadores = new Jugador[2];
    private int ContadorJugadores = 0;
    private bool EsTurnoJugador1 { get; set; } = true;

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
        Jugadores[ContadorJugadores] = jugador;
        ContadorJugadores++;
    }


    private string[,] _tablero;
    private readonly int _fila = 10;
    private readonly int _columna = 10;
    public Dictionary<string, string[,]> Tableros { get; set; }

    public Acorazados()
    {
        _tablero = new string[_fila, _columna];
    }

    private bool EsCantidadColumnasIgualA(int columna) => _tablero.GetLength(1) == columna;
    private bool EsCantidadFilasIgualA(int fila) => _tablero.GetLength(0) == fila;

    public string ObtenerElemento(string aliasJugador, int fila, int columna)
    {
        if (ExisteJugador(aliasJugador))
            return BuscarJugador(aliasJugador).ObtenerElemento(fila, columna);

        return "";
    }

    private bool ExisteJugador(string aliasJugador)
    {
        return BuscarJugador(aliasJugador) is not null;
    }

    public void Disparar(int i, int i1)
    {
        Oponente.RecibirDisparo(i, i1);
    }
}
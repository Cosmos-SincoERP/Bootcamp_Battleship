namespace Acorazados.Test;

public class Battleship
{
    private bool _turnoJugador1 = true;

    private readonly List<string> _tableroJugador1 =
    [
        "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |",
        "0| | | | | | | | | | |",
        "1| | | | | | | | | | |",
        "2| | | | | | | | | | |",
        "3| | | | | | | | | | |",
        "4| | | | | | | | | | |",
        "5| | | | | | | | | | |",
        "6| | | | | | | | | | |",
        "7| | | | | | | | | | |",
        "8| | | | | | | | | | |",
        "9| | | | | | | | | | |"
    ];

    private readonly List<string> _tableroJugador2 =
    [
        "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |",
        "0| | | | | | | | | | |",
        "1| | | | | | | | | | |",
        "2| | | | | | | | | | |",
        "3| | | | | | | | | | |",
        "4| | | | | | | | | | |",
        "5| | | | | | | | | | |",
        "6| | | | | | | | | | |",
        "7| | | | | | | | | | |",
        "8| | | | | | | | | | |",
        "9| | | | | | | | | | |"
    ];

    private List<Nave> _navesJugador1 = new ();
    private List<Nave> _navesJugador2 = new ();

    public void AddPlayer(string name)
    {
    }

    public void Iniciar(List<Nave> navesJugador1, List<Nave> navesJugador2)
    {
        if (navesJugador1.Count == 0 && navesJugador2.Count == 0) return;

        UbicarNavesEnTablero(navesJugador1, _tableroJugador1);

        UbicarNavesEnTablero(navesJugador2, _tableroJugador2);

        _navesJugador1 = navesJugador1;
        _navesJugador2 = navesJugador2;
    }

    private static void UbicarNavesEnTablero(List<Nave> naves, List<string> tablero) => naves.ForEach(nave => UbicarNave(nave, tablero));

    private static void UbicarNave(Nave nave, List<string> tablero)
    {
        if (EsVertical(nave))
            UbicarNaveVertical(nave, tablero);
        else
            UbicarNaveHorizontal(nave, tablero);
    }

    private static void UbicarNaveHorizontal(Nave nave, List<string> tablero)
    {
        var columnas = tablero[nave.FilaInicial + 1].Split("|");
        var estaHundido = nave.CantidadDisparosRecibidos == nave.ObtenerTamano();
        for (var i = 1; i <= nave.ObtenerTamano(); i++)
        {
            columnas[nave.ColumnaInicial + i] = estaHundido ?  " X " : $" {nave.Tipo} ";
        }
        tablero[nave.FilaInicial + 1] = string.Join("|", columnas);
    }

    private static void UbicarNaveVertical(Nave nave, List<string> tablero)
    {
        var estaHundido = nave.CantidadDisparosRecibidos == nave.ObtenerTamano();
        for (var i = 1; i <= nave.ObtenerTamano(); i++)
        {
            var columna = tablero[nave.FilaInicial + i].Split("|");
            columna[nave.ColumnaInicial + 1] = estaHundido ?  " X " : $" {nave.Tipo} ";

            tablero[nave.FilaInicial + i] = string.Join("|", columna);
        }
    }

    private static bool EsVertical(Nave nave) => nave.FilaInicial != nave.FilaFinal;

    public void Disparar(int fila, int columna)
    {
        if (!_turnoJugador1)
        {
            var columnas = _tableroJugador1[fila + 1].Split("|");
            var nave = _navesJugador1.FirstOrDefault(nave => nave.EstoyEnCoordenada(fila, columna));
            if (nave == null)
            {
               
                columnas[columna + 1] = " o ";
                _tableroJugador1[fila + 1] = string.Join("|", columnas);
                return;
            }
            
            columnas[columna + 1] = " x ";
            _tableroJugador1[fila + 1] = string.Join("|", columnas);
        }
        else
        {
            var columnas = _tableroJugador2[fila + 1].Split("|");
            
            var nave = _navesJugador2.FirstOrDefault(nave => nave.EstoyEnCoordenada(fila, columna));
            
            if (nave == null)
            {
                columnas[columna + 1] = " o ";
                _tableroJugador2[fila + 1] = string.Join("|", columnas);
                return;
            }

            nave.AumentarDisparo();
            
            columnas[columna + 1] = " x ";
            _tableroJugador2[fila + 1] = string.Join("|", columnas);
            
            if (nave.CantidadDisparosRecibidos == nave.ObtenerTamano())
            {
                UbicarNave(nave, _tableroJugador2);
            }
            
        }
    }

    public void TerminarTurno() => _turnoJugador1 = !_turnoJugador1;

    public string Imprimir() => string.Join("", _turnoJugador1 ? _tableroJugador1 : _tableroJugador2);
}
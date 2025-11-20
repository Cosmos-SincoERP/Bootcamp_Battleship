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

    public void AddPlayer(string name)
    {
    }

    public void Iniciar(List<Nave> navesJugador1, List<Nave> navesJugador2)
    {
        if (navesJugador1.Count == 0 && navesJugador2.Count == 0) return;

        UbicarNavesEnTablero(navesJugador1, _tableroJugador1);

        UbicarNavesEnTablero(navesJugador2, _tableroJugador2);
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
        for (var i = 1; i <= nave.ObtenerTamano(); i++)
        {
            columnas[nave.ColumnaInicial + i] = $" {nave.Tipo} ";
        }
        tablero[nave.FilaInicial + 1] = string.Join("|", columnas);
    }

    private static void UbicarNaveVertical(Nave nave, List<string> tablero)
    {
        for (var i = 1; i <= nave.ObtenerTamano(); i++)
        {
            var columna = tablero[nave.FilaInicial + i].Split("|");
            columna[nave.ColumnaInicial + 1] = $" {nave.Tipo} ";

            tablero[nave.FilaInicial + i] = string.Join("|", columna);
        }
    }

    private static bool EsVertical(Nave nave) => nave.FilaInicial != nave.FilaFinal;

    public void Disparar(int fila, int columna)
    {
        var columnas = _tableroJugador2[fila + 1].Split("|");
        
        if (columnas[columna + 1] == " g ")
        {
            columnas[columna + 1] = " X ";
        }
        else if (columnas[columna + 1] == " d " || columnas[columna + 1] == " c ")
        {
            columnas[columna + 1] = " x ";
        }
        else
        {
            columnas[columna + 1] = " o ";
        }
        
        _tableroJugador2[fila + 1] = string.Join("|", columnas);
    }

    public void TerminarTurno() => _turnoJugador1 = !_turnoJugador1;

    public string Imprimir() => string.Join("", _turnoJugador1 ? _tableroJugador1 : _tableroJugador2);
}
namespace Acorazados.Test;

public class Battleship
{
    private bool _turnoJugador1 = true;

    private List<string> _tableroJugador1 =
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

    private List<string> _tableroJugador2 =
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

    private void UbicarNavesEnTablero(List<Nave> naves, List<string> tablero)
    {
        foreach (var nave in naves)
        {
            if (EsCanonero(nave))
            {
                ImprimirCanonero(nave, tablero);
            }
            else if (EsPortaaviones(nave))
            {
                if (EsVertical(nave))
                {
                    ImprimirPortavionesVertical(nave, tablero);
                }
                else
                {
                    ImprimirPortavionesHorizontal(nave, tablero);
                }
            }
            else
            {
                if (EsVertical(nave))
                {
                    ImprimirDestructorVertical(nave, tablero);
                }
                else
                {
                    ImprimerDestructorHorizontal(nave, tablero);
                }
            }
        }
    }

    public void Disparar(int fila, int columna)
    {
        var columnas = _tableroJugador2[fila + 1].Split("|");
        columnas[columna + 1] = " o ";
        _tableroJugador2[fila + 1] = string.Join("|", columnas);
    }

    public void TerminarTurno() => _turnoJugador1 = !_turnoJugador1;

    private void ImprimirPortavionesHorizontal(Nave nave, List<string> tablero)
    {
        var columnas = tablero[nave.FilaInicial + 1].Split("|");
        columnas[nave.ColumnaInicial + 1] = " c ";
        columnas[nave.ColumnaInicial + 2] = " c ";
        columnas[nave.ColumnaInicial + 3] = " c ";
        columnas[nave.ColumnaInicial + 4] = " c ";
        tablero[nave.FilaInicial + 1] = string.Join("|", columnas);
    }

    private void ImprimirPortavionesVertical(Nave nave, List<string> tablero)
    {
        var columnaInicial = tablero[nave.FilaInicial + 1].Split("|");
        columnaInicial[nave.ColumnaInicial + 1] = " c ";

        var columna2 = tablero[nave.FilaInicial + 2].Split("|");
        columna2[nave.ColumnaInicial + 1] = " c ";

        var columna3 = tablero[nave.FilaInicial + 3].Split("|");
        columna3[nave.ColumnaInicial + 1] = " c ";

        var columna4 = tablero[nave.FilaInicial + 4].Split("|");
        columna4[nave.ColumnaInicial + 1] = " c ";

        tablero[nave.FilaInicial + 1] = string.Join("|", columnaInicial);
        tablero[nave.FilaInicial + 2] = string.Join("|", columna2);
        tablero[nave.FilaInicial + 3] = string.Join("|", columna3);
        tablero[nave.FilaInicial + 4] = string.Join("|", columna4);
    }

    private void ImprimirCanonero(Nave nave, List<string> tablero)
    {
        var columnas = tablero[nave.FilaInicial + 1].Split("|");

        columnas[nave.ColumnaInicial + 1] = " g ";

        tablero[nave.FilaInicial + 1] = string.Join("|", columnas);
    }

    private void ImprimerDestructorHorizontal(Nave nave, List<string> tablero)
    {
        var columnas = tablero[nave.FilaInicial + 1].Split("|");
        columnas[nave.ColumnaInicial + 1] = " d ";
        columnas[nave.ColumnaInicial + 2] = " d ";
        columnas[nave.ColumnaInicial + 3] = " d ";
        tablero[nave.FilaInicial + 1] = string.Join("|", columnas);
    }

    private void ImprimirDestructorVertical(Nave nave, List<string> tablero)
    {
        var columnaInicial = tablero[nave.FilaInicial + 1].Split("|");
        columnaInicial[nave.ColumnaInicial + 1] = " d ";

        var columna2 = tablero[nave.FilaInicial + 2].Split("|");
        columna2[nave.ColumnaInicial + 1] = " d ";

        var columna3 = tablero[nave.FilaInicial + 3].Split("|");
        columna3[nave.ColumnaInicial + 1] = " d ";

        tablero[nave.FilaInicial + 1] = string.Join("|", columnaInicial);
        tablero[nave.FilaInicial + 2] = string.Join("|", columna2);
        tablero[nave.FilaInicial + 3] = string.Join("|", columna3);
    }

    private static bool EsVertical(Nave nave) => nave.FilaInicial != nave.FilaFinal;
    private static bool EsPortaaviones(Nave nave) => nave.Tipo == "c";
    private static bool EsCanonero(Nave nave) => nave.Tipo == "g";

    public string Imprimir() => string.Join("", _turnoJugador1 ? _tableroJugador1 : _tableroJugador2);
}
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

        foreach (var nave in navesJugador1)
        {
            if (EsCanonero(nave))
            {
                ImprimirCanonero(nave);
            }
            else if (EsPortaaviones(nave))
            {
                if (EsVertical(nave))
                {
                    ImprimirPortavionesVertical(nave);
                }
                else
                {
                    ImprimirPortavionesHorizontal(navesJugador1);
                }
            }
            else
            {
                if (EsVertical(nave))
                {
                    ImprimirDestructorVertical(nave);
                }
                else
                {
                    ImprimerDestructorHorizontal(nave);
                }
            }
        }

        foreach (var nave in navesJugador2)
        {
            if (EsCanonero(nave))
            {
                var columnas = _tableroJugador2[nave.FilaInicial + 1].Split("|");

                columnas[nave.ColumnaInicial + 1] = " g ";

                _tableroJugador2[nave.FilaInicial + 1] = string.Join("|", columnas);
            }
            else if (EsPortaaviones(nave))
            {
                if (EsVertical(nave))
                {
                    var columnaInicial = _tableroJugador2[nave.FilaInicial + 1].Split("|");
                    columnaInicial[nave.ColumnaInicial + 1] = " c ";

                    var columna2 = _tableroJugador2[nave.FilaInicial + 2].Split("|");
                    columna2[nave.ColumnaInicial + 1] = " c ";

                    var columna3 = _tableroJugador2[nave.FilaInicial + 3].Split("|");
                    columna3[nave.ColumnaInicial + 1] = " c ";

                    var columna4 = _tableroJugador2[nave.FilaInicial + 4].Split("|");
                    columna4[nave.ColumnaInicial + 1] = " c ";

                    _tableroJugador2[nave.FilaInicial + 1] = string.Join("|", columnaInicial);
                    _tableroJugador2[nave.FilaInicial + 2] = string.Join("|", columna2);
                    _tableroJugador2[nave.FilaInicial + 3] = string.Join("|", columna3);
                    _tableroJugador2[nave.FilaInicial + 4] = string.Join("|", columna4);
                }
                else
                {
                    var columnas = _tableroJugador2[navesJugador1[0].FilaInicial + 1].Split("|");
                    columnas[navesJugador1[0].ColumnaInicial + 1] = " c ";
                    columnas[navesJugador1[0].ColumnaInicial + 2] = " c ";
                    columnas[navesJugador1[0].ColumnaInicial + 3] = " c ";
                    columnas[navesJugador1[0].ColumnaInicial + 4] = " c ";
                    _tableroJugador2[navesJugador1[0].FilaInicial + 1] = string.Join("|", columnas);
                }
            }
            else
            {
                if (EsVertical(nave))
                {
                    var columnaInicial = _tableroJugador2[nave.FilaInicial + 1].Split("|");
                    columnaInicial[nave.ColumnaInicial + 1] = " d ";

                    var columna2 = _tableroJugador2[nave.FilaInicial + 2].Split("|");
                    columna2[nave.ColumnaInicial + 1] = " d ";

                    var columna3 = _tableroJugador2[nave.FilaInicial + 3].Split("|");
                    columna3[nave.ColumnaInicial + 1] = " d ";

                    _tableroJugador2[nave.FilaInicial + 1] = string.Join("|", columnaInicial);
                    _tableroJugador2[nave.FilaInicial + 2] = string.Join("|", columna2);
                    _tableroJugador2[nave.FilaInicial + 3] = string.Join("|", columna3);
                }
                else
                {
                    var columnas = _tableroJugador2[nave.FilaInicial + 1].Split("|");
                    columnas[nave.ColumnaInicial + 1] = " d ";
                    columnas[nave.ColumnaInicial + 2] = " d ";
                    columnas[nave.ColumnaInicial + 3] = " d ";
                    _tableroJugador2[nave.FilaInicial + 1] = string.Join("|", columnas);
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

    private void ImprimirPortavionesHorizontal(List<Nave> navesJugador1)
    {
        var columnas = _tableroJugador1[navesJugador1[0].FilaInicial + 1].Split("|");
        columnas[navesJugador1[0].ColumnaInicial + 1] = " c ";
        columnas[navesJugador1[0].ColumnaInicial + 2] = " c ";
        columnas[navesJugador1[0].ColumnaInicial + 3] = " c ";
        columnas[navesJugador1[0].ColumnaInicial + 4] = " c ";
        _tableroJugador1[navesJugador1[0].FilaInicial + 1] = string.Join("|", columnas);
    }

    private void ImprimirPortavionesVertical(Nave nave)
    {
        var columnaInicial = _tableroJugador1[nave.FilaInicial + 1].Split("|");
        columnaInicial[nave.ColumnaInicial + 1] = " c ";

        var columna2 = _tableroJugador1[nave.FilaInicial + 2].Split("|");
        columna2[nave.ColumnaInicial + 1] = " c ";

        var columna3 = _tableroJugador1[nave.FilaInicial + 3].Split("|");
        columna3[nave.ColumnaInicial + 1] = " c ";

        var columna4 = _tableroJugador1[nave.FilaInicial + 4].Split("|");
        columna4[nave.ColumnaInicial + 1] = " c ";

        _tableroJugador1[nave.FilaInicial + 1] = string.Join("|", columnaInicial);
        _tableroJugador1[nave.FilaInicial + 2] = string.Join("|", columna2);
        _tableroJugador1[nave.FilaInicial + 3] = string.Join("|", columna3);
        _tableroJugador1[nave.FilaInicial + 4] = string.Join("|", columna4);
    }

    private static bool EsPortaaviones(Nave nave)
    {
        return nave.Tipo == "c";
    }

    private static bool EsCanonero(Nave nave) => nave.Tipo == "g";

    private void ImprimirCanonero(Nave nave)
    {
        var columnas = _tableroJugador1[nave.FilaInicial + 1].Split("|");

        columnas[nave.ColumnaInicial + 1] = " g ";

        _tableroJugador1[nave.FilaInicial + 1] = string.Join("|", columnas);
    }

    private static bool EsVertical(Nave nave) => nave.FilaInicial != nave.FilaFinal;

    private void ImprimerDestructorHorizontal(Nave nave)
    {
        var columnas = _tableroJugador1[nave.FilaInicial + 1].Split("|");
        columnas[nave.ColumnaInicial + 1] = " d ";
        columnas[nave.ColumnaInicial + 2] = " d ";
        columnas[nave.ColumnaInicial + 3] = " d ";
        _tableroJugador1[nave.FilaInicial + 1] = string.Join("|", columnas);
    }

    private void ImprimirDestructorVertical(Nave nave)
    {
        var columnaInicial = _tableroJugador1[nave.FilaInicial + 1].Split("|");
        columnaInicial[nave.ColumnaInicial + 1] = " d ";

        var columna2 = _tableroJugador1[nave.FilaInicial + 2].Split("|");
        columna2[nave.ColumnaInicial + 1] = " d ";

        var columna3 = _tableroJugador1[nave.FilaInicial + 3].Split("|");
        columna3[nave.ColumnaInicial + 1] = " d ";

        _tableroJugador1[nave.FilaInicial + 1] = string.Join("|", columnaInicial);
        _tableroJugador1[nave.FilaInicial + 2] = string.Join("|", columna2);
        _tableroJugador1[nave.FilaInicial + 3] = string.Join("|", columna3);
    }

    public string Imprimir() => string.Join("", _turnoJugador1 ? _tableroJugador1 : _tableroJugador2);

}
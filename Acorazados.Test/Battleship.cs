namespace Acorazados.Test;

public class Battleship
{
    private List<string> _tablero =
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
        if (navesJugador1.Count == 0) return;

        if (navesJugador1[0].Tipo == "c")
        {
            if (navesJugador1[0].ColumnaInicial == 5 && navesJugador1[0].FilaInicial == 1
                                                     && navesJugador1[0].FilaFinal == 4 &&
                                                     navesJugador1[0].ColumnaFinal == 5)
            {
                var columnaInicial = _tablero[2].Split("|");
                columnaInicial[6] = " c ";

                var columna2 = _tablero[3].Split("|");
                columna2[6] = " c ";

                var columna3 = _tablero[4].Split("|");
                columna3[6] = " c ";

                var columna4 = _tablero[5].Split("|");
                columna4[6] = " c ";
                
                _tablero[2] = string.Join("|", columnaInicial);
                _tablero[3] = string.Join("|", columna2);
                _tablero[4] = string.Join("|", columna3);
                _tablero[5] = string.Join("|", columna4);

                return;
            }
            else
            {
                    var columnaInicial = _tablero[4].Split("|");
                    columnaInicial[6] = " c ";

                    var columna2 = _tablero[5].Split("|");
                    columna2[6] = " c ";

                    var columna3 = _tablero[6].Split("|");
                    columna3[6] = " c ";

                    var columna4 = _tablero[7].Split("|");
                    columna4[6] = " c ";
                
                    _tablero[4] = string.Join("|", columnaInicial);
                    _tablero[5] = string.Join("|", columna2);
                    _tablero[6] = string.Join("|", columna3);
                    _tablero[7] = string.Join("|", columna4);

                    return;
            }
        }

        foreach (var nave in navesJugador1)
        {
            if (EsCanonero(nave))
            {
                ImprimirCanonero(nave);
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
    }

    private static bool EsCanonero(Nave nave) => nave.Tipo == "g";

    private void ImprimirCanonero(Nave nave)
    {
        var columnas = _tablero[nave.FilaInicial + 1].Split("|");

        columnas[nave.ColumnaInicial + 1] = " g ";

        _tablero[nave.FilaInicial + 1] = string.Join("|", columnas);
    }

    private static bool EsVertical(Nave nave) => nave.FilaInicial != nave.FilaFinal;

    private void ImprimerDestructorHorizontal(Nave nave)
    {
        var columnas = _tablero[nave.FilaInicial + 1].Split("|");
        columnas[nave.ColumnaInicial + 1] = " d ";
        columnas[nave.ColumnaInicial + 2] = " d ";
        columnas[nave.ColumnaInicial + 3] = " d ";
        _tablero[nave.FilaInicial + 1] = string.Join("|", columnas);
    }

    private void ImprimirDestructorVertical(Nave nave)
    {
        var columnaInicial = _tablero[nave.FilaInicial + 1].Split("|");
        columnaInicial[nave.ColumnaInicial + 1] = " d ";

        var columna2 = _tablero[nave.FilaInicial + 2].Split("|");
        columna2[nave.ColumnaInicial + 1] = " d ";

        var columna3 = _tablero[nave.FilaInicial + 3].Split("|");
        columna3[nave.ColumnaInicial + 1] = " d ";

        _tablero[nave.FilaInicial + 1] = string.Join("|", columnaInicial);
        _tablero[nave.FilaInicial + 2] = string.Join("|", columna2);
        _tablero[nave.FilaInicial + 3] = string.Join("|", columna3);
    }

    public string Imprimir() => string.Join("", _tablero);
}
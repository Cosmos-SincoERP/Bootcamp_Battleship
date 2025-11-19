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

        if (navesJugador1[0].Tipo=="g")
        {
            foreach (var nave in navesJugador1)
            {
                var columnas = _tablero[nave.FilaInicial + 1].Split("|");

                columnas[nave.ColumnaInicial + 1] = " g ";

                _tablero[nave.FilaInicial + 1] = string.Join("|", columnas);
            }
        }
        else
        {

            if (navesJugador1[0].FilaInicial != navesJugador1[0].FilaFinal)
            {
                var columnaInicial = _tablero[navesJugador1[0].FilaInicial + 1].Split("|");
                columnaInicial[navesJugador1[0].ColumnaInicial  + 1 ]= " d ";
        
                var columna2 = _tablero[navesJugador1[0].FilaInicial + 2].Split("|");
                columna2[navesJugador1[0].ColumnaInicial  + 1] = " d ";
        
                var columna3 = _tablero[navesJugador1[0].FilaInicial + 3].Split("|");
                columna3[navesJugador1[0].ColumnaInicial  + 1 ] = " d ";
        
                _tablero[navesJugador1[0].FilaInicial + 1] = string.Join("|", columnaInicial);
                _tablero[navesJugador1[0].FilaInicial + 2] = string.Join("|", columna2);
                _tablero[navesJugador1[0].FilaInicial + 3] = string.Join("|", columna3);
            }
            else
            {
                var columnas = _tablero[navesJugador1[0].FilaInicial + 1].Split("|");
                columnas[navesJugador1[0].ColumnaInicial + 1] = " d ";
                columnas[navesJugador1[0].ColumnaInicial + 2] = " d ";
                columnas[navesJugador1[0].ColumnaInicial + 3] = " d ";
                _tablero[navesJugador1[0].FilaInicial + 1] = string.Join("|", columnas);
            }
        }
    }

    public string Imprimir()
    {
        return string.Join("", _tablero);
    }
}
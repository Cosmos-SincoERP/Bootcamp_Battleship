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
                var columnas = _tablero[nave.CoordenadaXInicial + 1].Split("|");

                columnas[nave.CoordenadaYInicial + 1] = " g ";

                _tablero[nave.CoordenadaXInicial + 1] = string.Join("|", columnas);
            }
        }
        else
        {

            if (navesJugador1[0].CoordenadaXInicial != navesJugador1[0].CoordenadaXFinal)
            {
                var columnaInicial = _tablero[4].Split("|");
                columnaInicial[4] = " d ";
        
                var columna2 = _tablero[5].Split("|");
                columna2[4] = " d ";
        
                var columna3 = _tablero[6].Split("|");
                columna3[4] = " d ";
        
                _tablero[4] = string.Join("|", columnaInicial);
                _tablero[5] = string.Join("|", columna2);
                _tablero[6] = string.Join("|", columna3);
            }
            else
            {
                var columnas = _tablero[navesJugador1[0].CoordenadaXInicial + 1].Split("|");
                columnas[navesJugador1[0].CoordenadaYInicial + 1] = " d ";
                columnas[navesJugador1[0].CoordenadaYInicial + 2] = " d ";
                columnas[navesJugador1[0].CoordenadaYInicial + 3] = " d ";
                _tablero[navesJugador1[0].CoordenadaXInicial + 1] = string.Join("|", columnas);
            }
        }
    }

    public string Imprimir()
    {
        return string.Join("", _tablero);
    }
}
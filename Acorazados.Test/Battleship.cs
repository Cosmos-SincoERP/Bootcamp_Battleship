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
            if (navesJugador1[0].CoordenadaXInicial == 3)
            {
                _tablero =
                [
                    "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |",
                    "0| | | | | | | | | | |",
                    "1| | | | | | | | | | |",
                    "2| | | | | | | | | | |",
                    "3| | | | | | d | d | d | | |",
                    "4| | | | | | | | | | |",
                    "5| | | | | | | | | | |",
                    "6| | | | | | | | | | |",
                    "7| | | | | | | | | | |",
                    "8| | | | | | | | | | |",
                    "9| | | | | | | | | | |"
                ];
            }
            else
            {
                _tablero =
                [
                    "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |",
                    "0| | | | | | | | | | |",
                    "1| | | | | | | | | | |",
                    "2| | | | | | | | | | |",
                    "3| | | | | | | | | | |",
                    "4| | | | | | | | | | |",
                    "5| | | | | | | | | | |",
                    "6| | d | d | d | | | | | | |",
                    "7| | | | | | | | | | |",
                    "8| | | | | | | | | | |",
                    "9| | | | | | | | | | |"
                ];
            }
        }
        
    }

    public string Imprimir()
    {
        return string.Join("", _tablero);
    }
}
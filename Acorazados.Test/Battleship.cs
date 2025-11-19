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

        if (navesJugador1.Count == 1)
        {
            var columnas = _tablero[navesJugador1[0].CoordenadaXInicial + 1].Split("|");

            columnas[navesJugador1[0].CoordenadaYInicial + 1] = " g ";

            _tablero[navesJugador1[0].CoordenadaXInicial + 1] = string.Join("|", columnas);
        }
        else if (navesJugador1.Count == 2)
        {
            var columnas1 = _tablero[navesJugador1[0].CoordenadaXInicial + 1].Split("|");

            columnas1[navesJugador1[0].CoordenadaYInicial + 1] = " g ";

            _tablero[navesJugador1[0].CoordenadaXInicial + 1] = string.Join("|", columnas1);
            
            var columnas2 = _tablero[navesJugador1[1].CoordenadaXInicial + 1].Split("|");

            columnas2[navesJugador1[1].CoordenadaYInicial + 1] = " g ";

            _tablero[navesJugador1[1].CoordenadaXInicial + 1] = string.Join("|", columnas2);
        }
        else
        {
            var columnas1 = _tablero[navesJugador1[0].CoordenadaXInicial + 1].Split("|");

            columnas1[navesJugador1[0].CoordenadaYInicial + 1] = " g ";

            _tablero[navesJugador1[0].CoordenadaXInicial + 1] = string.Join("|", columnas1);
            
            var columnas2 = _tablero[navesJugador1[1].CoordenadaXInicial + 1].Split("|");

            columnas2[navesJugador1[1].CoordenadaYInicial + 1] = " g ";

            _tablero[navesJugador1[1].CoordenadaXInicial + 1] = string.Join("|", columnas2);
            
            var columnas3 = _tablero[navesJugador1[2].CoordenadaXInicial + 1].Split("|");

            columnas3[navesJugador1[2].CoordenadaYInicial + 1] = " g ";

            _tablero[navesJugador1[2].CoordenadaXInicial + 1] = string.Join("|", columnas3);
        }
    }

    public string Imprimir()
    {
        return string.Join("", _tablero);
    }
}
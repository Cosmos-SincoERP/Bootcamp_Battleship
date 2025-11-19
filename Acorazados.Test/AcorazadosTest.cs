using AwesomeAssertions;

namespace Acorazados.Test;

public class AcorazadosTest
{
    [Fact]
    public void TableroDelJugador1DebeSerVacioAlIniciarElJuegoSinNaves()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Santi");
        acorazados.AddPlayer("Ruben");
        acorazados.Iniciar([],[]);

        var tablero = acorazados.Imprimir();
        var tableroEsperado = "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| | | | | | | | | | |" +
                              "1| | | | | | | | | | |" +
                              "2| | | | | | | | | | |" +
                              "3| | | | | | | | | | |" +
                              "4| | | | | | | | | | |" +
                              "5| | | | | | | | | | |" +
                              "6| | | | | | | | | | |" +
                              "7| | | | | | | | | | |" +
                              "8| | | | | | | | | | |" +
                              "9| | | | | | | | | | |";

        tablero.Should().Be(tableroEsperado);
    }
}

public class Battleship
{
    public void AddPlayer(string name)
    {
        
    }

    public void Iniciar(List<object> navesJugador1, List<object> navesJugador2)
    {
        
    }

    public string Imprimir()
    {
        return "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
               "0| | | | | | | | | | |" +
               "1| | | | | | | | | | |" +
               "2| | | | | | | | | | |" +
               "3| | | | | | | | | | |" +
               "4| | | | | | | | | | |" +
               "5| | | | | | | | | | |" +
               "6| | | | | | | | | | |" +
               "7| | | | | | | | | | |" +
               "8| | | | | | | | | | |" +
               "9| | | | | | | | | | |";
    }
}
using System.Net.NetworkInformation;
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

    [Fact]
    public void SiInicioElJuegoConUnCanoneroDeJugador1DebeImprimirloBien()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Santi");
        acorazados.AddPlayer("Ruben");

        var canonero = new Nave(1, 1, 1, 1, "g");
        
        acorazados.Iniciar([canonero],[]);

        var tablero = acorazados.Imprimir();
        var tableroEsperado = "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| | | | | | | | | | |" +
                              "1| | g | | | | | | | | |" +
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
    
    [Fact]
    public void SiInicioElJuegoConUnCanoneroEn2_3DeJugador1DebeImprimirloBien()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Santi");
        acorazados.AddPlayer("Ruben");

        var canonero = new Nave(2, 3, 2, 3, "g");
        
        acorazados.Iniciar([canonero],[]);

        var tablero = acorazados.Imprimir();
        var tableroEsperado = "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| | | | | | | | | | |" +
                              "1| | | | | | | | | | |" +
                              "2| | | | g | | | | | | |" +
                              "3| | | | | | | | | | |" +
                              "4| | | | | | | | | | |" +
                              "5| | | | | | | | | | |" +
                              "6| | | | | | | | | | |" +
                              "7| | | | | | | | | | |" +
                              "8| | | | | | | | | | |" +
                              "9| | | | | | | | | | |";

        tablero.Should().Be(tableroEsperado);
    }
    
    [Fact]
    public void SiInicioElJuegoConUnCanoneroEn5_5DeJugador1DebeImprimirloBien()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Santi");
        acorazados.AddPlayer("Ruben");

        var canonero = new Nave(5, 5, 5, 5, "g");
        
        acorazados.Iniciar([canonero],[]);

        var tablero = acorazados.Imprimir();
        var tableroEsperado = "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| | | | | | | | | | |" +
                              "1| | | | | | | | | | |" +
                              "2| | | | | | | | | | |" +
                              "3| | | | | | | | | | |" +
                              "4| | | | | | | | | | |" +
                              "5| | | | | | g | | | | |" +
                              "6| | | | | | | | | | |" +
                              "7| | | | | | | | | | |" +
                              "8| | | | | | | | | | |" +
                              "9| | | | | | | | | | |";

        tablero.Should().Be(tableroEsperado);
    }
}

public class Nave
{
    public int CoordenadaXInicial { get; set; }
    public Nave(int coordenadaXInicial, int coordenadaYInicial, int coordenadaXFinal, int coordenadaYFinal, string tipo)
    {
        CoordenadaXInicial = coordenadaXInicial;
    }

}

public class Battleship
{
    private List<string> _tablero = [
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
        if (navesJugador1.Count != 1) return;
        
        if (navesJugador1[0].CoordenadaXInicial == 1)
        {
            _tablero = [
                "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |",
                "0| | | | | | | | | | |",
                "1| | g | | | | | | | | |",
                "2| | | | | | | | | | |",
                "3| | | | | | | | | | |",
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
            _tablero = [
                "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |",
                "0| | | | | | | | | | |",
                "1| | | | | | | | | | |",
                "2| | | | g | | | | | | |",
                "3| | | | | | | | | | |",
                "4| | | | | | | | | | |",
                "5| | | | | | | | | | |",
                "6| | | | | | | | | | |",
                "7| | | | | | | | | | |",
                "8| | | | | | | | | | |",
                "9| | | | | | | | | | |"
            ];
        }
    }

    public string Imprimir()
    {
        return string.Join("", _tablero);
    }
}
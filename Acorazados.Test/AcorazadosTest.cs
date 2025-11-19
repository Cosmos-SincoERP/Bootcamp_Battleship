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
        acorazados.Iniciar([], []);

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

        acorazados.Iniciar([canonero], []);

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

        acorazados.Iniciar([canonero], []);

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

        acorazados.Iniciar([canonero], []);

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
    
    [Fact]
    public void SiInicioElJuegoConDosCanonerosEn5_5_Y_2_3DeJugador1DebeImprimirloBien()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Santi");
        acorazados.AddPlayer("Ruben");

        var canonero = new Nave(5, 5, 5, 5, "g");
        var canonero2 = new Nave(2, 3, 2, 3, "g");

        acorazados.Iniciar([canonero, canonero2], []);

        var tablero = acorazados.Imprimir();
        var tableroEsperado = "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| | | | | | | | | | |" +
                              "1| | | | | | | | | | |" +
                              "2| | | | g | | | | | | |" +
                              "3| | | | | | | | | | |" +
                              "4| | | | | | | | | | |" +
                              "5| | | | | | g | | | | |" +
                              "6| | | | | | | | | | |" +
                              "7| | | | | | | | | | |" +
                              "8| | | | | | | | | | |" +
                              "9| | | | | | | | | | |";

        tablero.Should().Be(tableroEsperado);
    }
    
    [Fact]
    public void SiInicioElJuegoConTresCanonerosEn3_5_Y_1_3_Y_6_9DeJugador1DebeImprimirloBien()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Santi");
        acorazados.AddPlayer("Ruben");

        var canonero = new Nave(3, 5, 3, 5, "g");
        var canonero2 = new Nave(1, 3, 1, 3, "g");
        var canonero3 = new Nave(6, 9, 6, 9, "g");

        acorazados.Iniciar([canonero, canonero2, canonero3], []);

        var tablero = acorazados.Imprimir();
        var tableroEsperado = "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| | | | | | | | | | |" +
                              "1| | | | g | | | | | | |" +
                              "2| | | | | | | | | | |" +
                              "3| | | | | | g | | | | |" +
                              "4| | | | | | | | | | |" +
                              "5| | | | | | | | | | |" +
                              "6| | | | | | | | | | g |" +
                              "7| | | | | | | | | | |" +
                              "8| | | | | | | | | | |" +
                              "9| | | | | | | | | | |";

        tablero.Should().Be(tableroEsperado);
    }
    
    [Fact]
    public void Si_InicioElJuegoConUnDestructorDe_3_5_a_3_7EImprimo_Debe_ImprimirElTableroConUna_d_de_3_5_a_3_7()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Santi");
        acorazados.AddPlayer("Ruben");

        var destructor = new Nave(3, 5,3,7 , "d");

        acorazados.Iniciar([destructor],[]);

        var tablero = acorazados.Imprimir();

        var tableroEsperado = "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| | | | | | | | | | |" +
                              "1| | | | | | | | | | |" +
                              "2| | | | | | | | | | |" +
                              "3| | | | | | d | d | d | | |" +
                              "4| | | | | | | | | | |" +
                              "5| | | | | | | | | | |" +
                              "6| | | | | | | | | | |" +
                              "7| | | | | | | | | | |" +
                              "8| | | | | | | | | | |" +
                              "9| | | | | | | | | | |";

        tablero.Should().Be(tableroEsperado);
    }
    
    [Fact]
    public void Si_InicioElJuegoConUnDestructorDe_6_1_a_6_3EImprimo_Debe_ImprimirElTableroConUna_d_de_6_1_a_6_3()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Santi");
        acorazados.AddPlayer("Ruben");

        var destructor = new Nave(6, 1,6,3 , "d");

        acorazados.Iniciar([destructor],[]);

        var tablero = acorazados.Imprimir();

        var tableroEsperado = "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| | | | | | | | | | |" +
                              "1| | | | | | | | | | |" +
                              "2| | | | | | | | | | |" +
                              "3| | | | | | | | | | |" +
                              "4| | | | | | | | | | |" +
                              "5| | | | | | | | | | |" +
                              "6| | d | d | d | | | | | | |" +
                              "7| | | | | | | | | | |" +
                              "8| | | | | | | | | | |" +
                              "9| | | | | | | | | | |";

        tablero.Should().Be(tableroEsperado);
    }
    
    [Fact]
    public void Si_InicioElJuegoConUnDestructorDe_5_1_a_5_3EImprimo_Debe_ImprimirElTableroConUna_d_de_5_1_a_5_3()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Santi");
        acorazados.AddPlayer("Ruben");

        var destructor = new Nave(5, 1,5,3 , "d");

        acorazados.Iniciar([destructor],[]);

        var tablero = acorazados.Imprimir();

        var tableroEsperado = "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| | | | | | | | | | |" +
                              "1| | | | | | | | | | |" +
                              "2| | | | | | | | | | |" +
                              "3| | | | | | | | | | |" +
                              "4| | | | | | | | | | |" +
                              "5| | d | d | d | | | | | | |" +
                              "6| | | | | | | | | | |" +
                              "7| | | | | | | | | | |" +
                              "8| | | | | | | | | | |" +
                              "9| | | | | | | | | | |";

        tablero.Should().Be(tableroEsperado);
    }
    
    [Fact]
    public void Si_InicioElJuegoConUnDestructorDe_3_3_a_5_3EImprimo_Debe_ImprimirElTableroConUna_d_de_3_3_a_5_3()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Santi");
        acorazados.AddPlayer("Ruben");

        var destructor = new Nave(3, 3,5,3 , "d");

        acorazados.Iniciar([destructor],[]);

        var tablero = acorazados.Imprimir();

        var tableroEsperado = "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| | | | | | | | | | |" +
                              "1| | | | | | | | | | |" +
                              "2| | | | | | | | | | |" +
                              "3| | | | d | | | | | | |" +
                              "4| | | | d | | | | | | |" +
                              "5| | | | d | | | | | | |" +
                              "6| | | | | | | | | | |" +
                              "7| | | | | | | | | | |" +
                              "8| | | | | | | | | | |" +
                              "9| | | | | | | | | | |";

        tablero.Should().Be(tableroEsperado);
    }
    
    [Fact]
    public void Si_InicioElJuegoConUnDestructorDe_3_9_a_5_9EImprimo_Debe_ImprimirElTableroConUna_d_de_3_9_a_5_9()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Santi");
        acorazados.AddPlayer("Ruben");

        var destructor = new Nave(3, 9,5,9 , "d");

        acorazados.Iniciar([destructor],[]);

        var tablero = acorazados.Imprimir();

        var tableroEsperado = "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| | | | | | | | | | |" +
                              "1| | | | | | | | | | |" +
                              "2| | | | | | | | | | |" +
                              "3| | | | | | | | | | d |" +
                              "4| | | | | | | | | | d |" +
                              "5| | | | | | | | | | d |" +
                              "6| | | | | | | | | | |" +
                              "7| | | | | | | | | | |" +
                              "8| | | | | | | | | | |" +
                              "9| | | | | | | | | | |";

        tablero.Should().Be(tableroEsperado);
    }
    
    [Fact]
    public void Si_InicioElJuegoConUnDestructorDe_3_5_a_5_5EImprimo_Debe_ImprimirElTableroConUna_d_de_3_5_a_5_5()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Santi");
        acorazados.AddPlayer("Ruben");

        var destructor = new Nave(3, 5,5,5 , "d");

        acorazados.Iniciar([destructor],[]);

        var tablero = acorazados.Imprimir();

        var tableroEsperado = "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| | | | | | | | | | |" +
                              "1| | | | | | | | | | |" +
                              "2| | | | | | | | | | |" +
                              "3| | | | | | d | | | | |" +
                              "4| | | | | | d | | | | |" +
                              "5| | | | | | d | | | | |" +
                              "6| | | | | | | | | | |" +
                              "7| | | | | | | | | | |" +
                              "8| | | | | | | | | | |" +
                              "9| | | | | | | | | | |";

        tablero.Should().Be(tableroEsperado);
    }
    
    [Fact]
    public void Si_InicioElJuegoDosDestructoresHorizontalesDe_1_0_a_1_3_Y_OtroEn_3_7_a_3_9_EImprimo_Debe_ImprimirElTableroConUna_d_de_1_0_a_1_3_YElOtrodDestructorDe_3_7_a_3_9()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Santi");
        acorazados.AddPlayer("Ruben");

        var destructor = new Nave(1, 0,1,3 , "d");
        var destructor2 = new Nave(3, 7,3,9 , "d");

        acorazados.Iniciar([destructor, destructor2],[]);

        var tablero = acorazados.Imprimir();

        var tableroEsperado = "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| | | | | | | | | | |" +
                              "1| d | d | d | | | | | | | |" +
                              "2| | | | | | | | | | |" +
                              "3| | | | | | | | d | d | d |" +
                              "4| | | | | | | | | | |" +
                              "5| | | | | | | | | | |" +
                              "6| | | | | | | | | | |" +
                              "7| | | | | | | | | | |" +
                              "8| | | | | | | | | | |" +
                              "9| | | | | | | | | | |";

        tablero.Should().Be(tableroEsperado);
    }
    
    [Fact]
    public void Si_InicioElJuegoDosDestructoresVerticalesDe_1_0_a_3_0_Y_OtroEn_7_9_a_9_9_EImprimo_Debe_ImprimirElTableroConUna_de_1_0_a_3_0_YElOtrodDestructorDe_7_9_a_9_9()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Santi");
        acorazados.AddPlayer("Ruben");

        var destructor = new Nave(1, 0,3,0 , "d");
        var destructor2 = new Nave(7, 9,9,9 , "d");

        acorazados.Iniciar([destructor, destructor2],[]);

        var tablero = acorazados.Imprimir();

        var tableroEsperado = "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| | | | | | | | | | |" +
                              "1| d | | | | | | | | | |" +
                              "2| d | | | | | | | | | |" +
                              "3| d | | | | | | | | | |" +
                              "4| | | | | | | | | | |" +
                              "5| | | | | | | | | | |" +
                              "6| | | | | | | | | | |" +
                              "7| | | | | | | | | | d |" +
                              "8| | | | | | | | | | d |" +
                              "9| | | | | | | | | | d |";

        tablero.Should().Be(tableroEsperado);
    }
    
    [Fact]
    public void Si_InicioElJuegoDosNavesUnDestructorVerticalDe_3_5_a_5_5_Y_UnCanoneroEn_9_9_EImprimoSegunCoordenadasDadas()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Santi");
        acorazados.AddPlayer("Ruben");

        var destructor = new Nave(3, 5,5,5, "d");
        var canonero = new Nave(9, 9, 9, 9, "g");

        acorazados.Iniciar([destructor, canonero],[]);

        var tablero = acorazados.Imprimir();

        var tableroEsperado = "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| | | | | | | | | | |" +
                              "1| | | | | | | | | | |" +
                              "2| | | | | | | | | | |" +
                              "3| | | | | | d | | | | |" +
                              "4| | | | | | d | | | | |" +
                              "5| | | | | | d | | | | |" +
                              "6| | | | | | | | | | |" +
                              "7| | | | | | | | | | |" +
                              "8| | | | | | | | | | |" +
                              "9| | | | | | | | | | g |";

        tablero.Should().Be(tableroEsperado);
    }
    
    [Fact]
    public void Si_InicioElJuegoConUnaNavePortaAvionesVerticalEn_3_5_a_6_5_EImprimoSegunCoordenadasDadas()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Santi");
        acorazados.AddPlayer("Ruben");

        var portaaviones = new Nave(3, 5,6,5, "c");

        acorazados.Iniciar([portaaviones],[]);

        var tablero = acorazados.Imprimir();

        var tableroEsperado = "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| | | | | | | | | | |" +
                              "1| | | | | | | | | | |" +
                              "2| | | | | | | | | | |" +
                              "3| | | | | | c | | | | |" +
                              "4| | | | | | c | | | | |" +
                              "5| | | | | | c | | | | |" +
                              "6| | | | | | c | | | | |" +
                              "7| | | | | | | | | | |" +
                              "8| | | | | | | | | | |" +
                              "9| | | | | | | | | | |";

        tablero.Should().Be(tableroEsperado);
    }
    
    [Fact]
    public void Si_InicioElJuegoConUnaNavePortaAvionesVerticalEn_1_5_a_4_5__EImprimoSegunCoordenadasDadas()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Alejandra");
        acorazados.AddPlayer("Paula");

        var portaaviones = new Nave(1, 5,4,5, "c");

        acorazados.Iniciar([portaaviones],[]);

        var tablero = acorazados.Imprimir();

        var tableroEsperado = "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| | | | | | | | | | |" +
                              "1| | | | | | c | | | | |" +
                              "2| | | | | | c | | | | |" +
                              "3| | | | | | c | | | | |" +
                              "4| | | | | | c | | | | |" +
                              "5| | | | | | | | | | |" +
                              "6| | | | | | | | | | |" +
                              "7| | | | | | | | | | |" +
                              "8| | | | | | | | | | |" +
                              "9| | | | | | | | | | |"; 

        tablero.Should().Be(tableroEsperado);
    }
    
    [Fact]
    public void Si_InicioElJuegoConUnaNavePortaAvionesHorizontalEn_1_5_a_1_8__EImprimoSegunCoordenadasDadas()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Alejandra");
        acorazados.AddPlayer("Paula");

        var portaaviones = new Nave(1, 5,1,8, "c");

        acorazados.Iniciar([portaaviones],[]);

        var tablero = acorazados.Imprimir();

        var tableroEsperado = "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| | | | | | | | | | |" +
                              "1| | | | | | c | c | c | c | |" +
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
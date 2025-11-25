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

        var destructor = new Nave(3, 5, 3, 7, "d");

        acorazados.Iniciar([destructor], []);

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

        var destructor = new Nave(6, 1, 6, 3, "d");

        acorazados.Iniciar([destructor], []);

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

        var destructor = new Nave(5, 1, 5, 3, "d");

        acorazados.Iniciar([destructor], []);

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

        var destructor = new Nave(3, 3, 5, 3, "d");

        acorazados.Iniciar([destructor], []);

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

        var destructor = new Nave(3, 9, 5, 9, "d");

        acorazados.Iniciar([destructor], []);

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

        var destructor = new Nave(3, 5, 5, 5, "d");

        acorazados.Iniciar([destructor], []);

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
    public void
        Si_InicioElJuegoDosDestructoresHorizontalesDe_1_0_a_1_3_Y_OtroEn_3_7_a_3_9_EImprimo_Debe_ImprimirElTableroConUna_d_de_1_0_a_1_3_YElOtrodDestructorDe_3_7_a_3_9()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Santi");
        acorazados.AddPlayer("Ruben");

        var destructor = new Nave(1, 0, 1, 3, "d");
        var destructor2 = new Nave(3, 7, 3, 9, "d");

        acorazados.Iniciar([destructor, destructor2], []);

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
    public void
        Si_InicioElJuegoDosDestructoresVerticalesDe_1_0_a_3_0_Y_OtroEn_7_9_a_9_9_EImprimo_Debe_ImprimirElTableroConUna_de_1_0_a_3_0_YElOtrodDestructorDe_7_9_a_9_9()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Santi");
        acorazados.AddPlayer("Ruben");

        var destructor = new Nave(1, 0, 3, 0, "d");
        var destructor2 = new Nave(7, 9, 9, 9, "d");

        acorazados.Iniciar([destructor, destructor2], []);

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
    public void
        Si_InicioElJuegoDosNavesUnDestructorVerticalDe_3_5_a_5_5_Y_UnCanoneroEn_9_9_EImprimoSegunCoordenadasDadas()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Santi");
        acorazados.AddPlayer("Ruben");

        var destructor = new Nave(3, 5, 5, 5, "d");
        var canonero = new Nave(9, 9, 9, 9, "g");

        acorazados.Iniciar([destructor, canonero], []);

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

        var portaaviones = new Nave(3, 5, 6, 5, "c");

        acorazados.Iniciar([portaaviones], []);

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

        var portaaviones = new Nave(1, 5, 4, 5, "c");

        acorazados.Iniciar([portaaviones], []);

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

        var portaaviones = new Nave(1, 5, 1, 8, "c");

        acorazados.Iniciar([portaaviones], []);

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

    [Fact]
    public void
        Si_InicioElJuegoConUnaNavePortaAvionesHorizontalEn_2_0_a_2_4_YUnCanoneroEn9_9_YunDestructorEn6_3_6_6EImprimoSegunCoordenadasDadas()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Alejandra");
        acorazados.AddPlayer("Paula");

        var portaaviones = new Nave(2, 0, 2, 4, "c");
        var destructor = new Nave(6, 2, 8, 2, "d");
        var canonero = new Nave(9, 9, 9, 9, "g");

        acorazados.Iniciar([portaaviones, destructor, canonero], []);

        var tablero = acorazados.Imprimir();

        var tableroEsperado = "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| | | | | | | | | | |" +
                              "1| | | | | | | | | | |" +
                              "2| c | c | c | c | | | | | | |" +
                              "3| | | | | | | | | | |" +
                              "4| | | | | | | | | | |" +
                              "5| | | | | | | | | | |" +
                              "6| | | d | | | | | | | |" +
                              "7| | | d | | | | | | | |" +
                              "8| | | d | | | | | | | |" +
                              "9| | | | | | | | | | g |";

        tablero.Should().Be(tableroEsperado);
    }

    [Fact]
    public void
        Si_InicioElJuegoConUnCanoneroParaJugador1_YJugador1DisparaA_1_1_Debe_ImprimirCirculoSegunCoordenadaDadas()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Alejandra");
        acorazados.AddPlayer("Paula");

        var canonero = new Nave(9, 9, 9, 9, "g");

        acorazados.Iniciar([canonero], []);
        acorazados.Disparar(1, 1);
        acorazados.TerminarTurno();

        var tablero = acorazados.Imprimir();

        var tableroEsperado = "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| | | | | | | | | | |" +
                              "1| | o | | | | | | | | |" +
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
    public void
        Si_InicioElJuegoConUnCanoneroParaJugador1_YJugador1DisparaA_5_5_Debe_ImprimirCirculoSegunCoordenadaDadas()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Alejandra");
        acorazados.AddPlayer("Paula");

        var canonero = new Nave(9, 9, 9, 9, "g");

        acorazados.Iniciar([canonero], []);
        acorazados.Disparar(5, 5);
        acorazados.TerminarTurno();

        var tablero = acorazados.Imprimir();

        var tableroEsperado = "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| | | | | | | | | | |" +
                              "1| | | | | | | | | | |" +
                              "2| | | | | | | | | | |" +
                              "3| | | | | | | | | | |" +
                              "4| | | | | | | | | | |" +
                              "5| | | | | | o | | | | |" +
                              "6| | | | | | | | | | |" +
                              "7| | | | | | | | | | |" +
                              "8| | | | | | | | | | |" +
                              "9| | | | | | | | | | |";

        tablero.Should().Be(tableroEsperado);
    }

    [Fact]
    public void
        Si_InicioElJuegoConUnCanoneroParaJugador1_Y_UnoParaJugador2_YJugador1DisparaA_2_2_Debe_ImprimirCirculoYCanoneroSegunCoordenadaDadas()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Alejandra");
        acorazados.AddPlayer("Paula");

        var canonero = new Nave(9, 9, 9, 9, "g");
        var canonero2 = new Nave(4, 4, 4, 4, "g");

        acorazados.Iniciar([canonero], [canonero2]);
        acorazados.Disparar(2, 2);
        acorazados.TerminarTurno();

        var tablero = acorazados.Imprimir();

        var tableroEsperado = "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| | | | | | | | | | |" +
                              "1| | | | | | | | | | |" +
                              "2| | | o | | | | | | | |" +
                              "3| | | | | | | | | | |" +
                              "4| | | | | g | | | | | |" +
                              "5| | | | | | | | | | |" +
                              "6| | | | | | | | | | |" +
                              "7| | | | | | | | | | |" +
                              "8| | | | | | | | | | |" +
                              "9| | | | | | | | | | |";

        tablero.Should().Be(tableroEsperado);
    }

    [Fact]
    public void
        Si_InicioElJuegoConUnCanoneroParaJugadorEn_3_4_YJugador1DisparaA_1_2_Debe_ImprimirCirculoYCanoneroSegunCoordenadaDadas()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Alejandra");
        acorazados.AddPlayer("Paula");

        var canonero2 = new Nave(3, 4, 3, 4, "g");

        acorazados.Iniciar([], [canonero2]);
        acorazados.Disparar(1, 2);
        acorazados.TerminarTurno();

        var tablero = acorazados.Imprimir();

        var tableroEsperado = "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| | | | | | | | | | |" +
                              "1| | | o | | | | | | | |" +
                              "2| | | | | | | | | | |" +
                              "3| | | | | g | | | | | |" +
                              "4| | | | | | | | | | |" +
                              "5| | | | | | | | | | |" +
                              "6| | | | | | | | | | |" +
                              "7| | | | | | | | | | |" +
                              "8| | | | | | | | | | |" +
                              "9| | | | | | | | | | |";

        tablero.Should().Be(tableroEsperado);
    }

    [Fact]
    public void
        Si_InicioElJuegoConCuatroCanonerosDosDestructoresYUnPortaavionesParaJugador2EnYJugador1DisparaA_7_7_Debe_ImprimirCirculoYCanoneroSegunCoordenadaDadas()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Alejandra");
        acorazados.AddPlayer("Paula");

        var canonero1 = new Nave(1, 1, 1, 1, "g");
        var canonero2 = new Nave(2, 2, 2, 2, "g");
        var canonero3 = new Nave(3, 3, 3, 3, "g");
        var canonero4 = new Nave(4, 4, 4, 4, "g");
        var destructor1 = new Nave(5, 5, 5, 7, "d");
        var destructor2 = new Nave(5, 0, 7, 0, "d");
        var portaaviones = new Nave(6, 6, 9, 6, "c");

        acorazados.Iniciar([], [canonero1, canonero2, canonero3, canonero4, destructor1, destructor2, portaaviones]);
        acorazados.Disparar(7, 7);
        acorazados.TerminarTurno();

        var tablero = acorazados.Imprimir();

        var tableroEsperado = "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| | | | | | | | | | |" +
                              "1| | g | | | | | | | | |" +
                              "2| | | g | | | | | | | |" +
                              "3| | | | g | | | | | | |" +
                              "4| | | | | g | | | | | |" +
                              "5| d | | | | | d | d | d | | |" +
                              "6| d | | | | | | c | | | |" +
                              "7| d | | | | | | c | o | | |" +
                              "8| | | | | | | c | | | |" +
                              "9| | | | | | | c | | | |";

        tablero.Should().Be(tableroEsperado);
    }

    [Fact]
    public void Si_InicioElJuegoConUnCanoneroEn8_8ParaJugador2_YJugador1DisparaA_8_8_Debe_ImprimirX()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Paula");
        acorazados.AddPlayer("Ruben");

        var canonero1 = new Nave(8, 8, 8, 8, "g");
        var canonero2 = new Nave(0, 0, 0, 0, "g");

        acorazados.Iniciar([], [canonero1,canonero2]);
        acorazados.Disparar(8, 8);
        acorazados.TerminarTurno();

        var tablero = acorazados.Imprimir();

        var tableroEsperado = "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| g | | | | | | | | | |" +
                              "1| | | | | | | | | | |" +
                              "2| | | | | | | | | | |" +
                              "3| | | | | | | | | | |" +
                              "4| | | | | | | | | | |" +
                              "5| | | | | | | | | | |" +
                              "6| | | | | | | | | | |" +
                              "7| | | | | | | | | | |" +
                              "8| | | | | | | | | X | |" +
                              "9| | | | | | | | | | |";

        tablero.Should().Be(tableroEsperado);
    }

    [Fact]
    public void Si_InicioElJuegoConUnCanoneroEn6_6ParaJugador2_YJugador1DisparaA_6_6_Debe_ImprimirX()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Paula");
        acorazados.AddPlayer("Ruben");

        var canonero1 = new Nave(6, 6, 6, 6, "g");
        var canonero2 = new Nave(0, 0, 0, 0, "g");

        acorazados.Iniciar([], [canonero1,canonero2]);
        acorazados.Disparar(6, 6);
        acorazados.TerminarTurno();

        var tablero = acorazados.Imprimir();

        var tableroEsperado = "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| g | | | | | | | | | |" +
                              "1| | | | | | | | | | |" +
                              "2| | | | | | | | | | |" +
                              "3| | | | | | | | | | |" +
                              "4| | | | | | | | | | |" +
                              "5| | | | | | | | | | |" +
                              "6| | | | | | | X | | | |" +
                              "7| | | | | | | | | | |" +
                              "8| | | | | | | | | | |" +
                              "9| | | | | | | | | | |";

        tablero.Should().Be(tableroEsperado);
    }

    [Fact]
    public void Si_InicioElJuegoConUnCanoneroEn5_6ParaJugador2_YJugador1DisparaA_6_6_Debe_ImprimirX()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Paula");
        acorazados.AddPlayer("Ruben");

        var canonero1 = new Nave(5, 6, 5, 6, "g");

        acorazados.Iniciar([], [canonero1]);
        acorazados.Disparar(6, 6);
        acorazados.TerminarTurno();

        var tablero = acorazados.Imprimir();

        var tableroEsperado = "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| | | | | | | | | | |" +
                              "1| | | | | | | | | | |" +
                              "2| | | | | | | | | | |" +
                              "3| | | | | | | | | | |" +
                              "4| | | | | | | | | | |" +
                              "5| | | | | | | g | | | |" +
                              "6| | | | | | | o | | | |" +
                              "7| | | | | | | | | | |" +
                              "8| | | | | | | | | | |" +
                              "9| | | | | | | | | | |";

        tablero.Should().Be(tableroEsperado);
    }

    [Fact]
    public void Si_InicioElJuegoConUnDestructorEn5_6ParaJugador2_YJugador1DisparaA_5_6_Debe_Imprimirx()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Paula");
        acorazados.AddPlayer("Ruben");

        var destructor = new Nave(5, 6, 5, 8, "d");

        acorazados.Iniciar([], [destructor]);
        acorazados.Disparar(5, 6);
        acorazados.TerminarTurno();

        var tablero = acorazados.Imprimir();

        var tableroEsperado = "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| | | | | | | | | | |" +
                              "1| | | | | | | | | | |" +
                              "2| | | | | | | | | | |" +
                              "3| | | | | | | | | | |" +
                              "4| | | | | | | | | | |" +
                              "5| | | | | | | x | d | d | |" +
                              "6| | | | | | | | | | |" +
                              "7| | | | | | | | | | |" +
                              "8| | | | | | | | | | |" +
                              "9| | | | | | | | | | |";

        tablero.Should().Be(tableroEsperado);
    }

    [Fact]
    public void Si_InicioElJuegoConUnPortavionesEn6_6ParaJugador2_YJugador1DisparaA_6_6_Debe_Imprimirx()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Paula");
        acorazados.AddPlayer("Ruben");

        var destructor = new Nave(6, 6, 6, 9, "c");

        acorazados.Iniciar([], [destructor]);
        acorazados.Disparar(6, 6);
        acorazados.TerminarTurno();

        var tablero = acorazados.Imprimir();

        var tableroEsperado = "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| | | | | | | | | | |" +
                              "1| | | | | | | | | | |" +
                              "2| | | | | | | | | | |" +
                              "3| | | | | | | | | | |" +
                              "4| | | | | | | | | | |" +
                              "5| | | | | | | | | | |" +
                              "6| | | | | | | x | c | c | c |" +
                              "7| | | | | | | | | | |" +
                              "8| | | | | | | | | | |" +
                              "9| | | | | | | | | | |";

        tablero.Should().Be(tableroEsperado);
    }

    [Fact]
    public void Si_InicioElJuegoSinBarcos_YJugador2Dispara_a_2_2_Debe_Imprimir_o_EnLasCoordenadasDadas()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Paula");
        acorazados.AddPlayer("Ruben");

        acorazados.Iniciar([], []);

        acorazados.Disparar(0, 0);
        acorazados.TerminarTurno();

        acorazados.Disparar(2, 2);
        acorazados.TerminarTurno();

        var tablero = acorazados.Imprimir();

        var tableroEsperado = "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| | | | | | | | | | |" +
                              "1| | | | | | | | | | |" +
                              "2| | | o | | | | | | | |" +
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
    public void
        Si_InicioElJuegoConUnDestructorEnCoordenada_5_6_a_5_7_ParaJugador2_YJugador1_Debe_DispararHastaHundirDestructorDeJugador2()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Paula");
        acorazados.AddPlayer("Ruben");

        var destructor1 = new Nave(5, 5, 5, 7, "d");
        var canonero1 = new Nave(0, 0, 0, 0, "g");

        acorazados.Iniciar([], [destructor1,canonero1]);

        acorazados.Disparar(5, 5);
        acorazados.TerminarTurno();

        acorazados.Disparar(0, 0);
        acorazados.TerminarTurno();

        acorazados.Disparar(5, 6);
        acorazados.TerminarTurno();

        acorazados.Disparar(1, 1);
        acorazados.TerminarTurno();

        acorazados.Disparar(5, 7);
        acorazados.TerminarTurno();

        var tablero = acorazados.Imprimir();

        var tableroEsperado = "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| g | | | | | | | | | |" +
                              "1| | | | | | | | | | |" +
                              "2| | | | | | | | | | |" +
                              "3| | | | | | | | | | |" +
                              "4| | | | | | | | | | |" +
                              "5| | | | | | X | X | X | | |" +
                              "6| | | | | | | | | | |" +
                              "7| | | | | | | | | | |" +
                              "8| | | | | | | | | | |" +
                              "9| | | | | | | | | | |";

        tablero.Should().Be(tableroEsperado);
    }

    [Fact]
    public void
        Si_InicioElJuegoConUnDestructorEnCoordenada_4_6_a_4_8_ParaJugador2_YJugador1_Debe_DispararHastaHundirDestructorDeJugador2()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Paula");
        acorazados.AddPlayer("Ruben");

        var destructor1 = new Nave(4, 6, 4, 8, "d");
        var canonero1 = new Nave(0, 0, 0, 0, "g");

        acorazados.Iniciar([], [destructor1,canonero1]);

        acorazados.Disparar(4, 6);
        acorazados.TerminarTurno();

        acorazados.Disparar(0, 0);
        acorazados.TerminarTurno();

        acorazados.Disparar(4, 7);
        acorazados.TerminarTurno();

        acorazados.Disparar(1, 1);
        acorazados.TerminarTurno();

        acorazados.Disparar(4, 8);
        acorazados.TerminarTurno();

        var tablero = acorazados.Imprimir();

        var tableroEsperado = "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| g | | | | | | | | | |" +
                              "1| | | | | | | | | | |" +
                              "2| | | | | | | | | | |" +
                              "3| | | | | | | | | | |" +
                              "4| | | | | | | X | X | X | |" +
                              "5| | | | | | | | | | |" +
                              "6| | | | | | | | | | |" +
                              "7| | | | | | | | | | |" +
                              "8| | | | | | | | | | |" +
                              "9| | | | | | | | | | |";

        tablero.Should().Be(tableroEsperado);
    }

    [Fact]
    public void
        Si_InicioElJuegoConUnDestructorEnCoordenada_2_3_a_2_5_ParaJugador2_YJugador1_Debe_DispararHastaHundirDestructorDeJugador2()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Paula");
        acorazados.AddPlayer("Ruben");

        var destructor1 = new Nave(2, 3, 2, 5, "d");
        var canonero1 = new Nave(0, 0, 0, 0, "g");

        acorazados.Iniciar([], [destructor1,canonero1]);

        acorazados.Disparar(2, 3);
        acorazados.TerminarTurno();

        acorazados.Disparar(0, 0);
        acorazados.TerminarTurno();

        acorazados.Disparar(2, 4);
        acorazados.TerminarTurno();

        acorazados.Disparar(1, 1);
        acorazados.TerminarTurno();

        acorazados.Disparar(2, 5);
        acorazados.TerminarTurno();

        var tablero = acorazados.Imprimir();

        var tableroEsperado = "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| g | | | | | | | | | |" +
                              "1| | | | | | | | | | |" +
                              "2| | | | X | X | X | | | | |" +
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
    public void Si_InicioElJuegoConUnDestructorEn5_6ParaJugador1_YJugador2DisparaA_5_6_Debe_Imprimir_x()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Paula");
        acorazados.AddPlayer("Ruben");

        var destructor = new Nave(5, 6, 5, 8, "d");

        acorazados.Iniciar([destructor], []);
        acorazados.Disparar(0, 0);
        acorazados.TerminarTurno();

        acorazados.Disparar(5, 6);
        acorazados.TerminarTurno();

        var tablero = acorazados.Imprimir();

        var tableroEsperado = "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| | | | | | | | | | |" +
                              "1| | | | | | | | | | |" +
                              "2| | | | | | | | | | |" +
                              "3| | | | | | | | | | |" +
                              "4| | | | | | | | | | |" +
                              "5| | | | | | | x | d | d | |" +
                              "6| | | | | | | | | | |" +
                              "7| | | | | | | | | | |" +
                              "8| | | | | | | | | | |" +
                              "9| | | | | | | | | | |";

        tablero.Should().Be(tableroEsperado);
    }

    [Fact]
    public void
        Si_InicioElJuegoConUnDestructorEnCoordenada_2_3_a_2_5_ParaJugador1_YJugador2_Debe_DispararHastaHundirDestructorDeJugador1()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Paula");
        acorazados.AddPlayer("Ruben");

        var destructor1 = new Nave(2, 3, 2, 5, "d");
        var canonero1 = new Nave(0, 0, 0, 0, "g");

        acorazados.Iniciar([destructor1,canonero1], []);

        acorazados.Disparar(0, 0);
        acorazados.TerminarTurno();

        acorazados.Disparar(2, 3);
        acorazados.TerminarTurno();

        acorazados.Disparar(1, 1);
        acorazados.TerminarTurno();

        acorazados.Disparar(2, 4);
        acorazados.TerminarTurno();

        acorazados.Disparar(2, 2);
        acorazados.TerminarTurno();

        acorazados.Disparar(2, 5);
        acorazados.TerminarTurno();

        var tablero = acorazados.Imprimir();

        var tableroEsperado = "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| g | | | | | | | | | |" +
                              "1| | | | | | | | | | |" +
                              "2| | | | X | X | X | | | | |" +
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
    public void Si_InicioElJuegoConUnDestructorEnCoordenada_2_3_a_2_5_ParaJugador1_YJugador2_Debe_DispararHastaHundirDestructorDeJugador1_ImprimirMensajeDeNaveHundida()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Paula");
        acorazados.AddPlayer("Ruben");

        var destructor1 = new Nave(2, 3, 2, 5, "d");

        acorazados.Iniciar([destructor1], []);
        
        acorazados.Disparar(0, 0);
        acorazados.TerminarTurno();

        acorazados.Disparar(2, 3);
        acorazados.TerminarTurno();

        acorazados.Disparar(1, 1);
        acorazados.TerminarTurno();

        acorazados.Disparar(2, 4);
        acorazados.TerminarTurno();
        
        acorazados.Disparar(2, 2);
        acorazados.TerminarTurno();

        var mensajeEsperado = acorazados.Disparar(2, 5);

        mensajeEsperado.Should().Be("Barco hundido");
    }
    
    [Fact]
    public void
        Si_InicioElJuegoConUnCanoneroParaJugador2_YJugador1DisparaA_9_9_Jugador1_Gana_Debe_ImprimirReporte()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Alejandra");
        acorazados.AddPlayer("Paula");

        var canonero = new Nave(9, 9, 9, 9, "g");

        acorazados.Iniciar([], [canonero]);
        acorazados.Disparar(9, 9);

        var tablero = acorazados.Imprimir();

        var reporte = 
            """
            [ Alejandra
                Total shots: 1
                Misses: 0
                Hits: 1
                Ships Sunk: [
                    Gunship: (9,9)
                ]
            """;

        var tableroEsperado = reporte + 
                              "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| | | | | | | | | | |" +
                              "1| | | | | | | | | | |" +
                              "2| | | | | | | | | | |" +
                              "3| | | | | | | | | | |" +
                              "4| | | | | | | | | | |" +
                              "5| | | | | | | | | | |" +
                              "6| | | | | | | | | | |" +
                              "7| | | | | | | | | | |" +
                              "8| | | | | | | | | | |" +
                              "9| | | | | | | | | | X |";

        tablero.Should().Be(tableroEsperado);
    }
    
    [Fact]
    public void
        Si_InicioElJuegoConDosCanonerosParaJugador2_YJugador1LosHunde_Jugador1_Gana_Debe_ImprimirReporte()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Alejandra");
        acorazados.AddPlayer("Paula");

        var canonero = new Nave(9, 9, 9, 9, "g");
        var canonero2 = new Nave(8, 8, 8, 8, "g");

        acorazados.Iniciar([], [canonero, canonero2]);
        acorazados.Disparar(9, 9);
        acorazados.TerminarTurno();
        
        acorazados.Disparar(1, 1);
        acorazados.TerminarTurno();
        
        acorazados.Disparar(8,8);

        var tablero = acorazados.Imprimir();

        var reporte = 
            """
            [ Alejandra
                Total shots: 2
                Misses: 0
                Hits: 2
                Ships Sunk: [
                    Gunship: (9,9)
                    Gunship: (8,8)
                ]
            """;
        
        var tableroEsperado = reporte + 
                              "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| | | | | | | | | | |" +
                              "1| | | | | | | | | | |" +
                              "2| | | | | | | | | | |" +
                              "3| | | | | | | | | | |" +
                              "4| | | | | | | | | | |" +
                              "5| | | | | | | | | | |" +
                              "6| | | | | | | | | | |" +
                              "7| | | | | | | | | | |" +
                              "8| | | | | | | | | X | |" +
                              "9| | | | | | | | | | X |";

        tablero.Should().Be(tableroEsperado);
    }
    
    [Fact]
    public void
        Si_InicioElJuegoConUnCanoneroParaJugador1_YJugador2LoHunde_Jugador2_Gana_Debe_ImprimirReporte()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Alejandra");
        acorazados.AddPlayer("Paula");

        var canonero = new Nave(9, 9, 9, 9, "g");

        acorazados.Iniciar([canonero], []);
        acorazados.Disparar(1, 1);
        acorazados.TerminarTurno();
        
        acorazados.Disparar(9, 9);

        var tablero = acorazados.Imprimir();

        var reporte = 
            """
            [ Paula
                Total shots: 1
                Misses: 0
                Hits: 1
                Ships Sunk: [
                    Gunship: (9,9)
                ]
            """;
        
        var tableroEsperado = reporte + 
                              "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |" +
                              "0| | | | | | | | | | |" +
                              "1| | | | | | | | | | |" +
                              "2| | | | | | | | | | |" +
                              "3| | | | | | | | | | |" +
                              "4| | | | | | | | | | |" +
                              "5| | | | | | | | | | |" +
                              "6| | | | | | | | | | |" +
                              "7| | | | | | | | | | |" +
                              "8| | | | | | | | | | |" +
                              "9| | | | | | | | | | X |";

        tablero.Should().Be(tableroEsperado);
    }
    
    [Fact]
    public void
        Si_InicioElJuegoConUnCanoneroParaJugador1_YJugador2LoHunde_Jugador2_Gana_Y_TerminoTurno_Debe_LanzarExcepcion()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Alejandra");
        acorazados.AddPlayer("Paula");

        var canonero = new Nave(9, 9, 9, 9, "g");

        acorazados.Iniciar([canonero], []);
        acorazados.Disparar(1, 1);
        acorazados.TerminarTurno();
        
        acorazados.Disparar(9, 9);

        var act = () => acorazados.TerminarTurno();
        
        act.Should().Throw<ApplicationException>();
    }
    
    [Fact]
    public void
        Si_InicioElJuegoConUnCanoneroParaJugador1_YJugador2LoHunde_Jugador2_Gana_E_IntentoDisparar_Debe_LanzarExcepcion()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Alejandra");
        acorazados.AddPlayer("Paula");

        var canonero = new Nave(9, 9, 9, 9, "g");

        acorazados.Iniciar([canonero], []);
        acorazados.Disparar(1, 1);
        acorazados.TerminarTurno();
        
        acorazados.Disparar(9, 9);

        var act = () => acorazados.Disparar(7, 9);
        
        act.Should().Throw<ApplicationException>();
    }
    
    [Fact]
    public void
        Si_NoInicioElJuego_E_IntentoDisparar_Debe_LanzarExcepcion()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Alejandra");
        acorazados.AddPlayer("Paula");

        var act = () => acorazados.Disparar(7, 9);
        
        act.Should().Throw<ApplicationException>();
    }
    
    [Fact]
    public void
        Si_NoInicioElJuego_E_IntentoImprimir_Debe_LanzarExcepcion()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Alejandra");
        acorazados.AddPlayer("Paula");

        var act = () => acorazados.Imprimir();
        
        act.Should().Throw<ApplicationException>();
    }
    
    [Fact]
    public void Si_NoInicioElJuego_E_IntentoTerminaTurno_Debe_LanzarExcepcion()
    {
        var acorazados = new Battleship();
        acorazados.AddPlayer("Alejandra");
        acorazados.AddPlayer("Paula");

        var act = () => acorazados.TerminarTurno();
        
        act.Should().Throw<ApplicationException>("No puede terminar turno cuando el juego no ha comenzado");
    }
    
    [Fact]
    public void Si_IntentoAgregaTresJugadores_Debe_LanzarExcepcion()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Alejandra");
        acorazados.AddPlayer("Paula");

        var act = () => acorazados.AddPlayer("Ruben");
        
        act.Should().Throw<ApplicationException>("No se pueden agregar mas de dos jugadores");
    }
    
    [Fact]
    public void Si_IntentoIniciarElJuegoSinJugadores_Debe_LanzarExcepcion()
    {
        var acorazados = new Battleship();
        
        var act = () => acorazados.Iniciar([], []);
        
        act.Should().Throw<ApplicationException>("El juego requiere de dos jugadores para iniciar");
    }
    
    
    [Theory]
    [InlineData(5,10)]
    [InlineData(10,5)]
    [InlineData(-1,5)]
    [InlineData(5,-1)]
    public void Si_IntentoDispararFueraDelTablero_Debe_LanzarExcepcion(int fila, int columna)
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Alejandra");
        acorazados.AddPlayer("Paula");
        acorazados.Iniciar([], []);

        var act = () => acorazados.Disparar(fila, columna);
        
        act.Should().Throw<ApplicationException>("Las coordenadas dadas para el disparo estan fuera del limite del tablero");
    }
    
    [Fact]
    public void Si_IntentoDispararDosVecesEnLaMismaCoordenada_Debe_LanzarExcepcion()
    {
        var acorazados = new Battleship();

        acorazados.AddPlayer("Alejandra");
        acorazados.AddPlayer("Paula");
        acorazados.Iniciar([], []);

        acorazados.Disparar(5, 5);
        acorazados.TerminarTurno();
        
        acorazados.Disparar(3, 3);
        acorazados.TerminarTurno();

        var act = () => acorazados.Disparar(5, 5);
        
        act.Should().Throw<ApplicationException>("Ya disparaste en esa misma coordenada. Usa otra por favor.");
    }
    [Fact]
    public void Si_IntentoIniciarYCrearUnaNaveCanoneroFueraDelTablero_Debe_LanzarExcepcion()
    {
        var acorazados = new Battleship();
        acorazados.AddPlayer("Alejandra");
        acorazados.AddPlayer("Paula");
        var canonero = new Nave(11, 11, 11, 11, "g");
        
        var act = () => acorazados.Iniciar([canonero], []);
        
        act.Should().Throw<ApplicationException>("Las coordenadas dadas para pintar la nave estan fuera del limite del tablero");
        
    }
    
    [Fact]
    public void Si_InicioEIntentoCrearUnDestructorFueraDelTablero_Debe_LanzarExcepcion()
    {
        var acorazados = new Battleship();
        acorazados.AddPlayer("Alejandra");
        acorazados.AddPlayer("Paula");
        var destructor = new Nave(2, 8, 2, 11, "d");
        
        var act = () => acorazados.Iniciar([destructor], []);
        
        act.Should().Throw<ApplicationException>("Las coordenadas dadas para pintar la nave estan fuera del limite del tablero");
        
    }
    
    [Fact]
    public void Si_InicioEIntentoCrearUnNaveYEstaenlasMismasCoordenadas_Debe_LanzarExcepcion()
    {
        var acorazados = new Battleship();
        acorazados.AddPlayer("Alejandra");
        acorazados.AddPlayer("Paula");
        
        var canonero = new Nave(9, 9, 9, 9, "g");
        var canonero2 = new Nave(9, 9, 9, 9, "g");
        
        var act = () => acorazados.Iniciar([canonero,canonero2], []);
        
        act.Should().Throw<ApplicationException>("Ya existe una nave en las coordenadas indicadas.");
        
    }
    
    [Fact]
    public void Si_InicioEIntentoCrearNavesDiferentesA_G_C_D_Debe_LanzarExcepcion()
    {
        var acorazados = new Battleship();
        acorazados.AddPlayer("Alejandra");
        acorazados.AddPlayer("Paula");
        
        var canonero = new Nave(9, 9, 9, 9, "h");
        
        var act = () => acorazados.Iniciar([canonero], []);
        
        act.Should().Throw<ApplicationException>("El tipo de nave indicada no es valida.");
        
    }
}
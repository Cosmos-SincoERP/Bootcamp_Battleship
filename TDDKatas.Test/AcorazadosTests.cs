using AwesomeAssertions;

namespace TDDKatas;

public class AcorazadosTests
{
    [Fact]
    public void Si_InicioElJuegoEImprimo_Debe_MostrarTableroVacio()
    {
        var acorazado = new Acorazado();
        var imprimir = acorazado.Imprimir();

        imprimir.Should().Be("    0   1   2   3   4   5   6   7   8   9\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "0 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "1 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "2 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "3 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "4 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "5 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "6 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "7 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "8 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "9 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+");
    }

    [Fact]
    public void Si_InicioElJuegoYUbicoCañoneroEnPosicion0_0Imprimir_Debe_RetornarElTableroConGEnPosicion0_0()
    {
        var acorazado = new Acorazado();
        acorazado.AgregarJugador("Player 1");
        acorazado.PosicionarNave(0, 0, TiposNave.Canionero, Orientacion.Derecha);

        var imprimir = acorazado.Imprimir();

        imprimir.Should().Be("    0   1   2   3   4   5   6   7   8   9\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "0 | g |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "1 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "2 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "3 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "4 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "5 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "6 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "7 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "8 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "9 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+");
    }

    [Fact]
    public void Si_InicioElJuegoYUbicoCañoneroEnPosicion1_1Imprimir_Debe_RetornarElTableroConGEnPosicion1_1()
    {
        var acorazado = new Acorazado();
        acorazado.AgregarJugador("Player 1");
        acorazado.PosicionarNave(1, 1, TiposNave.Canionero, Orientacion.Derecha);

        var imprimir = acorazado.Imprimir();

        imprimir.Should().Be("    0   1   2   3   4   5   6   7   8   9\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "0 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "1 |   | g |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "2 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "3 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "4 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "5 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "6 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "7 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "8 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "9 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+");
    }

    [Fact]
    public void Si_InicioElJuegoYUbicoDestructorEnPosicion0_0Imprimir_Debe_RetornarElTableroConDPosicionadoEn0_0()
    {
        var acorazado = new Acorazado();
        acorazado.AgregarJugador("Player 1");
        acorazado.PosicionarNave(0, 0, TiposNave.Destructor, Orientacion.Derecha);

        var imprimir = acorazado.Imprimir();

        imprimir.Should().Be("    0   1   2   3   4   5   6   7   8   9\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "0 | d | d | d |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "1 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "2 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "3 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "4 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "5 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "6 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "7 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "8 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "9 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+");
    }

    [Fact]
    public void Si_InicioElJuegoYUbicoPortaAvionesEnPosicion0_0Imprimir_Debe_RetornarElTableroConCPosicionadoEn0_0()
    {
        var acorazado = new Acorazado();
        acorazado.AgregarJugador("Player 1");
        acorazado.PosicionarNave(0, 0, TiposNave.PortaAviones, Orientacion.Derecha);

        var imprimir = acorazado.Imprimir();

        imprimir.Should().Be("    0   1   2   3   4   5   6   7   8   9\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "0 | c | c | c | c |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "1 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "2 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "3 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "4 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "5 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "6 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "7 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "8 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "9 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+");
    }


    [Fact]
    public void
        Si_InicioElJuegoYUbicoDestructorEnPosicion1_3OrientacionIzquierdaImprimir_Debe_RetornarElTableroConDPosicionadoEn1_3OrientadoALaIzquierda()
    {
        var acorazado = new Acorazado();
        acorazado.AgregarJugador("Player 1");
        acorazado.PosicionarNave(1, 3, TiposNave.Destructor, Orientacion.Izquierda);

        var imprimir = acorazado.Imprimir();

        imprimir.Should().Be("    0   1   2   3   4   5   6   7   8   9\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "0 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "1 |   | d | d | d |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "2 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "3 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "4 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "5 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "6 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "7 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "8 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "9 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+");
    }

    [Fact]
    public void
        Si_InicioElJuegoYUbicoDestructorEnPosicion2_3OrientacionArribaImprimir_Debe_RetornarElTableroConDPosicionadoEn2_3OrientadoHaciaArriba()
    {
        var acorazado = new Acorazado();
        acorazado.AgregarJugador("Player 1");
        acorazado.PosicionarNave(2, 3, TiposNave.Destructor, Orientacion.Arriba);

        var imprimir = acorazado.Imprimir();

        imprimir.Should().Be("    0   1   2   3   4   5   6   7   8   9\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "0 |   |   |   | d |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "1 |   |   |   | d |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "2 |   |   |   | d |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "3 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "4 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "5 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "6 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "7 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "8 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "9 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+");
    }

    [Fact]
    public void
        Si_InicioElJuegoYUbicoDestructorEnPosicion2_3OrientacionAbajoImprimir_Debe_RetornarElTableroConDPosicionadoEn2_3OrientadoHaciaAbajo()
    {
        var acorazado = new Acorazado();
        acorazado.AgregarJugador("Player 1");
        acorazado.PosicionarNave(2, 3, TiposNave.Destructor, Orientacion.Abajo);

        var imprimir = acorazado.Imprimir();

        imprimir.Should().Be("    0   1   2   3   4   5   6   7   8   9\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "0 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "1 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "2 |   |   |   | d |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "3 |   |   |   | d |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "4 |   |   |   | d |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "5 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "6 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "7 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "8 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "9 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+");
    }

    [Fact]
    public void
        Si_InicioElJuegoYUbicoPortaAvionesEnPosicion2_3OrientacionIzquierdaImprimir_Debe_RetornarElTableroConCPosicionadoEn2_3OrientadoHaciaLaIzquierda()
    {
        var acorazado = new Acorazado();
        acorazado.AgregarJugador("Player 1");
        acorazado.PosicionarNave(2, 3, TiposNave.PortaAviones, Orientacion.Izquierda);

        var imprimir = acorazado.Imprimir();

        imprimir.Should().Be("    0   1   2   3   4   5   6   7   8   9\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "0 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "1 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "2 | c | c | c | c |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "3 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "4 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "5 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "6 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "7 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "8 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "9 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+");
    }

    [Fact]
    public void
        Si_InicioElJuegoYUbicoPortaAvionesEnPosicion3_3OrientacionArribaImprimir_Debe_RetornarElTableroConCPosicionadoEn3_3OrientadoHaciaArriba()
    {
        var acorazado = new Acorazado();
        acorazado.AgregarJugador("Player 1");
        acorazado.PosicionarNave(3, 3, TiposNave.PortaAviones, Orientacion.Arriba);

        var imprimir = acorazado.Imprimir();

        imprimir.Should().Be("    0   1   2   3   4   5   6   7   8   9\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "0 |   |   |   | c |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "1 |   |   |   | c |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "2 |   |   |   | c |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "3 |   |   |   | c |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "4 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "5 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "6 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "7 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "8 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "9 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+");
    }

    [Fact]
    public void
        Si_InicioElJuegoYUbicoPortaAvionesEnPosicion3_3OrientacionAbajoImprimir_Debe_RetornarElTableroConCPosicionadoEn3_3OrientadoHaciaAbajo()
    {
        var acorazado = new Acorazado();
        acorazado.AgregarJugador("Player 1");
        acorazado.PosicionarNave(3, 3, TiposNave.PortaAviones, Orientacion.Abajo);

        var imprimir = acorazado.Imprimir();

        imprimir.Should().Be("    0   1   2   3   4   5   6   7   8   9\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "0 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "1 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "2 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "3 |   |   |   | c |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "4 |   |   |   | c |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "5 |   |   |   | c |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "6 |   |   |   | c |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "7 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "8 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "9 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+");
    }

    [Fact]
    public void Si_InicioLaPartidaSinJuadores_Debe_RetornarExcepcion()
    {
        var acorazado = new Acorazado();


        var resultado = () => acorazado.Iniciar();

        resultado.Should().ThrowExactly<InvalidOperationException>()
            .WithMessage("*Deben haber minimo 2 jugadores para iniciar la partida");
    }

    [Fact]
    public void Si_InicioLaPartidaYAgrego2Jugadores_Debe_LanzarExcepcion()
    {
        var acorazado = new Acorazado();
        acorazado.AgregarJugador("Player 1");
        acorazado.AgregarJugador("Player 2");

        var resultado = () => acorazado.Iniciar();

        resultado.Should().ThrowExactly<InvalidOperationException>().WithMessage("*Jugador 1 no ha posicionado naves");
    }

    [Fact]
    public void Si_InicioJuegoAgrego1JugadorYPosiciono5Cañoneros_Debe_LanzarExcepcion()
    {
        var acorazado = new Acorazado();
        acorazado.AgregarJugador("Player 1");
        acorazado.PosicionarNave(0, 0, TiposNave.Canionero, Orientacion.Abajo);
        acorazado.PosicionarNave(0, 1, TiposNave.Canionero, Orientacion.Abajo);
        acorazado.PosicionarNave(0, 2, TiposNave.Canionero, Orientacion.Abajo);
        acorazado.PosicionarNave(0, 3, TiposNave.Canionero, Orientacion.Abajo);
        
        var resultado = () => acorazado.PosicionarNave(0, 4, TiposNave.Canionero, Orientacion.Abajo);
        
        resultado.Should().ThrowExactly<InvalidOperationException>()
            .WithMessage("*No es posible agregar mas de 4 cañoreros");
    }

    [Fact]
    public void Si_InicioJuegoAgrego1JugadorYPosiciono3Destructores_Debe_LanzarExcepcion()
    {
        var acorazado = new Acorazado();
        acorazado.AgregarJugador("Player 1");
        acorazado.PosicionarNave(0, 0, TiposNave.Destructor, Orientacion.Derecha);
        acorazado.PosicionarNave(1, 0, TiposNave.Destructor, Orientacion.Derecha);

        var resultado = () => acorazado.PosicionarNave(2, 0, TiposNave.Destructor, Orientacion.Derecha);
        
        resultado.Should().ThrowExactly<InvalidOperationException>()
            .WithMessage("*No es posible agregar mas de 2 destructores");
    }
    
    [Fact]
    public void Si_InicioJuegoAgrego1JugadorYPosiciono2PortaAviones_Debe_LanzarExcepcion()
    {
        var acorazado = new Acorazado();
        acorazado.AgregarJugador("Player 1");
        acorazado.PosicionarNave(0, 0, TiposNave.PortaAviones, Orientacion.Derecha);

        var resultado = () => acorazado.PosicionarNave(1, 0, TiposNave.PortaAviones, Orientacion.Derecha);
        
        resultado.Should().ThrowExactly<InvalidOperationException>()
            .WithMessage("*No es posible agregar mas de 1 portaavion");
    }

    [Fact]
    public void Si_Agrego1JugadorYPosiciono1Portaaviones1CanoneroImprimir_Debe_RetornarElTableroConCanoneroYPortaavionesPosicionado()
    {
        var acorazado = new Acorazado();
        acorazado.AgregarJugador("Player 1");
        acorazado.PosicionarNave(0, 0, TiposNave.PortaAviones, Orientacion.Derecha);
        acorazado.PosicionarNave(1, 0, TiposNave.Canionero, Orientacion.Derecha);
        
        var imprimir = acorazado.Imprimir();

        imprimir.Should().Be("    0   1   2   3   4   5   6   7   8   9\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "0 | c | c | c | c |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "1 | g |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "2 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "3 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "4 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "5 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "6 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "7 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "8 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "9 |   |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+");
        
        
    }
    
}
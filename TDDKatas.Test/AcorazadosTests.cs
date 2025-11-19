using AwesomeAssertions;

namespace TDDKatas;

public class AcorazadosTests
{
    [Fact]
    public void Si_InicioElJuegoYAgregoUnJugadorEImprimo_Debe_MostrarTableroVacio()
    {
        var acorazado = new Acorazado();
        acorazado.AgregarJugador("Player 1");
        
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
    public void Si_InicioElJuegoAgregoJugadorYUbicoCañoneroEnPosicion0_0Imprimir_Debe_RetornarElTableroConGEnPosicion0_0()
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
    public void Si_InicioElJuegoAgregoJugadorYUbicoCañoneroEnPosicion1_1Imprimir_Debe_RetornarElTableroConGEnPosicion1_1()
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
    public void Si_InicioElJuegoAgregoJugadorYUbicoDestructorEnPosicion0_0Imprimir_Debe_RetornarElTableroConDPosicionadoEn0_0()
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
    public void Si_InicioElJuegoAgregoJugadorYUbicoPortaAvionesEnPosicion0_0Imprimir_Debe_RetornarElTableroConCPosicionadoEn0_0()
    {
        var acorazado = new Acorazado();
        acorazado.AgregarJugador("Player 1");
        acorazado.PosicionarNave(0, 0, TiposNave.Portaviones, Orientacion.Derecha);

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
        Si_InicioElJuegoAgregoJugadorYUbicoDestructorEnPosicion1_3OrientacionIzquierdaImprimir_Debe_RetornarElTableroConDPosicionadoEn1_3OrientadoALaIzquierda()
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
        Si_InicioElJuegoAgregoJugadorYUbicoDestructorEnPosicion2_3OrientacionArribaImprimir_Debe_RetornarElTableroConDPosicionadoEn2_3OrientadoHaciaArriba()
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
        Si_InicioElJuegoAgregoJugadorYUbicoDestructorEnPosicion2_3OrientacionAbajoImprimir_Debe_RetornarElTableroConDPosicionadoEn2_3OrientadoHaciaAbajo()
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
        Si_InicioElJuegoAgregoJugadorYUbicoPortaAvionesEnPosicion2_3OrientacionIzquierdaImprimir_Debe_RetornarElTableroConCPosicionadoEn2_3OrientadoHaciaLaIzquierda()
    {
        var acorazado = new Acorazado();
        acorazado.AgregarJugador("Player 1");
        acorazado.PosicionarNave(2, 3, TiposNave.Portaviones, Orientacion.Izquierda);

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
        Si_InicioElJuegoAgregoJugadorYUbicoPortaAvionesEnPosicion3_3OrientacionArribaImprimir_Debe_RetornarElTableroConCPosicionadoEn3_3OrientadoHaciaArriba()
    {
        var acorazado = new Acorazado();
        acorazado.AgregarJugador("Player 1");
        acorazado.PosicionarNave(3, 3, TiposNave.Portaviones, Orientacion.Arriba);

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
        Si_InicioElJuegoAgregoJugadorYUbicoPortaAvionesEnPosicion3_3OrientacionAbajoImprimir_Debe_RetornarElTableroConCPosicionadoEn3_3OrientadoHaciaAbajo()
    {
        var acorazado = new Acorazado();
        acorazado.AgregarJugador("Player 1");
        acorazado.PosicionarNave(3, 3, TiposNave.Portaviones, Orientacion.Abajo);

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
            .WithMessage("*No es posible agregar mas de 4 nave(s) de tipo Cañonero");
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
            .WithMessage("*No es posible agregar mas de 2 nave(s) de tipo Destructor");
    }

    [Fact]
    public void Si_InicioJuegoAgrego1JugadorYPosiciono2PortaAviones_Debe_LanzarExcepcion()
    {
        var acorazado = new Acorazado();
        acorazado.AgregarJugador("Player 1");
        acorazado.PosicionarNave(0, 0, TiposNave.Portaviones, Orientacion.Derecha);

        var resultado = () => acorazado.PosicionarNave(1, 0, TiposNave.Portaviones, Orientacion.Derecha);

        resultado.Should().ThrowExactly<InvalidOperationException>()
            .WithMessage("No es posible agregar mas de 1 nave(s) de tipo Portaviones");
    }

    [Fact]
    public void
        Si_Agrego1JugadorYPosiciono1Portaaviones1CanoneroImprimir_Debe_RetornarElTableroConCanoneroYPortaavionesPosicionado()
    {
        var acorazado = new Acorazado();
        acorazado.AgregarJugador("Player 1");
        acorazado.PosicionarNave(0, 0, TiposNave.Portaviones, Orientacion.Derecha);
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

    [Fact]
    public void Si_Agrego1JugadorYPosiciono1Destructor1CanoneroImprimir_Debe_RetornarElTableroConCanoneroYDestructor()
    {
        var acorazado = new Acorazado();
        acorazado.AgregarJugador("Player 1");

        acorazado.PosicionarNave(1, 0, TiposNave.Destructor, Orientacion.Derecha);
        acorazado.PosicionarNave(2, 0, TiposNave.Destructor, Orientacion.Derecha);
        acorazado.PosicionarNave(0, 0, TiposNave.Canionero, Orientacion.Derecha);

        var imprimir = acorazado.Imprimir();

        imprimir.Should().Be("    0   1   2   3   4   5   6   7   8   9\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "0 | g |   |   |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "1 | d | d | d |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "2 | d | d | d |   |   |   |   |   |   |   |\n" +
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
        Si_Agrego1JugadorYPosiciono1PortaAvion4DestructorImprimir_Debe_RetornarElTableroConCanoneroYPortaAviones()
    {
        var acorazado = new Acorazado();
        acorazado.AgregarJugador("Player 1");

        acorazado.PosicionarNave(0, 0, TiposNave.Canionero, Orientacion.Derecha);
        acorazado.PosicionarNave(0, 1, TiposNave.Canionero, Orientacion.Derecha);
        acorazado.PosicionarNave(0, 2, TiposNave.Canionero, Orientacion.Derecha);
        acorazado.PosicionarNave(0, 3, TiposNave.Canionero, Orientacion.Derecha);
        acorazado.PosicionarNave(1, 0, TiposNave.Portaviones, Orientacion.Derecha);

        var imprimir = acorazado.Imprimir();

        imprimir.Should().Be("    0   1   2   3   4   5   6   7   8   9\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "0 | g | g | g | g |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "1 | c | c | c | c |   |   |   |   |   |   |\n" +
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
    public void Si_AgregoUnJugadorYLaEstrategiaNoEstaCompleta_Debe_LanzarExcepcion()
    {
        var acorazado = new Acorazado();
        acorazado.AgregarJugador("Player 1");
        acorazado.PosicionarNave(0, 0, TiposNave.Canionero, Orientacion.Derecha);


        var resultado = () => acorazado.AgregarJugador("Player 2");

        resultado.Should().ThrowExactly<InvalidOperationException>()
            .WithMessage("*Jugador anterior no ha completado la estrategia");
    }

    [Fact]
    public void Si_InicioLaPartidaYAgrego2JugadoresYSegundoJugadorNoHaCompletadoEstrategia_Debe_LanzarExcepcion()
    {
        var acorazado = new Acorazado();
        acorazado.AgregarJugador("Player 1");
        acorazado.PosicionarNave(0, 0, TiposNave.Canionero, Orientacion.Derecha);
        acorazado.PosicionarNave(0, 1, TiposNave.Canionero, Orientacion.Derecha);
        acorazado.PosicionarNave(0, 2, TiposNave.Canionero, Orientacion.Derecha);
        acorazado.PosicionarNave(0, 3, TiposNave.Canionero, Orientacion.Derecha);
        acorazado.PosicionarNave(1, 0, TiposNave.Portaviones, Orientacion.Derecha);
        acorazado.PosicionarNave(2, 0, TiposNave.Destructor, Orientacion.Derecha);
        acorazado.PosicionarNave(3, 0, TiposNave.Destructor, Orientacion.Derecha);
        acorazado.AgregarJugador("Player 2");

        var resultado = () => acorazado.Iniciar();

        resultado.Should().ThrowExactly<InvalidOperationException>()
            .WithMessage("*Jugador anterior no ha completado la estrategia");
    }
    
    [Fact]
    public void Si_InicioLaPartidaYAgrego2JugadoresConSusEstrategiasCompletas_Debe_IniciarElTurnoDelJugadorUno()
    {
        var acorazado = new Acorazado();
        acorazado.AgregarJugador("Player 1");
        acorazado.PosicionarNave(0, 0, TiposNave.Canionero, Orientacion.Derecha);
        acorazado.PosicionarNave(0, 1, TiposNave.Canionero, Orientacion.Derecha);
        acorazado.PosicionarNave(0, 2, TiposNave.Canionero, Orientacion.Derecha);
        acorazado.PosicionarNave(0, 3, TiposNave.Canionero, Orientacion.Derecha);
        acorazado.PosicionarNave(1, 0, TiposNave.Portaviones, Orientacion.Derecha);
        acorazado.PosicionarNave(2, 0, TiposNave.Destructor, Orientacion.Derecha);
        acorazado.PosicionarNave(3, 0, TiposNave.Destructor, Orientacion.Derecha);
        acorazado.AgregarJugador("Player 2");
        acorazado.PosicionarNave(0, 0, TiposNave.Canionero, Orientacion.Derecha);
        acorazado.PosicionarNave(0, 1, TiposNave.Canionero, Orientacion.Derecha);
        acorazado.PosicionarNave(0, 2, TiposNave.Canionero, Orientacion.Derecha);
        acorazado.PosicionarNave(0, 3, TiposNave.Canionero, Orientacion.Derecha);
        acorazado.PosicionarNave(1, 0, TiposNave.Portaviones, Orientacion.Derecha);
        acorazado.PosicionarNave(2, 0, TiposNave.Destructor, Orientacion.Derecha);
        acorazado.PosicionarNave(3, 0, TiposNave.Destructor, Orientacion.Derecha);
        
        var resultado = acorazado.Iniciar();
        
        resultado.Should().Be("TURNO JUGADOR 1");

    }
    
     
    [Fact]
    public void Si_InicioLaPartidaYAgrego2JugadoresConSusEstrategiasCompletasYJugador1DisparaAUnCanioneroDelJugador2_Debe_RetornarBarcoHundido()
    {
        var acorazado = new Acorazado();
        acorazado.AgregarJugador("Player 1");
        acorazado.PosicionarNave(0, 0, TiposNave.Canionero, Orientacion.Derecha);
        acorazado.PosicionarNave(0, 1, TiposNave.Canionero, Orientacion.Derecha);
        acorazado.PosicionarNave(0, 2, TiposNave.Canionero, Orientacion.Derecha);
        acorazado.PosicionarNave(0, 3, TiposNave.Canionero, Orientacion.Derecha);
        acorazado.PosicionarNave(1, 0, TiposNave.Portaviones, Orientacion.Derecha);
        acorazado.PosicionarNave(2, 0, TiposNave.Destructor, Orientacion.Derecha);
        acorazado.PosicionarNave(3, 0, TiposNave.Destructor, Orientacion.Derecha);
        acorazado.AgregarJugador("Player 2");
        acorazado.PosicionarNave(9, 9, TiposNave.Canionero, Orientacion.Izquierda);
        acorazado.PosicionarNave(9, 8, TiposNave.Canionero, Orientacion.Izquierda);
        acorazado.PosicionarNave(9, 7, TiposNave.Canionero, Orientacion.Izquierda);
        acorazado.PosicionarNave(9, 6, TiposNave.Canionero, Orientacion.Izquierda);
        acorazado.PosicionarNave(1, 0, TiposNave.Portaviones, Orientacion.Derecha);
        acorazado.PosicionarNave(2, 0, TiposNave.Destructor, Orientacion.Derecha);
        acorazado.PosicionarNave(3, 0, TiposNave.Destructor, Orientacion.Derecha);
        acorazado.Iniciar();

        var imprimir = acorazado.Imprimir();
        
        imprimir.Should().Be("    0   1   2   3   4   5   6   7   8   9\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "0 | g | g | g | g |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "1 | c | c | c | c |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "2 | d | d | d |   |   |   |   |   |   |   |\n" +
                             "  +---+---+---+---+---+---+---+---+---+---+\n" +
                             "3 | d | d | d |   |   |   |   |   |   |   |\n" +
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
using AwesomeAssertions;

namespace AcorazadosTests;

public class AcorazadosTests
{
    [Fact]
    public void Si_InicializoUnTablero_Debe_TenerDimensionesDe10X10()
    {
        var acorazados = new Acorazados();

        acorazados.TieneDimensiones(10, 10).Should().BeTrue();
    }

    [Fact]
    public void Si_InicializoUnTableroDe10x1o_Debe_TenerDimensionesDe10X10()
    {
        var acorazados = new Acorazados();

        acorazados.TieneDimensiones(11, 11).Should().BeFalse();
    }

    [Fact]
    public void Si_AgregoUnJugador_Debe_ExistirUnJugadorConElAliasAsignado()
    {
        var acorazados = new Acorazados();

        var jugador1 = "jugador 1";
        acorazados.AgregarJugador(jugador1);

        acorazados.BuscarJugador(jugador1).Alias.Should().Be(jugador1);
    }

    [Fact]
    public void Si_JugadorAgregaCanoneroEnLaPosicionFila2Columna7_Debe_EnTableroEnPosicionX7Y2TenerG()
    {
        var acorazados = new Acorazados();
        var jugador1 = "jugador 1";
        acorazados.AgregarJugador(jugador1);

        acorazados.BuscarJugador(jugador1).AgregarGunShip(2, 7);

        acorazados.ObtenerElemento(jugador1, 2, 7).Should().Be(new GunShip().Valor);
    }

    [Fact]
    public void Si_JugadorAgregaDestroyerEnLaFila3Columna2YOrientacionHorizontal_Debe_TableroOcuparDesde32A34_TenerD()
    {
        var acorazados = new Acorazados();
        var jugador1 = "jugador 1";
        acorazados.AgregarJugador(jugador1);

        acorazados.BuscarJugador(jugador1).AgregarDestroyer(3, 2, Orientacion.Horizontal);

        var valorDestroyer = new Destroyer().Valor;
        acorazados.ObtenerElemento(jugador1, 3, 2).Should().Be(valorDestroyer);
        acorazados.ObtenerElemento(jugador1, 3, 3).Should().Be(valorDestroyer);
        acorazados.ObtenerElemento(jugador1, 3, 4).Should().Be(valorDestroyer);
    }

    [Fact]
    public void Si_JugadorAgregaDestroyerEnLaFila7Columna5YOrientacionVertical_Debe_TableroOcuparDesde75A95_TenerD()
    {
        var acorazados = new Acorazados();
        var jugador1 = "jugador 1";
        acorazados.AgregarJugador(jugador1);

        acorazados.BuscarJugador(jugador1).AgregarDestroyer(7, 5, Orientacion.Vertical);

        var valorDestroyer = new Destroyer().Valor;
        acorazados.ObtenerElemento(jugador1, 7, 5).Should().Be(valorDestroyer);
        acorazados.ObtenerElemento(jugador1, 8, 5).Should().Be(valorDestroyer);
        acorazados.ObtenerElemento(jugador1, 9, 5).Should().Be(valorDestroyer);
    }


    [Fact]
    public void Si_JugadorAgregaCarrierEnLaFila4Columna8YOrientacionVertical_Debe_TableroOcuparDesde48A78_TenerC()
    {
        var acorazados = new Acorazados();
        var jugador1 = "jugador 1";
        acorazados.AgregarJugador(jugador1);

        acorazados.BuscarJugador(jugador1).AgregarCarrier(4, 8, Orientacion.Vertical);

        var valorCarrier = new Carrier().Valor;
        acorazados.ObtenerElemento(jugador1, 4, 8).Should().Be(valorCarrier);
        acorazados.ObtenerElemento(jugador1, 5, 8).Should().Be(valorCarrier);
        acorazados.ObtenerElemento(jugador1, 6, 8).Should().Be(valorCarrier);
        acorazados.ObtenerElemento(jugador1, 7, 8).Should().Be(valorCarrier);
    }

    [Fact]
    public void Si_JugadorAgregaCarrierEnLaFila9Columna0YOrientacionHorizontal_Debe_TableroOcuparDesde90A93_TenerC()
    {
        var acorazados = new Acorazados();
        var jugador1 = "jugador 1";
        acorazados.AgregarJugador(jugador1);

        acorazados.BuscarJugador(jugador1).AgregarCarrier(9, 0, Orientacion.Horizontal);

        var valorCarrier = new Carrier().Valor;
        acorazados.ObtenerElemento(jugador1, 9, 0).Should().Be(valorCarrier);
        acorazados.ObtenerElemento(jugador1, 9, 1).Should().Be(valorCarrier);
        acorazados.ObtenerElemento(jugador1, 9, 2).Should().Be(valorCarrier);
        acorazados.ObtenerElemento(jugador1, 9, 3).Should().Be(valorCarrier);
    }

    [Theory]
    [InlineData(9, -1)]
    [InlineData(9, 10)]
    [InlineData(-1, 10)]
    [InlineData(10, 10)]
    public void Si_JugadorAgregaUnDestroyerFueraDeLosLimitesDelTablero_Debe_LanzarExcepcion(int fila, int columna)
    {
        var acorazados = new Acorazados();
        var jugador1 = "jugador 1";
        acorazados.AgregarJugador(jugador1);

        var caller = () => acorazados.BuscarJugador(jugador1).AgregarDestroyer(fila, columna, Orientacion.Vertical);
        caller.Should().ThrowExactly<IndexOutOfRangeException>()
            .WithMessage($"Nave fuera del rango");
    }

    [Theory]
    [InlineData(9, -1)]
    [InlineData(9, 10)]
    [InlineData(-1, 10)]
    [InlineData(10, 10)]
    public void Si_JugadorAgregaUnCarrierFueraDeLosLimitesDelTablero_Debe_LanzarExcepcion(int fila, int columna)
    {
        var acorazados = new Acorazados();
        var jugador1 = "jugador 1";
        acorazados.AgregarJugador(jugador1);

        var caller = () => acorazados.BuscarJugador(jugador1).AgregarCarrier(fila, columna, Orientacion.Vertical);
        caller.Should().ThrowExactly<IndexOutOfRangeException>()
            .WithMessage("Nave fuera del rango");
    }


    [Theory]
    [InlineData(Orientacion.Vertical)]
    [InlineData(Orientacion.Horizontal)]
    public void Si_JugadorAgregaUnCarrierEnOrientacionIndicadaSinTenerElEspacioSuficiente_Debe_LanzarExcepcion(
        Orientacion orientacion)
    {
        var acorazados = new Acorazados();
        var jugador1 = "jugador 1";
        acorazados.AgregarJugador(jugador1);

        var caller = () => acorazados.BuscarJugador(jugador1).AgregarCarrier(9, 7, orientacion);
        caller.Should().ThrowExactly<IndexOutOfRangeException>()
            .WithMessage("Nave fuera del rango");
    }

    [Fact]
    public void Si_Jugador1AgregaUnGunshipEnLaPosicion00_Debe_ImprimirTableroGunShip()
    {
        var acorazados = new Acorazados();
        var jugador1 = "jugador 1";
        string expected = " |0|1|2|3|4|5|6|7|8|9|\r\n" +
                          "0|g| | | | | | | | | |\r\n" +
                          "1| | | | | | | | | | |\r\n" +
                          "2| | | | | | | | | | |\r\n" +
                          "3| | | | | | | | | | |\r\n" +
                          "4| | | | | | | | | | |\r\n" +
                          "5| | | | | | | | | | |\r\n" +
                          "6| | | | | | | | | | |\r\n" +
                          "7| | | | | | | | | | |\r\n" +
                          "8| | | | | | | | | | |\r\n" +
                          "9| | | | | | | | | | |\r\n";


        acorazados.AgregarJugador(jugador1);
        acorazados.BuscarJugador(jugador1).AgregarGunShip(0, 0);

        acorazados.BuscarJugador(jugador1).ImprimirTablero().Should().Be(expected);
    }

    [Fact]
    public void
        Si_Jugador1AgregaUnDestroyerEnLaPosicion32ConOrientacionHorizontal_Debe_ImprimirTableroDestroyerDesde32A34()
    {
        var acorazados = new Acorazados();
        var jugador1 = "jugador 1";
        string expected = " |0|1|2|3|4|5|6|7|8|9|\r\n" +
                          "0|g| | | | | | | | | |\r\n" +
                          "1| | | | | | | | | | |\r\n" +
                          "2| | | | | | | | | | |\r\n" +
                          "3| | |d|d|d| | | | | |\r\n" +
                          "4| | | | | | | | | | |\r\n" +
                          "5| | | | | | | | | | |\r\n" +
                          "6| | | | | | | | | | |\r\n" +
                          "7| | | | | | | | | | |\r\n" +
                          "8| | | | | | | | | | |\r\n" +
                          "9| | | | | | | | | | |\r\n";
        acorazados.AgregarJugador(jugador1);
        acorazados.BuscarJugador(jugador1).AgregarGunShip(0, 0);

        acorazados.BuscarJugador(jugador1).AgregarDestroyer(3, 2, Orientacion.Horizontal);


        acorazados.BuscarJugador(jugador1).ImprimirTablero().Should().Be(expected);
    }

    [Fact]
    public void SiAgrego2JugadoresYElJugador1Dispara_Debe_ImprimirElTableroDelJugador2ConElDisparoRecibido()
    {
        var acorazados = new Acorazados();
        var jugador1 = "jugador 1";
        var jugador2 = "jugador 2";
        acorazados.AgregarJugador(jugador1);
        acorazados.AgregarJugador(jugador2);

        var j1 = acorazados.BuscarJugador(jugador1);
        j1.AgregarCarrier(9, 0, Orientacion.Horizontal);
        j1.AgregarDestroyer(0, 1, Orientacion.Vertical);
        j1.AgregarGunShip(7, 1);
        j1.AgregarGunShip(8, 8);
        j1.AgregarGunShip(5, 1);
        j1.AgregarGunShip(4, 3);

        var j2 = acorazados.BuscarJugador(jugador2);
        j2.AgregarCarrier(9, 0, Orientacion.Horizontal);
        j2.AgregarDestroyer(0, 1, Orientacion.Vertical);
        j2.AgregarGunShip(7, 1);
        j2.AgregarGunShip(6, 5);
        j2.AgregarGunShip(3, 7);
        j2.AgregarGunShip(4, 3);

        string expected = " |0|1|2|3|4|5|6|7|8|9|\r\n" +
                          "0| |d| | | | | | | | |\r\n" +
                          "1| |d| | | | | | | | |\r\n" +
                          "2| |d| | |o| | | | | |\r\n" +
                          "3| | | | | | | |g| | |\r\n" +
                          "4| | | |g| | | | | | |\r\n" +
                          "5| | | | | | | | | | |\r\n" +
                          "6| | | | | |g| | | | |\r\n" +
                          "7| |g| | | | | | | | |\r\n" +
                          "8| | | | | | | | | | |\r\n" +
                          "9|c|c|c|c| | | | | | |\r\n";

        acorazados.Disparar(2, 4);


        j2.ImprimirTablero().Should().Be(expected);
    }

    [Fact]
    public void
        SiJugador1RealizaUnDisparoEnLaCoordenada43_Debe_ImprimirTableroDelJugador2ConDisparoRecibidoEnLaCoordenada()
    {
        var acorazados = new Acorazados();
        var jugador1 = "jugador 1";
        var jugador2 = "jugador 2";
        acorazados.AgregarJugador(jugador1);
        acorazados.AgregarJugador(jugador2);

        var j1 = acorazados.BuscarJugador(jugador1);
        j1.AgregarCarrier(9, 0, Orientacion.Horizontal);
        j1.AgregarDestroyer(0, 1, Orientacion.Vertical);
        j1.AgregarGunShip(7, 1);
        j1.AgregarGunShip(8, 8);
        j1.AgregarGunShip(5, 1);
        j1.AgregarGunShip(4, 3);

        var j2 = acorazados.BuscarJugador(jugador2);
        j2.AgregarCarrier(9, 0, Orientacion.Horizontal);
        j2.AgregarDestroyer(0, 1, Orientacion.Vertical);
        j2.AgregarGunShip(7, 1);
        j2.AgregarGunShip(6, 5);
        j2.AgregarGunShip(3, 7);
        j2.AgregarGunShip(4, 3);

        string expected = " |0|1|2|3|4|5|6|7|8|9|\r\n" +
                          "0| |d| | | | | | | | |\r\n" +
                          "1| |d| | | | | | | | |\r\n" +
                          "2| |d| | | | | | | | |\r\n" +
                          "3| | | | | | | |g| | |\r\n" +
                          "4| | | |X| | | | | | |\r\n" +
                          "5| | | | | | | | | | |\r\n" +
                          "6| | | | | |g| | | | |\r\n" +
                          "7| |g| | | | | | | | |\r\n" +
                          "8| | | | | | | | | | |\r\n" +
                          "9|c|c|c|c| | | | | | |\r\n";


        acorazados.Disparar(4, 3);


        j2.ImprimirTablero().Should().Be(expected);
    }

    [Fact]
    public void
        SiJugador1RealizaUnDisparoEnLaCoordenada43YNaveEsGunShip_Debe_ImprimirTableroDelJugador2ConDisparoRecibidoEnLaCoordenadaMarcadoConX()
    {
        var acorazados = new Acorazados();
        var jugador1 = "jugador 1";
        var jugador2 = "jugador 2";
        acorazados.AgregarJugador(jugador1);
        acorazados.AgregarJugador(jugador2);

        var j1 = acorazados.BuscarJugador(jugador1);
        j1.AgregarCarrier(9, 0, Orientacion.Horizontal);
        j1.AgregarDestroyer(0, 1, Orientacion.Vertical);
        j1.AgregarGunShip(7, 1);
        j1.AgregarGunShip(8, 8);
        j1.AgregarGunShip(5, 1);
        j1.AgregarGunShip(4, 3);

        var j2 = acorazados.BuscarJugador(jugador2);
        j2.AgregarCarrier(9, 0, Orientacion.Horizontal);
        j2.AgregarDestroyer(0, 1, Orientacion.Vertical);
        j2.AgregarGunShip(7, 1);
        j2.AgregarGunShip(6, 5);
        j2.AgregarGunShip(3, 7);
        j2.AgregarGunShip(4, 3);

        string expected = " |0|1|2|3|4|5|6|7|8|9|\r\n" +
                          "0| |d| | | | | | | | |\r\n" +
                          "1| |d| | | | | | | | |\r\n" +
                          "2| |d| | | | | | | | |\r\n" +
                          "3| | | | | | | |g| | |\r\n" +
                          "4| | | |X| | | | | | |\r\n" +
                          "5| | | | | | | | | | |\r\n" +
                          "6| | | | | |g| | | | |\r\n" +
                          "7| |g| | | | | | | | |\r\n" +
                          "8| | | | | | | | | | |\r\n" +
                          "9|c|c|c|c| | | | | | |\r\n";


        acorazados.Disparar(4, 3);


        j2.ImprimirTablero().Should().Be(expected);
    }

    [Fact]
    public void
        SiJugador1RealizaUnDisparoEnLaCoordenada11YNaveEsDestroyer_Debe_ImprimirTableroDelJugador2ConDisparoRecibidoEnLaCoordenadaMarcadoConx()
    {
        var acorazados = new Acorazados();
        var jugador1 = "jugador 1";
        var jugador2 = "jugador 2";
        acorazados.AgregarJugador(jugador1);
        acorazados.AgregarJugador(jugador2);

        var j1 = acorazados.BuscarJugador(jugador1);
        j1.AgregarCarrier(9, 0, Orientacion.Horizontal);
        j1.AgregarDestroyer(0, 1, Orientacion.Vertical);
        j1.AgregarGunShip(7, 1);
        j1.AgregarGunShip(8, 8);
        j1.AgregarGunShip(5, 1);
        j1.AgregarGunShip(4, 3);

        var j2 = acorazados.BuscarJugador(jugador2);
        j2.AgregarCarrier(9, 0, Orientacion.Horizontal);
        j2.AgregarDestroyer(0, 1, Orientacion.Vertical);
        j2.AgregarGunShip(7, 1);
        j2.AgregarGunShip(6, 5);
        j2.AgregarGunShip(3, 7);
        j2.AgregarGunShip(4, 3);

        string expected = " |0|1|2|3|4|5|6|7|8|9|\r\n" +
                          "0| |d| | | | | | | | |\r\n" +
                          "1| |x| | | | | | | | |\r\n" +
                          "2| |d| | | | | | | | |\r\n" +
                          "3| | | | | | | |g| | |\r\n" +
                          "4| | | |g| | | | | | |\r\n" +
                          "5| | | | | | | | | | |\r\n" +
                          "6| | | | | |g| | | | |\r\n" +
                          "7| |g| | | | | | | | |\r\n" +
                          "8| | | | | | | | | | |\r\n" +
                          "9|c|c|c|c| | | | | | |\r\n";


        acorazados.Disparar(1, 1);


        j2.ImprimirTablero().Should().Be(expected);
    }

    [Fact]
    public void
        SiJugador1RealizaUnDisparoEnLaCoordenada11YNaveEsDestroyer_Debe_ImprimirTableroDelJugador2ConDisparoRecibidoEnLaCoordenadaMarcadoConxYTurnoSerDeJugador2()
    {
        var acorazados = new Acorazados();
        var jugador1 = "jugador 1";
        var jugador2 = "jugador 2";
        acorazados.AgregarJugador(jugador1);
        acorazados.AgregarJugador(jugador2);

        var j1 = acorazados.BuscarJugador(jugador1);
        j1.AgregarCarrier(9, 0, Orientacion.Horizontal);
        j1.AgregarDestroyer(0, 1, Orientacion.Vertical);
        j1.AgregarGunShip(7, 1);
        j1.AgregarGunShip(8, 8);
        j1.AgregarGunShip(5, 1);
        j1.AgregarGunShip(4, 3);

        var j2 = acorazados.BuscarJugador(jugador2);
        j2.AgregarCarrier(9, 0, Orientacion.Horizontal);
        j2.AgregarDestroyer(0, 1, Orientacion.Vertical);
        j2.AgregarGunShip(7, 1);
        j2.AgregarGunShip(6, 5);
        j2.AgregarGunShip(3, 7);
        j2.AgregarGunShip(4, 3);

        string expected = " |0|1|2|3|4|5|6|7|8|9|\r\n" +
                          "0| |d| | | | | | | | |\r\n" +
                          "1| |x| | | | | | | | |\r\n" +
                          "2| |d| | | | | | | | |\r\n" +
                          "3| | | | | | | |g| | |\r\n" +
                          "4| | | |g| | | | | | |\r\n" +
                          "5| | | | | | | | | | |\r\n" +
                          "6| | | | | |g| | | | |\r\n" +
                          "7| |g| | | | | | | | |\r\n" +
                          "8| | | | | | | | | | |\r\n" +
                          "9|c|c|c|c| | | | | | |\r\n";


        acorazados.Disparar(1, 1);


        j2.ImprimirTablero().Should().Be(expected);
        acorazados.EsTurnoJugador1.Should().BeFalse();
    }

    [Fact]
    public void
        SiJugador1RealizaUnDisparoEnLaCoordenada91YNaveEsCarrier_Debe_ImprimirTableroDelJugador2ConDisparoRecibidoEnLaCoordenadaMarcadoConx()
    {
        var acorazados = new Acorazados();
        var jugador1 = "jugador 1";
        var jugador2 = "jugador 2";
        acorazados.AgregarJugador(jugador1);
        acorazados.AgregarJugador(jugador2);

        var j1 = acorazados.BuscarJugador(jugador1);
        j1.AgregarCarrier(9, 0, Orientacion.Horizontal);
        j1.AgregarDestroyer(0, 1, Orientacion.Vertical);
        j1.AgregarGunShip(7, 1);
        j1.AgregarGunShip(8, 8);
        j1.AgregarGunShip(5, 1);
        j1.AgregarGunShip(4, 3);

        var j2 = acorazados.BuscarJugador(jugador2);
        j2.AgregarCarrier(9, 0, Orientacion.Horizontal);
        j2.AgregarDestroyer(0, 1, Orientacion.Vertical);
        j2.AgregarGunShip(7, 1);
        j2.AgregarGunShip(6, 5);
        j2.AgregarGunShip(3, 7);
        j2.AgregarGunShip(4, 3);

        string expectedTableroJugador2 = " |0|1|2|3|4|5|6|7|8|9|\r\n" +
                                         "0| |d| | | | | | | | |\r\n" +
                                         "1| |d| | | | | | | | |\r\n" +
                                         "2| |d| | | | | | | | |\r\n" +
                                         "3| | | | | | | |g| | |\r\n" +
                                         "4| | | |g| | | | | | |\r\n" +
                                         "5| | | | | | | | | | |\r\n" +
                                         "6| | | | | |g| | | | |\r\n" +
                                         "7| |g| | | | | | | | |\r\n" +
                                         "8| | | | | | | | | | |\r\n" +
                                         "9|c|x|c|c| | | | | | |\r\n";


        acorazados.Disparar(9, 1);


        j2.ImprimirTablero().Should().Be(expectedTableroJugador2);
    }

    [Fact]
    public void Si_JugadorIntentaAgregarMasDe1Carrier_Debe_LanzarExepcion()
    {
        var acorazados = new Acorazados();
        var jugador1 = "jugador 1";

        acorazados.AgregarJugador(jugador1);
        var j1 = acorazados.BuscarJugador(jugador1);
        j1.AgregarCarrier(9, 0, Orientacion.Horizontal);

        var caller = () => j1.AgregarCarrier(5, 1, Orientacion.Horizontal);


        caller.Should().ThrowExactly<InvalidOperationException>()
            .WithMessage("Cantidad máxima de tipo de nave alcanzada");
    }

    [Fact]
    public void Si_JugadorIntentaAgregarMasDe2Destroyer_Debe_LanzarExepcion()
    {
        var acorazados = new Acorazados();
        var jugador1 = "jugador 1";

        acorazados.AgregarJugador(jugador1);
        var j1 = acorazados.BuscarJugador(jugador1);
        j1.AgregarDestroyer(2, 0, Orientacion.Vertical);
        j1.AgregarDestroyer(7, 0, Orientacion.Horizontal);

        var caller = () => j1.AgregarDestroyer(5, 1, Orientacion.Horizontal);


        caller.Should().ThrowExactly<InvalidOperationException>()
            .WithMessage("Cantidad máxima de tipo de nave alcanzada");
    }

    [Fact]
    public void Si_JugadorIntentaAgregarMasDe4GunShips_Debe_LanzarExepcion()
    {
        var acorazados = new Acorazados();
        var jugador1 = "jugador 1";

        acorazados.AgregarJugador(jugador1);
        var j1 = acorazados.BuscarJugador(jugador1);
        j1.AgregarGunShip(5, 0);
        j1.AgregarGunShip(2, 0);
        j1.AgregarGunShip(6, 5);
        j1.AgregarGunShip(4, 4);


        var caller = () => j1.AgregarGunShip(0, 0);


        caller.Should().ThrowExactly<InvalidOperationException>()
            .WithMessage("Cantidad máxima de tipo de nave alcanzada");
    }

    [Fact]
    public void Si_JugadorIntentaSuperPonerUnaNave_Debe_LanzarExepcion()
    {
        var acorazados = new Acorazados();
        var jugador1 = "jugador 1";
        acorazados.AgregarJugador(jugador1);
        var j1 = acorazados.BuscarJugador(jugador1);
        j1.AgregarGunShip(5, 0);

        var caller = () => j1.AgregarGunShip(5, 0);

        caller.Should().ThrowExactly<InvalidOperationException>()
            .WithMessage("No se puede superponer una nave");
    }

    [Fact]
    public void Si_JugadorIntentaSuperPonerUnDestroyer_Debe_LanzarExepcion()
    {
        var acorazados = new Acorazados();
        var jugador1 = "jugador 1";
        acorazados.AgregarJugador(jugador1);
        var j1 = acorazados.BuscarJugador(jugador1);
        j1.AgregarDestroyer(5, 0, Orientacion.Horizontal);

        var caller = () => j1.AgregarDestroyer(5, 0, Orientacion.Horizontal);

        caller.Should().ThrowExactly<InvalidOperationException>()
            .WithMessage("No se puede superponer una nave");
    }

    [Fact]
    public void Si_JugadorDisparaEnPosicion11EIntentaDispararNuevamenteEnPosicion11_Debe_LanzarExepcion()
    {
        var acorazados = new Acorazados();
        var jugador1 = "jugador 1";
        var jugador2 = "jugador 2";
        acorazados.AgregarJugador(jugador1);
        acorazados.AgregarJugador(jugador2);

        var j1 = acorazados.BuscarJugador(jugador1);
        j1.AgregarCarrier(9, 0, Orientacion.Horizontal);
        j1.AgregarDestroyer(0, 1, Orientacion.Vertical);
        j1.AgregarGunShip(7, 1);
        j1.AgregarGunShip(8, 8);
        j1.AgregarGunShip(5, 1);
        j1.AgregarGunShip(4, 3);

        var j2 = acorazados.BuscarJugador(jugador2);
        j2.AgregarCarrier(9, 0, Orientacion.Horizontal);
        j2.AgregarDestroyer(0, 1, Orientacion.Vertical);
        j2.AgregarGunShip(7, 1);
        j2.AgregarGunShip(6, 5);
        j2.AgregarGunShip(3, 7);
        j2.AgregarGunShip(4, 3);


        acorazados.Disparar(9, 1);
        acorazados.Disparar(4, 7);


        var caller = () => acorazados.Disparar(9, 1);

        caller.Should().ThrowExactly<InvalidOperationException>()
            .WithMessage("No se puede disparar al mismo punto");
    }
}
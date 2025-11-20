using Acorazados;
using AwesomeAssertions;

public class JuegoAcorazadosTest
{
    private JuegoAcorazados _juego;
    private string[,] tableroDisparos;

    public JuegoAcorazadosTest()
    {
        tableroDisparos = new string[,]
        {
            { null, null, null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null, null, null },
        };
        _juego = new JuegoAcorazados();
        var acorazadosJugador1 = new List<Acorazado>()
        {
            new PortaAviones(1, 1, Direccion.Derecha),
            new Destructor(5, 5, Direccion.Derecha),
            new Cañonero(7, 7, Direccion.Derecha),
            new Cañonero(9, 9, Direccion.Derecha)
        };
        _juego.AgregarJugador("Jugador 1", acorazadosJugador1);
        var acorazadosJugador2 = new List<Acorazado>()
        {
            new PortaAviones(1, 1, Direccion.Derecha),
            new Destructor(3, 3, Direccion.Derecha),
            new Destructor(4, 4, Direccion.Abajo),
            new Cañonero(4, 1, Direccion.Derecha),
            new Cañonero(6, 1, Direccion.Derecha)
        };
        _juego.AgregarJugador("Jugador 2", acorazadosJugador2);
        _juego.Iniciar();
    }

    [Fact]
    public void Si_DisparoEnLaPosicion22_Debe_TableroContrincanteTener_o()
    {
        tableroDisparos[2, 2] = Constantes.LetraDisparoFallido;
        ;

        _juego.Disparar(2, 2);

        _juego.ObtenerTableroContrincante().Should().BeEquivalentTo(tableroDisparos);
    }

    [Fact]
    public void Si_DisparoEnLaPosicion11_Debe_TableroContrincanteTener_x()
    {
        tableroDisparos[1, 1] = Constantes.LetraDisparoAcertado;
        ;

        _juego.Disparar(1, 1);

        _juego.ObtenerTableroContrincante().Should().BeEquivalentTo(tableroDisparos);
    }

    [Fact]
    public void Si_DisparoEnLasPosiciones11_12_13_14_Debe_TableroContrincanteTener_XXX()
    {
        tableroDisparos[1, 1] = Constantes.LetraAcorazadoHundido;
        ;
        tableroDisparos[1, 2] = Constantes.LetraAcorazadoHundido;
        ;
        tableroDisparos[1, 3] = Constantes.LetraAcorazadoHundido;
        ;
        tableroDisparos[1, 4] = Constantes.LetraAcorazadoHundido;
        ;

        _juego.Disparar(1, 1);
        _juego.Disparar(1, 2);
        _juego.Disparar(1, 3);
        _juego.Disparar(1, 4);

        _juego.ObtenerTableroContrincante().Should().BeEquivalentTo(tableroDisparos);
    }

    [Fact]
    public void Si_Disparo_EnLasPosiciones34_44_54_Debe_TableroContrincanteNoTenerX()
    {
        tableroDisparos[3, 4] = Constantes.LetraDisparoAcertado;
        tableroDisparos[4, 4] = Constantes.LetraDisparoAcertado;
        tableroDisparos[5, 4] = Constantes.LetraDisparoAcertado;

        _juego.Disparar(3, 4);
        _juego.Disparar(4, 4);
        _juego.Disparar(5, 4);

        _juego.ObtenerTableroContrincante().Should().BeEquivalentTo(tableroDisparos);
    }

    [Fact]
    public void Si_DisparoEnLaPosicion41_Debe_TableroContrincanteTener_X()
    {
        tableroDisparos[4, 1] = Constantes.LetraAcorazadoHundido;

        _juego.Disparar(4, 1);

        _juego.ObtenerTableroContrincante().Should().BeEquivalentTo(tableroDisparos);
    }

    [Fact]
    public void Si_DisparoEnLaPosicion41LaCualTieneUnaX_Debe_TableroContrincanteTener_X()
    {
        tableroDisparos[4, 1] = Constantes.LetraAcorazadoHundido;

        _juego.Disparar(4, 1);
        _juego.Disparar(4, 1);

        _juego.ObtenerTableroContrincante().Should().BeEquivalentTo(tableroDisparos);
    }

    [Fact]
    public void Si_FinalizoTurno_Debe_TableroJugador2Tener_g()
    {
        var tableroEsperadoJugador2 = tableroDisparos;
        tableroEsperadoJugador2[6, 1] = Constantes.LetraCoñonero;
        var juego = new JuegoAcorazados();
        var acorazadosJugador1 = new List<Acorazado>()
        {
            new PortaAviones(1, 1, Direccion.Derecha)
        };
        juego.AgregarJugador("Jugador 1", acorazadosJugador1);
        var acorazadosJugador2 = new List<Acorazado>()
        {
            new Cañonero(6, 1, Direccion.Derecha)
        };
        juego.AgregarJugador("Jugador 2", acorazadosJugador2);
        juego.Iniciar();

        juego.FinalizarTurno();

        juego.ImprimirTablero().Should().BeEquivalentTo(tableroDisparos);
    }

    [Theory]
    [InlineData(-1, -1)]
    [InlineData(11, 11)]
    public void Si_DisparoEnPosicionQueNoExiste_Debe_LanzarExcepcion(int fila, int columna)
    {
        Action act = () => _juego.Disparar(fila, columna);

        act.Should().Throw<ArgumentOutOfRangeException>().WithMessage("*No es posible disparar en esa direccion*");
    }

    [Fact]
    public void Si_DisparoYDestruyoUnAcorazado_Debe_RetornarSeHaHundidoUnAcorazado()
    {
        var mensaje = _juego.Disparar(6, 1);

        mensaje.Should().Be("Se ha hundido un acorazado");
    }

    [Fact]
    public void Si_DisparoYGolpeoUnAcorazado_Debe_RetornarSeInterceptoUnAcorazado()
    {
        var mensaje = _juego.Disparar(4, 4);

        mensaje.Should().Be("Se ha interceptado un acorazado");
    }

    [Fact]
    public void Si_DisparoYNoGolpeoUnAcorazado_Debe_RetornarDisparoFallido()
    {
        var mensaje = _juego.Disparar(4, 8);

        mensaje.Should().Be("Disparo fallido");
    }

    [Fact]
    public void Si_FinalizoTurnoYNoHayNiUnBarcoAflote_Debe_FinalizarJuegoRetornarElInforme()
    {
        var informeEsperado = new InformeJuego(
            "Jugador 1",
            2,
            1,
            1,
            new List<string>
            {
                "Cañonero: (6,1)"
            });
        var tableroEsperadoJugador2 = tableroDisparos;
        tableroEsperadoJugador2[6, 1] = Constantes.LetraCoñonero;
        var juego = new JuegoAcorazados();
        var acorazadosJugador1 = new List<Acorazado>()
        {
            new PortaAviones(1, 1, Direccion.Derecha)
        };
        juego.AgregarJugador("Jugador 1", acorazadosJugador1);
        var acorazadosJugador2 = new List<Acorazado>()
        {
            new Cañonero(6, 1, Direccion.Derecha)
        };
        juego.AgregarJugador("Jugador 2", acorazadosJugador2);
        juego.Iniciar();

        juego.Disparar(6, 2);
        juego.FinalizarTurno();
        juego.Disparar(1, 2);
        juego.FinalizarTurno();
        juego.Disparar(6, 1);

        var informe = juego.FinalizarTurno().First();
        informe.Should().BeEquivalentTo(informeEsperado);
    }

    [Fact]
    public void Si_FinalizoTurnoYNoHayNiUnBarcoAflote_Debe_FinalizarJuegoRetornarElInformeDelJugador2()
    {
        var informeEsperado = new InformeJuego(
            "Jugador 2",
            1,
            1,
            0,
            new List<string>());
        var tableroEsperadoJugador2 = tableroDisparos;
        tableroEsperadoJugador2[6, 1] = Constantes.LetraCoñonero;
        var juego = new JuegoAcorazados();
        var acorazadosJugador1 = new List<Acorazado>()
        {
            new PortaAviones(1, 1, Direccion.Derecha)
        };
        juego.AgregarJugador("Jugador 1", acorazadosJugador1);
        var acorazadosJugador2 = new List<Acorazado>()
        {
            new Cañonero(6, 1, Direccion.Derecha)
        };
        juego.AgregarJugador("Jugador 2", acorazadosJugador2);
        juego.Iniciar();

        juego.Disparar(6, 2);
        juego.FinalizarTurno();
        juego.Disparar(1, 2);
        juego.FinalizarTurno();
        juego.Disparar(6, 1);

        var informe = juego.FinalizarTurno().Last();
        informe.Should().BeEquivalentTo(informeEsperado);
    }
}
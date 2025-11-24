using Acorazados.Core.Clases;
using Acorazados.Core.Enum;
using Acorazados.Core.Interfaces;
using AwesomeAssertions;

namespace Acorazados.Test;

public class AcorazadosTest
{
    private readonly IAcorazadosBuilder _acorazadosBuilder = new AcorazadosBuilder();

    [Fact]
    public void Si_AgregoUnJugador_Debe_ExistirUnJugadorConUnTablero()
    {
        var acorazados = new Core.Acorazados();
        acorazados.AgregarJugador("David");

        var jugador = acorazados.ObtenerJugador(0);

        jugador.Nombre.Should().Be("David");
        jugador.Tablero.Should().NotBeNull();
    }

    [Fact]
    public void Si_AgregoMasDeDosJugadores_Debe_LanzarExcepcion()
    {
        var acorazados = new Core.Acorazados();
        acorazados.AgregarJugador("David");
        acorazados.AgregarJugador("Diego");

        Action resultado = () => acorazados.AgregarJugador("Juan");

        resultado.Should().ThrowExactly<InvalidOperationException>("No se pueden agregar más de dos jugadores");
    }

    [Fact]
    public void Si_InicialElJuegoYUnoDeLosDosJugadoresNoTieneBarcos_Debe_GenerarExcepcion()
    {
        var acorazados = new Core.Acorazados();
        acorazados.AgregarJugador("David");
        acorazados.AgregarJugador("Diego");
        var jugadorUno = acorazados.ObtenerJugador(0);
        jugadorUno.Tablero.AgregarBarco(Barcos.Canonero, 1, 1);

        Action respuesta = () => acorazados.Iniciar();

        respuesta
            .Should()
            .ThrowExactly<InvalidOperationException>()
            .WithMessage("Ambos jugadores deben tener barcos en el tablero");
    }

    [Fact]
    public void Si_InicializoElJuego_Debe_EstadoSerNoIniciado()
    {
        var acorazados = new Core.Acorazados();
        acorazados.EstadoJuego.Should().Be(EstadoJuego.NoIniciado);
    }

    [Fact]
    public void Si_ComienzoElJuegoConJugadoresYBarcos_Debe_EstadoSerIniciado()
    {
        var acorazados = _acorazadosBuilder
            .ConstruirJugadorUno("David", tablero => { tablero.AgregarBarco(Barcos.Canonero, 1, 1); })
            .ConstruirJugadorDos("Diego", tablero => { tablero.AgregarBarco(Barcos.Canonero, 1, 1); }).Construir();

        acorazados.Iniciar();

        acorazados.EstadoJuego.Should().Be(EstadoJuego.EnCurso);
    }

    [Fact]
    public void Si_JugadorUnoDisparaAlJugadorDosConCoordenada1_1_Debe_MostrarTiroExitoso()
    {
        var acorazados = _acorazadosBuilder
            .ConstruirJugadorUno("David", tablero => { tablero.AgregarBarco(Barcos.Destructor, 1, 2); })
            .ConstruirJugadorDos("Diego", tablero => { tablero.AgregarBarco(Barcos.Destructor, 1, 1); }).Construir();
        acorazados.Iniciar();

        acorazados.Disparar(1, 1).Should().Be("Tiro exitoso");
    }


    [Fact]
    public void Si_JugadorUnoDisparaAlJugadorDosConCoordenada5_5_Debe_MostrarAgua()
    {
        var acorazados = _acorazadosBuilder
            .ConstruirJugadorUno("David", tablero => { tablero.AgregarBarco(Barcos.Canonero, 1, 2); })
            .ConstruirJugadorDos("Diego", tablero => { tablero.AgregarBarco(Barcos.Canonero, 1, 1); }).Construir();
        acorazados.Iniciar();

        acorazados.Disparar(5, 5).Should().Be("Agua");
    }

    [Fact]
    public void Si_JugadorUnoDisparoYJugadorDosDisparaAlJugadorUnoConCoordenada1_2_Debe_MostrarTiroExitoso()
    {
        var acorazados = _acorazadosBuilder
            .ConstruirJugadorUno("David", tablero => { tablero.AgregarBarco(Barcos.Destructor, 1, 2); })
            .ConstruirJugadorDos("Diego", tablero => { tablero.AgregarBarco(Barcos.Destructor, 1, 1); }).Construir();
        acorazados.Iniciar();

        acorazados.Disparar(5, 5);

        acorazados.Disparar(1, 2).Should().Be("Tiro exitoso");
    }

    [Fact]
    public void Si_JugadorUnoDisparaYJugadorDosQuedaConTodosLosBarcosHundidos_Debe_EstadoDelJuegoEstarFinalizado()
    {
        var acorazados = _acorazadosBuilder
            .ConstruirJugadorUno("David", tablero => { tablero.AgregarBarco(Barcos.Canonero, 1, 2); })
            .ConstruirJugadorDos("Diego", tablero => { tablero.AgregarBarco(Barcos.Canonero, 1, 1); }).Construir();
        acorazados.Iniciar();

        acorazados.Disparar(1, 1).Should().Be("Barco hundido");
        acorazados.EstadoJuego.Should().Be(EstadoJuego.Finalizado);
    }

    [Fact]
    public void Si_DisparaYElEstadoDelJuegoEsNoIniciado_Debe_LanzarExcepcion()
    {
        var acorazados = _acorazadosBuilder
            .ConstruirJugadorUno("David", tablero => { tablero.AgregarBarco(Barcos.Canonero, 1, 2); })
            .ConstruirJugadorDos("Diego", tablero => { tablero.AgregarBarco(Barcos.Canonero, 1, 1); }).Construir();


        Action resultado = () => acorazados.Disparar(1, 1);

        resultado.Should().ThrowExactly<InvalidOperationException>("Debe iniciar el juego para poder disparar");
    }

    [Fact]
    public void Si_DisparaYElEstadoDelJuegoEsFinalizado_Debe_LanzarExcepcion()
    {
        var acorazados = _acorazadosBuilder
            .ConstruirJugadorUno("David", tablero => { tablero.AgregarBarco(Barcos.Canonero, 1, 2); })
            .ConstruirJugadorDos("Diego", tablero => { tablero.AgregarBarco(Barcos.Canonero, 1, 1); }).Construir();
        acorazados.Iniciar();
        acorazados.Disparar(1, 1);

        Action resultado = () => acorazados.Disparar(1, 1);

        resultado.Should().ThrowExactly<InvalidOperationException>("Debe iniciar un juego nuevo");
    }


    [Fact]
    public void Si_CualquierJugadorDisparaCoordenadasFueraDelRangoDelTablero_Debe_LanzarExcepcion()
    {
        var acorazados = _acorazadosBuilder
            .ConstruirJugadorUno("David", tablero => { tablero.AgregarBarco(Barcos.Canonero, 1, 2); })
            .ConstruirJugadorDos("Diego", tablero => { tablero.AgregarBarco(Barcos.Canonero, 1, 1); }).Construir();
        acorazados.Iniciar();

        Action resultado = () => acorazados.Disparar(111, 11);

        resultado.Should().ThrowExactly<InvalidOperationException>()
            .WithMessage("La coordenada excede el limite del tablero");
    }

    [Fact]
    public void
        Si_ElJugadorUnoTieneUnCanoneroEnLaCoordenada1_1EImprimoElTablero_Debe_MostrarTableroActualDelJugadorUnoConUnCanoneroEnCoordenada1_1()
    {
        var tableroEsperado =
            "  Jugador: David\n" +
            "  | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n" +
            "0 |   |   |   |   |   |   |   |   |   |   |\n" +
            "1 |   | g |   |   |   |   |   |   |   |   |\n" +
            "2 |   |   |   |   |   |   |   |   |   |   |\n" +
            "3 |   |   |   |   |   |   |   |   |   |   |\n" +
            "4 |   |   |   |   |   |   |   |   |   |   |\n" +
            "5 |   |   |   |   |   |   |   |   |   |   |\n" +
            "6 |   |   |   |   |   |   |   |   |   |   |\n" +
            "7 |   |   |   |   |   |   |   |   |   |   |\n" +
            "8 |   |   |   |   |   |   |   |   |   |   |\n" +
            "9 |   |   |   |   |   |   |   |   |   |   |";

        var acorazados = _acorazadosBuilder
            .ConstruirJugadorUno("David", tablero => { tablero.AgregarBarco(Barcos.Canonero, 1, 1); })
            .ConstruirJugadorDos("Diego", tablero => { tablero.AgregarBarco(Barcos.Canonero, 1, 1); }).Construir();
        acorazados.Iniciar();

        acorazados.ImprimirTableroJugadorEnTurno().Should().Be(tableroEsperado);
    }

    [Fact]
    public void
        Si_JugadorDosTieneUnCanoneroEnLaCoordenada1_1YJugadorUnoDisparaACoordenada2_2_Debe_MostrarTableroActualDelJugadorDosConUnCanoneroYUnTiroFallido()
    {
        var tableroEsperado =
            "  Jugador: Diego\n" +
            "  | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n" +
            "0 |   |   |   |   |   |   |   |   |   |   |\n" +
            "1 |   | g |   |   |   |   |   |   |   |   |\n" +
            "2 |   |   | o |   |   |   |   |   |   |   |\n" +
            "3 |   |   |   |   |   |   |   |   |   |   |\n" +
            "4 |   |   |   |   |   |   |   |   |   |   |\n" +
            "5 |   |   |   |   |   |   |   |   |   |   |\n" +
            "6 |   |   |   |   |   |   |   |   |   |   |\n" +
            "7 |   |   |   |   |   |   |   |   |   |   |\n" +
            "8 |   |   |   |   |   |   |   |   |   |   |\n" +
            "9 |   |   |   |   |   |   |   |   |   |   |";
        var acorazados = _acorazadosBuilder
            .ConstruirJugadorUno("David", tablero => { tablero.AgregarBarco(Barcos.Canonero, 1, 2); })
            .ConstruirJugadorDos("Diego", tablero => { tablero.AgregarBarco(Barcos.Canonero, 1, 1); }).Construir();
        acorazados.Iniciar();
        acorazados.Disparar(2, 2);

        acorazados.ImprimirTableroJugadorEnTurno().Should().Be(tableroEsperado);
    }

    [Fact]
    public void
        Si_JugadorUnoTieneUnCanoneroEnLaCoordenada1_1YJugadorDosDisparaACoordenada3_2_Debe_MostrarTableroActualDelJugadorUnoConUnCanoneroYUnTiroFallido()
    {
        var tableroEsperado =
            "  Jugador: David\n" +
            "  | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n" +
            "0 |   |   |   |   |   |   |   |   |   |   |\n" +
            "1 |   |   |   |   |   |   |   |   |   |   |\n" +
            "2 |   | g |   | o |   |   |   |   |   |   |\n" +
            "3 |   |   |   |   |   |   |   |   |   |   |\n" +
            "4 |   |   |   |   |   |   |   |   |   |   |\n" +
            "5 |   |   |   |   |   |   |   |   |   |   |\n" +
            "6 |   |   |   |   |   |   |   |   |   |   |\n" +
            "7 |   |   |   |   |   |   |   |   |   |   |\n" +
            "8 |   |   |   |   |   |   |   |   |   |   |\n" +
            "9 |   |   |   |   |   |   |   |   |   |   |";

        var acorazados = _acorazadosBuilder
            .ConstruirJugadorUno("David", tablero => { tablero.AgregarBarco(Barcos.Canonero, 1, 2); })
            .ConstruirJugadorDos("Diego", tablero => { tablero.AgregarBarco(Barcos.Canonero, 1, 1); }).Construir();
        acorazados.Iniciar();
        acorazados.Disparar(2, 2);
        acorazados.Disparar(3, 2);

        acorazados.ImprimirTableroJugadorEnTurno().Should().Be(tableroEsperado);
    }

    [Fact]
    public void
        Si_JugadorDosTieneUnDestructorEnLaCoordenada1_1EnPosicionHorizontalYJugadorUnoDisparaACoordenada1_1_Debe_MostrarTableroActualDelJugadorDosConUnDestructorYTiroExitoso()
    {
        var tableroEsperado =
            "  Jugador: Diego\n" +
            "  | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n" +
            "0 |   |   |   |   |   |   |   |   |   |   |\n" +
            "1 |   | x | d | d |   |   |   |   |   |   |\n" +
            "2 |   |   |   |   |   |   |   |   |   |   |\n" +
            "3 |   |   |   |   |   |   |   |   |   |   |\n" +
            "4 |   |   |   |   |   |   |   |   |   |   |\n" +
            "5 |   |   |   |   |   |   |   |   |   |   |\n" +
            "6 |   |   |   |   |   |   |   |   |   |   |\n" +
            "7 |   |   |   |   |   |   |   |   |   |   |\n" +
            "8 |   |   |   |   |   |   |   |   |   |   |\n" +
            "9 |   |   |   |   |   |   |   |   |   |   |";
        var acorazados = _acorazadosBuilder
            .ConstruirJugadorUno("David",
                tablero => { tablero.AgregarBarco(Barcos.Canonero, 1, 2, Orientacion.Horizontal); })
            .ConstruirJugadorDos("Diego", tablero => { tablero.AgregarBarco(Barcos.Destructor, 1, 1); }).Construir();
        acorazados.Iniciar();
        acorazados.Disparar(1, 1);

        acorazados.ImprimirTableroJugadorEnTurno().Should().Be(tableroEsperado);
    }

    [Fact]
    public void
        Si_JugadorDosTieneDosCanonerosEnLaCoordenadas1_1Y2_2YJugadorUnoHundeBarcoConCoordenada1_1_Debe_MostrarTableroActualDelJugadorDosConCanoneroHundidoEnCoordenada1_1YExistenteEnCoordenada2_2()
    {
        var tableroEsperado =
            "  Jugador: Diego\n" +
            "  | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n" +
            "0 |   |   |   |   |   |   |   |   |   |   |\n" +
            "1 |   | X |   |   |   |   |   |   |   |   |\n" +
            "2 |   |   | g |   |   |   |   |   |   |   |\n" +
            "3 |   |   |   |   |   |   |   |   |   |   |\n" +
            "4 |   |   |   |   |   |   |   |   |   |   |\n" +
            "5 |   |   |   |   |   |   |   |   |   |   |\n" +
            "6 |   |   |   |   |   |   |   |   |   |   |\n" +
            "7 |   |   |   |   |   |   |   |   |   |   |\n" +
            "8 |   |   |   |   |   |   |   |   |   |   |\n" +
            "9 |   |   |   |   |   |   |   |   |   |   |";
        var acorazados = _acorazadosBuilder
            .ConstruirJugadorUno("David", tablero => { tablero.AgregarBarco(Barcos.Canonero, 1, 2); })
            .ConstruirJugadorDos("Diego", tablero =>
            {
                tablero.AgregarBarco(Barcos.Canonero, 1, 1);
                tablero.AgregarBarco(Barcos.Canonero, 2, 2);
            }).Construir();
        acorazados.Iniciar();
        acorazados.Disparar(1, 1);

        acorazados.ImprimirTableroJugadorEnTurno().Should().Be(tableroEsperado);
    }

    [Fact]
    public void Si_ImprimoElInformeDeLaPartidaYElJuegoNoHaSidoFinalizado_Debe_LanzarExcepcion()
    {
        var acorazados = _acorazadosBuilder
            .ConstruirJugadorUno("David", tablero => { tablero.AgregarBarco(Barcos.Canonero, 1, 1); })
            .ConstruirJugadorDos("Diego", tablero => { tablero.AgregarBarco(Barcos.Canonero, 1, 1); }).Construir();
        acorazados.Iniciar();

        Action resultado = () => acorazados.ImprimirReporte();

        resultado.Should().ThrowExactly<InvalidOperationException>().WithMessage("El juego no se ha finalizado");
    }

    [Fact]
    public void Si_Jugador1DisparaYElJuegoSeHaFinalizadoYSeImprimeReporteJugadorDos_Debe_TotalDeDisparosSer1()
    {
        var acorazados = _acorazadosBuilder
            .ConstruirJugadorUno("David", tablero => { tablero.AgregarBarco(Barcos.Canonero, 1, 1); })
            .ConstruirJugadorDos("Diego", tablero => { tablero.AgregarBarco(Barcos.Canonero, 1, 1); }).Construir();
        acorazados.Iniciar();

        acorazados.Disparar(1, 1);

        var reporteJugador2 = acorazados.ObtenerJugador(1).ImprimirReporte();
        reporteJugador2.Should().Contain("Disparos totales: 1");
    }

    [Fact]
    public void Si_Jugador1DisparaDosVecesYElJuegoSeHaFinalizadoYSeImprimeReporteJugadorDos_Debe_TotalDeDisparosSer2()
    {
        var acorazados = _acorazadosBuilder
            .ConstruirJugadorUno("David", tablero => { tablero.AgregarBarco(Barcos.Canonero, 1, 1); })
            .ConstruirJugadorDos("Diego", tablero =>
            {
                tablero.AgregarBarco(Barcos.Canonero, 1, 1);
                tablero.AgregarBarco(Barcos.Canonero, 1, 2);
            }).Construir();
        acorazados.Iniciar();

        acorazados.Disparar(1, 1);
        acorazados.Disparar(1, 2);
        acorazados.Disparar(1, 2);

        var reporteGenerado = acorazados.ObtenerJugador(1).ImprimirReporte();

        reporteGenerado.Should().Contain("Disparos totales: 2");
    }

    [Fact]
    public void
        Si_Jugador1DisparaDosVecesYUnoDeLosTirosEsFallidoYElJuegoSeHaFinalizadoYSeImprimeReporteJugadorDos_Debe_TotalDeDisparosSer2YTotalDeTirosFallidosSer1()
    {
        var acorazados = _acorazadosBuilder
            .ConstruirJugadorUno("David", tablero => { tablero.AgregarBarco(Barcos.Canonero, 1, 1); })
            .ConstruirJugadorDos("Diego", tablero => { tablero.AgregarBarco(Barcos.Canonero, 1, 1); }).Construir();
        acorazados.Iniciar();
        acorazados.Disparar(1, 3);
        acorazados.Disparar(1, 2);
        acorazados.Disparar(1, 1);

        var reporteGenerado = acorazados.ObtenerJugador(1).ImprimirReporte();

        reporteGenerado.Should().Contain("Disparos totales: 2");
        reporteGenerado.Should().Contain("Fallidos: 1");
    }

    [Fact]
    public void
        Si_Jugador1DisparaDosVecesYAmbosTirosSonFallidosYElJuegoSeHaFinalizadoYSeImprimeReporteJugadorDos_Debe_TotalDeDisparosSer2YTotalDeTirosFallidosSer2()
    {
        var acorazados = _acorazadosBuilder
            .ConstruirJugadorUno("David", tablero => { tablero.AgregarBarco(Barcos.Canonero, 1, 1); })
            .ConstruirJugadorDos("Diego", tablero => { tablero.AgregarBarco(Barcos.Canonero, 1, 1); }).Construir();
        acorazados.Iniciar();
        acorazados.Disparar(1, 3);
        acorazados.Disparar(1, 2);
        acorazados.Disparar(1, 2);
        acorazados.Disparar(1, 1);

        var reporteGenerado = acorazados.ObtenerJugador(1).ImprimirReporte();

        reporteGenerado.Should().Contain("Disparos totales: 2");
        reporteGenerado.Should().Contain("Fallidos: 2");
    }

    [Fact]
    public void
        Si_Jugador1DisparaDosVecesYUnoDeLosTirosEsExitosoYElJuegoSeHaFinalizadoYSeImprimeReporteJugadorDos_Debe_TotalDeDisparosSer2YTotalDeTirosExitososSer1()
    {
        var acorazados = _acorazadosBuilder
            .ConstruirJugadorUno("David", tablero => { tablero.AgregarBarco(Barcos.Canonero, 1, 1); })
            .ConstruirJugadorDos("Diego", tablero => { tablero.AgregarBarco(Barcos.Canonero, 1, 1); }).Construir();
        acorazados.Iniciar();
        acorazados.Disparar(1, 2);
        acorazados.Disparar(1, 2);
        acorazados.Disparar(1, 1);
        var jugador2 = acorazados.ObtenerJugador(1);

        var reporteGenerado = acorazados.ObtenerJugador(1).ImprimirReporte();

        reporteGenerado.Should().Contain("Disparos totales: 2");
        reporteGenerado.Should().Contain("Exitosos: 1");
    }

    [Fact]
    public void
        Si_Jugador1DisparaDosVecesYAmbosTirosSonExitososYElJuegoSeHaFinalizadoYSeImprimeReporteJugadorDos_Debe_TotalDeDisparosSer2YTotalDeTirosExitososSer2()
    {
        var acorazados = _acorazadosBuilder
            .ConstruirJugadorUno("David", tablero => { tablero.AgregarBarco(Barcos.Canonero, 1, 1); })
            .ConstruirJugadorDos("Diego", tablero =>
            {
                tablero.AgregarBarco(Barcos.Canonero, 1, 1);
                tablero.AgregarBarco(Barcos.Canonero, 1, 2);
            }).Construir();
        acorazados.Iniciar();
        acorazados.Disparar(1, 2);
        acorazados.Disparar(1, 2);
        acorazados.Disparar(1, 1);

        var reporteGenerado = acorazados.ObtenerJugador(1).ImprimirReporte();

        reporteGenerado.Should().Contain("Disparos totales: 2");
        reporteGenerado.Should().Contain("Exitosos: 2");
    }

    [Fact]
    public void
        Si_Jugador1DisparaAlJugador2SinExitoYElJuegoSeHaFinalizadoYSeImprimeReporteJugadorDos_Debe_MostrarVaciaLaListaDeBarcosHundidos()
    {
        var acorazados = _acorazadosBuilder
            .ConstruirJugadorUno("David", tablero => { tablero.AgregarBarco(Barcos.Canonero, 1, 1); })
            .ConstruirJugadorDos("Diego", tablero =>
            {
                tablero.AgregarBarco(Barcos.Canonero, 1, 1);
                tablero.AgregarBarco(Barcos.Canonero, 1, 2);
            }).Construir();
        acorazados.Iniciar();
        acorazados.Disparar(1, 3);
        acorazados.Disparar(1, 1);
        var jugador2 = acorazados.ObtenerJugador(1);

        var reporteGenerado = acorazados.ObtenerJugador(1).ImprimirReporte();

        reporteGenerado.Should().Contain("Barcos hundidos: []");
    }

    [Fact]
    public void
        Si_Jugador1DisparaAlCanoneroDelJugador2ConCoordenada1_1YElJuegoSeHaFinalizadoYSeImprimeReporteJugadorDos_Debe_MostrarUnCanoneroConCoordenada1_1LaListaDeBarcosHundidos()
    {
        var acorazados = _acorazadosBuilder
            .ConstruirJugadorUno("David", tablero => { tablero.AgregarBarco(Barcos.Canonero, 1, 1); })
            .ConstruirJugadorDos("Diego", tablero =>
            {
                tablero.AgregarBarco(Barcos.Canonero, 1, 1);
                tablero.AgregarBarco(Barcos.Canonero, 1, 2);
            }).Construir();
        acorazados.Iniciar();
        acorazados.Disparar(1, 1);
        acorazados.Disparar(1, 1);
        var reporte1 = acorazados.ObtenerJugador(0).ImprimirReporte();
        var report2 = acorazados.ObtenerJugador(1).ImprimirReporte();

        report2.Should().Contain("Barcos hundidos: [ " +
                                 "cañonero: (1,1) ]");
    }

    [Fact]
    public void
        Si_Jugador1DisparaADosCanonerosDelJugador2ConCoordenadas1_11_2YElJuegoSeHaFinalizadoYSeImprimeReporteJugadorDos_Debe_MostrarDosCanoneroConCoordenada1_11_2EnLaListaDeBarcosHundidos()
    {
        var acorazados = _acorazadosBuilder
            .ConstruirJugadorUno("David", tablero => { tablero.AgregarBarco(Barcos.Canonero, 1, 1); })
            .ConstruirJugadorDos("Diego", tablero =>
            {
                tablero.AgregarBarco(Barcos.Canonero, 1, 1);
                tablero.AgregarBarco(Barcos.Canonero, 1, 2);
            }).Construir();
        acorazados.Iniciar();
        acorazados.Disparar(1, 1);
        acorazados.Disparar(1, 3);
        acorazados.Disparar(1, 2);
        
        var reporteGenerado = acorazados.ObtenerJugador(1).ImprimirReporte();

        reporteGenerado.Should().Contain("Barcos hundidos: [ " +
                                         "cañonero: (1,1)," +
                                         "cañonero: (1,2) ]");
    }

    [Fact]
    public void Si_SeJuegaUnaPartidaCompletaConMultiplesBarcosYDisparos_Debe_ImprimirReporteCompletoDeAmbosJugadores()
    {
        var acorazados = _acorazadosBuilder
            .ConstruirJugadorUno("David", tablero =>
            {
                tablero.AgregarBarco(Barcos.Canonero, 1, 1, Orientacion.Horizontal);
                tablero.AgregarBarco(Barcos.Canonero, 3, 3, Orientacion.Horizontal);
                tablero.AgregarBarco(Barcos.Destructor, 5, 5, Orientacion.Horizontal);
                tablero.AgregarBarco(Barcos.Destructor, 7, 7, Orientacion.Vertical);
            })
            .ConstruirJugadorDos("Diego", tablero =>
            {
                tablero.AgregarBarco(Barcos.Canonero, 2, 2, Orientacion.Horizontal);
                tablero.AgregarBarco(Barcos.Canonero, 8, 8, Orientacion.Horizontal);
                tablero.AgregarBarco(Barcos.Destructor, 4, 4, Orientacion.Vertical);
                tablero.AgregarBarco(Barcos.Portaaviones, 0, 0, Orientacion.Horizontal);
            }).Construir();
        acorazados.Iniciar();

        // Jugador 1 dispara al Jugador 2
        acorazados.Disparar(2, 2); // Canonero - Hundido

        // Jugador 2 dispara al Jugador 1
        acorazados.Disparar(9, 9); // Agua

        // Jugador 1 dispara al Jugador 2
        acorazados.Disparar(9, 9); // Agua

        // Jugador 2 dispara al Jugador 1
        acorazados.Disparar(1, 1); // Canonero - Hundido

        // Jugador 1 dispara al Jugador 2
        acorazados.Disparar(4, 4); // Destructor - Tiro exitoso

        // Jugador 2 dispara al Jugador 1
        acorazados.Disparar(3, 3); // Canonero - Hundido

        // Jugador 1 dispara al Jugador 2
        acorazados.Disparar(5, 4); // Destructor - Tiro exitoso

        // Jugador 2 dispara al Jugador 1
        acorazados.Disparar(5, 5); // Destructor - Tiro exitoso

        // Jugador 1 dispara al Jugador 2
        acorazados.Disparar(6, 4); // Destructor - Hundido

        // Jugador 2 dispara al Jugador 1
        acorazados.Disparar(6, 5); // Destructor - Tiro exitoso

        // Jugador 1 dispara al Jugador 2
        acorazados.Disparar(0, 0); // Portaaviones - Tiro exitoso

        // Jugador 2 dispara al Jugador 1
        acorazados.Disparar(7, 5); // Destructor - Hundido

        // Jugador 1 dispara al Jugador 2
        acorazados.Disparar(1, 0); // Portaaviones - Tiro exitoso

        // Jugador 2 dispara al Jugador 1
        acorazados.Disparar(7, 7); // Destructor - Tiro exitoso

        // Jugador 1 dispara al Jugador 2
        acorazados.Disparar(2, 0); // Portaaviones - Tiro exitoso

        // Jugador 2 dispara al Jugador 1
        acorazados.Disparar(8, 7); // Destructor - Tiro exitoso

        // Jugador 1 dispara al Jugador 2
        acorazados.Disparar(3, 0); // Portaaviones - Hundido

        // Jugador 2 dispara al Jugador 1
        acorazados.Disparar(9, 7); // Destructor - Hundido

        // Jugador 1 dispara al Jugador 2
        acorazados.Disparar(8, 8); // Portaaviones - Hundido

        // Jugador 2 dispara al Jugador 1
        acorazados.Disparar(0, 1); // Destructor - Hundido

        // Jugador 1 dispara al Jugador 2
        acorazados.Disparar(4, 5); // Destructor - Tiro exitoso

        // Jugador 2 dispara al Jugador 1
        acorazados.Disparar(0, 2); // Destructor - Hundido

        // Jugador 1 dispara al Jugador 2
        acorazados.Disparar(4, 6); // Destructor - Tiro exitoso
        
        
        var reporte = acorazados.ImprimirReporte();

        //Estadísticas del jugador 1
        reporte.Should().Contain("  Jugador: David\n" +
                                 "Disparos totales: 11 \n" +
                                 " Fallidos: 5\n" +
                                 " Exitosos: 6\n" +
                                 " Barcos hundidos: [ " +
                                 "cañonero: (1,1)," +
                                 "cañonero: (3,3)," +
                                 "destructor: (5,5) ]");
        
         //Estadísticas del jugador 2
         reporte.Should().Contain("  Jugador: Diego\n" +
                                  "Disparos totales: 12 \n" +
                                  " Fallidos: 3\n" +
                                  " Exitosos: 9\n" +
                                  " Barcos hundidos: [ " +
                                  "cañonero: (2,2)," +
                                  "cañonero: (8,8)," +
                                  "destructor: (4,4)," +
                                  "portaaviones: (0,0) ]");
    }

    [Fact]
    public void Si_SeJuegaUnaPartidaCompletaConMultiplesBarcosYDisparos_Debe_ImprimirReporteYTableroFinal()
    {
        var tableroEsperadoJugador1 =
            "  Jugador: David\n" +
            "  | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n" +
            "0 |   |   |   |   |   |   |   |   |   |   |\n" +
            "1 | o | X |   |   |   |   |   |   |   |   |\n" +
            "2 | o |   |   |   |   |   |   |   |   |   |\n" +
            "3 |   |   |   | X |   |   |   |   |   |   |\n" +
            "4 |   |   |   |   |   |   |   |   |   |   |\n" +
            "5 |   |   |   |   |   | X | X | X |   |   |\n" +
            "6 |   |   |   |   |   |   |   |   |   |   |\n" +
            "7 |   |   |   |   |   |   |   | x | o | o |\n" +
            "8 |   |   |   |   |   |   |   | d |   |   |\n" +
            "9 |   |   |   |   |   |   |   | d |   | o |";


        var tableroEsperadoJugador2 =
            "  Jugador: Diego\n" +
            "  | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n" +
            "0 | X | X | X | X |   |   |   |   |   |   |\n" +
            "1 |   |   |   |   |   |   |   |   |   |   |\n" +
            "2 |   |   | X |   |   |   |   |   |   |   |\n" +
            "3 |   |   |   |   |   |   |   |   |   |   |\n" +
            "4 |   |   |   |   | X | o | o |   |   |   |\n" +
            "5 |   |   |   |   | X |   |   |   |   |   |\n" +
            "6 |   |   |   |   | X |   |   |   |   |   |\n" +
            "7 |   |   |   |   |   |   |   |   |   |   |\n" +
            "8 |   |   |   |   |   |   |   |   | X |   |\n" +
            "9 |   |   |   |   |   |   |   |   |   | o |";


        var acorazados = _acorazadosBuilder
            .ConstruirJugadorUno("David", tablero =>
            {
                tablero.AgregarBarco(Barcos.Canonero, 1, 1, Orientacion.Horizontal);
                tablero.AgregarBarco(Barcos.Canonero, 3, 3, Orientacion.Horizontal);
                tablero.AgregarBarco(Barcos.Destructor, 5, 5, Orientacion.Horizontal);
                tablero.AgregarBarco(Barcos.Destructor, 7, 7, Orientacion.Vertical);
            })
            .ConstruirJugadorDos("Diego", tablero =>
            {
                tablero.AgregarBarco(Barcos.Canonero, 2, 2, Orientacion.Horizontal);
                tablero.AgregarBarco(Barcos.Canonero, 8, 8, Orientacion.Horizontal);
                tablero.AgregarBarco(Barcos.Destructor, 4, 4, Orientacion.Vertical);
                tablero.AgregarBarco(Barcos.Portaaviones, 0, 0, Orientacion.Horizontal);
            })
            .Construir();

        acorazados.Iniciar();


        acorazados.Disparar(2, 2);
        acorazados.Disparar(9, 9);
        acorazados.Disparar(9, 9);
        acorazados.Disparar(1, 1);
        acorazados.Disparar(4, 4);
        acorazados.Disparar(3, 3);
        acorazados.Disparar(5, 4);
        acorazados.Disparar(5, 5);
        acorazados.Disparar(6, 4);
        acorazados.Disparar(6, 5);
        acorazados.Disparar(0, 0);
        acorazados.Disparar(7, 5);
        acorazados.Disparar(1, 0);
        acorazados.Disparar(7, 7);
        acorazados.Disparar(2, 0);
        acorazados.Disparar(8, 7);
        acorazados.Disparar(3, 0);
        acorazados.Disparar(9, 7);
        acorazados.Disparar(8, 8);
        acorazados.Disparar(0, 1);
        acorazados.Disparar(4, 5);
        acorazados.Disparar(0, 2);
        acorazados.Disparar(4, 6);

        acorazados.EstadoJuego.Should().Be(EstadoJuego.Finalizado);


        var reporteJugador1 = acorazados.ObtenerJugador(0).ImprimirReporte();
        var tableroJugador1 = acorazados.ObtenerJugador(0).ImprimirTablero();

        var reporteJugador2 = acorazados.ObtenerJugador(1).ImprimirReporte();
        var tableroJugador2 = acorazados.ObtenerJugador(1).ImprimirTablero();

        reporteJugador1.Should().Contain("Disparos totales: 11");
        reporteJugador1.Should().Contain("Exitosos: 6");
        reporteJugador1.Should().Contain("Fallidos: 5");

        reporteJugador2.Should().Contain("Disparos totales: 12");
        reporteJugador2.Should().Contain("Exitosos: 9");
        reporteJugador2.Should().Contain("Fallidos: 3");


        reporteJugador2.Should().Contain("cañonero: (2,2)");
        reporteJugador2.Should().Contain("destructor: (4,4)");
        reporteJugador2.Should().Contain("portaaviones: (0,0)");

        reporteJugador1.Should().Contain("cañonero: (1,1)");
        reporteJugador1.Should().Contain("cañonero: (3,3)");
        reporteJugador1.Should().Contain("destructor: (5,5)");


        tableroJugador1.Should().Be(tableroEsperadoJugador1);
        tableroJugador2.Should().Be(tableroEsperadoJugador2);
    }
}
using System.Collections.ObjectModel;
using System.Runtime.ExceptionServices;
using AwesomeAssertions;

namespace BattleshipsTDD;

public class BattleshipsTest
{
    public BattleshipsTest()
    {
    }

    [Fact]
    public void Si_SeCreaUnTablero10X10_Al_Imprimirlo_Debe_MostrarUnTableroVacioDe10X10()
    {
        //Arrange
        var batallaNaval = new BatallaNaval();
        batallaNaval.AddPlayer();
        //Act
        string tablero = batallaNaval.Print();

        //Assert
        string tableroEsperado = "   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n" +
                                 " 0 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 1 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 2 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 3 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 4 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 5 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 6 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 7 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 8 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 9 |   |   |   |   |   |   |   |   |   |   |\n";
        tablero.Should().Be(tableroEsperado);
    }

    [Fact]
    public void Si_ElJugador1AgregaUnaCañoneraEnPosicion0_0_Debe_AparecerEnElTableroDelJugador1LaPosicion0_0LaCañonera()
    {
        //Arrange
        var batallaNaval = new BatallaNaval();
        batallaNaval.AddPlayer();

        //Act
        batallaNaval.ColocarBarco(jugador: 1, columna: 0, fila: 0, tipo: TipoBarco.Cañonero);
        string tablero = batallaNaval.Print();

        //Assert 
        string tableroEsperado = "   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n" +
                                 " 0 | g |   |   |   |   |   |   |   |   |   |\n" +
                                 " 1 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 2 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 3 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 4 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 5 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 6 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 7 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 8 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 9 |   |   |   |   |   |   |   |   |   |   |\n";
        tablero.Should().Be(tableroEsperado);
    }

    [Fact]
    public void Si_SeCreaUnTablero09X09_Al_Imprimirlo_Debe_MostrarUnTableroVacioDe09X09()
    {
        //Arrange
        var batallaNaval = new BatallaNaval(filasTablero: 9, columnasTablero: 9);
        batallaNaval.AddPlayer();
        //Act
        string tablero = batallaNaval.Print();

        //Assert
        string tableroEsperado = "   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 |\n" +
                                 " 0 |   |   |   |   |   |   |   |   |   |\n" +
                                 " 1 |   |   |   |   |   |   |   |   |   |\n" +
                                 " 2 |   |   |   |   |   |   |   |   |   |\n" +
                                 " 3 |   |   |   |   |   |   |   |   |   |\n" +
                                 " 4 |   |   |   |   |   |   |   |   |   |\n" +
                                 " 5 |   |   |   |   |   |   |   |   |   |\n" +
                                 " 6 |   |   |   |   |   |   |   |   |   |\n" +
                                 " 7 |   |   |   |   |   |   |   |   |   |\n" +
                                 " 8 |   |   |   |   |   |   |   |   |   |\n";
        tablero.Should().Be(tableroEsperado);
    }

    [Fact]
    public void Si_ElJugador1AgregaUnaCañoneraEnPosicion1_1_Debe_AparecerEnElTableroDelJugador1LaPosicion1_1LaCañonera()
    {
        //Arrange
        var batallaNaval = new BatallaNaval();
        batallaNaval.AddPlayer();

        //Act
        batallaNaval.ColocarBarco(jugador: 1, columna: 1, fila: 1, tipo: TipoBarco.Cañonero);
        string tablero = batallaNaval.Print();

        //Assert 
        string tableroEsperado = "   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n" +
                                 " 0 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 1 |   | g |   |   |   |   |   |   |   |   |\n" +
                                 " 2 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 3 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 4 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 5 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 6 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 7 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 8 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 9 |   |   |   |   |   |   |   |   |   |   |\n";
        tablero.Should().Be(tableroEsperado);
    }


    [Fact]
    public void
        Si_ElJugador1AgregaUnDestructorEnPosicion1_1ConOrientacionHorizontal_Debe_AparecerEnElTableroDelJugador1LaPosicion1_1Y1_2Y1_3ElDestructor()
    {
        //Arrange
        var batallaNaval = new BatallaNaval();
        batallaNaval.AddPlayer();

        //Act
        batallaNaval.ColocarBarco(jugador: 1, fila: 1, columna: 1, tipo: TipoBarco.Destructor,
            orientacion: TipoOrientacion.Horizontal);
        string tablero = batallaNaval.Print();

        //Assert 
        string tableroEsperado = "   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n" +
                                 " 0 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 1 |   | d | d | d |   |   |   |   |   |   |\n" +
                                 " 2 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 3 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 4 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 5 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 6 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 7 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 8 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 9 |   |   |   |   |   |   |   |   |   |   |\n";
        tablero.Should().Be(tableroEsperado);
    }

    [Fact]
    public void
        Si_ElJugador1AgregaUnDestructorEnPosicion1_1ConOrientacionVertical_Debe_AparecerEnElTableroDelJugador1LaPosicion1_1Y2_1Y3_1ElDestructor()
    {
        //Arrange
        var batallaNaval = new BatallaNaval();
        batallaNaval.AddPlayer();

        //Act
        batallaNaval.ColocarBarco(jugador: 1, fila: 1, columna: 1, tipo: TipoBarco.Destructor,
            orientacion: TipoOrientacion.Vertical);
        string tablero = batallaNaval.Print();

        //Assert 
        string tableroEsperado = "   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n" +
                                 " 0 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 1 |   | d |   |   |   |   |   |   |   |   |\n" +
                                 " 2 |   | d |   |   |   |   |   |   |   |   |\n" +
                                 " 3 |   | d |   |   |   |   |   |   |   |   |\n" +
                                 " 4 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 5 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 6 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 7 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 8 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 9 |   |   |   |   |   |   |   |   |   |   |\n";
        tablero.Should().Be(tableroEsperado);
    }

    [Fact]
    public void
        Si_ElJugador1AgregaUnPortaavionesEnPosicion1_1ConOrientacionVertical_Debe_AparecerEnElTableroDelJugador1LaPosicion1_1Y2_1Y3_1Y4_1ElPortaaviones()
    {
        //Arrange
        var batallaNaval = new BatallaNaval();
        batallaNaval.AddPlayer();

        //Act
        batallaNaval.ColocarBarco(jugador: 1, fila: 1, columna: 1, tipo: TipoBarco.PortaAviones,
            orientacion: TipoOrientacion.Vertical);
        string tablero = batallaNaval.Print();

        //Assert 
        string tableroEsperado = "   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n" +
                                 " 0 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 1 |   | c |   |   |   |   |   |   |   |   |\n" +
                                 " 2 |   | c |   |   |   |   |   |   |   |   |\n" +
                                 " 3 |   | c |   |   |   |   |   |   |   |   |\n" +
                                 " 4 |   | c |   |   |   |   |   |   |   |   |\n" +
                                 " 5 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 6 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 7 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 8 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 9 |   |   |   |   |   |   |   |   |   |   |\n";
        tablero.Should().Be(tableroEsperado);
    }

    [Fact]
    public void
        Si_ElJugador1AgregaUnPortaavionesEnPosicion1_1ConOrientacionHorizonta_Debe_AparecerEnElTableroDelJugador1LaPosicion1_1Y1_2Y1_3Y1_4ElPortaaviones()
    {
        //Arrange
        var batallaNaval = new BatallaNaval();
        batallaNaval.AddPlayer();

        //Act
        batallaNaval.ColocarBarco(jugador: 1, fila: 1, columna: 1, tipo: TipoBarco.PortaAviones,
            orientacion: TipoOrientacion.Horizontal);
        string tablero = batallaNaval.Print();

        //Assert 
        string tableroEsperado = "   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n" +
                                 " 0 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 1 |   | c | c | c | c |   |   |   |   |   |\n" +
                                 " 2 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 3 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 4 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 5 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 6 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 7 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 8 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 9 |   |   |   |   |   |   |   |   |   |   |\n";
        tablero.Should().Be(tableroEsperado);
    }

    [Fact]
    public void
        Si_ElJugador1AgregaUnaCañoneroEnPosicion1_1_y_El_jugador2AgregaUnaCañoneroEnPosicion2_2_Debe_AparecerEnElTableroDelJugador2UnicamenteEnLaPosicion2_2UnaCañonero()
    {
        //Arrange
        var batallaNaval = new BatallaNaval();
        batallaNaval.AddPlayer();
        batallaNaval.AddPlayer();

        //Act
        batallaNaval.ColocarBarco(jugador: 1, fila: 1, columna: 1, tipo: TipoBarco.Cañonero);
        batallaNaval.ColocarBarco(jugador: 2, fila: 2, columna: 2, tipo: TipoBarco.Cañonero);
        string tablero = batallaNaval.Print(jugador: 2);

        //Assert 
        string tableroEsperado = "   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n" +
                                 " 0 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 1 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 2 |   |   | g |   |   |   |   |   |   |   |\n" +
                                 " 3 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 4 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 5 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 6 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 7 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 8 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 9 |   |   |   |   |   |   |   |   |   |   |\n";
        tablero.Should().Be(tableroEsperado);
    }

    [Fact]
    public void
        Si_ElJugador1AgregaUnaCañoneroEnPosicion1_1_y_El_jugador2AgregaUnaCañoneroEnPosicion2_2Y_El_jugador3AgregaUnaCañoneroEnPosicion3_3_Debe_AparecerEnElTableroDelJugador3UnicamenteEnLaPosicion3_3UnaCañonero()
    {
        //Arrange
        var batallaNaval = new BatallaNaval();
        batallaNaval.AddPlayer();
        batallaNaval.AddPlayer();
        batallaNaval.AddPlayer();

        //Act
        batallaNaval.ColocarBarco(jugador: 1, fila: 1, columna: 1, tipo: TipoBarco.Cañonero);
        batallaNaval.ColocarBarco(jugador: 2, fila: 2, columna: 2, tipo: TipoBarco.Cañonero);
        batallaNaval.ColocarBarco(jugador: 3, fila: 3, columna: 3, tipo: TipoBarco.Cañonero);
        string tablero = batallaNaval.Print(jugador: 3);

        //Assert 
        string tableroEsperado = "   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n" +
                                 " 0 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 1 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 2 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 3 |   |   |   | g |   |   |   |   |   |   |\n" +
                                 " 4 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 5 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 6 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 7 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 8 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 9 |   |   |   |   |   |   |   |   |   |   |\n";
        tablero.Should().Be(tableroEsperado);
    }

    [Fact]
    public void
        Si_AlIniciaLaPartidaElPrimerJugadorAtacaEnPosicion2_2_Y_FinalizaElTurno_Y_SegundoJugadorAtacaEnPosicion1_1_Debe_MostrarEnElTableroDelJugador2ComoLaUnicaPosicionAtacada_2_2()
    {
        //Arrange
        var batallaNaval = new BatallaNaval();
        batallaNaval.AddPlayer();
        batallaNaval.AddPlayer();
        batallaNaval.AddPlayer();
        batallaNaval.ColocarBarco(jugador: 1, fila: 3, columna: 3, tipo: TipoBarco.Cañonero);
        batallaNaval.ColocarBarco(jugador: 2, fila: 1, columna: 1, tipo: TipoBarco.Cañonero);
        batallaNaval.Start();
        batallaNaval.Fire(fila: 2, columna: 2); // ataque jugador 1 => mod al 2
        batallaNaval.EndTurn();
        batallaNaval.Fire(fila: 1, columna: 1); // ataque jugador 2 => mod al 1

        //Act

        string tablero = batallaNaval.Print(jugador: 2);


        //Assert 
        string tableroEsperado = "   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n" +
                                 " 0 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 1 |   | g |   |   |   |   |   |   |   |   |\n" +
                                 " 2 |   |   | o |   |   |   |   |   |   |   |\n" +
                                 " 3 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 4 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 5 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 6 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 7 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 8 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 9 |   |   |   |   |   |   |   |   |   |   |\n";
        tablero.Should().Be(tableroEsperado);
    }

    [Fact]
    public void
        Si_AlIniciaLaPartidaElPrimerJugadorAtacaEnPosicion2_2_Y_FinalizaElTurno_Y_SegundoJugadorAtacaEnPosicion1_1_Debe_MostrarEnElTableroDelJugador1ComoLaUnicaPosicionAtacada_1_1()
    {
        //Arrange
        var batallaNaval = new BatallaNaval();
        batallaNaval.AddPlayer();
        batallaNaval.AddPlayer();
        batallaNaval.ColocarBarco(jugador: 1, fila: 3, columna: 3, tipo: TipoBarco.Cañonero);
        batallaNaval.ColocarBarco(jugador: 2, fila: 1, columna: 1, tipo: TipoBarco.Cañonero);
        batallaNaval.Start();
        batallaNaval.Fire(fila: 2, columna: 2); // ataque jugador 1 => mod al 2
        batallaNaval.EndTurn();
        batallaNaval.Fire(fila: 1, columna: 1); // ataque jugador 2 => mod al 1

        //Act

        string tablero = batallaNaval.Print(jugador: 1);


        //Assert 
        string tableroEsperado = "   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n" +
                                 " 0 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 1 |   | o |   |   |   |   |   |   |   |   |\n" +
                                 " 2 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 3 |   |   |   | g |   |   |   |   |   |   |\n" +
                                 " 4 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 5 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 6 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 7 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 8 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 9 |   |   |   |   |   |   |   |   |   |   |\n";
        tablero.Should().Be(tableroEsperado);
    }

    [Fact]
    public void
        Si_AlIniciaLaPartidaElPrimerJugadorAtacaEnPosicion1_1_Y_FinalizaElTurno_Y_SegundoJugadorTieneUnCañeroEnPosicion_1_1_Debe_MostrarEnElTableroDelJugador2LaPosicion_1_1ComoLaUnicaImpactada()
    {
        //Arrange
        var batallaNaval = new BatallaNaval();
        batallaNaval.AddPlayer();
        batallaNaval.AddPlayer();
        batallaNaval.ColocarBarco(jugador: 1, fila: 3, columna: 3, tipo: TipoBarco.Cañonero);
        batallaNaval.ColocarBarco(jugador: 2, fila: 1, columna: 1, tipo: TipoBarco.Cañonero);
        batallaNaval.Start();

        //Act
        batallaNaval.Fire(fila: 1, columna: 1);
        string tablero = batallaNaval.Print(jugador: 2);

        //Assert 
        string tableroEsperado = "   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n" +
                                 " 0 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 1 |   | X |   |   |   |   |   |   |   |   |\n" +
                                 " 2 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 3 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 4 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 5 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 6 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 7 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 8 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 9 |   |   |   |   |   |   |   |   |   |   |\n";
        tablero.Should().Be(tableroEsperado);
    }

    [Fact]
    public void
        Si_AlIniciarLaPartidaElPrimerJugadorAtacaEnPosicion1_1_Y_FinalizaElTurno_Y_SegundoJugadorTieneUnDestructorEnPosicion_1_1_Debe_MostrarEnElTableroDelJugador2LaPosicion_1_1ComoLaUnicaImpactada_xí()
    {
        //Arrange
        var batallaNaval = new BatallaNaval();
        batallaNaval.AddPlayer();
        batallaNaval.AddPlayer();
        batallaNaval.ColocarBarco(jugador: 1, fila: 3, columna: 3, tipo: TipoBarco.Cañonero);
        batallaNaval.ColocarBarco(jugador: 2, fila: 1, columna: 1, tipo: TipoBarco.Destructor,
            orientacion: TipoOrientacion.Horizontal);
        batallaNaval.Start();

        //Act
        batallaNaval.Fire(fila: 1, columna: 1);
        string tablero = batallaNaval.Print(jugador: 2);

        //Assert 
        string tableroEsperado = "   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n" +
                                 " 0 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 1 |   | x | d | d |   |   |   |   |   |   |\n" +
                                 " 2 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 3 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 4 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 5 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 6 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 7 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 8 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 9 |   |   |   |   |   |   |   |   |   |   |\n";
        tablero.Should().Be(tableroEsperado);
    }

    [Fact]
    public void
        Si_AlIniciarLaPartidaElPrimerJugadorAtacaLasPosicion1_1_y_1_2Y_FinalizaElTurno_Y_SegundoJugadorTieneUnDestructorEnPosicion_1_1_Debe_MostrarEnElTableroDelJugador2LaPosicion_1_1_y_1_2ComoLaUnicaImpactada_x()
    {
        //Arrange
        var batallaNaval = new BatallaNaval();
        batallaNaval.AddPlayer();
        batallaNaval.AddPlayer();
        batallaNaval.ColocarBarco(jugador: 1, fila: 3, columna: 3, tipo: TipoBarco.Cañonero);
        batallaNaval.ColocarBarco(jugador: 2, fila: 1, columna: 1, tipo: TipoBarco.Destructor,
            orientacion: TipoOrientacion.Horizontal);
        batallaNaval.Start();

        //Act
        batallaNaval.Fire(fila: 1, columna: 1);
        batallaNaval.Fire(fila: 1, columna: 2);
        string tablero = batallaNaval.Print(jugador: 2);

        //Assert 
        string tableroEsperado = "   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n" +
                                 " 0 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 1 |   | x | x | d |   |   |   |   |   |   |\n" +
                                 " 2 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 3 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 4 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 5 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 6 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 7 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 8 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 9 |   |   |   |   |   |   |   |   |   |   |\n";
        tablero.Should().Be(tableroEsperado);
    }

    [Fact]
    public void
        Si_ElJugador1ColocoUnaCañoneraEnPosicion3_3YElJugador2ColocoUnaCañoneraEnPosicion1_1YUnicamenteElJugador1RealizaUnAtaqueEnPosicion_1_1E_Impacta_Debe_ElInformeGeneralDelJugador1Tener0DisparosRecibidos0DisparosAsertadosEnemigo0DisparosFalladosEnemigoYEnTableroConPosicion3_3UnaCañonera()
    {
        //Arrange
        var batallaNaval = new BatallaNaval();
        batallaNaval.AddPlayer();
        batallaNaval.AddPlayer();
        batallaNaval.ColocarBarco(jugador: 1, fila: 3, columna: 3, tipo: TipoBarco.Cañonero);
        batallaNaval.ColocarBarco(jugador: 2, fila: 1, columna: 1, tipo: TipoBarco.Cañonero);
        batallaNaval.Start();
        batallaNaval.Fire(fila: 1, columna: 1);

        //Act
        var informe = batallaNaval.InformeGeneral()[1];
        var disparosRecibidos = informe.DisparosRecibidos;
        var disparosAsertadosEnemigo = informe.DisparosAsertadosEnemigo;
        var disparosFalladosEnemigo = informe.DisparosFalladosEnemigo;
        var tablero = informe.RepresentacionTablero;

        //Assert 
        string tableroEsperado = "   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n" +
                                 " 0 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 1 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 2 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 3 |   |   |   | g |   |   |   |   |   |   |\n" +
                                 " 4 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 5 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 6 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 7 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 8 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 9 |   |   |   |   |   |   |   |   |   |   |\n";
        tablero.Should().Be(tableroEsperado);
        disparosAsertadosEnemigo.Should().Be(0);
        disparosFalladosEnemigo.Should().Be(0);
        disparosRecibidos.Should().Be(0);
    }

    [Fact]
    public void
        Si_ElJugador1ColocoUnaCañoneraEnPosicion3_3YElJugador2ColocoUnaCañoneraEnPosicion1_1YElJugador1RealizaUnAtaqueEnPosicion_2_2YElJugador1RealizaUnAtaqueEnPosicion_0_0YElJugador1RealizaUnAtaqueEnPosicion_1_1_Debe_ElInformeGeneralDelJugador1Tener1DisparosRecibidos0DisparosAsertadosEnemigo1DisparosFalladosEnemigoYEnTableroConPosicion3_3UnaCañonera()
    {
        //Arrange
        var batallaNaval = new BatallaNaval();
        batallaNaval.AddPlayer();
        batallaNaval.AddPlayer();
        batallaNaval.ColocarBarco(jugador: 1, fila: 3, columna: 3, tipo: TipoBarco.Cañonero);
        batallaNaval.ColocarBarco(jugador: 2, fila: 1, columna: 1, tipo: TipoBarco.Cañonero);
        batallaNaval.Start();
        batallaNaval.Fire(fila: 2, columna: 2);
        batallaNaval.EndTurn();
        batallaNaval.Fire(fila: 0, columna: 0);
        batallaNaval.EndTurn();
        batallaNaval.Fire(fila: 1, columna: 1);

        //Act
        var informe = batallaNaval.InformeGeneral()[1];
        var disparosRecibidos = informe.DisparosRecibidos;
        var disparosAsertadosEnemigo = informe.DisparosAsertadosEnemigo;
        var disparosFalladosEnemigo = informe.DisparosFalladosEnemigo;
        var tablero = informe.RepresentacionTablero;

        //Assert 
        string tableroEsperado = "   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n" +
                                 " 0 | o |   |   |   |   |   |   |   |   |   |\n" +
                                 " 1 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 2 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 3 |   |   |   | g |   |   |   |   |   |   |\n" +
                                 " 4 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 5 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 6 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 7 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 8 |   |   |   |   |   |   |   |   |   |   |\n" +
                                 " 9 |   |   |   |   |   |   |   |   |   |   |\n";
        tablero.Should().Be(tableroEsperado);
        disparosRecibidos.Should().Be(1);
        disparosAsertadosEnemigo.Should().Be(0);
        disparosFalladosEnemigo.Should().Be(1);
    }

    [Fact]
    public void
        Si_ElSeSolicitaElInformeGeneralDelJuegoYExistenDosJugadoresElInforme_Debe_MostrarLaRepresentacionDelTableroDeLosDosJugadores()
    {
        //Arrange
        var batallaNaval = new BatallaNaval();
        batallaNaval.AddPlayer();
        batallaNaval.AddPlayer();
        batallaNaval.ColocarBarco(jugador: 1, fila: 3, columna: 3, tipo: TipoBarco.Cañonero);
        batallaNaval.ColocarBarco(jugador: 2, fila: 1, columna: 1, tipo: TipoBarco.Cañonero);
        batallaNaval.Start();
        batallaNaval.Fire(fila: 2, columna: 2);
        batallaNaval.EndTurn();
        batallaNaval.Fire(fila: 0, columna: 0);
        batallaNaval.EndTurn();
        batallaNaval.Fire(fila: 1, columna: 1);

        //Act
        var informe = batallaNaval.InformeGeneral();
        var tableroJugador1 = informe[1].RepresentacionTablero;
        var tableroJugador2 = informe[2].RepresentacionTablero;

        //Assert 
        string tableroEsperadoJugador1 = "   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n" +
                                         " 0 | o |   |   |   |   |   |   |   |   |   |\n" +
                                         " 1 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 2 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 3 |   |   |   | g |   |   |   |   |   |   |\n" +
                                         " 4 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 5 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 6 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 7 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 8 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 9 |   |   |   |   |   |   |   |   |   |   |\n";


        string tableroEsperadoJugador2 = "   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n" +
                                         " 0 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 1 |   | X |   |   |   |   |   |   |   |   |\n" +
                                         " 2 |   |   | o |   |   |   |   |   |   |   |\n" +
                                         " 3 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 4 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 5 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 6 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 7 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 8 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 9 |   |   |   |   |   |   |   |   |   |   |\n";
        tableroJugador1.Should().Be(tableroEsperadoJugador1);
        tableroJugador2.Should().Be(tableroEsperadoJugador2);
    }

    [Fact]
    public void
        Si_SeSolicitaLosBarcosUndidosDelJugador2YElJugador2TieneUnCañoneroUndidoEnLaPosicion1_1ElInforme_Debe_MostrarUnCañoneroUnidoEnLaPosicion1_1()
    {
        //Arrange
        var batallaNaval = new BatallaNaval();
        batallaNaval.AddPlayer();
        batallaNaval.AddPlayer();
        batallaNaval.ColocarBarco(jugador: 1, fila: 3, columna: 3, tipo: TipoBarco.Cañonero);
        batallaNaval.ColocarBarco(jugador: 2, fila: 1, columna: 1, tipo: TipoBarco.Cañonero);
        batallaNaval.Start();
        batallaNaval.Fire(fila: 2, columna: 2);
        batallaNaval.EndTurn();
        batallaNaval.Fire(fila: 0, columna: 0);
        batallaNaval.EndTurn();
        batallaNaval.Fire(fila: 1, columna: 1);


        //Act
        var informe = batallaNaval.InformeGeneral()[2];
        var tableroJugador2 = informe.RepresentacionTablero;
        var barcosUndidos = informe.ObtenerBarcosUndidos();

        //Assert 
        string tableroEsperadoJugador2 = "   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n" +
                                         " 0 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 1 |   | X |   |   |   |   |   |   |   |   |\n" +
                                         " 2 |   |   | o |   |   |   |   |   |   |   |\n" +
                                         " 3 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 4 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 5 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 6 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 7 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 8 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 9 |   |   |   |   |   |   |   |   |   |   |\n";

        tableroJugador2.Should().Be(tableroEsperadoJugador2);
        barcosUndidos.Should().HaveCount(1);
        barcosUndidos[0].Should().BeEquivalentTo((TipoBarco.Cañonero, new Coordenada(1, 1)));
    }

    [Fact]
    public void
        Si_SeSolicitaLosBarcosUndidosDelJugador2YElJugador2TieneUnCañoneroUndidoEnLaPosicion5_5ElInforme_Debe_MostrarUnCañoneroUnidoEnLaPosicion1_1()
    {
        //Arrange
        var batallaNaval = new BatallaNaval();
        batallaNaval.AddPlayer();
        batallaNaval.AddPlayer();
        batallaNaval.ColocarBarco(jugador: 1, fila: 3, columna: 3, tipo: TipoBarco.Cañonero);
        batallaNaval.ColocarBarco(jugador: 2, fila: 5, columna: 5, tipo: TipoBarco.Cañonero);
        batallaNaval.Start();
        batallaNaval.Fire(fila: 2, columna: 2);
        batallaNaval.EndTurn();
        batallaNaval.Fire(fila: 0, columna: 0);
        batallaNaval.EndTurn();
        batallaNaval.Fire(fila: 5, columna: 5);


        //Act
        var informe = batallaNaval.InformeGeneral()[2];
        var tableroJugador2 = informe.RepresentacionTablero;
        ReadOnlyCollection<(TipoBarco TipoBarco, Coordenada cordenada)> barcosUndidos = informe.ObtenerBarcosUndidos();

        //Assert 
        string tableroEsperadoJugador2 = "   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n" +
                                         " 0 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 1 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 2 |   |   | o |   |   |   |   |   |   |   |\n" +
                                         " 3 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 4 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 5 |   |   |   |   |   | X |   |   |   |   |\n" +
                                         " 6 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 7 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 8 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 9 |   |   |   |   |   |   |   |   |   |   |\n";

        tableroJugador2.Should().Be(tableroEsperadoJugador2);
        barcosUndidos.Should().HaveCount(1);

        barcosUndidos[0].Should().BeEquivalentTo((TipoBarco.Cañonero, new Coordenada(5, 5)));
    }

    [Fact]
    public void
        Si_ElJugadorDosColocaUnDestructorConPosicionHorizontalEnLaCoordenada5_5YElJugadorUnoLoUnde_Debe_ElTableroDelJugadorDosRepresentarElDestructorIndidoConX()
    {
        //Arrange
        var batallaNaval = new BatallaNaval();
        batallaNaval.AddPlayer();
        batallaNaval.AddPlayer();
        batallaNaval.ColocarBarco(jugador: 1, fila: 3, columna: 3, tipo: TipoBarco.Cañonero);
        batallaNaval.ColocarBarco(jugador: 2, fila: 5, columna: 5, tipo: TipoBarco.Destructor,
            orientacion: TipoOrientacion.Horizontal);
        batallaNaval.Start();
        batallaNaval.Fire(fila: 5, columna: 5);
        batallaNaval.Fire(fila: 5, columna: 6);
        batallaNaval.Fire(fila: 5, columna: 7);
        batallaNaval.EndTurn();

        //Act
        var tableroJugador2 = batallaNaval.Print(2);

        //Assert 
        string tableroEsperadoJugador2 = "   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n" +
                                         " 0 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 1 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 2 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 3 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 4 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 5 |   |   |   |   |   | X | X | X |   |   |\n" +
                                         " 6 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 7 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 8 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 9 |   |   |   |   |   |   |   |   |   |   |\n";

        tableroJugador2.Should().Be(tableroEsperadoJugador2);
    }

    [Fact]
    public void
        Si_ElJugadorDosColocaUnDestructorConPosicionHorizontalEnLaCoordenada5_5YElJugadorUnoLoUnde_Debe_EllInformeDelJugadorDosMostrarlDestructorUndidoConPosicion5_5()
    {
        //Arrange
        var batallaNaval = new BatallaNaval();
        batallaNaval.AddPlayer();
        batallaNaval.AddPlayer();
        batallaNaval.ColocarBarco(jugador: 1, fila: 3, columna: 3, tipo: TipoBarco.Cañonero);
        batallaNaval.ColocarBarco(jugador: 2, fila: 5, columna: 5, tipo: TipoBarco.Destructor,
            orientacion: TipoOrientacion.Horizontal);
        batallaNaval.Start();
        batallaNaval.Fire(fila: 5, columna: 6);
        batallaNaval.Fire(fila: 5, columna: 5);
        batallaNaval.Fire(fila: 5, columna: 7);
        batallaNaval.EndTurn();

        //Act
        var informe = batallaNaval.InformeGeneral()[2];
        var tableroJugador2 = informe.RepresentacionTablero;
        var barcosUndidos = informe.ObtenerBarcosUndidos();

        //Assert 
        string tableroEsperadoJugador2 = "   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n" +
                                         " 0 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 1 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 2 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 3 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 4 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 5 |   |   |   |   |   | X | X | X |   |   |\n" +
                                         " 6 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 7 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 8 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 9 |   |   |   |   |   |   |   |   |   |   |\n";

        tableroJugador2.Should().Be(tableroEsperadoJugador2);
        barcosUndidos.Should().HaveCount(1);

        barcosUndidos[0].Should().BeEquivalentTo((TipoBarco.Destructor, new Coordenada(5, 5)));
    }

    [Fact]
    public void
        Si_ElJugadorDosColocaUnPortaAvionYUnCanoneroYElJugadorUnoLosUnde_Debe_EllInformeDelJugadorDosMostrarElPortaAvionYElCanoneroUndidosConSusPosicionesIniciales()
    {
        //Arrange
        var batallaNaval = new BatallaNaval();
        batallaNaval.AddPlayer();
        batallaNaval.AddPlayer();
        batallaNaval.ColocarBarco(jugador: 1, fila: 3, columna: 3, tipo: TipoBarco.Cañonero);
        batallaNaval.ColocarBarco(jugador: 2, fila: 5, columna: 5, tipo: TipoBarco.PortaAviones,
            orientacion: TipoOrientacion.Horizontal);
        batallaNaval.ColocarBarco(jugador: 2, fila: 1, columna: 1, tipo: TipoBarco.Cañonero);
        batallaNaval.Start();
        batallaNaval.Fire(fila: 5, columna: 6);
        batallaNaval.Fire(fila: 5, columna: 5);
        batallaNaval.Fire(fila: 5, columna: 7);
        batallaNaval.Fire(fila: 5, columna: 8);
        batallaNaval.Fire(fila: 1, columna: 1);
        batallaNaval.EndTurn();

        //Act
        var informe = batallaNaval.InformeGeneral()[2];
        var tableroJugador2 = informe.RepresentacionTablero;
        var barcosUndidos = informe.ObtenerBarcosUndidos();

        //Assert 
        string tableroEsperadoJugador2 = "   | 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |\n" +
                                         " 0 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 1 |   | X |   |   |   |   |   |   |   |   |\n" +
                                         " 2 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 3 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 4 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 5 |   |   |   |   |   | X | X | X | X |   |\n" +
                                         " 6 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 7 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 8 |   |   |   |   |   |   |   |   |   |   |\n" +
                                         " 9 |   |   |   |   |   |   |   |   |   |   |\n";

        tableroJugador2.Should().Be(tableroEsperadoJugador2);
        barcosUndidos.Should().HaveCount(2);

        barcosUndidos[0].Should().BeEquivalentTo((TipoBarco.PortaAviones, new Coordenada(5, 5)));
        barcosUndidos[1].Should().BeEquivalentTo((TipoBarco.Cañonero, new Coordenada(1, 1)));
    }
    [Fact]
    public void
        Si_SeIniciaElJuegoSinAlMenosDosJugadores_Debe_LanzarExcepcion()
    {
        //Arrange
        var batallaNaval = new BatallaNaval();
        
        //Act
        Action action = () => batallaNaval.Start();
        
        //Assert 
        action.Should().ThrowExactly<InvalidOperationException>().WithMessage("El juego no puede iniciar sin almenos dos jugadores");
    }
    
    [Fact]
    public void
        Si_SoloHayUnJugadorYSeColocaBarcoEnTableroDeJugador2_Debe_LanzarExcepcion()
    {
        //Arrange
        var batallaNaval = new BatallaNaval();
        batallaNaval.AddPlayer();
        
        //Act
        Action action = () => batallaNaval.ColocarBarco(jugador: 2, fila: 1, columna: 1, tipo: TipoBarco.Cañonero);;
        
        //Assert 
        action.Should().ThrowExactly<InvalidOperationException>().WithMessage("No se puede colocar barco en tablero de jugador inexistente");
    }
    [Fact]
    public void
        Si_SeColocaBarcoEnCoordenada3_3YLasDimensionesDelTableroSon2x2_DebeLanzarExcepcion()
    {
        //Arrange
        var batallaNaval = new BatallaNaval(filasTablero:2,columnasTablero:2);
        batallaNaval.AddPlayer();
        
        //Act
        Action action = () => batallaNaval.ColocarBarco(jugador: 1, fila: 3, columna: 3, tipo: TipoBarco.Cañonero);
        
        //Assert 
        action.Should().ThrowExactly<InvalidOperationException>().WithMessage("No se puede colocar barco en coordenadas");
    }
    
    [Fact]
    public void
        Si_SeRealizaUnDisparoSinIniciarElJuego_Debe_LanzarExcepcion()
    {
        //Arrange
        var batallaNaval = new BatallaNaval(filasTablero:2,columnasTablero:2);
        batallaNaval.AddPlayer();
        
        //Act
        Action action = () => batallaNaval.Fire(fila: 1, columna: 1);
        
        //Assert 
        action.Should().ThrowExactly<InvalidOperationException>().WithMessage("No se puede disparar si el juego no ha iniciado");
    }

    

}
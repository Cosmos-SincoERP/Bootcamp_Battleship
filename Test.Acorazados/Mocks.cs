using Test.BattleShip.Dominio;
using Test.BattleShip.Dominio.Barcos;

namespace Test.BattleShip;

public class Mocks
{
    public static JuegoAcorazados MockIniciarJuego()
    {
        var juegoAcorazado = new JuegoAcorazados();
        juegoAcorazado.AgregarJugador();
        juegoAcorazado.AgregarJugador();
        var barcosJugador1 = new List<Barco>
        {
            new Cañonero(new(2, 1)),
            new Cañonero(new(1, 3)),
            new Cañonero(new(5, 2)),
            new Cañonero(new(7, 6)),
            new Destructor(new(1, 5), OrientacionBarco.Horizontal),
            new Destructor(new(7, 2), OrientacionBarco.Vertical),
            new PortaAviones(new (2, 7), OrientacionBarco.Horizontal)
        };
        var barcosJugador2 = new List<Barco>
        {
            new Cañonero(new(1, 8)),
            new Cañonero(new(1, 3)),
            new Cañonero(new(2, 5)),
            new Cañonero(new(4, 5)),
            new Destructor(new( 7, 4), OrientacionBarco.Horizontal),
            new Destructor(new( 4, 7), OrientacionBarco.Vertical),
            new PortaAviones(new(0, 4), OrientacionBarco.Vertical)
        };
        
        juegoAcorazado.Iniciar(barcosJugador1, barcosJugador2);
        return juegoAcorazado;
    }
}
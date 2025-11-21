namespace Test.BattleShip;

public class Mocks
{
    public static JuegoAcorazados MockIniciarJuego()
    {
        var juegoAcorazado = new JuegoAcorazados();
        juegoAcorazado.AgregarJugador();
        juegoAcorazado.AgregarJugador();
        var posicionesJugador1 = new List<(string tipo, int x, int y, string orientacion)>()
        {
            new("Cañonero", 2, 1, ""),
            new("Cañonero", 1, 3, ""),
            new("Cañonero", 5, 2, ""),
            new("Cañonero", 7, 6, ""),
            new("Destructor", 1, 5, "Horizontal"),
            new("Destructor", 7, 2, "Vertical"),
            new("Portaviones", 2, 7, "Horizontal"),
        };
        var posicionesJugador2 = new List<(string tipo, int x, int y, string orientacion)>()
        {
            new("Cañonero", 1, 8, ""),
            new("Cañonero", 1, 3, ""),
            new("Cañonero", 2, 5, ""),
            new("Cañonero", 4, 5, ""),
            new("Destructor", 7, 4, "Horizontal"),
            new("Destructor", 4, 7, "Vertical"),
            new("Portaviones", 0, 4, "Vertical"),
        };
        
        juegoAcorazado.Iniciar(posicionesJugador1, posicionesJugador2);
        return juegoAcorazado;
    }
}
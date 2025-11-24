using Test.BattleShip.Dominio;
using Test.BattleShip.Dominio.Barcos;

namespace Test.BattleShip;

public class Mocks
{
    private static Dictionary<string, int> _tamañoBarcos = new()
    {
        { "Cañonero", 1 },
        { "Destructor", 3 },
        { "PortaAviones", 4 },
    };

    public static Juego MockIniciarJuego(bool disparos = false)
    {
        var juegoAcorazado = new Juego();
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
            new PortaAviones(new(2, 7), OrientacionBarco.Horizontal)
        };
        var barcosJugador2 = new List<Barco>
        {
            new Cañonero(new(1, 8)),
            new Cañonero(new(1, 3)),
            new Cañonero(new(2, 5)),
            new Cañonero(new(4, 5)),
            new Destructor(new(7, 4), OrientacionBarco.Horizontal),
            new Destructor(new(4, 7), OrientacionBarco.Vertical),
            new PortaAviones(new(4, 0), OrientacionBarco.Vertical)
        };

        juegoAcorazado.Iniciar([(0, barcosJugador1), (1, barcosJugador2)]);

        if (!disparos)
            return juegoAcorazado;

        foreach (var barcos in barcosJugador1)
        {
            var tamaño = _tamañoBarcos[barcos.GetType().Name];
            for (var i = 0; i < tamaño; i++)
            {
                juegoAcorazado.Disparar(new Coordenada(0 + new Random().Next(0, 10), 0 + new Random().Next(0, 10)));
                juegoAcorazado.FinalizarTurno();

                if (barcos.Orientacion == OrientacionBarco.Horizontal)
                    juegoAcorazado.Disparar(new Coordenada(barcos.Coordenada.X + i, barcos.Coordenada.Y));
                else
                    juegoAcorazado.Disparar(new Coordenada(barcos.Coordenada.X, barcos.Coordenada.Y + i));

                juegoAcorazado.FinalizarTurno();
            }
        }

        return juegoAcorazado;
    }

    public static string TableroEsperado(char[,] tablero)
    {
        var tableroEsperado = string.Empty;
        for (var x = 0; x < tablero.GetLength(0); x++)
        {
            for (int y = 0; y < tablero.GetLength(1); y++)
            {
                tableroEsperado += tablero[x, y];
            }

            tableroEsperado += '\n';
        }

        return tableroEsperado;
    }

    public static Juego MockIniciarJuegoConBarcoEnCoordenadaXMayorA10(bool disparos = false)
    {
        var juegoAcorazado = new Juego();
        juegoAcorazado.AgregarJugador();
        juegoAcorazado.AgregarJugador();
        var barcosJugador1 = new List<Barco>
        {
            new Cañonero(new(11, 1))
        };
        var barcosJugador2 = new List<Barco>
        {
            new Cañonero(new(1, 8))
        };

        juegoAcorazado.Iniciar([(0, barcosJugador1), (1, barcosJugador2)]);

        return juegoAcorazado;
    }

    public static Juego MockIniciarJuegoConBarcoEnCoordenadaXMenorA0(bool disparos = false)
    {
        var juegoAcorazado = new Juego();
        juegoAcorazado.AgregarJugador();
        juegoAcorazado.AgregarJugador();
        var barcosJugador1 = new List<Barco>
        {
            new Cañonero(new(-1, 1))
        };
        var barcosJugador2 = new List<Barco>
        {
            new Cañonero(new(1, 8))
        };

        juegoAcorazado.Iniciar([(0, barcosJugador1), (1, barcosJugador2)]);

        return juegoAcorazado;
    }
}
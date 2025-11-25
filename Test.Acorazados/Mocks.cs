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

    public static string TableroEsperado(char[,] tablero)
    {
        var tableroEsperado = string.Empty;
        tableroEsperado += "   |";
        for (int i = 0; i < tablero.GetLength(1); i++)
        {
            tableroEsperado += $" {i} |";
        }
        tableroEsperado += " \n";

        tableroEsperado += "-------------------------------------------| \n";

        for (var x = 0; x < tablero.GetLength(0); x++)
        {
            tableroEsperado += $" {x} |";
            for (int y = 0; y < tablero.GetLength(1); y++)
            {
                char valorAMostar = tablero[x, y] == '\0' ? ' ' : tablero[x, y];
                tableroEsperado += $" {valorAMostar} |";
            }
            tableroEsperado += " \n";
        }

        return tableroEsperado;
    }
    
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

        var random = new Random();

        var coordenadasDisparosJugador1 = new List<Coordenada>();
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                coordenadasDisparosJugador1.Add(new Coordenada(x, y));
            }
        }



        foreach (var barcos in barcosJugador1)
        {
            var tamaño = _tamañoBarcos[barcos.GetType().Name];
            for (var i = 0; i < tamaño; i++)
            {
                var coordenada = coordenadasDisparosJugador1[0];
                coordenadasDisparosJugador1.RemoveAt(0);
                juegoAcorazado.Disparar(coordenada);
                juegoAcorazado.FinalizarTurno();

                juegoAcorazado.Disparar(barcos.Orientacion == OrientacionBarco.Horizontal
                    ? new Coordenada(barcos.Coordenada.X + i, barcos.Coordenada.Y)
                    : new Coordenada(barcos.Coordenada.X, barcos.Coordenada.Y + i));

                juegoAcorazado.FinalizarTurno();
            }
        }

        return juegoAcorazado;
    }

    public static Juego MockIniciarJuegoConBarcoEnCoordenadaXMayorA10()
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

    public static Juego MockIniciarJuegoConBarcoEnCoordenadaXMenorA0()
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

    public static Juego MockIniciarJuegoConBarcoEnCoordenadaYMayorA10()
    {
        var juegoAcorazado = new Juego();
        juegoAcorazado.AgregarJugador();
        juegoAcorazado.AgregarJugador();
        var barcosJugador1 = new List<Barco>
        {
            new Cañonero(new(1, 11))
        };
        var barcosJugador2 = new List<Barco>
        {
            new Cañonero(new(1, 8))
        };

        juegoAcorazado.Iniciar([(0, barcosJugador1), (1, barcosJugador2)]);

        return juegoAcorazado;
    }

    public static Juego MockIniciarJuegoConBarcoEnCoordenadaYMenorA0()
    {
        var juegoAcorazado = new Juego();
        juegoAcorazado.AgregarJugador();
        juegoAcorazado.AgregarJugador();
        var barcosJugador1 = new List<Barco>
        {
            new Cañonero(new(1, -1))
        };
        var barcosJugador2 = new List<Barco>
        {
            new Cañonero(new(1, 8))
        };

        juegoAcorazado.Iniciar([(0, barcosJugador1), (1, barcosJugador2)]);

        return juegoAcorazado;
    }

    public static Juego MockIniciarJuegoConBarcoEnCoordenadaNoValidas()
    {
        var juegoAcorazado = new Juego();
        juegoAcorazado.AgregarJugador();
        juegoAcorazado.AgregarJugador();
        var barcosJugador1 = new List<Barco>
        {
            new Cañonero(new(-1, 1)),
            new Cañonero(new(1, 1)),
            new Cañonero(new(5, 2)),
            new Cañonero(new(7, 6)),
            new Destructor(new(1, 15), OrientacionBarco.Horizontal),
            new Destructor(new(7, 2), OrientacionBarco.Vertical),
            new PortaAviones(new(2, 7), OrientacionBarco.Horizontal)
        };
        var barcosJugador2 = new List<Barco>
        {
            new Cañonero(new(1, 8))
        };

        juegoAcorazado.Iniciar([(0, barcosJugador1), (1, barcosJugador2)]);

        return juegoAcorazado;
    }

    public static Juego MockIniciarJuegoConBarcoEnPosicionesOcupadas()
    {
        var juegoAcorazado = new Juego();
        juegoAcorazado.AgregarJugador();
        juegoAcorazado.AgregarJugador();
        var barcosJugador1 = new List<Barco>
        {
            new Cañonero(new(2, 2)),
            new Cañonero(new(2, 2)),
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

        return juegoAcorazado;
    }
    
    public static Juego MockIniciarJuegoConBarcoDeDiferentesTipoEnPosicionesOcupadas()
    {
        var juegoAcorazado = new Juego();
        juegoAcorazado.AgregarJugador();
        juegoAcorazado.AgregarJugador();
        var barcosJugador1 = new List<Barco>
        {
            new Cañonero(new(2, 2)),
            new Cañonero(new(2, 2)),
            new Cañonero(new(5, 2)),
            new Cañonero(new(7, 6)),
            new Destructor(new(1, 5), OrientacionBarco.Horizontal),
            new Destructor(new(1, 5), OrientacionBarco.Vertical),
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

        return juegoAcorazado;
    }
}
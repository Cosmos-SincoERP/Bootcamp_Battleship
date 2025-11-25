using Test.BattleShip.Dominio;
using Test.BattleShip.Dominio.Barcos;

namespace BattleShip.Console;

class Program
{
    static void Main(string[] args)
    {
        System.Console.WriteLine("===================================");
        System.Console.WriteLine("  BIENVENIDO A BATALLA NAVAL");
        System.Console.WriteLine("===================================");
        System.Console.WriteLine();

        // Crear el juego y agregar jugadores
        var juego = new Juego();
        juego.AgregarJugador();
        juego.AgregarJugador();

        // Crear las flotas predefinidas para ambos jugadores
        var flotasIniciales = CrearFlotasPredefinidas();

        // Iniciar el juego
        juego.Iniciar(flotasIniciales);

        System.Console.WriteLine("El juego ha comenzado!");
        System.Console.WriteLine("Tablero: 10x10 (coordenadas de 0 a 9)");
        System.Console.WriteLine();

        // Loop del juego
        var jugadorActual = 1;
        var juegoTerminado = false;

        while (!juegoTerminado)
        {
            try
            {
                System.Console.WriteLine($"===================================");
                System.Console.WriteLine($"  TURNO DEL JUGADOR {jugadorActual}");
                System.Console.WriteLine($"===================================");
                System.Console.WriteLine();
                
                // Pedir coordenadas por consola
                System.Console.Write("Ingrese coordenada X (0-9): ");
                var x = int.Parse(System.Console.ReadLine() ?? "0");

                System.Console.Write("Ingrese coordenada Y (0-9): ");
                var y = int.Parse(System.Console.ReadLine() ?? "0");

                var coordenada = new Coordenada(x, y);

                // Disparar
                var resultado = juego.Disparar(coordenada);

                System.Console.WriteLine();
                System.Console.WriteLine(!string.IsNullOrEmpty(resultado)
                    ? $"¡Barco Hundido! {resultado}"
                    : $"Disparo en ({x},{y})");
                System.Console.WriteLine();
                
                // Mostrar el tablero del enemigo
                System.Console.WriteLine("Tablero del enemigo:");
                System.Console.WriteLine(juego.Imprimir());
                System.Console.WriteLine();
                
                // Finalizar turno
                juego.FinalizarTurno();

                // Verificar si el juego terminó
                var informeFinal = juego.Imprimir();
                if (informeFinal.Contains("Informe de batalla"))
                {
                    juegoTerminado = true;
                    System.Console.WriteLine();
                    System.Console.WriteLine("===================================");
                    System.Console.WriteLine("  ¡JUEGO TERMINADO!");
                    System.Console.WriteLine("===================================");
                    System.Console.WriteLine();
                    System.Console.WriteLine(informeFinal);
                }
                else
                {
                    // Cambiar al otro jugador
                    jugadorActual = jugadorActual == 1 ? 2 : 1;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error: {ex.Message}");
                System.Console.WriteLine("===================================");
                System.Console.WriteLine("Intente nuevamente !!!");
                System.Console.WriteLine("===================================");
                System.Console.WriteLine();
                
                // Mostrar el tablero del enemigo
                System.Console.WriteLine("Tablero del enemigo:");
                System.Console.WriteLine(juego.Imprimir());
                System.Console.WriteLine();
            }
        }

        System.Console.WriteLine();
        System.Console.WriteLine("Presione cualquier tecla para salir...");
        System.Console.ReadKey();
    }

    private static List<(int indexJugador, List<Barco> barcos)> CrearFlotasPredefinidas()
    {
        // Flota del Jugador 1
        var flotaJugador1 = new List<Barco>
        {
            new Cañonero(new Coordenada(0, 0)),
            new Cañonero(new Coordenada(2, 0)),
            new Cañonero(new Coordenada(4, 0)),
            new Cañonero(new Coordenada(6, 0)),
            new Destructor(new Coordenada(0, 2), OrientacionBarco.Horizontal),
            new Destructor(new Coordenada(5, 2), OrientacionBarco.Vertical),
            new PortaAviones(new Coordenada(5, 6), OrientacionBarco.Horizontal)
        };

        // Flota del Jugador 2
        var flotaJugador2 = new List<Barco>
        {
            new Cañonero(new Coordenada(1, 1)),
            new Cañonero(new Coordenada(3, 1)),
            new Cañonero(new Coordenada(5, 1)),
            new Cañonero(new Coordenada(7, 1)),

            new Destructor(new Coordenada(1, 4), OrientacionBarco.Horizontal),
            new Destructor(new Coordenada(8, 3), OrientacionBarco.Vertical),

            new PortaAviones(new Coordenada(0, 0), OrientacionBarco.Vertical)
        };

        return new List<(int, List<Barco>)>
        {
            (0, flotaJugador1),
            (1, flotaJugador2)
        };
    }
}

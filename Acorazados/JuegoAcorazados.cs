using System.Net;
using Acorazados;



public class JuegoAcorazados
{
    private bool _juegoIniciado;
    private List<Jugador> jugadores = new();

    public void AgregarJugador(string jugador, List<Acorazado> acorazados)
    {
        if (jugadores.Count < 2)
        {
            jugadores.Add(new Jugador(jugador, acorazados));
        }
        else
        {
            throw new ArgumentException("No puede agregar mas de dos jugadores");
        }
    }

    public string[,] ImprimirTablero()
    {
        return jugadores.First().ObtenerTablero();
    }

    public void Iniciar()
    {
        if (_juegoIniciado)
            throw new Exception("Ya hay un juego en curso");
        if (jugadores.Count.Equals(0))
            throw new ArgumentNullException("Debe tener jugadores para iniciar el juego");
        _juegoIniciado = true;
    }

    public void Disparar(int fila, int columna)
    {
        jugadores.Last().RecibirDisparo(fila, columna);
    }

    public string[,] ObtenerTableroContrincante()
    {
        var obtenerTableroContrincante = jugadores.Last().ObtenerTablero();
        var letrasDisparos = new List<string>
        {
            "o", "x", "X"
        };

        for (int fila = 0; fila < jugadores.Last().ObtenerLongitudTablero(0); fila++)
        {
            for (int columna = 0; columna < jugadores.Last().ObtenerLongitudTablero(1); columna++)
            {
                if (!letrasDisparos.Contains(obtenerTableroContrincante[fila, columna]) && obtenerTableroContrincante[fila, columna] != null)
                {
                    obtenerTableroContrincante[fila, columna] = null;
                }
            }
        }
        
        return obtenerTableroContrincante;
    }

    public void FinalizarTurno()
    {
        jugadores.Reverse();
    }
}
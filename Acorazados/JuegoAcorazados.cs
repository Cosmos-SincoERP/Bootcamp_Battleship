using System.Net;
using Acorazados;

public record AcorazadoAcuatizado(
    Acorazado tipoAcorazado,
    int fila,
    int columna,
    Direccion? direccion
);

public class JuegoAcorazados
{
    Jugador jugador1;
    Jugador jugador2;
    private bool _juegoIniciado;

    public void AgregarJugador(string jugador, List<AcorazadoAcuatizado> acorazados)
    {
        if (jugador1 is null)
        {
            jugador1 = new Jugador(jugador, acorazados);
        }
        else if (jugador2 is null)
        {
            jugador2 = new Jugador(jugador, acorazados);
        }
        else
        {
            throw new ArgumentException("No puede agregar mas de dos jugadores");
        }
    }

    public string[,] ImprimirTablero()
    {
        return jugador1.ObtenerTablero();
    }

    public void Iniciar()
    {
        if (_juegoIniciado)
            throw new Exception("Ya hay un juego en curso");
        if (jugador1 is null)
            throw new ArgumentNullException("Debe tener jugadores para iniciar el juego");
        _juegoIniciado = true;
    }

    public void Disparar(int fila, int columna)
    {
        jugador2.RecibirDisparo(fila, columna);
    }

    public string[,] ObtenerTableroContrincante()
    {
        var obtenerTableroContrincante = jugador2.ObtenerTablero();
        var letrasDisparos = new List<string>
        {
            "o", "x"
        };

        for (int fila = 0; fila < jugador2.ObtenerLongitudTablero(0); fila++)
        {
            for (int columna = 0; columna < jugador2.ObtenerLongitudTablero(1); columna++)
            {
                if (!letrasDisparos.Contains(obtenerTableroContrincante[fila, columna]) && obtenerTableroContrincante[fila, columna] != null)
                {
                    obtenerTableroContrincante[fila, columna] = null;
                }
            }
        }
        
        return obtenerTableroContrincante;
    }
}
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
        if (jugador1 is null)
            throw new ArgumentNullException("Debe tener jugadores para iniciar el juego");
    }
}
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
    
    public void AgregarJugador(string jugador, List<AcorazadoAcuatizado> acorazados)
    {
        jugador1 = new Jugador(jugador, acorazados);
    }

    public string[,] ImprimirTablero()
    {
        return jugador1.ObtenerTablero();
    }

    public void Iniciar()
    {
       if(jugador1 is null)
           throw new ArgumentNullException("Debe tener jugadores para iniciar el juego");
    }
}
namespace Test.BattleShip;

public class JuegoAcorazadosTemp
{
    public List<(string, char[,])> _jugadores { get; } = new();
    public void Iniciar(List<(Coordenada, Barco, OrientacionBarco orientacion)> barcosJugador1, List<(Coordenada, Barco, OrientacionBarco orientacion)> barcosJugador2)
    {
        if (_jugadores.Count != 2)
            throw new Exception("No se puede iniciar el juego, debe haber al menos 2 jugadores");

        var tableroJugador1 = _jugadores[0].Item2;
        PosicionarBarcosEnTablero(barcosJugador1, tableroJugador1);
    }

    private static void PosicionarBarcosEnTablero(List<(Coordenada coordenada, Barco barco, OrientacionBarco orientacion)> posicionesBarcosJugador1, char[,] tableroJugador1)
    {
        foreach (var posicionBarco in posicionesBarcosJugador1)
        {
            if (posicionBarco.barco.ElBarcoTieneOrientacion)
            {
                AsignarPosicionEnTablero(tableroJugador1, posicionBarco.coordenada.x, posicionBarco.coordenada.y, posicionBarco.barco.Valor);
            }
            else
            {
                if (posicionBarco.orientacion == OrientacionBarco.Vertical)
                {
                    for (int i = 0; i < posicionBarco.barco.Cantidad; i++)
                    {
                        AsignarPosicionEnTablero(tableroJugador1, posicionBarco.coordenada.x + i, posicionBarco.coordenada.y, posicionBarco.barco.Valor);
                    }
                }
                else
                {
                    for (int i = 0; i < posicionBarco.barco.Cantidad; i++)
                    {
                        AsignarPosicionEnTablero(tableroJugador1, posicionBarco.coordenada.x, posicionBarco.coordenada.y + i, posicionBarco.barco.Valor);
                    }
                }
            }


        }
    }

    private static void AsignarPosicionEnTablero(char[,] tableroJugador1, int x, int y, char valor)
    {
        tableroJugador1[x, y] = valor;
    }


    public void AgregarJugador(string nombre)
    {
        _jugadores.Add((nombre, new char[10, 10]));
    }

    public string Imprimir(string nombreJugador)
    {
        var tablero = _jugadores.FirstOrDefault(jugador => jugador.Item1 == nombreJugador).Item2;
        var visualizarTablero = string.Empty;

        visualizarTablero += "\n";

        visualizarTablero += "   |";
        for (int i = 0; i < tablero.GetLength(1); i++)
        {
            visualizarTablero += $" {i} |";
        }
        visualizarTablero += " \n";

        visualizarTablero += "-------------------------------------------| \n";

        for (var x = 0; x < tablero.GetLength(0); x++)
        {
            visualizarTablero += $" {x} |";
            for (int y = 0; y < tablero.GetLength(1); y++)
            {
                char valorAMostar = tablero[x, y] == '\0' ? ' ' : tablero[x, y];
                visualizarTablero += $" {valorAMostar} |";
            }
            visualizarTablero += " \n";
        }

        visualizarTablero += "-------------------------------------------| \n";

        return visualizarTablero;
    }
}

public abstract class Barco
{
    public Barco(int cantidad, char valor, bool eslBarcoTieneOrientacion)
    {
        Cantidad = cantidad;
        Valor = valor;
        ElBarcoTieneOrientacion = ElBarcoTieneOrientacion;
    }

    public int Cantidad { get; set; }
    public char Valor { get; set; }
    public bool ElBarcoTieneOrientacion { get; set; }

}

public class BarcoCañonero : Barco
{
    public BarcoCañonero() : base(1, 'g', false)
    {
    }
}

public class BarcoPortaviones : Barco
{
    public BarcoPortaviones() : base(4, 'c', true)
    {
    }
}

public class BarcoDestructor : Barco
{
    public BarcoDestructor() : base(3, 'd', true)
    {
    }
}
public record Coordenada(int x, int y);

public enum OrientacionBarco
{
    Vertical,
    Horizontal
}
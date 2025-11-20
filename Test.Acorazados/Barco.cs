namespace Test.BattleShip;

public abstract class Barco
{
    public int Tamaño { get; private set; }
    public char Valor { get; private set; }
    public Orientacion? Orientacion { get; set; }

    public Barco(int tamaño, char valor, Orientacion? orientacion = null)
    {
        Tamaño = tamaño;
        Valor = valor;
        Orientacion = orientacion;
    }
}

public class Cañonero() : Barco(1, 'g');
public class PortaAviones(Orientacion orientacion) : Barco(4, 'c', orientacion);
public class Destructor(Orientacion orientacion) : Barco(3, 'd', orientacion);

public record PosicionarBarco((int X, int Y) Coordenadas, Barco Barco);

public enum Orientacion
{
    Horizontal, 
    Vertical
}

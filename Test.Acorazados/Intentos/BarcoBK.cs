namespace Test.BattleShip;

public abstract class BarcoBK
{
    public int Tamaño { get; private set; }
    public char Valor { get; private set; }
    public Orientacion? Orientacion { get; set; }

    public BarcoBK(int tamaño, char valor, Orientacion? orientacion = null)
    {
        Tamaño = tamaño;
        Valor = valor;
        Orientacion = orientacion;
    }
}

public class Cañonero() : BarcoBK(1, 'g');
public class PortaAviones(Orientacion orientacion) : BarcoBK(4, 'c', orientacion);
public class Destructor(Orientacion orientacion) : BarcoBK(3, 'd', orientacion);

public record PosicionarBarco((int X, int Y) Coordenadas, BarcoBK BarcoBk);

public enum Orientacion
{
    Horizontal, 
    Vertical
}

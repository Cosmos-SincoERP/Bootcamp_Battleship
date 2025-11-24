namespace AcorazadosTests;

public interface INave
{
    public int Longitud { get; }
    public string Valor { get; }
    public int MaxPermitidos { get; }
}

public abstract class Nave : INave
{
    public int Longitud { get; protected set; }
    public string Valor { get; protected set; } = "";
    public int MaxPermitidos { get; set; }
}

public sealed class Carrier : Nave
{
    public Carrier()
    {
        Longitud = 4;
        Valor = "c";
        MaxPermitidos = 1;
    }
}

public sealed class Destroyer : Nave
{
    public Destroyer()
    {
        Longitud = 3;
        Valor = "d";
        MaxPermitidos = 2;
    }
}

public sealed class GunShip : Nave
{
    public GunShip()
    {
        Longitud = 1;
        Valor = "g";
        MaxPermitidos = 4;
    }
}

public class NavePosicionada
{
    public object TipoNave { get; set; }
    public List<(int fila, int columna)> Posiciones { get; set; }
}

public class NavesHundidas
{
    public List<(int fila, int columna)> GunShips { get; } = [];
    public List<(int fila, int columna)> Destroyer { get; } = [];
    public List<(int fila, int columna)> Carrier { get; } = [];
}
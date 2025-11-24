namespace Acorazados.Test;

public class Barcos(TiposBarcos tipo, string nombre, int casillas, string simbolo, int cantidadPermitida)
{
    public readonly string Nombre = nombre;
    public TiposBarcos Tipo { get; private set; } = tipo;
    public int Casillas { get; private set; } = casillas;
    public string Simbolo { get; private set; } = simbolo;
    public IReadOnlyList<Coordenada> Coordenadas => _coordenadas;
    public int CantidadPermitida { get; private set; } = cantidadPermitida;
    public bool EstaHundido { get; private set; }
    private readonly List<Coordenada> _coordenadas = [];
    public void HundirBarco()
        =>  EstaHundido = true;

    public void AgregarCoordenada(Coordenada coordenada)
        =>  _coordenadas.Add(coordenada);

    public static Barcos Destructor => new(TiposBarcos.Destructor, "destructor", 3, "d", 2);
    public static Barcos Portaaviones => new(TiposBarcos.Portaaviones,  "portaaviones", 4, "c", 1);
    public static Barcos Canonero => new(TiposBarcos.Canonero,  "cañonero", 1, "g", 4);
}
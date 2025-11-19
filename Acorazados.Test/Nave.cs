namespace Acorazados.Test;

public class Nave
{
    public int CoordenadaXInicial { get; set; }
    public int CoordenadaYInicial { get; set; }
    public string Tipo { get; set; }

    public Nave(int coordenadaXInicial, int coordenadaYInicial, int coordenadaXFinal, int coordenadaYFinal, string tipo)
    {
        CoordenadaXInicial = coordenadaXInicial;
        CoordenadaYInicial = coordenadaYInicial;
        Tipo = tipo;
    }
}
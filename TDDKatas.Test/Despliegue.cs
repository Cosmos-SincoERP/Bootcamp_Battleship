namespace TDDKatas;

public class Despliegue(Nave Nave, int PosicionX, int PosicionY, Orientacion Orientacion)
{
    public Nave Nave { get; init; } = Nave;
    public int PosicionX { get; init; } = PosicionX;
    public int PosicionY { get; init; } = PosicionY;
    public Orientacion Orientacion { get; init; } = Orientacion;

    public void Deconstruct(out Nave nave, out int posicionX, out int posicionY, out Orientacion orientacion)
    {
        nave = this.Nave;
        posicionX = this.PosicionX;
        posicionY = this.PosicionY;
        orientacion = this.Orientacion;
    }

    public bool EstaHundida(List<(int, int)> coordenadasDisparadas)
    {
        var coordenadasNave = ObtenerCoordenadasPorOrientacion(PosicionX, PosicionY, Nave, Orientacion);

        return coordenadasNave.TrueForAll(x => coordenadasDisparadas.Contains(x));
    }
    
    public List<(int, int)> CoordenadasNave() => ObtenerCoordenadasPorOrientacion(PosicionX, PosicionY, Nave, Orientacion);

    private List<(int, int)> ObtenerCoordenadasPorOrientacion(int posicionX, int posicionY, Nave nave,
        Orientacion orientacion)
    {
        List<(int, int)> coordenadas = new List<(int, int)>();

        for (int i = 0; i < nave.Tamanio; i++)
        {
            if (orientacion == Orientacion.Izquierda)
                coordenadas.Add((posicionX, posicionY - i));
            else if (orientacion == Orientacion.Arriba)
                coordenadas.Add((posicionX - i, posicionY));
            else if (orientacion == Orientacion.Abajo)
                coordenadas.Add((posicionX + i, posicionY));
            else
                coordenadas.Add((posicionX, posicionY + i));
        }

        return coordenadas;
    }
}
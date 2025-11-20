namespace TDDKatas;

internal class Despliegue(Nave Nave, int PosicionX, int PosicionY, Orientacion Orientacion)
{
    private readonly Coordenada _coordenada = new(PosicionX,PosicionY);
    public Nave Nave { get; } = Nave;
    public Orientacion Orientacion { get; } = Orientacion;

    public Coordenada Coordenada
    {
        get { return _coordenada; }
    }

    public bool EstaHundida(List<Coordenada> coordenadasDisparadas)
    {
        var coordenadasNave = ObtenerCoordenadasPorOrientacion(Coordenada.PosicionX, Coordenada.PosicionY, Nave, Orientacion);

        return coordenadasNave.TrueForAll(x => coordenadasDisparadas.Contains(x));
    }
    
    public List<Coordenada> CoordenadasNave() => ObtenerCoordenadasPorOrientacion(Coordenada.PosicionX, Coordenada.PosicionY, Nave, Orientacion);

    private List<Coordenada> ObtenerCoordenadasPorOrientacion(int posicionX, int posicionY, Nave nave,
        Orientacion orientacion)
    {
        List<Coordenada> coordenadas = [];

        for (int i = 0; i < nave.Tamanio; i++)
        {
            if (orientacion == Orientacion.Izquierda)
                coordenadas.Add(new Coordenada(posicionX, posicionY - i));
            else if (orientacion == Orientacion.Arriba)
                coordenadas.Add(new Coordenada(posicionX - i, posicionY));
            else if (orientacion == Orientacion.Abajo)
                coordenadas.Add(new Coordenada(posicionX + i, posicionY));
            else
                coordenadas.Add(new Coordenada(posicionX, posicionY + i));
        }

        return coordenadas;
    }
}
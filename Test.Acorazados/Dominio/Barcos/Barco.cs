namespace Test.BattleShip.Dominio.Barcos;

public abstract class Barco
{
    public Coordenada Coordenada { get; }
    public List<Coordenada> CoordenadasDeLaPosicion { get; } = [];
    public char Representacion { get; }
    public OrientacionBarco? Orientacion { get; }

    private int _tamaño;
    private int _impactos;

    protected Barco(Coordenada coordenada, int tamaño, char representacion, OrientacionBarco? orientacion)
    {
        Coordenada = coordenada;
        _tamaño = tamaño;
        Representacion = representacion;
        Orientacion = orientacion;
        AgregarCoordenadasParaPosicionar();
    }
    
    public bool EstaEnLaCoordenada(Coordenada coordenada) =>
        CoordenadasDeLaPosicion.Any(coordenadaEnLaPosicion =>
            coordenadaEnLaPosicion.X == coordenada.X
            && coordenadaEnLaPosicion.Y == coordenada.Y
        );

    public void MarcarImpacto() => _impactos++;
    public bool SeHundio() => _tamaño == _impactos;

    private void AgregarCoordenadasParaPosicionar()
    {
        for (int i = 0; i < _tamaño; i++)
        {
            if (Orientacion == OrientacionBarco.Horizontal)
                CoordenadasDeLaPosicion.Add(new(Coordenada.X + i, Coordenada.Y));
            else
                CoordenadasDeLaPosicion.Add(new(Coordenada.X, Coordenada.Y + i));
        }
    }
}

public enum FlotaBarcos
{
    Cañonero = 4,
    Destructor = 2,
    PortaAviones = 1
}
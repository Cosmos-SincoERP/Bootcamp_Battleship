namespace Test.BattleShip.Dominio.Barcos;

public abstract class Barco
{
    public Coordenada Coordenada { get; }
    public char Representacion { get; }
    public List<Coordenada> CoordenadasDeLaPosicion { get; } = [];
    public OrientacionBarco? Orientacion { get; }

    private int _tamaño;
    private int _impactos;

    public Barco(Coordenada coordenada, int tamaño, char representacion, OrientacionBarco? orientacion)
    {
        Coordenada = coordenada;
        _tamaño = tamaño;
        Representacion = representacion;
        Orientacion = orientacion;

        AgregarCoordenadasDeLaPosicion();
    }

    public bool EstaEnLaCoordenada(Coordenada coordenada) =>
        CoordenadasDeLaPosicion.Any(coordenadaEnLaPosicion =>
            coordenadaEnLaPosicion.X == coordenada.X
            && coordenadaEnLaPosicion.Y == coordenada.Y
        );

    public void RegistrarImpacto() => _impactos++;
    public bool SeHundio() => _tamaño == _impactos;

    private void AgregarCoordenadasDeLaPosicion()
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
namespace Test.BattleShip.Dominio.Barcos;

public abstract class Barco
{
    public Coordenada Coordenada { get; }
    private int Tamaño { get; }
    public char Representacion { get; }
    public OrientacionBarco? Orientacion { get; }

    public Barco(Coordenada coordenada, int tamaño, char representacion, OrientacionBarco? orientacion)
    {
        Coordenada = coordenada;
        Tamaño = tamaño;
        Representacion = representacion;
        Orientacion = orientacion;
    }
    
}
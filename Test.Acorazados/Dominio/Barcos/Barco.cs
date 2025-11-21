namespace Test.BattleShip.Dominio.Barcos;

public abstract class Barco
{
    public Coordenada Posicion { get; }
    private int Tamaño { get; }
    public char Representacion { get; }
    public OrientacionBarco? Orientacion { get; }

    public Barco(Coordenada posicion, int tamaño, char representacion, OrientacionBarco? orientacion)
    {
        Posicion = posicion;
        Tamaño = tamaño;
        Representacion = representacion;
        Orientacion = orientacion;
    }
    
}
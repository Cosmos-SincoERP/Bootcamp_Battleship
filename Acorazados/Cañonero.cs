namespace Acorazados;

public class Cañonero : Acorazado
{
    public override string Letra => "g";
    public override int CantidadMaximaAcorazadosEnTablero => 4;
    public override int CantidaCasillasOcupadasPorAcorazado => 1;
}
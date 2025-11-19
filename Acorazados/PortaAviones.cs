namespace Acorazados;

public class PortaAviones : Acorazado
{
    public override string Letra => "c";
    public override int CantidadMaximaAcorazadosEnTablero => 1;
    public override int CantidaCasillasOcupadasPorAcorazado => 4;
}
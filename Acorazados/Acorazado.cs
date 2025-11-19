namespace Acorazados;

public abstract partial class Acorazado
{
    public abstract string Letra { get; }
    public abstract int CantidadMaximaAcorazadosEnTablero { get; }
    public abstract int CantidaCasillasOcupadasPorAcorazado { get; }
}
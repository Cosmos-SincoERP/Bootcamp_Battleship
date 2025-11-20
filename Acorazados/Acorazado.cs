namespace Acorazados;

public abstract class Acorazado
{
    public abstract string Letra { get; }
    public abstract int CantidadMaximaAcorazadosEnTablero { get; }
    public abstract int CantidaCasillasOcupadasPorAcorazado { get; }
    public List<SegmentoAcorazado> SegmentosAcorazado = new();
    public bool EstaDestruido => SegmentosAcorazado.All(segmento => segmento.destruido);

    public void RegistrarDisparo(int fila, int columna)
    {
        var segmentoAfectado = SegmentosAcorazado.Where(segmento => segmento.fila == fila && segmento.columna == columna).First();
        segmentoAfectado = segmentoAfectado with
        {
            destruido = true
        };
        SegmentosAcorazado[SegmentosAcorazado.FindIndex(segmento => segmento.fila == fila && segmento.columna == columna)] = segmentoAfectado;
    }
}

public record SegmentoAcorazado(int fila, int columna, bool destruido);
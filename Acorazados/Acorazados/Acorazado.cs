namespace Acorazados;

public abstract class Acorazado
{
    protected int _fila;
    protected int _columna;
    protected Direccion _direccion;
    public Acorazado(int fila, int columna, Direccion direccion)
    {
        _fila = fila;
        _columna = columna;
        _direccion = direccion;
    }
    
    public abstract string Letra { get; }
    public abstract int CantidadMaximaAcorazadosEnTablero { get; }
    public List<SegmentoAcorazado> SegmentosAcorazado { get;  } = new();
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

    protected void AsignarSegmentos(int fila, int columna, Direccion direccion, int cantidadSegmentos)
    {
        for (int i = 0; i < cantidadSegmentos; i++)
        {
            switch (direccion)
            {
                case Direccion.Derecha:
                    SegmentosAcorazado.Add(new SegmentoAcorazado(fila, columna+i, false));
                    break;
                case Direccion.Abajo:
                    SegmentosAcorazado.Add(new SegmentoAcorazado(fila+i, columna, false));
                    break;
                case Direccion.Izquierda:
                    SegmentosAcorazado.Add(new SegmentoAcorazado(fila, columna-i, false));
                    break;
                default:
                    SegmentosAcorazado.Add(new SegmentoAcorazado(fila-i, columna, false));
                    break;
            }
        }    
    }
}

public record SegmentoAcorazado(int fila, int columna, bool destruido);
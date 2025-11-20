namespace Acorazados;

public class Jugador
{
    public string Nombre { get; private set; }
    private string[,] Tablero;

    private List<Acorazado> Acorazados = new List<Acorazado>();

    public Jugador(string player, List<AcorazadoAcuatizado> acorazados)
    {
        Nombre = player;
        Tablero = new string[10, 10];
        foreach (var acorazado in acorazados)
            AgregarAcorazado(acorazado);
    }
  
    private void AgregarAcorazado(AcorazadoAcuatizado acorazadoAcuatizado)
    {
        ValidarCantidadMaximaTipoAcorazado(acorazadoAcuatizado.tipoAcorazado);

        for (int i = 0; i < acorazadoAcuatizado.tipoAcorazado.CantidaCasillasOcupadasPorAcorazado; i++)
        {
            switch (acorazadoAcuatizado.direccion)
            {
                case Direccion.Derecha:
                    AsignarCasillaAcorazado(acorazadoAcuatizado.tipoAcorazado, acorazadoAcuatizado.fila, acorazadoAcuatizado.columna + i);
                    break;
                case Direccion.Abajo:
                    AsignarCasillaAcorazado(acorazadoAcuatizado.tipoAcorazado, acorazadoAcuatizado.fila + i, acorazadoAcuatizado.columna);
                    break;
                case Direccion.Izquierda:
                    AsignarCasillaAcorazado(acorazadoAcuatizado.tipoAcorazado, acorazadoAcuatizado.fila, acorazadoAcuatizado.columna - i);
                    break;
                default:
                    AsignarCasillaAcorazado(acorazadoAcuatizado.tipoAcorazado, acorazadoAcuatizado.fila - i, acorazadoAcuatizado.columna);
                    break;
            }
        }

        Acorazados.Add(acorazadoAcuatizado.tipoAcorazado);
    }

    private void AsignarCasillaAcorazado(Acorazado tipoAcorazado, int fila, int columna)
    {
        ValidacionesTablero(fila, columna);
        Tablero[fila, columna] = tipoAcorazado.Letra;
        tipoAcorazado.SegmentosAcorazado.Add(new SegmentoAcorazado(fila, columna, false));
    }

    private void ValidarCantidadMaximaTipoAcorazado(Acorazado tipoAcorazado)
    {
        int cantidadAcorazadosPorTipo = Acorazados.Where(x => x.GetType() == tipoAcorazado.GetType()).Count();
        if (cantidadAcorazadosPorTipo == tipoAcorazado.CantidadMaximaAcorazadosEnTablero)
            throw new ArgumentException("Se supero el maximo de acorazados de este tipo");
    }

    private void ValidacionesTablero(int x, int y)
    {
        if (ObtenerLongitudTablero(0) - 1 < x || ObtenerLongitudTablero(1) - 1 < y || x < 0 || y < 0)
        {
            throw new ArgumentOutOfRangeException("No es posible ubicar el acorazado en esa direccion");
        }

        if (!string.IsNullOrEmpty(ObtenerCasilla(x, y)))
        {
            throw new ArgumentException("Ya existe un acorazado en esa posicion");
        }
    }

    private string ObtenerCasilla(int x, int y)
    {
        return Tablero[x, y];
    }

    public string[,] ObtenerTablero()
    {
        return (string[,])Tablero.Clone();
    }

    public int ObtenerLongitudTablero(int dimension)
    {
        return Tablero.GetLength(dimension);
    }

    public void RecibirDisparo(int fila, int columna)
    {
        var valorCasilla = ObtenerCasilla(fila, columna);
        switch (valorCasilla)
        {
            case "c":
                GestionarDisparo<PortaAviones>(fila, columna);
                break;
            case "d":
                GestionarDisparo<Destructor>(fila, columna);
                break;
            case "g":
                GestionarDisparo<Cañonero>(fila, columna);
                break;
            default:
                Tablero[fila, columna] = "o";
                break;
        }
    }

    private void GestionarDisparo<T>(int fila, int columna) where T : Acorazado
    {
        var acorazados = Acorazados.Where(acorazado => acorazado.GetType() == typeof(T));
        foreach (var acorazado in acorazados)
        {
            if (acorazado.SegmentosAcorazado.Any(segmento => segmento.fila == fila && segmento.columna == columna))
            {
                acorazado.RegistrarDisparo(fila, columna);
                RegistrarDisparoAcorazadoEnTablero(fila, columna, acorazado);
            }
        }
    }

    private void RegistrarDisparoAcorazadoEnTablero(int fila, int columna, Acorazado acorazado)
    {
        if (acorazado.EstaDestruido)
        {
            foreach (var segmento in acorazado.SegmentosAcorazado)
            {
                Tablero[segmento.fila, segmento.columna] = "X";
            }
        }
        else
        {
            Tablero[fila, columna] = "x";
        }
    }
}
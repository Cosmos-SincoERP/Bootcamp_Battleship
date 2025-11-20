namespace Acorazados;

public class Jugador
{
    public string Nombre { get; private set; }
    private string[,] Tablero;
    private List<Acorazado> Acorazados = new();

    public Jugador(string player, List<Acorazado> acorazados)
    {
        Nombre = player;
        Tablero = new string[10, 10];
        foreach (var acorazado in acorazados)
            AgregarAcorazado(acorazado);
    }

    private void AgregarAcorazado(Acorazado acorazadoAcuatizado)
    {
        ValidarCantidadMaximaTipoAcorazado(acorazadoAcuatizado);
        acorazadoAcuatizado.SegmentosAcorazado.ForEach(segmento =>
            AsignarCasillaAcorazado(acorazadoAcuatizado, segmento.fila, segmento.columna));

        Acorazados.Add(acorazadoAcuatizado);
    }

    private void AsignarCasillaAcorazado(Acorazado tipoAcorazado, int fila, int columna)
    {
        ValidacionesTablero(fila, columna);
        Tablero[fila, columna] = tipoAcorazado.Letra;
    }

    private void ValidarCantidadMaximaTipoAcorazado(Acorazado tipoAcorazado)
    {
        int cantidadAcorazadosPorTipo = Acorazados.Where(x => x.GetType() == tipoAcorazado.GetType()).Count();
        if (cantidadAcorazadosPorTipo == tipoAcorazado.CantidadMaximaAcorazadosEnTablero)
            throw new ArgumentException("Se supero el maximo de acorazados de este tipo");
    }

    private void ValidacionesTablero(int fila, int columna)
    {
        if (EstaAfueraDelTablero(fila, columna))
        {
            throw new ArgumentOutOfRangeException("No es posible ubicar el acorazado en esa direccion");
        }

        if (!string.IsNullOrEmpty(ObtenerCasilla(fila, columna)))
        {
            throw new ArgumentException("Ya existe un acorazado en esa posicion");
        }
    }

    private bool EstaAfueraDelTablero(int fila, int columna)
    {
        return ObtenerLongitudTablero(0) - 1 < fila
               || ObtenerLongitudTablero(1) - 1 < columna
               || fila < 0
               || columna < 0;
    }

    private string ObtenerCasilla(int fila, int columna)
    {
        return Tablero[fila, columna];
    }

    public string[,] ObtenerTablero()
    {
        return (string[,])Tablero.Clone();
    }

    public int ObtenerLongitudTablero(int dimension)
    {
        return Tablero.GetLength(dimension);
    }

    public string RecibirDisparo(int fila, int columna)
    {
        if (EstaAfueraDelTablero(fila, columna))
        {
            throw new ArgumentOutOfRangeException("No es posible disparar en esa direccion");
        }

        var valorCasilla = ObtenerCasilla(fila, columna);
        switch (valorCasilla)
        {
            case Constantes.LetraPortaAviones:
                return GestionarDisparo<PortaAviones>(fila, columna);
            case Constantes.LetraDestructor:
                return GestionarDisparo<Destructor>(fila, columna);
            case Constantes.LetraCoñonero:
                return GestionarDisparo<Cañonero>(fila, columna);
            case null:
                Tablero[fila, columna] = Constantes.LetraDisparoFallido;
                break;
        }

        return "Disparo fallido";
    }

    private string GestionarDisparo<T>(int fila, int columna) where T : Acorazado
    {
        var acorazados = Acorazados.Where(acorazado => acorazado.GetType() == typeof(T));
        foreach (var acorazado in acorazados)
        {
            if (acorazado.SegmentosAcorazado.Any(segmento => segmento.fila == fila && segmento.columna == columna))
            {
                acorazado.RegistrarDisparo(fila, columna);
                return RegistrarDisparoAcorazadoEnTablero(fila, columna, acorazado);
            }
        }

        return "Segmento no encontrado";
    }

    private string RegistrarDisparoAcorazadoEnTablero(int fila, int columna, Acorazado acorazado)
    {
        if (acorazado.EstaDestruido)
        {
            foreach (var segmento in acorazado.SegmentosAcorazado)
            {
                Tablero[segmento.fila, segmento.columna] = Constantes.LetraAcorazadoHundido;
            }

            return "Se ha hundido un acorazado";
        }

        Tablero[fila, columna] = Constantes.LetraDisparoAcertado;
        return "Se ha interceptado un acorazado";
    }

    public InformeJuego ObtenerReporteJuego()
    {
        int cantidadDisparosFallidos = SumarCantidadLetras(Constantes.LetraDisparoFallido);
        int cantidadDisparosAcertados = SumarCantidadLetras(Constantes.LetraDisparoAcertado) +
                                        SumarCantidadLetras(Constantes.LetraAcorazadoHundido);
        int totalDisparos = cantidadDisparosFallidos + cantidadDisparosAcertados;
        var barcosHundidos = Acorazados.Where(acorazado => acorazado.EstaDestruido).Select(acorazado =>
                $"{acorazado.GetType().Name}: ({(acorazado.SegmentosAcorazado[0].fila)},{acorazado.SegmentosAcorazado[0].columna})")
            .ToList();

        return new InformeJuego(
            Nombre,
            totalDisparos,
            cantidadDisparosAcertados,
            cantidadDisparosFallidos,
            barcosHundidos);
    }

    private int SumarCantidadLetras(string listaLetras)
    {
        return Tablero.Cast<string>().Count(letra => letra == listaLetras);
    }

    public bool NoTieneAcorazadosAflote()
    {
        return Acorazados.All(acorazado => acorazado.EstaDestruido);
    }
}
namespace AcorazadosTests;

public class Jugador
{
    private int _longitudColumnas;
    private int _longitudFilas;
    private int _cantidadCarriers;
    private int _cantidadDestroyers;
    private int _cantidadGunships;

    public string Alias { get; private set; }
    public string[,] Tablero { get; init; }
    public int DisparosTotales { get; private set; }
    public int Aciertos { get; private set; }
    public int Fallos { get; set; }

    private List<NavePosicionada> _naves = new();

    public Jugador(string alias)
    {
        Alias = alias;
    }

    public void DispararA(Jugador oponente, int fila, int columna)
    {
        DisparosTotales++;
        var resultado = oponente.RecibirDisparo(fila, columna);
        if (resultado is ResultadoDisparo.Tocado or ResultadoDisparo.Hundido)
            Aciertos++;
        if (resultado == ResultadoDisparo.Agua)
            Fallos++;
    }

    public string ObtenerElemento(int fila, int columna) => Tablero[fila, columna];

    public void AgregarGunShip(int fila, int columna)
    {
        if (EsMaxCantidadGunShipsPermitido())
            LanzaExcepcionSiSuperaLimiteTipoNave();
        if (EstaNavePosicionadaEnCoordenada(fila, columna))
            LanzarExepcionPorNaveSuperpuesta();
        PosicionarNave(new GunShip(), Orientacion.Horizontal, fila, columna);
        _cantidadGunships++;
    }


    public void AgregarDestroyer(int fila, int columna, Orientacion orientacion)
    {
        if (EsMaxCantidadDestroyerPermitido())
            LanzaExcepcionSiSuperaLimiteTipoNave();

        LanzarExcepcionSiSuperaLimitesTablero(fila, columna, new Destroyer().Longitud, orientacion);
        PosicionarNave(new Destroyer(), orientacion, fila, columna);
        _cantidadDestroyers++;
    }


    public void AgregarCarrier(int fila, int columna, Orientacion orientacion)
    {
        if (EsMaxCantidadCarriersPermitido())
            LanzaExcepcionSiSuperaLimiteTipoNave();
        LanzarExcepcionSiSuperaLimitesTablero(fila, columna, new Carrier().Longitud, orientacion);
        PosicionarNave(new Carrier(), orientacion, fila, columna);
        _cantidadCarriers++;
    }


    public string ImprimirTablero()
    {
        var tablero = " |";
        tablero = AgregarEncabezado(tablero);
        tablero = AgregarSaltoDeLinea(tablero);

        for (var posicionFila = 0; posicionFila < Tablero.GetLength(0); posicionFila++)
        {
            for (var posicionColumna = 0; posicionColumna < Tablero.GetLength(1); posicionColumna++)
            {
                if (posicionColumna == 0)
                    tablero += $"{posicionFila}|";

                tablero = AgregarElementoACasilla(posicionFila, posicionColumna, tablero);
                tablero = AgregarSaltoDeLineaEnBorde(posicionColumna, tablero);
            }
        }

        return tablero;
    }

    public ResultadoDisparo RecibirDisparo(int x, int y)
    {
        if (EstaCasillaConDisparo(x, y))
            LanzarExcepcionNoSePuedeDispararALaMismaCoordenada();
        var casilla = ObtenerElemento(x, y);
        if (casilla is "d" or "c" or "g")
        {
            Tablero[x, y] = ResultadoDisparo.Tocado.ValorDisparo();
            if (MarcaNaveHundida(x, y))
            {
                return ResultadoDisparo.Hundido;
            }
            return ResultadoDisparo.Tocado;
        }
        Tablero[x, y] = ResultadoDisparo.Agua.ValorDisparo();
        return ResultadoDisparo.Agua;
    }

    public bool HaPosicionadoTodasLasNaves()
    {
        bool carriersListos = _cantidadCarriers == new Carrier().MaxPermitidos;
        bool destroyersListos = _cantidadDestroyers == new Destroyer().MaxPermitidos;
        bool gunshipsListos = _cantidadGunships == new GunShip().MaxPermitidos;

        return carriersListos && destroyersListos && gunshipsListos;
    }

    private bool MarcaNaveHundida(int fila, int columna)
    {
        var nave = _naves.FirstOrDefault(nave =>
            nave.Posiciones.Any(posicion => posicion.fila == fila && posicion.columna == columna));
        if (nave == null)
            return false;
        if (!EsNaveHundida(nave))
            return false;

        foreach (var posicion in nave.Posiciones)
        {
            Tablero[posicion.fila, posicion.columna] = ResultadoDisparo.Hundido.ValorDisparo();
        }
        return true;
    }

    private bool EsNaveHundida(NavePosicionada nave)
    {
        return nave.Posiciones.All(posicion =>
            Tablero[posicion.fila, posicion.columna] == ResultadoDisparo.Tocado.ValorDisparo() || Tablero[posicion.fila, posicion.columna] == ResultadoDisparo.Hundido.ValorDisparo());
    }


    private bool EstaCasillaConDisparo(int x, int y)
    {
        var casilla = Tablero[x, y];
        return casilla == ResultadoDisparo.Tocado.ValorDisparo() || casilla == ResultadoDisparo.Hundido.ValorDisparo() || casilla == ResultadoDisparo.Agua.ValorDisparo();
    }

    private bool EsMaxCantidadGunShipsPermitido() => _cantidadGunships >= new GunShip().MaxPermitidos;

    private bool EsMaxCantidadDestroyerPermitido() => _cantidadDestroyers >= new Destroyer().MaxPermitidos;
    private bool EsMaxCantidadCarriersPermitido() => _cantidadCarriers >= new Carrier().MaxPermitidos;


    private void PosicionarNave(INave nave, Orientacion orientacion, int fila, int columna)
    {
        var longitud = nave.Longitud;
        var posiciones = new List<(int fila, int columna)>();

        if (EstaNavePosicionadaEnCoordenada(fila, columna))
            LanzarExepcionPorNaveSuperpuesta();

        for (var posicion = 0; posicion < longitud; posicion++)
        {
            var siguienteFila = EsPosicionVertical(orientacion) ? fila + posicion : fila;
            var siguienteColumna = EsPosicionHorizontal(orientacion) ? columna + posicion : columna;
            Tablero[siguienteFila, siguienteColumna] = nave.Valor;
            posiciones.Add((siguienteFila, siguienteColumna));
        }

        _naves.Add(new NavePosicionada
        {
            Tipo = nave.Valor,
            Posiciones = posiciones
        });
    }


    private bool EstaNavePosicionadaEnCoordenada(int fila, int columna) => ObtenerElemento(fila, columna) != null;

    private void LanzarExcepcionNoSePuedeDispararALaMismaCoordenada() =>
        throw new InvalidOperationException("No se puede disparar al mismo punto");

    private void LanzaExcepcionSiSuperaLimiteTipoNave() =>
        throw new InvalidOperationException("Cantidad máxima de tipo de nave alcanzada");

    private void LanzarExepcionPorNaveSuperpuesta() =>
        throw new InvalidOperationException("No se puede superponer una nave");

    private void LanzarExcepcionSiSuperaLimitesTablero(int fila, int columna, int longitud,
        Orientacion orientacion)
    {
        _longitudFilas = Tablero.GetLength(0);
        _longitudColumnas = Tablero.GetLength(1);

        if (EsNaveFueraRangoFila(fila, longitud, orientacion) ||
            EsNaveFueraRangoColumna(columna, longitud, orientacion))
            throw new IndexOutOfRangeException("Nave fuera del rango");
    }

    private bool EsPosicionHorizontal(Orientacion orientacion) => orientacion == Orientacion.Horizontal;

    private bool EsPosicionVertical(Orientacion orientacion) => orientacion == Orientacion.Vertical;

    private bool NoTieneEspacioSuficienteColumna(int columna, int longitud, Orientacion orientacion)
    {
        return columna + longitud > _longitudColumnas && EsPosicionHorizontal(orientacion);
    }

    private bool EsNaveFueraRangoColumna(int columna, int longitud, Orientacion orientacion)
    {
        return columna >= _longitudColumnas || columna < 0 ||
               NoTieneEspacioSuficienteColumna(columna, longitud, orientacion);
    }

    private bool EsNaveFueraRangoFila(int fila, int longitud, Orientacion orientacion)
    {
        return fila >= _longitudFilas || fila < 0 || NoTieneEspacioSuficienteEnFilas(fila, longitud, orientacion);
    }

    private bool NoTieneEspacioSuficienteEnFilas(int fila, int longitud, Orientacion orientacion)
    {
        return fila + longitud > _longitudFilas && EsPosicionVertical(orientacion);
    }


    private string AgregarSaltoDeLineaEnBorde(int posicionColumna, string tablero)
    {
        if (posicionColumna == Tablero.GetLength(1) - 1)
            tablero = AgregarSaltoDeLinea(tablero);
        return tablero;
    }

    private string AgregarElementoACasilla(int posicionFila, int posicionColumna, string tablero)
    {
        var casilla = Tablero[posicionFila, posicionColumna];
        tablero += (!string.IsNullOrEmpty(casilla) ? casilla : " ") + "|";
        return tablero;
    }


    private string AgregarEncabezado(string tablero)
    {
        for (int posicionColumna = 0; posicionColumna < Tablero.GetLength(1); posicionColumna++)
        {
            tablero += $"{posicionColumna}|";
        }

        return tablero;
    }

    private string AgregarSaltoDeLinea(string tablero)
    {
        tablero += "\r\n";
        return tablero;
    }
}
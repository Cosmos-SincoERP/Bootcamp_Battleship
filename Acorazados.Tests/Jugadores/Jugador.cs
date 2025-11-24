namespace AcorazadosTests;

public class Jugador
{
    public string Alias { get; private set; }
    public int Aciertos { get; private set; }
    public int DisparosTotales { get; private set; }
    public string[,] Tablero { get; init; }
    public int Fallos { get; set; }
    public NavesHundidas NaveHundida { get; init; } = new();

    public Jugador(string alias)
    {
        Alias = alias;
    }

    private int _longitudColumnas;
    private int _longitudFilas;
    private int _cantidadCarriers;
    private int _cantidadDestroyers;
    private int _cantidadGunships;
    private readonly List<NavePosicionada> _naves = [];

    public void DispararA(Jugador oponente, int fila, int columna)
    {
        AumentarDisparos();
        var resultado = oponente.RecibirDisparo(fila, columna);
        if (resultado is ResultadoDisparo.Tocado or ResultadoDisparo.Hundido)
            AumentarAciertos();
        if (resultado == ResultadoDisparo.Agua)
            AumentarFallos();
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

    public ResultadoDisparo RecibirDisparo(int fila, int columna)
    {
        if (EstaCasillaConDisparo(fila, columna))
            LanzarExcepcionNoSePuedeDispararALaMismaCoordenada();
        var casilla = ObtenerElemento(fila, columna);
        if (casilla is "d" or "c" or "g")
        {
            Tablero[fila, columna] = ResultadoDisparo.Tocado.ValorDisparo();
            if (MarcaNaveHundida(fila, columna))
            {
                return ResultadoDisparo.Hundido;
            }

            return ResultadoDisparo.Tocado;
        }

        Tablero[fila, columna] = ResultadoDisparo.Agua.ValorDisparo();
        return ResultadoDisparo.Agua;
    }

    public bool HaPosicionadoTodasLasNaves()
    {
        bool carriersListos = _cantidadCarriers == new Carrier().MaxPermitidos;
        bool destroyersListos = _cantidadDestroyers == new Destroyer().MaxPermitidos;
        bool gunshipsListos = _cantidadGunships == new GunShip().MaxPermitidos;

        return carriersListos && destroyersListos && gunshipsListos;
    }

    public bool TodasLasNavesHundidas()
    {
        if (_naves.Count == 0)
            return false;
        return _naves.All(nave => EsNaveHundida(nave));
    }

    private void AumentarFallos() => Fallos++;

    private void AumentarAciertos() => Aciertos++;

    private void AumentarDisparos() => DisparosTotales++;

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
            if ((string)nave.TipoNave == new GunShip().Valor)
                NaveHundida.GunShips.Add(new ValueTuple<int, int>(posicion.fila, posicion.columna));
            else if ((string)nave.TipoNave == new Destroyer().Valor && nave.Posiciones[0].fila == posicion.fila &&
                     nave.Posiciones[0].columna == posicion.columna)
                NaveHundida.Destroyer.Add(new ValueTuple<int, int>(posicion.fila, posicion.columna));
            else if (nave.Posiciones[0].fila == posicion.fila && nave.Posiciones[0].columna == posicion.columna)
                NaveHundida.Carrier.Add(new ValueTuple<int, int>(posicion.fila, posicion.columna));
        }

        return true;
    }

    private bool EsNaveHundida(NavePosicionada nave)
    {
        return nave.Posiciones.All(posicion =>
            Tablero[posicion.fila, posicion.columna] == ResultadoDisparo.Tocado.ValorDisparo() ||
            Tablero[posicion.fila, posicion.columna] == ResultadoDisparo.Hundido.ValorDisparo());
    }


    private bool EstaCasillaConDisparo(int x, int y)
    {
        var casilla = Tablero[x, y];
        return casilla == ResultadoDisparo.Tocado.ValorDisparo() ||
               casilla == ResultadoDisparo.Hundido.ValorDisparo() || casilla == ResultadoDisparo.Agua.ValorDisparo();
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
            TipoNave = nave.Valor,
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
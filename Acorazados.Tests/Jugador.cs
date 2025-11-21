using System.Runtime.CompilerServices;
using System.Text;

namespace AcorazadosTests;

public class Jugador
{
    private int _longitudColumnas;
    private int _longitudFilas;

    public Jugador(string alias)
    {
        Alias = alias;
    }

    public string Alias { get; private set; }
    public string[,] Tablero { get; init; }

    public string ObtenerElemento(int fila, int columna) => Tablero[fila, columna];
    public void AgregarGunShip(int fila, int columna) => Tablero[fila, columna] = new GunShip().Valor;

    public void AgregarDestroyer(int fila, int columna, Orientacion orientacion)
    {
        LanzarExcepcionSiSuperaLimitesTablero(fila, columna, new Destroyer().Longitud, orientacion);
        PosicionarNave(new Destroyer(), orientacion, fila, columna);
    }

    public void AgregarCarrier(int fila, int columna, Orientacion orientacion)
    {
        LanzarExcepcionSiSuperaLimitesTablero(fila, columna, new Carrier().Longitud, orientacion);
        PosicionarNave(new Carrier(), orientacion, fila, columna);
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

    private void PosicionarNave(INave nave, Orientacion orientacion, int fila, int columna)
    {
        var longitud = nave.Longitud;

        for (var posicion = 0; posicion < longitud; posicion++)
        {
            var siguienteFila = EsPosicionVertical(orientacion) ? fila + posicion : fila;
            var siguienteColumna = EsPosicionHorizontal(orientacion) ? columna + posicion : columna;
            Tablero[siguienteFila, siguienteColumna] = nave.Valor;
        }
    }


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

    public (int x, int y) Disparar(int fila, int columna)
    {
        return (fila, columna);
    }

    public void RecibirDisparo(int x, int y)
    {
        if (ObtenerElemento(x, y) == "g")
            Tablero[x, y] = "X";
        else
            Tablero[x, y] = "o";
    }
}
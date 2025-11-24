using System.Collections.ObjectModel;

namespace BattleshipsTDD;

public class Jugador
{
    public char[,] Tablero { get; set; }
    private readonly Informe _Informe = new();
    private Barco _barcoAsignado;

    public Jugador(char[,] tableroInicial)
    {
        Tablero = tableroInicial;
    }

    public Informe ObtenerInforme()
    {
        _Informe.ModificarRepresentacionTablero(Serializador.SerializarTablero(Tablero));
        return _Informe;
    }

    public void RegistrarBarco(Barco barco)
    {
        _barcoAsignado = barco;
    }

    public Barco ObtenerBarco() => _barcoAsignado;
}
using System.Collections.ObjectModel;

namespace BattleshipsTDD;

public class Jugador
{
    public Tablero Tablero { get; set; }
    private readonly Informe _Informe = new();
    private List<Barco> _barcosAsignados = new();

    public Jugador(Tablero tableroInicial)
    {
        Tablero = tableroInicial;
    }

    public Informe ObtenerInforme()
    {
        _Informe.ModificarRepresentacionTablero(Tablero.TableroSerializado);
        return _Informe;
    }

    public void RegistrarBarco(Barco barco)
    {
        _barcosAsignados.Add(barco);
    }

    public List<Barco> ObtenerBarcos() => _barcosAsignados;

    public Barco ObtenerBarcoPorCoordenada(Coordenada coordenada)
    {
        return _barcosAsignados.First(b =>
            b.ObtenerPartes().Any(p =>  p.Coordenada.Columna == coordenada.Columna && p.Coordenada.Fila == coordenada.Fila)
        );
    }
}
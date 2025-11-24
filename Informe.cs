using System.Collections.ObjectModel;

namespace BattleshipsTDD;

public class Informe
{
    public int DisparosRecibidos { get; private set; }
    public int DisparosAsertadosEnemigo { get; private set; }
    public int DisparosFalladosEnemigo { get; private set; }
    public string RepresentacionTablero { get; private set; }

    private List<(TipoBarco TipoBarco, Coordenada cordenada)> _BarcosUndidos { get; set; } = new();

    public void RegistrarBarcoUndido(TipoBarco tipoBarco, Coordenada coordenada)
    {
        _BarcosUndidos.Add((tipoBarco, coordenada));
    }

    public ReadOnlyCollection<(TipoBarco TipoBarco, Coordenada cordenada)> ObtenerBarcosUndidos()
    {
        return _BarcosUndidos.AsReadOnly();
    }


    public void IncrementarDisparosRecibidosTotales()
    {
        DisparosRecibidos++;
    }

    public void IncrementarDisparosFallados()
    {
        DisparosFalladosEnemigo++;
    }

    public void IncrementarDisparosAsertados()
    {
        DisparosAsertadosEnemigo++;
    }

    public void ModificarRepresentacionTablero(string representacion)
    {
        RepresentacionTablero = representacion; 
    }
}
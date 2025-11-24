using System.Text;

namespace Acorazados.Core.Clases;

public class Jugador(string nombre)
{
    public Tablero Tablero { get; } = new();
    public string Nombre { get; } = nombre;

    public string ImprimirReporte() =>
        AgregarLineaJugador() +
        AgregarLineaDisparosTotales() +
        AgregarLineaDisparosFallidos() +
        AgregarLineaDisparosExitosos() +
        AgregarLineasBarcosHundidos() + '\n' +
        AgregarDibujoTablero();

    public string ImprimirTablero() =>
        AgregarLineaJugador() +
        AgregarDibujoTablero();
    
    
    private string AgregarLineaJugador() => $"  Jugador: {Nombre}\n";
    private string AgregarDibujoTablero() => Tablero.DibujarTablero();
    private string AgregarLineaDisparosTotales() => $"Disparos totales: {Tablero.ObtenerDisparosTotales()} ";
    private string AgregarLineaDisparosFallidos() => $"\n Fallidos: {Tablero.ObtenerDisparosFallidos()}";
    private string AgregarLineaDisparosExitosos() => $"\n Exitosos: {Tablero.ObtenerDisparosExitosos()}";
    private string AgregarLineasBarcosHundidos()
    {
        var barcosHundidos = Tablero.ConsultarBarcosHundidos();
    
        if (!barcosHundidos.Any())
            return "\n Barcos hundidos: []";
    
        var contenidoBarcosHundidos = ConcatenarBarcos(barcosHundidos);
        return $"\n Barcos hundidos: [ {contenidoBarcosHundidos} ]";
    }
    private string ConcatenarBarcos(List<Barcos> barcosHundidos) =>
        string.Join(",",
            barcosHundidos.Select(ObtenerDescripcionBarco)
        );
    private string ObtenerDescripcionBarco(Barcos barco)
    {
        var coordenada = barco.Coordenadas[0];
        return $"{barco.Nombre}: ({coordenada.X},{coordenada.Y})";
    }
}
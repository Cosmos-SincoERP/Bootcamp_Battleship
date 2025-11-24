using System.Collections.ObjectModel;

namespace BattleshipsTDD;

public class Barco
{
    private List<ParteBarco> _partes = new();

    public void AgregarParte(Coordenada coordenada)
    {
        _partes.Add(new ParteBarco { Coordenada = coordenada, Undida = false });
    }

    public void UndirParte(Coordenada coordenada)
    {
        if (ObtenerParteBarco(coordenada) is { } parte)
        {
            parte.Undida = true;
        }
    }

    private ParteBarco? ObtenerParteBarco(Coordenada coordenada)
    {
        return _partes.Find(p =>
            p.Coordenada.Columna == coordenada.Columna && p.Coordenada.Fila == coordenada.Fila);
    }

    public bool EstaElBarcoDestruido() => _partes.All(p => p.Undida);

    public ReadOnlyCollection<ParteBarco> ObtenerPartes()
    {
        return _partes.AsReadOnly();
    }
}

public class ParteBarco
{
    public Coordenada Coordenada { get; set; }
    public bool Undida { get; set; } = false;
}
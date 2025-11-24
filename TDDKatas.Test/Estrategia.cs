using System.Collections.ObjectModel;

namespace TDDKatas;

internal class Estrategia
{
    private List<Despliegue> _despliegues;

    public Estrategia(List<Despliegue>  despliegues)
    {
        _despliegues = despliegues;
    }

    public Despliegue ObtenerDespliegueEnCoordenada(Coordenada coordenadas) => _despliegues.First(x =>
        x.CoordenadasNave().Contains(coordenadas));

    public ReadOnlyCollection<Despliegue> ObtenerNaves() => _despliegues.AsReadOnly();
    
    public Despliegue ObtenerNave(int indice) => _despliegues[indice];
    
    public int CantidadNaves() => _despliegues.Count;

    public int CantidadNavesPorTipo(TiposNave tipo) => _despliegues.Count(despliegue => despliegue.Nave.Tipo == tipo);
    
    public void AgregarDespliegue(Despliegue despliegue) => _despliegues.Add(despliegue);





}
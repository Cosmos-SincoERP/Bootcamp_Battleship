namespace Acorazados.Test;

public class Nave
{
    public int FilaInicial { get; set; }
    public int ColumnaInicial { get; set; }
    public string Tipo { get; set; }
    public int FilaFinal { get; set; }
    public int ColumnaFinal { get; set; }
    
    public int CantidadDisparosRecibidos { get; private set; }

    public Nave(int filaInicial, int columnaInicial, int filaFinal, int columnaFinal, string tipo)
    {
        FilaInicial = filaInicial;
        FilaFinal = filaFinal;
        ColumnaInicial = columnaInicial;
        ColumnaFinal = columnaFinal;
        Tipo = tipo;
    }

    public int ObtenerTamano()
    {
        return Tipo switch
        {
            "g" => 1,
            "d" => 3,
            "c" => 4,
            _ => 0
        };
    }
    
    public string ObtenerNombre()
    {
        return Tipo switch
        {
            "g" => "Gunship",
            "d" => "Destroyer",
            "c" => "Carrier",
            _ => ""
        };
    }

    public void AumentarDisparo() => CantidadDisparosRecibidos++;
    public bool EstoyEnCoordenada(int fila, int columna) => EstaEntreLasFilas(fila) && EstaEntreLasColumnas(columna);
    
    private bool EstaEntreLasFilas(int fila) => fila >= FilaInicial && fila <= FilaFinal;

    private bool EstaEntreLasColumnas(int columna) => columna >= ColumnaInicial && columna <= ColumnaFinal;
}
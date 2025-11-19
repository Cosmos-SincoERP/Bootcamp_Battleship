namespace Acorazados.Test;

public class Nave
{
    public int FilaInicial { get; set; }
    public int ColumnaInicial { get; set; }
    public string Tipo { get; set; }
    public int FilaFinal { get; set; }

    public Nave(int filaInicial, int columnaInicial, int filaFinal, int columnaFinal, string tipo)
    {
        FilaInicial = filaInicial;
        ColumnaInicial = columnaInicial;
        FilaFinal = filaFinal;
        Tipo = tipo;
    }
}
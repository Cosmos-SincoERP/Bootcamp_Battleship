namespace Acorazados;

public class Cañonero : Acorazado
{
    public Cañonero(int fila, int columna, Direccion direccion) : base(fila, columna, direccion)
    {
        AsignarSegmentos(fila,columna,direccion,1);
    }

    public override string Letra => "g";
    public override int CantidadMaximaAcorazadosEnTablero => 4;
}
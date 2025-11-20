namespace Acorazados;

public class Destructor : Acorazado
{
    public override string Letra => "d";
    public override int CantidadMaximaAcorazadosEnTablero => 2;
    public Destructor(int fila, int columna, Direccion direccion) : base(fila, columna, direccion)
    {
        AsignarSegmentos(fila,columna,direccion,3);    
    }
}
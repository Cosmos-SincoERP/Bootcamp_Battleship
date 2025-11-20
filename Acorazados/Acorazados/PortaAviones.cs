namespace Acorazados;

public class PortaAviones : Acorazado
{
    public override string Letra => Constantes.LetraPortaAviones;
    public override int CantidadMaximaAcorazadosEnTablero => 1;
    
    public PortaAviones(int fila, int columna, Direccion direccion) : base(fila, columna, direccion)
    {
        AsignarSegmentos(fila,columna,direccion,4);
    }

}
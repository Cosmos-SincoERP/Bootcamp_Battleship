namespace Acorazados;



public enum Direccion
{
    Arriba, 
    Derecha,
    Izquierda,
    Abajo
}


public abstract class Acorazado
{
    public abstract string Letra { get; }
    public abstract int CantidadMaximaAcorazadosEnTablero { get; }
    public abstract int CantidaCasillasOcupadasPorAcorazado { get; }
}

public class Cañonero : Acorazado
{
    public override string Letra => "g";
    public override int CantidadMaximaAcorazadosEnTablero => 4;
    public override int CantidaCasillasOcupadasPorAcorazado => 1;
}

public class Destructor : Acorazado
{
    public override string Letra => "d";
    public override int CantidadMaximaAcorazadosEnTablero => 2;
    public override int CantidaCasillasOcupadasPorAcorazado => 3;
}

public class PortaAviones : Acorazado
{
    public override string Letra => "c";
    public override int CantidadMaximaAcorazadosEnTablero => 1;
    public override int CantidaCasillasOcupadasPorAcorazado => 4;
}




public class Jugador
{
    public string Nombre { get; private set; }
    private string[,] Tablero;
    
    private List<Acorazado> Acorazados = new List<Acorazado>();

    public Jugador(string player)
    {
        Nombre = player;
        Tablero = new string[10,10];
    }

    public void AgregarAcorazado(Acorazado tipoAcorazado, int fila, int columna, Direccion? direccion = null)
    {
        ValidarCantidadMaximaTipoAcorazado(tipoAcorazado);

        for (int i = 0; i < tipoAcorazado.CantidaCasillasOcupadasPorAcorazado; i++)
        {
            switch (direccion)
            {
                case Direccion.Derecha:
                    AsignarCasillaAcorazado(tipoAcorazado, fila, columna+i);
                    break;
                case Direccion.Abajo:
                    AsignarCasillaAcorazado(tipoAcorazado, fila+i, columna);
                    break;
                case Direccion.Izquierda:
                    AsignarCasillaAcorazado(tipoAcorazado, fila, columna-i);
                    break;
                default:
                    AsignarCasillaAcorazado(tipoAcorazado, fila-i, columna);
                    break;
            }
        }
        Acorazados.Add(tipoAcorazado);
    }

    private void AsignarCasillaAcorazado(Acorazado tipoAcorazado, int fila, int columna)
    {
        ValidacionesTablero(fila, columna);
        Tablero[fila, columna] = tipoAcorazado.Letra;
    }



    private void ValidarCantidadMaximaTipoAcorazado(Acorazado tipoAcorazado)
    {
        int cantidadAcorazadosPorTipo = Acorazados.Where(x => x.GetType() == tipoAcorazado.GetType()).Count();
        if(cantidadAcorazadosPorTipo == tipoAcorazado.CantidadMaximaAcorazadosEnTablero)
            throw new ArgumentException("Se supero el maximo de acorazados de este tipo");
    }

    private void ValidacionesTablero(int x, int y)
    {
        if (ObtenerLongitudTablero(0) - 1 < x || ObtenerLongitudTablero(1) - 1 < y || x < 0 || y < 0)
        {
            throw new ArgumentOutOfRangeException("No es posible ubicar el acorazado en esa direccion");
        }

        if (!string.IsNullOrEmpty(ObtenerCasilla(x, y)))
        {
            throw new ArgumentException("Ya existe un acorazado en esa posicion");
        }
    }

    private string ObtenerCasilla(int x, int y)
    {
        return Tablero[x, y];
    }
    
    public string[,] ObtenerTablero()
    {
        return  Tablero;
    }

    public int ObtenerLongitudTablero(int dimension)
    {
        return Tablero.GetLength(dimension);
    }
}
namespace Acorazados;

public enum Acorazado
{
    Cañonero = 1,
    Destructor = 3,
    Portaaviones = 4
}

public enum Direccion
{
    Arriba, 
    Derecha,
    Izquierda,
    Abajo
}

public class Jugador
{
    public string Nombre { get; private set; }
    private string[,] Tablero;
    private int _conteoCañoneros;
    private int _conteoDestructores;
    private int _conteoPortaaviones;
    private Dictionary<Acorazado, string> LetraAcozados = new Dictionary<Acorazado, string>
    {
        { Acorazado.Cañonero, "g" },
        { Acorazado.Destructor, "d" },
        { Acorazado.Portaaviones, "c" }
    };


    public Jugador(string player)
    {
        Nombre = player;
        Tablero = new string[10,10];
    }

    public void AgregarAcorazado(Acorazado tipoAcorazado, int fila, int columna, Direccion? direccion = null)
    {
        ValidarCantidadMaximaTipoAcorazado(tipoAcorazado);

        for (int i = 0; i < (int)tipoAcorazado; i++)
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
        AumentarCantidadTipoAcorazado(tipoAcorazado);
    }

    private void AsignarCasillaAcorazado(Acorazado tipoAcorazado, int fila, int columna)
    {
        ValidacionesTablero(fila, columna);
        Tablero[fila, columna] = LetraAcozados[tipoAcorazado];
    }

    private void AumentarCantidadTipoAcorazado(Acorazado tipoAcorazado)
    {
        if(tipoAcorazado == Acorazado.Cañonero) 
            _conteoCañoneros++;
        if (tipoAcorazado == Acorazado.Destructor)
            _conteoDestructores++;
        if (tipoAcorazado == Acorazado.Portaaviones)
            _conteoPortaaviones++;
    }

    private void ValidarCantidadMaximaTipoAcorazado(Acorazado tipoAcorazado)
    {
        if(_conteoCañoneros==4 && tipoAcorazado == Acorazado.Cañonero)
            throw new ArgumentException("Se supero el maximo de acorazados de este tipo");
        if(_conteoDestructores==2 && tipoAcorazado == Acorazado.Destructor)
            throw new ArgumentException("Se supero el maximo de acorazados de este tipo");
        if(_conteoPortaaviones==1 && tipoAcorazado == Acorazado.Portaaviones)
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
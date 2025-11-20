namespace Test.BattleShip;

public class JuegoAcorazado
{
    private List<string> _jugadores = new();
    private readonly char[,] _tablero;

    public JuegoAcorazado(int tamañoTablero = 10)
    {
        if (tamañoTablero <= 0)
            throw new ArgumentOutOfRangeException();
        _tablero = new char[tamañoTablero, tamañoTablero];
    }

    public void AgregarPortaAviones(int posicionX, int posicionY, string direccion)
    {
        for (var i = 0; i < 4; i++)
        {
            if (direccion == "Vertical")
            {
                ValidarPosicionDeLaNave(posicionY + i, 1, "Portaviones");
                AsignarElValorDeLaNaveALaPosicion(posicionX, posicionY + i, 'c');
            }
            else
            {
                ValidarPosicionDeLaNave(posicionX + i, 0, "Portaviones");
                AsignarElValorDeLaNaveALaPosicion(posicionX + i, posicionY, 'c');
            }
        }
    }


    public void AgregarDestructor(int posicionEnX, int posicionEnY, string direccion)
    {
        if (direccion == "Vertical")
        {
            for (int i = 0; i < 3; i++)
            {
                ValidarPosicionDeLaNave(posicionEnY + i, 1, "Destructor");
                AsignarElValorDeLaNaveALaPosicion(posicionEnX, posicionEnY + i, 'd');
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                ValidarPosicionDeLaNave(posicionEnX + i, 0, "Destructor");
                AsignarElValorDeLaNaveALaPosicion(posicionEnX + i, posicionEnY, 'd');
            }
        }
    }

    public void AgregarCañonero(int posicionEnX, int posicionEnY)
    {
        ValidarPosicionDeLaNave(posicionEnX, 0, "Cañonero");
        ValidarPosicionDeLaNave(posicionEnY, 1, "Cañonero");
        AsignarElValorDeLaNaveALaPosicion(posicionEnX, posicionEnY, 'g');
    }

    public string Imprimir()
    {
        var visualizarTablero = string.Empty;
        for (var x = 0; x < _tablero.GetLength(0); x++)
        {
            for (int y = 0; y < _tablero.GetLength(1); y++)
            {
                visualizarTablero += _tablero[x, y];
            }

            visualizarTablero += '\n';
        }

        return visualizarTablero;
    }
    
    
    public void AgregarJugador()
    {
        if (_jugadores.Any())
        {
            var portaAviones  = _tablero.Cast<char>().Count(barco => barco.Equals('c'));
            if (portaAviones == 0)
                throw new Exception();
        }
        
        _jugadores.Add("Jugador 1");
    }
    
    private void ValidarPosicionDeLaNave(int posicion, int dimension, string nave)
    {
        if (posicion > _tablero.GetLength(dimension) - 1)
            throw new Exception($"La posicion del {nave} debe estar dentro del tablero");
    }

    private void AsignarElValorDeLaNaveALaPosicion(int posicionX, int posicionY, char valorNave)
    {
        _tablero[posicionX, posicionY] = valorNave;
    }

    public string ReporteBatalla()
    {
        return "Jugador 1";
    }
}
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

    public void AgregarBarco(PosicionarBarco posicionarBarco)
    {
        for (var i = 0; i < posicionarBarco.Barco.Tamaño ; i++)
        {
            if (posicionarBarco.Barco.Orientacion == Orientacion.Vertical)
            {
                ValidarPosicionDeLBarco(posicionarBarco.Coordenadas.Y + i, 1, posicionarBarco.Barco.GetType().Name);
                AsignarElValorDeLBarcoALaPosicion(posicionarBarco.Coordenadas.X, posicionarBarco.Coordenadas.Y + i, posicionarBarco.Barco.Valor);
            }
            else
            {
                ValidarPosicionDeLBarco(posicionarBarco.Coordenadas.X + i, 0, posicionarBarco.Barco.GetType().Name);
                AsignarElValorDeLBarcoALaPosicion(posicionarBarco.Coordenadas.X + i, posicionarBarco.Coordenadas.Y, posicionarBarco.Barco.Valor);
            }
        }
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
    
    public string ReporteBatalla()
    {
        return "Jugador 1";
    }
    
    private void ValidarPosicionDeLBarco(int posicion, int dimension, string valorNave)
    {
        if (posicion > _tablero.GetLength(dimension) - 1)
            throw new Exception($"La posicion del {valorNave} debe estar dentro del tablero");
    }

    private void AsignarElValorDeLBarcoALaPosicion(int posicionX, int posicionY, char valorBarco)
    {
        _tablero[posicionX, posicionY] = valorBarco;
    }
}
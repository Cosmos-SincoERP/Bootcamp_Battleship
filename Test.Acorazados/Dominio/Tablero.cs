namespace Test.BattleShip.Dominio;

public class Tablero(int tamaño)
{
    private readonly char[,] _plataforma = new char[tamaño, tamaño];

    public int ObtenerTamañoEnX() => _plataforma.GetLength(0);
    
    public int ObtenerTamañoEnY() => _plataforma.GetLength(1);

    public bool HayUnaMarca(Coordenada coordenada) => _plataforma[coordenada.X, coordenada.Y] != '\0';
    
    public void MarcarRepresentacionEnElTablero(Coordenada coordenada, char simbolo) =>
        _plataforma[coordenada.X, coordenada.Y] = simbolo;

    public string Visualizar()
    {
        var visualizar = string.Empty;
        for (var x = 0; x < _plataforma.GetLength(0); x++)
        {
            for (var y = 0; y < _plataforma.GetLength(1); y++)
            {
                var valorAMostar = _plataforma[x, y] == '\0' ? ' ' : _plataforma[x, y];
                visualizar += $" {valorAMostar} ";
            }
            visualizar += '\n';
        }

        return visualizar;
    }
    
    
}
namespace Test.BattleShip;

public class JuegoAcorazado
{
    private List<string> _jugadores = new();
    private char[,] _tablero = new char[10, 10];

    public void AgregarJugador(List<Nave>? naves = null)
    {
        if (naves != null)
            foreach (var nave in naves)
            {
                if (nave.Tipo == "Cañonero")
                    _tablero[nave.PosicionX, nave.PosicionY] = 'g';
                else if (nave.Tipo == "Portaviones")
                {
                    if (nave.Orientacion == "Horizontal")
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            _tablero[nave.PosicionX + i, nave.PosicionY] = 'c';
                        }
                    }
                    else
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            _tablero[nave.PosicionX, nave.PosicionY + i] = 'c';
                        }
                    }
                }
                else
                    _tablero[nave.PosicionX, nave.PosicionY] = 'd';
            }

        _jugadores.Add(_jugadores.Count == 1 ? "Jugador 2" : "Jugador 1");
    }

    public List<string> MostrarJugadores()
    {
        return _jugadores;
    }

    public void Iniciar()
    {
        if (_jugadores.Count != 2)
            throw new Exception("El juego no puede iniciarse hasta que se hayan agregado 2 jugadores");
    }

    public string Imprimir()
    {
        var tablero = string.Empty;
        for (var x = 0; x < _tablero.GetLength(0); x++)
        {
            for (int y = 0; y < _tablero.GetLength(1); y++)
            {
                tablero += _tablero[x, y];
            }

            tablero += '\n';
        }

        return tablero;
    }
}

public record Nave(int PosicionX, int PosicionY, string Tipo, string? Orientacion = null);
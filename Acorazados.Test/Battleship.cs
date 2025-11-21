using System.Text;

namespace Acorazados.Test;

public class Battleship
{
    private bool _turnoJugador1 = true;
    
    private bool _jugador1Gano;

    private bool _jugador2Gano;

    private string _jugador1 = "";

    private string _jugador2 = "";

    private int _conteoDisparosJugador1;
    
    private int _conteoDisparosJugador2;
    
    private int _conteoDisparosAcertadosJugador1;
    
    private int _conteoDisparosAcertadosJugador2;

    private readonly List<string> _tableroJugador1 =
    [
        "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |",
        "0| | | | | | | | | | |",
        "1| | | | | | | | | | |",
        "2| | | | | | | | | | |",
        "3| | | | | | | | | | |",
        "4| | | | | | | | | | |",
        "5| | | | | | | | | | |",
        "6| | | | | | | | | | |",
        "7| | | | | | | | | | |",
        "8| | | | | | | | | | |",
        "9| | | | | | | | | | |"
    ];

    private readonly List<string> _tableroJugador2 =
    [
        "| 0 | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 |",
        "0| | | | | | | | | | |",
        "1| | | | | | | | | | |",
        "2| | | | | | | | | | |",
        "3| | | | | | | | | | |",
        "4| | | | | | | | | | |",
        "5| | | | | | | | | | |",
        "6| | | | | | | | | | |",
        "7| | | | | | | | | | |",
        "8| | | | | | | | | | |",
        "9| | | | | | | | | | |"
    ];

    private List<Nave> _navesJugador1 = new();
    
    private List<Nave> _navesJugador2 = new();

    private List<Nave> _navesHundidasJugador1 = new();
    
    private List<Nave> _navesHundidasJugador2 = new();

    public void AddPlayer(string name)
    {
        if (_jugador1 == "")
            _jugador1 = name;
        else if (_jugador2 == "")
            _jugador2 = name;
    }

    public void Iniciar(List<Nave> navesJugador1, List<Nave> navesJugador2)
    {
        if (navesJugador1.Count == 0 && navesJugador2.Count == 0) return;

        UbicarNavesEnTablero(navesJugador1, _tableroJugador1);

        UbicarNavesEnTablero(navesJugador2, _tableroJugador2);

        _navesJugador1 = navesJugador1;
        _navesJugador2 = navesJugador2;
    }

    private static void UbicarNavesEnTablero(List<Nave> naves, List<string> tablero) =>
        naves.ForEach(nave => UbicarNave(nave, tablero));

    private static void UbicarNave(Nave nave, List<string> tablero)
    {
        if (EsVertical(nave))
            UbicarNaveVertical(nave, tablero);
        else
            UbicarNaveHorizontal(nave, tablero);
    }

    private static void UbicarNaveHorizontal(Nave nave, List<string> tablero)
    {
        var columnas = tablero[nave.FilaInicial + 1].Split("|");
        var estaHundido = nave.CantidadDisparosRecibidos == nave.ObtenerTamano();
        for (var i = 1; i <= nave.ObtenerTamano(); i++)
        {
            columnas[nave.ColumnaInicial + i] = estaHundido ? " X " : $" {nave.Tipo} ";
        }

        tablero[nave.FilaInicial + 1] = string.Join("|", columnas);
    }

    private static void UbicarNaveVertical(Nave nave, List<string> tablero)
    {
        var estaHundido = nave.CantidadDisparosRecibidos == nave.ObtenerTamano();
        for (var i = 1; i <= nave.ObtenerTamano(); i++)
        {
            var columna = tablero[nave.FilaInicial + i].Split("|");
            columna[nave.ColumnaInicial + 1] = estaHundido ? " X " : $" {nave.Tipo} ";

            tablero[nave.FilaInicial + i] = string.Join("|", columna);
        }
    }

    private static bool EsVertical(Nave nave) => nave.FilaInicial != nave.FilaFinal;

    public string? Disparar(int fila, int columna)
    {
        Nave? nave = _turnoJugador1
            ? UbicarDisparosEnTablero(fila, columna, _tableroJugador2, _navesJugador2)
            : UbicarDisparosEnTablero(fila, columna, _tableroJugador1, _navesJugador1);

        if (_turnoJugador1)
        {
            _conteoDisparosJugador1++;
            _conteoDisparosAcertadosJugador1 =
                nave == null ? _conteoDisparosAcertadosJugador1 : _conteoDisparosAcertadosJugador1 + 1;
            if (nave?.CantidadDisparosRecibidos == nave?.ObtenerTamano())
                if (nave != null)
                    _navesHundidasJugador1.Add(nave);
        }
        else
        {
            _conteoDisparosJugador2++;
            _conteoDisparosAcertadosJugador2 =
                nave == null ? _conteoDisparosAcertadosJugador2 : _conteoDisparosAcertadosJugador2 + 1;
            if (nave?.CantidadDisparosRecibidos == nave?.ObtenerTamano())
                if (nave != null)
                    _navesHundidasJugador2.Add(nave);
        }
        

        _jugador1Gano = _navesJugador2.Count != 0 && _navesJugador2.All(naveRecorrida => naveRecorrida.CantidadDisparosRecibidos == naveRecorrida.ObtenerTamano());
        _jugador2Gano = _navesJugador1.Count != 0 && _navesJugador1.All(naveRecorrida => naveRecorrida.CantidadDisparosRecibidos == naveRecorrida.ObtenerTamano());

        return nave?.CantidadDisparosRecibidos == nave?.ObtenerTamano() ? "Barco hundido" : string.Empty;
    }

    private Nave? UbicarDisparosEnTablero(int fila, int columna, List<string> tablero, List<Nave> navesJugador)
    {
        var columnas = tablero[fila + 1].Split("|");
        var nave = navesJugador.FirstOrDefault(nave => nave.EstoyEnCoordenada(fila, columna));
       
        if (nave == null)
        {
            columnas[columna + 1] = " o ";
            tablero[fila + 1] = string.Join("|", columnas);
            return nave;
        }

        nave.AumentarDisparo();

        columnas[columna + 1] = " x ";
        tablero[fila + 1] = string.Join("|", columnas);

        if (nave.CantidadDisparosRecibidos == nave.ObtenerTamano())
        {
            UbicarNave(nave, tablero);
        }

        return nave;
    }

    public void TerminarTurno() => _turnoJugador1 = !_turnoJugador1;

    public string Imprimir()
    {
        if (_jugador1Gano)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"[ {_jugador1}");
            sb.AppendLine($"    Total shots: {_conteoDisparosJugador1}");
            sb.AppendLine($"    Misses: {_conteoDisparosJugador1 - _conteoDisparosAcertadosJugador1}");
            sb.AppendLine($"    Hits: {_conteoDisparosAcertadosJugador1}");
            sb.AppendLine("    Ships Sunk: [");

            foreach (var nave in _navesHundidasJugador1)
            {
                sb.AppendLine($"        {nave.ObtenerNombre()}: ({nave.FilaInicial},{nave.ColumnaInicial})");
            }

            sb.Append("    ]");
            sb.Append(string.Join("", _tableroJugador2));

            return sb.ToString();
        }
        if (_jugador2Gano)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"[ {_jugador2}");
            sb.AppendLine($"    Total shots: {_conteoDisparosJugador2}");
            sb.AppendLine($"    Misses: {_conteoDisparosJugador2 - _conteoDisparosAcertadosJugador2}");
            sb.AppendLine($"    Hits: {_conteoDisparosAcertadosJugador2}");
            sb.AppendLine("    Ships Sunk: [");

            foreach (var nave in _navesHundidasJugador2)
            {
                sb.AppendLine($"        {nave.ObtenerNombre()}: ({nave.FilaInicial},{nave.ColumnaInicial})");
            }

            sb.Append("    ]");
            sb.Append(string.Join("", _tableroJugador1));

            return sb.ToString();
        }
        return string.Join("", _turnoJugador1 ? _tableroJugador1 : _tableroJugador2);
    }
}
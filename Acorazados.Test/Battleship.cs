using System.Text;

namespace Acorazados.Test;

public class Battleship
{
    private bool _enJuego;
    
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
        else
            throw new ApplicationException("No se pueden agregar mas de dos jugadores");
    }

    public void Iniciar(List<Nave> navesJugador1, List<Nave> navesJugador2)
    {
        if (string.IsNullOrEmpty(_jugador1) || string.IsNullOrEmpty(_jugador2))
            throw new ApplicationException("El juego requiere de dos jugadores para iniciar");
        
        _enJuego = true;
        
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
        if(_jugador1Gano || _jugador2Gano)
            throw new ApplicationException("No puede disparar cuando el juego ya acabó");
        if(!_enJuego)
            throw new ApplicationException("No puede disparar cuando el juego no ha comenzado");
        
        var (tableroObjetivo, navesObjetivo) = ObtenerTableroYNavesObjetivo();
    
        Nave? naveImpactada = UbicarDisparosEnTablero(fila, columna, tableroObjetivo, navesObjetivo);
    
        ActualizarEstadisticasDisparo(naveImpactada);
    
        if (NaveHundida(naveImpactada))
        {
            AgregarNaveHundida(naveImpactada);
        }
    
        VerificarGanadores();
    
        return NaveHundida(naveImpactada) ? "Barco hundido" : string.Empty;
    }

    private (List<string> tablero, List<Nave> naves) ObtenerTableroYNavesObjetivo()
    {
        return _turnoJugador1 
            ? (_tableroJugador2, _navesJugador2) 
            : (_tableroJugador1, _navesJugador1);
    }

    private void ActualizarEstadisticasDisparo(Nave? naveImpactada)
    {
        if (_turnoJugador1)
        {
            _conteoDisparosJugador1++;
            if (naveImpactada != null)
            {
                _conteoDisparosAcertadosJugador1++;
            }
        }
        else
        {
            _conteoDisparosJugador2++;
            if (naveImpactada != null)
            {
                _conteoDisparosAcertadosJugador2++;
            }
        }
    }

    private bool NaveHundida(Nave? nave) => nave != null && nave.CantidadDisparosRecibidos == nave.ObtenerTamano();

    private void AgregarNaveHundida(Nave? nave)
    {
        if (_turnoJugador1)
        {
            _navesHundidasJugador1.Add(nave);
        }
        else
        {
            _navesHundidasJugador2.Add(nave);
        }
    }

    private void VerificarGanadores()
    {
        _jugador1Gano = TodasLasNavesHundidas(_navesJugador2);
        _jugador2Gano = TodasLasNavesHundidas(_navesJugador1);
    }

    private bool TodasLasNavesHundidas(List<Nave> naves) =>
        naves.Count > 0 && 
        naves.All(nave => nave.CantidadDisparosRecibidos == nave.ObtenerTamano());

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

    public void TerminarTurno()
    {
        if(_jugador1Gano || _jugador2Gano)
            throw new ApplicationException("No puede terminar turno cuando el juego ya acabó");
        
        if(!_enJuego)
            throw new ApplicationException("No puede terminar turno cuando el juego no ha comenzado");
        
        _turnoJugador1 = !_turnoJugador1;
    }

    public string Imprimir()
    {
        if(!_enJuego)
            throw new ApplicationException("No puede disparar cuando el juego no ha comenzado");
        
        if (_jugador1Gano)
        {
            return ImprimirReporteVictoria(
                _jugador1, 
                _conteoDisparosJugador1, 
                _conteoDisparosAcertadosJugador1, 
                _navesHundidasJugador1, 
                _tableroJugador2
            );
        }
    
        if (_jugador2Gano)
        {
            return ImprimirReporteVictoria(
                _jugador2, 
                _conteoDisparosJugador2, 
                _conteoDisparosAcertadosJugador2, 
                _navesHundidasJugador2, 
                _tableroJugador1
            );
        }
    
        return ImprimirTablero(_turnoJugador1 ? _tableroJugador1 : _tableroJugador2);
    }

    private string ImprimirReporteVictoria(
        string nombreJugador, 
        int totalDisparos, 
        int disparosAcertados, 
        List<Nave> navesHundidas, 
        List<string> tableroOponente)
    {
        var sb = new StringBuilder();
    
        sb.AppendLine($"[ {nombreJugador}");
        sb.AppendLine($"    Total shots: {totalDisparos}");
        sb.AppendLine($"    Misses: {totalDisparos - disparosAcertados}");
        sb.AppendLine($"    Hits: {disparosAcertados}");
        sb.AppendLine("    Ships Sunk: [");
    
        foreach (var nave in navesHundidas)
        {
            sb.AppendLine($"        {nave.ObtenerNombre()}: ({nave.FilaInicial},{nave.ColumnaInicial})");
        }
    
        sb.Append("    ]");
        sb.Append(ImprimirTablero(tableroOponente));
    
        return sb.ToString();
    }

    private string ImprimirTablero(List<string> tablero) => string.Join("", tablero);
}
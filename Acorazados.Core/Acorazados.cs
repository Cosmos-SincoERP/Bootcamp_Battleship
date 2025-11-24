using Acorazados.Core.Clases;
using Acorazados.Core.Enum;

namespace Acorazados.Core;

public class Acorazados
{
    public EstadoJuego EstadoJuego { get; private set; } = EstadoJuego.NoIniciado;
    private const int CantidadMaximaJugadores = 2;
    private List<Jugador> Jugadores { get; } = [];
    private int _indiceJugadorOponente = 1;
    private int _indiceJugadorActual = 0;

    public void AgregarJugador(string nombre)
    {
        LanzarExcepcionSiExcedeCantidadMaximaDeJugadores();
        Jugadores.Add(new Jugador(nombre));
    }

    public Jugador ObtenerJugador(int indice) =>  Jugadores[indice];

    public void Iniciar()
    {
        LanzarExcepcionSiAlgunoDeLosDosJugadoresNoTieneBarcos();
        IniciarJuego();
    }

    public string Disparar(int x, int y)
    {
        LanzarExcepcionesSiElJuegoNoEstaEnCurso();
        var respuesta = ObtenerJugadorOponente().Tablero.RecibirDisparo(x, y);
        VerificarJuegoFinalizado(ObtenerJugadorOponente());
        
        return respuesta;
    }
    
    public string ImprimirTableroJugadorEnTurno()
    {
        var jugadorActual = ObtenerJugadorEnTurnoActual();
        return jugadorActual.ImprimirTablero();
    }
    
    public string ImprimirReporte()
    {
        LanzarExcepcionSiJuegoNoHaSidoFinalizado();
        return DibujarReporteDelJuego();
    }

    private string DibujarReporteDelJuego()
    {
        var jugador = Jugadores.Where(b => b.Tablero.BarcosNoHundidos()).FirstOrDefault();
        var jugadorGanador = $"El jugador ganador es: {jugador.Nombre} ";
        var reporte = DibujarInformacionDetalladaJugadores();
        return jugadorGanador + reporte;
    }

    private string DibujarInformacionDetalladaJugadores()
    {
        var reporteJugadores = string.Empty;
        foreach (var jugador in Jugadores)
        {
            if (!string.IsNullOrEmpty(reporteJugadores))
            {
                reporteJugadores = AgregarLineasDeSeparacion(reporteJugadores);
            }
            reporteJugadores += jugador.ImprimirReporte();
        }

        return reporteJugadores;
    }

    private static string AgregarLineasDeSeparacion(string reporteCompleto)
    {
        reporteCompleto += "\n";
        reporteCompleto += "---------------------------------------------------";
        reporteCompleto += "\n";
        return reporteCompleto;
    }

    private Jugador ObtenerJugadorOponente()
        => ObtenerJugador(_indiceJugadorOponente);

    private void CambiarTurno()
    {
        _indiceJugadorActual = 1 - _indiceJugadorActual;     
        _indiceJugadorOponente = 1 - _indiceJugadorOponente;
    }
    
    private void LanzarExcepcionSiExcedeCantidadMaximaDeJugadores()
    {
        if(Jugadores.Count == CantidadMaximaJugadores)
            throw new InvalidOperationException("No se pueden agregar más de dos jugadores");
    }
    private void LanzarExcepcionesSiElJuegoNoEstaEnCurso()
    {
        if (EstadoJuego == EstadoJuego.NoIniciado)
            throw new InvalidOperationException("Debe iniciar el juego para poder disparar");
        if (EstadoJuego == EstadoJuego.Finalizado) 
            throw new InvalidOperationException("Debe iniciar un juego nuevo");
    }
    
    private void LanzarExcepcionSiAlgunoDeLosDosJugadoresNoTieneBarcos()
    {
        if (Jugadores.Count(a => a.Tablero.ExistenBarcos()) != Jugadores.Count)
            throw new InvalidOperationException("Ambos jugadores deben tener barcos en el tablero");
    }

    private void VerificarJuegoFinalizado(Jugador jugadorOponente)
    {
        if(!jugadorOponente.Tablero.BarcosNoHundidos())
            FinalizarJuego();
        
        else
            CambiarTurno();
        
    }
    private void IniciarJuego() => EstadoJuego = EstadoJuego.EnCurso;
    private void FinalizarJuego() => EstadoJuego = EstadoJuego.Finalizado;

    private Jugador ObtenerJugadorEnTurnoActual() => ObtenerJugador(_indiceJugadorActual);

    private void LanzarExcepcionSiJuegoNoHaSidoFinalizado()
    {
        if (EstadoJuego != EstadoJuego.Finalizado)
            throw new InvalidOperationException("El juego no se ha finalizado");
    }
}
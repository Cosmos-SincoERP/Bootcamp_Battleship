using Test.BattleShip.Dominio.Barcos;

namespace Test.BattleShip.Dominio;

public class Juego
{
    private List<Jugador> _jugadores = [];
    private int _jugadorActivo;
    private int _jugadorEnemigo = 1;
    private bool _juegoTerminado;
    private bool _disparoYaSeRealizoEnTurno;

    public void AgregarJugador()
    {
        ValidacionesParaAgregarJugador();
        _jugadores.Add(new Jugador(AsignarNombreJugadorPredeterminado()));
    }

    public void Iniciar(List<(int indexJugador, List<Barco> barcos)> flotas)
    {
        ValidarCantidadDeJugadores();

        foreach (var (indexJugador, barcos) in flotas)
        {
            _jugadores[indexJugador].AgregarFlotaDeBarcos(barcos);
        }
    }

    public string Disparar(Coordenada coordenada)
    {
        ValidarSiJugadorYaDisparo();

        var jugadorActivo = ObtenerJugadorActivo();
        var jugadorEnemigo = ObtenerJugadorEnemigo();

        var disparoAcertado = false;
        var mensaje = string.Empty;
        var barco = jugadorEnemigo.BuscarBarco(coordenada);
        var tablero = jugadorEnemigo.Tablero;

        if (barco != null)
        {
            disparoAcertado = true;
            barco.MarcarImpacto();
            if (barco.SeHundio())
                mensaje = MarcarBarcoHundido(barco, tablero);
            else
                tablero.MarcarRepresentacionEnElTablero(coordenada, 'x');
        }
        else
            tablero.MarcarRepresentacionEnElTablero(coordenada, 'o');

        jugadorActivo.AgregarDisparo(disparoAcertado);
        MarcarDisparoRealizadoEnTurno();

        return mensaje;
    }

    public void FinalizarTurno()
    {
        if (ObtenerJugadorEnemigo().TodosLosBarcosEstanHundidos())
            _juegoTerminado = true;
        else
        {
            CambiarJugadorActivo();
            CambiarJugadorEnemigo();
            LimpiarDisparoRealizadoEnTurno();
        }
    }

    public string Imprimir()
    {
        var informacion = string.Empty;

        if (_juegoTerminado)
            informacion = InformeBatalla();
        else
            informacion += ObtenerJugadorEnemigo().Tablero.Visualizar();

        return informacion;
    }

    private string InformeBatalla()
    {
        var informe = "------- Informe de batalla -------- \n";
        
        informe += $"Ganador: Jugador {ObtenerJugadorActivo().Nombre} \n";

        foreach (var jugador in _jugadores)
        {
            informe += $"Jugador {jugador.Nombre}  \n";
            informe += $"{jugador.ObtenerInformacionDeDisparos()} \n";
            informe += $"Barcos Hundidos: {jugador.ObtenerInformacionDeBarcosHundidos()} \n";
            
        }
        return informe;
    }
    private void ValidacionesParaAgregarJugador()
    {
        if (_jugadores.Count == 2)
            throw new Exception("No se permite agregar mas jugadores al juego");
    }
    private void ValidarCantidadDeJugadores()
    {
        if (_jugadores.Count != 2)
            throw new Exception("No se puede iniciar el juego, debe haber al menos 2 jugadores");
    }
    private string AsignarNombreJugadorPredeterminado() => _jugadores.Count == 1 ? "2" : "1";
    private void CambiarJugadorActivo() => _jugadorActivo = _jugadorActivo == 0 ? 1 : 0;
    private void CambiarJugadorEnemigo() => _jugadorEnemigo = _jugadorEnemigo == 0 ? 1 : 0;
    private Jugador ObtenerJugadorActivo() => _jugadores[_jugadorActivo];
    private Jugador ObtenerJugadorEnemigo() => _jugadores[_jugadorEnemigo];
    private string MarcarBarcoHundido(Barco barco, Tablero tablero)
    {
        foreach (var coordenada in barco.CoordenadasDeLaPosicion)
            tablero.MarcarRepresentacionEnElTablero(coordenada, 'X');

        return $"Se hundio un barco en la coordenada ({barco.Coordenada.X},{barco.Coordenada.Y})";
    }
    private void MarcarDisparoRealizadoEnTurno() => _disparoYaSeRealizoEnTurno = true;
    private void LimpiarDisparoRealizadoEnTurno() => _disparoYaSeRealizoEnTurno = false;
    private void ValidarSiJugadorYaDisparo()
    {
        if (_disparoYaSeRealizoEnTurno)
            throw new Exception("El jugador ya ha realizado un disparo en este turno");
    }

}
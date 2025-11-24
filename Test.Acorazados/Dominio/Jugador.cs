using Test.BattleShip.Dominio.Barcos;

namespace Test.BattleShip.Dominio;

public class Jugador(string nombre)
{
    private int _cantidadDisparos;
    private int _cantidadDisparosFallidos;
    private int _cantidadDisparosAcertados;
    private readonly List<Barco> _barcos = [];
    public string Nombre { get; } = nombre;
    public Tablero Tablero { get; } = new(10);

    public void AgregarDisparoRealizado(bool esAcertado)
    {
        _cantidadDisparos++;
        if (esAcertado)
            _cantidadDisparosAcertados++;
        else
            _cantidadDisparosFallidos++;
    }

    public void AgregarFlotaDeBarcos(List<Barco> flotaBarcos)
    {
        ValidarSiHayCoordenadaPorFueraDelLimite(flotaBarcos, Nombre);
        ValidarSiExisteUnBarcoEnLaCoordenada(flotaBarcos, Nombre);
        ValidarFlotaCañoneros(flotaBarcos);
        ValidarFlotaDestructores(flotaBarcos);
        ValidarFlotaPortaAviones(flotaBarcos);

        _barcos.AddRange(flotaBarcos);
    }

    public string ObtenerInformacionDeDisparos() =>
        $"Total de disparos: {_cantidadDisparos} \nDisparos fallidos: {_cantidadDisparosFallidos} \nDisparos acertados: {_cantidadDisparosAcertados}\n";

    public (bool, string) AtaqueDelJugadorEnemigo(Coordenada coordenada)
    {
        ValidarSiTableroYaTieneUnDisparoEnCoordenada(coordenada);

        var barco = BuscarBarco(coordenada);
        return MarcarDisparo(coordenada, barco);
    }

    public bool TodosLosBarcosEstanHundidos() => _barcos.All(barco => barco.SeHundio());

    public string ObtenerInformacionDeBarcosHundidos()
    {
        var mensaje = string.Empty;
        _barcos.Where(barco => barco.SeHundio())
            .ToList()
            .ForEach(barco => mensaje += $"{barco.GetType().Name}: ({barco.Coordenada.X},{barco.Coordenada.Y}) \n");

        return mensaje;
    }

    public void MarcarEnElTableroLasCasillasDeLosBarcosAFlote()
    {
        _barcos.ForEach(barco =>
        {
            foreach (var coordenada in barco.CoordenadasDeLaPosicion.Where(coordenada => !Tablero.HayUnaMarca(coordenada)))
            {
                Tablero.MarcarRepresentacionEnElTablero(coordenada, barco.Representacion);
            }
        });
    }

    private Barco? BuscarBarco(Coordenada coordenada) => _barcos.FirstOrDefault(barco => barco.EstaEnLaCoordenada(coordenada));

    private void ValidarFlotaCañoneros(List<Barco> flotaCañoneros)
    {
        if (flotaCañoneros.Count(barco => barco.GetType().Name == nameof(Cañonero)) < (int)FlotaBarcos.Cañonero)
            throw new Exception($"El jugador {Nombre}, no ha enviado todos los cañoneros para posicionar");
    }

    private void ValidarFlotaDestructores(List<Barco> flotaDestructores)
    {
        if (flotaDestructores.Count(barco => barco.GetType().Name == nameof(Destructor)) < (int)FlotaBarcos.Destructor)
            throw new Exception($"El jugador {Nombre}, no ha enviado todos los destructores para posicionar");
    }

    private void ValidarFlotaPortaAviones(List<Barco> flotaPortaviones)
    {
        if (flotaPortaviones.Count(barco => barco.GetType().Name == nameof(PortaAviones)) < (int)FlotaBarcos.PortaAviones)
            throw new Exception($"El jugador {Nombre}, no ha enviado todos los portaviones para posicionar");
    }

    private void ValidarSiHayCoordenadaPorFueraDelLimite(List<Barco> barcos, string nombreJugador)
    {
        var coordenadaNoValida = new List<string>();
        barcos.Where(barco => barco.Coordenada.X >= Tablero.ObtenerTamañoEnX() ||
                                barco.Coordenada.X < 0 ||
                                barco.Coordenada.Y >= Tablero.ObtenerTamañoEnY() ||
                                barco.Coordenada.Y < 0)
            .ToList()
            .ForEach(barco =>
            {
                coordenadaNoValida.Add($"{barco.GetType().Name}({barco.Coordenada.X},{barco.Coordenada.Y})");
            });

        if (coordenadaNoValida.Any())
            throw new Exception($"El jugador {nombreJugador} ha enviado un barco con coordenadas invalidas, " + string.Join(", ", coordenadaNoValida));
    }

    private void ValidarSiExisteUnBarcoEnLaCoordenada(List<Barco> flotaBarcos, string nombre)
    {
        var coordenadasRepetidas = flotaBarcos
            .SelectMany(barco => barco.CoordenadasDeLaPosicion)
            .GroupBy(coordenada => coordenada)
            .Where(grupo => grupo.Count() > 1)
            .Select(grupo => $"({grupo.Key.X},{grupo.Key.Y})")
            .ToList();

        if (coordenadasRepetidas.Count != 0)
            throw new Exception($"El jugador {nombre} ha enviado barcos que existen en la coordenada:" + string.Join(", ", coordenadasRepetidas));
    }

    private (bool, string) MarcarDisparo(Coordenada coordenada, Barco? barco)
    {
        var mensaje = string.Empty;
        var disparoAcertado = false;
        if (barco != null)
        {
            disparoAcertado = true;
            mensaje = VerificarSiElBarcoFueHundidoYMarcarEnElTablero(coordenada, barco);
        }
        else
            Tablero.MarcarRepresentacionEnElTablero(coordenada, 'o');

        return (disparoAcertado, mensaje);
    }

    private string VerificarSiElBarcoFueHundidoYMarcarEnElTablero(Coordenada coordenada, Barco barco)
    {
        var mensaje = string.Empty;
        barco.MarcarImpacto();
        if (barco.SeHundio())
            mensaje = MarcarBarcoHundido(barco);
        else
            Tablero.MarcarRepresentacionEnElTablero(coordenada, 'x');
        return mensaje;
    }

    private string MarcarBarcoHundido(Barco barco)
    {
        foreach (var coordenada in barco.CoordenadasDeLaPosicion)
            Tablero.MarcarRepresentacionEnElTablero(coordenada, 'X');

        return $"Se hundio un barco en la coordenada ({barco.Coordenada.X},{barco.Coordenada.Y})";
    }

    private void ValidarSiTableroYaTieneUnDisparoEnCoordenada(Coordenada coordenada)
    {
        if (Tablero.HayUnaMarca(coordenada))
            throw new Exception($"El jugador ya lanzo un disparo en la coordenada ({coordenada.X},{coordenada.Y})");
    }
}
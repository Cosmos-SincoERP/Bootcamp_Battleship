using Test.BattleShip.Dominio.Barcos;

namespace Test.BattleShip.Dominio;

public class Jugador(string nombre)
{
    private string _nombre = nombre;
    private int _cantidadDisparos;
    private int _cantidadDisparosFallidos;
    private int _cantidadDisparosAcertados;
    private static readonly (int tamañoMinimo, int tamañoMaximo) _tamañoLimite = (0, 9);

    public Tablero Tablero { get; } = new(10);
    public List<Barco> Barcos { get; } = [];

    public void AgregarDisparo(bool esAcertado)
    {
        _cantidadDisparos++;
        if (esAcertado)
            _cantidadDisparosAcertados++;
        else
            _cantidadDisparosFallidos++;
    }

    public void AgregarFlotaDeBarcos(List<Barco> flotaBarcos)
    {
        ValidarSiHayCoordenadaPorFueraDelLimite(flotaBarcos, _nombre);
        ValidarsSiExisteUnBarcoEnLaCoordenada(flotaBarcos, _nombre);

        ValidarFlotaCañoneros(flotaBarcos);
        ValidarFlotaDestructores(flotaBarcos);
        ValidarFlotaPortaAviones(flotaBarcos);

        Barcos.AddRange(flotaBarcos);
    }

    public string ObtenerInformacionDeDisparos() =>
        $"Total de disparos: {_cantidadDisparos} \n Disparos fallidos: {_cantidadDisparosFallidos} \n Disparos acertados: {_cantidadDisparosAcertados}";

    public Barco? BuscarBarco(Coordenada coordenada) => Barcos.FirstOrDefault(barco => barco.EstaEnLaCoordenada(coordenada));

    private void ValidarFlotaCañoneros(List<Barco> flotaCañoneros)
    {
        if (flotaCañoneros.Count(barco => barco.GetType().Name == nameof(Cañonero)) < (int)FlotaBarcos.Cañonero)
            throw new Exception($"El jugador {_nombre}, no ha enviado todos los cañoneros para posicionar");
    }

    private void ValidarFlotaDestructores(List<Barco> flotaDestructores)
    {
        if (flotaDestructores.Count(barco => barco.GetType().Name == nameof(FlotaBarcos.Destructor)) < (int)FlotaBarcos.Destructor)
            throw new Exception($"El jugador {_nombre}, no ha enviado todos los destructores para posicionar");
    }

    private void ValidarFlotaPortaAviones(List<Barco> flotaPortaviones)
    {
        if (flotaPortaviones.Count(barco => barco.GetType().Name == nameof(FlotaBarcos.PortaAviones)) < (int)FlotaBarcos.PortaAviones)
            throw new Exception($"El jugador {_nombre}, no ha enviado todos los portaviones para posicionar");
    }

    private static void ValidarSiHayCoordenadaPorFueraDelLimite(List<Barco> barcos, string nombreJugador)
    {
        List<string> coordenadaNoValida = new List<string>();
        barcos.Where(barco => barco.Coordenada.X > _tamañoLimite.tamañoMaximo ||
                                barco.Coordenada.X < _tamañoLimite.tamañoMinimo ||
                                barco.Coordenada.Y > _tamañoLimite.tamañoMaximo ||
                                barco.Coordenada.Y < _tamañoLimite.tamañoMinimo)
            .ToList()
            .ForEach(barco =>
            {
                coordenadaNoValida.Add($"{barco.GetType().Name}({barco.Coordenada.X},{barco.Coordenada.Y})");
            });

        if (coordenadaNoValida.Any())
            throw new Exception($"El jugador {nombreJugador} ha enviado un barco con coordenadas invalidas, " + string.Join(", ", coordenadaNoValida));
    }

    private void ValidarsSiExisteUnBarcoEnLaCoordenada(List<Barco> flotaBarcos, string nombre)
    {
        var coordenadasRepetidas = flotaBarcos
            .SelectMany(barco => barco.CoordenadasDeLaPosicion)
            .GroupBy(coordenada => coordenada)
            .Where(grupo => grupo.Count() > 1)
            .Select(grupo => $"({grupo.Key.X},{grupo.Key.Y})")
            .ToList();

        if (coordenadasRepetidas.Any())
            throw new Exception($"El jugador {nombre} ha enviado barcos que existen en la coordenada:" + string.Join(", ", coordenadasRepetidas));
    }
}
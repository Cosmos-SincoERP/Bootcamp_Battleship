using Test.BattleShip.Dominio.Barcos;

namespace Test.BattleShip.Dominio;

public class Jugador(string nombre)
{
    private string _nombre = nombre;
    private int _cantidadDisparos;
    private int _cantidadDisparosFallidos;
    private int _cantidadDisparosAcertados;

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
        ValidarCoordenadas(flotaBarcos, _nombre);

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

    private static void ValidarCoordenadas(List<Barco> barcos, string nombreJugador)
    {
        barcos.Where(barco => barco.Coordenada.X > 9 || barco.Coordenada.X < 0 || barco.Coordenada.Y > 9)
            .ToList()
            .ForEach(barco =>
            {
                throw new Exception($"El jugador {nombreJugador}, ha enviado un barco con coordenadas invalidas ({barco.Coordenada.X},{barco.Coordenada.Y})");
            });
    }
}
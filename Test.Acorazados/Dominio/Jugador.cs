using Test.BattleShip.Dominio.Barcos;

namespace Test.BattleShip.Dominio;

public class Jugador(string nombre)
{
    private string _nombre = nombre;
    public char[,] Tablero { get; } = new char[10, 10];
    private int _cantidadDisparos;
    private int _cantidadDisparosFallidos;
    private int _cantidadDisparosAcertados;
    public List<Barco> Barcos { get; } = [];

    public void AgregarDisparo(bool esAcertado)
    {
        _cantidadDisparos++;
        if (esAcertado)
            _cantidadDisparosAcertados++;
        else
            _cantidadDisparosFallidos++;
    }

    public void FlotaDeBarcos(List<Barco> flotaBarcos)
    {
        ValidarFlotaCañoneros(flotaBarcos);
        ValidateFlotaDestructores(flotaBarcos);
        ValidarFlotaPortaAviones(flotaBarcos);
        
        Barcos.AddRange(flotaBarcos);
    }
    
    public string ObtenerTotalDisparos() => $"Total de disparos: {_cantidadDisparos}";
    public string ObtenerTotalDisparosFallidos() => $"Disparos fallidos: {_cantidadDisparosFallidos}";
    public string ObtenerTotalDisparosAcertados() => $"Disparos acertados: {_cantidadDisparosAcertados}";

    private void ValidarFlotaCañoneros(List<Barco> flotaCañoneros)
    {
        if (flotaCañoneros.Count(barco => barco.GetType().Name == nameof(Cañonero)) < (int)FlotaBarcos.Cañonero)
            throw new Exception($"El jugador {_nombre}, no ha enviado todos los cañoneros para posicionar");
    }

    private void ValidateFlotaDestructores(List<Barco> flotaDestructores)
    {
        if (flotaDestructores.Count(barco => barco.GetType().Name == nameof(FlotaBarcos.Destructor)) < (int)FlotaBarcos.Destructor)
            throw new Exception($"El jugador {_nombre}, no ha enviado todos los destructores para posicionar");
    }

    private void ValidarFlotaPortaAviones(List<Barco> flotaPortaviones)
    {
        if (flotaPortaviones.Count(barco => barco.GetType().Name == nameof(FlotaBarcos.PortaAviones)) < (int)FlotaBarcos.PortaAviones)
            throw new Exception($"El jugador {_nombre}, no ha enviado todos los portaviones para posicionar");
    }
}
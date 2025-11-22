namespace Test.BattleShip.Dominio;

public class Jugador(string nombre)
{
    public string Nombre { get; } = nombre;
    public char[,] Tablero { get; } = new char[10, 10];
    public int ContadorDisparos { get; private set; }
    public int ContadorDisparosFallidos { get; private set; }
    public int ContadorDisparosAcertados { get; private set; }
    
    public void DisparoRealizado(bool acertado)
    {
        ContadorDisparos++;
        if (acertado)
            ContadorDisparosAcertados++;
        else
            ContadorDisparosFallidos++;
    }
}
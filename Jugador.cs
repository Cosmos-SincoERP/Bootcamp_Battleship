namespace BattleshipsTDD;

public class Jugador
{
    public char[,] Tablero { get; set; }
    public Informe Informe { private get; set; } = new Informe();

    public Jugador(char[,] tableroInicial)
    {
        Tablero = tableroInicial;
    }

    public Informe ObtenerInforme()
    {
        Informe.RepresentacionTablero = Serializador.SerializarTablero(Tablero);
        return Informe;
    }
    
    public void RecibirDisparo (bool disparaAcertado)
    {
        if (disparaAcertado)
            IncrementarDisparosAsertados();
        else
            IncrementarDisparosFallados();

        IncrementarDisparosRecibidosTotales();
    }
    
    public void RegistrarBarcoUndido(TipoBarco tipoBarco,Coordenada coordenada) 
    {
        Informe.AgregarBarcoUndido(tipoBarco, coordenada);
    }

    private void IncrementarDisparosRecibidosTotales()
    {
        Informe.DisparosRecibidos++;
    }

    private void IncrementarDisparosFallados()
    {
        Informe.DisparosFalladosEnemigo++;
    }

    private void IncrementarDisparosAsertados()
    {
        Informe.DisparosAsertadosEnemigo++;
    }
    
    
}
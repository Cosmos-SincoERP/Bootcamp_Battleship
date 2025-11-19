using Acorazados;
using AwesomeAssertions;

public class JuegoAcorazadosTest
{
    private JuegoAcorazados _juego;
    private Cañonero _cañonero;
    private Destructor _destructor;
    private PortaAviones _portaAviones;
    private string[,] tableroDisparos;
    
    public JuegoAcorazadosTest()
    {
        tableroDisparos = new string[,]
        {
            { null, null, null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null, null, null },
        };
        _juego = new JuegoAcorazados();
        var acorazadosJugador1 = new List<AcorazadoAcuatizado>()
        {
            new(_portaAviones, 1, 1, Direccion.Derecha),
            new(_destructor, 5, 5, Direccion.Derecha),
            new(_cañonero, 7, 7, Direccion.Derecha),
            new(_cañonero, 9, 9, Direccion.Derecha)
        };
        _juego.AgregarJugador("Jugador 1", acorazadosJugador1);
        var acorazadosJugador2 = new List<AcorazadoAcuatizado>()
        {
            new(_portaAviones, 1, 1, Direccion.Derecha),
            new(_destructor, 3, 3, Direccion.Derecha),
            new(_cañonero, 4, 1, Direccion.Derecha),
            new(_cañonero, 6, 1, Direccion.Derecha)
        };
        _juego.AgregarJugador("Jugador 2", acorazadosJugador2);
        _juego.Iniciar();
    }
    
    [Fact]
    public void Si_DisparoEnLaPosicion33_Debe_TableroContrincanteTener_o()
    {
        tableroDisparos[2, 2] = "o";
        
        _juego.Disparar(3, 3);

        _juego.ObtenerTableroContrincante().Should().BeEquivalentTo(tableroDisparos);
    }
}
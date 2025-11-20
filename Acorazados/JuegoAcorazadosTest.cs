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
        _cañonero = new Cañonero();
        _destructor = new Destructor();
        _portaAviones = new PortaAviones();
        _juego = new JuegoAcorazados();
        var acorazadosJugador1 = new List<AcorazadoAcuatizado>()
        {
            new(_portaAviones, 1, 1, Direccion.Derecha),
            new(_destructor, 5, 5, Direccion.Derecha),
            new(_cañonero, 7, 7, Direccion.Derecha),
            new(_cañonero, 9, 9, Direccion.Derecha)
        };
        _juego.AgregarJugador("Jugador 1", acorazadosJugador1);
        _cañonero = new Cañonero();
        _destructor = new Destructor();
        _portaAviones = new PortaAviones();
        var acorazadosJugador2 = new List<AcorazadoAcuatizado>()
        {
            new(_portaAviones, 1, 1, Direccion.Derecha),
            new(_destructor, 3, 3, Direccion.Derecha),
            new(_destructor, 4, 4, Direccion.Abajo),
            new(_cañonero, 4, 1, Direccion.Derecha),
            new(_cañonero, 6, 1, Direccion.Derecha)
        };
        _juego.AgregarJugador("Jugador 2", acorazadosJugador2);
        _juego.Iniciar();
    }
    
    [Fact]
    public void Si_DisparoEnLaPosicion22_Debe_TableroContrincanteTener_o()
    {
        tableroDisparos[2, 2] = "o";
        
        _juego.Disparar(2, 2);

        _juego.ObtenerTableroContrincante().Should().BeEquivalentTo(tableroDisparos);
    }

    [Fact]
    public void Si_DisparoEnLaPosicion11_Debe_TableroContrincanteTener_x()
    {
        tableroDisparos[1, 1] = "x";
        
        _juego.Disparar(1, 1);

        _juego.ObtenerTableroContrincante().Should().BeEquivalentTo(tableroDisparos);
    }

    [Fact]
    public void Si_DisparoEnLasPosiciones11_12_13_14_Debe_TableroContrincanteTener_XXX()
    {
        tableroDisparos[1, 1] = "X";
        tableroDisparos[1, 2] = "X";
        tableroDisparos[1, 3] = "X";
        tableroDisparos[1, 4] = "X";
        
        _juego.Disparar(1, 1);
        _juego.Disparar(1, 2);
        _juego.Disparar(1, 3);
        _juego.Disparar(1, 4);
        
        _juego.ObtenerTableroContrincante().Should().BeEquivalentTo(tableroDisparos);
    }

    [Fact]
    public void Si_Disparo_EnLasPosiciones34_44_54_Debe_TableroContrincanteNoTenerX()
    {
        tableroDisparos[3, 4] = "x";
        tableroDisparos[4, 4] = "x";
        tableroDisparos[5, 4] = "x";
        
        _juego.Disparar(3, 4);
        _juego.Disparar(4, 4);
        _juego.Disparar(5, 4);
        
        _juego.ObtenerTableroContrincante().Should().BeEquivalentTo(tableroDisparos);
    }
}
// namespace Test.BattleShip;
//
// public class MocksBK
// {
//     public static JuegoAcorazadoBK MockIniciarJuego()
//         {
//             var juegoAcorazado = new JuegoAcorazadoBK();
//             juegoAcorazado.AgregarJugador();
//             juegoAcorazado.AgregarBarco(
//                 new PosicionarBarco((2, 0), new Cañonero())
//             );
//             juegoAcorazado.AgregarBarco(
//                 new PosicionarBarco((6, 3), new Cañonero())
//             );
//             juegoAcorazado.AgregarBarco(
//                 new PosicionarBarco((8, 6), new Cañonero())
//             );
//             juegoAcorazado.AgregarBarco(
//                 new PosicionarBarco((9, 6), new Cañonero())
//             );
//             juegoAcorazado.AgregarBarco(
//                 new PosicionarBarco((2, 6), new Destructor(Orientacion.Horizontal))
//             );
//             juegoAcorazado.AgregarBarco(
//                 new PosicionarBarco((0, 2), new Destructor(Orientacion.Vertical))
//             );
//             juegoAcorazado.AgregarBarco(
//                 new PosicionarBarco((9, 0), new PortaAviones(Orientacion.Vertical))
//             );
//             
//             juegoAcorazado.AgregarJugador();
//             
//             juegoAcorazado.AgregarBarco(
//                 new PosicionarBarco((8, 2), new Cañonero()),
//                 "Jugador 2"
//             );
//             juegoAcorazado.AgregarBarco(
//                 new PosicionarBarco((5, 0), new Cañonero()),
//                 "Jugador 2"
//             );
//             juegoAcorazado.AgregarBarco(
//                 new PosicionarBarco((7, 4), new Cañonero()),
//                 "Jugador 2"
//             );
//             juegoAcorazado.AgregarBarco(
//                 new PosicionarBarco((3, 7), new Cañonero()),
//                 "Jugador 2"
//             );
//             juegoAcorazado.AgregarBarco(
//                 new PosicionarBarco((2, 6), new Destructor(Orientacion.Horizontal)),
//                 "Jugador 2"
//             );
//             juegoAcorazado.AgregarBarco(
//                 new PosicionarBarco((2, 2), new Destructor(Orientacion.Vertical)),
//                 "Jugador 2"
//             );
//             juegoAcorazado.AgregarBarco(
//                 new PosicionarBarco((4, 0), new PortaAviones(Orientacion.Vertical)),
//                 "Jugador 2"
//             );
//             return juegoAcorazado;
//         }
//     
//     public static string TableroEsperado(char[,] tablero)
//     {
//         var tableroEsperado = string.Empty;
//         for (var x = 0; x < tablero.GetLength(0); x++)
//         {
//             for (int y = 0; y < tablero.GetLength(1); y++)
//             {
//                 tableroEsperado += tablero[x, y];
//             }
//
//             tableroEsperado += '\n';
//         }
//
//         return tableroEsperado;
//     }
// }
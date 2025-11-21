El juego cuenta con 3 naves
- PortaAviones: 4 casillas (es la cantidad) - representa con una c en el tablero
- Desctructor: 3 casillas (es la cantidad) - representa con una d En el tablero
- Cañonero: 1 casillas (es la cantidad) - representa con una g En el tablero

Comandos:

- AgregarJugador
- Inicio: inicia una partida, pero antes debe haber agregado las naves en las coordenadas que el mismo jugador defina
- FinalizaTurno
- Mostrar: Comando para imprimir el tablero
- Fuego: Lanza un torpedo en las coordenadas (x, y)
  - Si el torpedo llega al mar (no le pega a la nave), se marca el espacio con "o"
  - Si el torpedo llega al una nave (le pega a la nave), se marca el espacio con "x"
  - Si un barco tiene todas las casillas impactadas, se imprimirá un mensaje notificando al jugador que el barco se ha hundido 
    - (¿Cuando se refiere a todas las casillas, son las naves?).
    - (¿Cuando se refiere a un barco, son todas las naves de cada tipo?)
  
Reglas
 - Todos los barcos hundidos, el juego termina
 - Al finalizar partida debe mostrar un informe con la siguiente informacion
   - Disparos realizados por cada jugaror
   - Incluyendo barcos hundidos o fallados
 - En el caso del comando Fuego, si un barco se hundio, debe mostrar el mesnaje de que se hundio el barco, junto a la posicion minima posible
 - Al mostrar el tablero, los barcos hundidos en su totalidad marcan con una X mayuscula y los que no se hundieron en su totalidad en una x minuscula

Restricciones
- Completar utilizando outside-in. Es London School
- Un jugador tiene como maximo las siguientes naves:
  - 1 Porta avion
  - 2 Desctructores
  - 4 Cañoneras

-La cuadricula es de 10x10;

Contratos
void AgregarJugador()
void Iniciar(List<PosicionBarco> jugador1, List<PosicionBarco> jugador2)
void Imprimir()
string Disparar(Coordenada coordenada)
void FinalizarTurno()

PosicionBarco(Barco barco, Coordenada coordenada, Orientacion orientacion)

[ ] Si no hay jugadores y se inicia el juego debe lanzar una excepcion por cantidad de jugadores (Assert con Iniciar)
[ ] Si hay un jugador y se inicia el juego debe lanzar una excepcion por cantidad de jugadores (Assert con Iniciar)
[ ] Si hay dos jugadores y se inicia el juego no debe lanzar una excepcion por cantidad de jugadores (Assert con Iniciar)
[ ] Si se agrega un tercer jugador  debe lanzar una excepcion por cantidad de jugadores (Assert con AgregarJugador)
[ ] Si inicia el juego sin Posicionar los barcos del jugador 1 debe lanzar una excepcion por falta de posicionamiento de barcos (Assert con Iniciar)
[ ] Si inicia el juego solo Posicionando el portaAviones del jugador 1 debe lanzar una excepcion por falta de posicionamiento de barcos (Assert con Iniciar)
[ ] Si inicia el juego solo Posicionando los destructores del jugador 1 debe lanzar una excepcion por falta de posicionamiento de barcos (Assert con Iniciar)
[ ] Si inicia el juego solo Posicionando los cañoneros del jugador 1 debe lanzar una excepcion por falta de posicionamiento de barcos (Assert con Iniciar)
[ ] Si inicia el juego solo Posicionando Todos los barcos del jugador 1 y no se posicionan los barcos del jugador 2 debe lanzar una excepcion por falta de posicionamiento de barcos (Assert con Iniciar)
[ ] Si inicia el juego solo Posicionando Todos los barcos del jugador 1 y no se posiciona el portaAviones del jugador 2 debe lanzar una excepcion por falta de posicionamiento de barcos (Assert con Iniciar)
[ ] Si inicia el juego solo Posicionando Todos los barcos del jugador 1 y no se posiciona los destructores del jugador 2 debe lanzar una excepcion por falta de posicionamiento de barcos (Assert con Iniciar)
[ ] Si inicia el juego solo Posicionando Todos los barcos del jugador 1 y no se posiciona los cañoneros  del jugador 2 debe lanzar una excepcion por falta de posicionamiento de barcos (Assert con Iniciar)
[ ] Si inicia el juego Posicionando todos los barcos del jugador 1 y todos los jugador 2 debe mostrar la flota del jugador 1 (Assert con Imprimir)

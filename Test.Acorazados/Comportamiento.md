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

# UnityProjects

# ControlPersonaje Script

Este script, escrito en C# para Unity, controla el movimiento y las interacciones del personaje en un juego. El personaje tiene la capacidad de invertir la gravedad y puede interactuar con elementos del entorno para avanzar o retroceder niveles.

## Características Principales

- **Movimiento del Personaje:** El script permite al jugador mover el personaje horizontalmente mediante las teclas de dirección.

- **Inversión de Gravedad:** Presionando la barra espaciadora, el jugador puede invertir la gravedad, afectando el movimiento y la apariencia del personaje.

- **Animaciones:** Se gestionan animaciones del personaje según su movimiento.

- **Transiciones de Nivel:** Se manejan transiciones entre niveles al colisionar con objetos marcados con las etiquetas "NextLevel" y "ReturnLevel".

- **Colisiones con Obstáculos:** Colisionar con objetos marcados como "Pinchos" resulta en la destrucción del personaje y el reinicio del juego.

## Uso del Singleton

Se implementa el patrón Singleton para garantizar que solo haya una instancia del script ControlPersonaje en ejecución.

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

# SpawnPlayer Script

Este script, escrito en C# para Unity, se encarga de gestionar el spawn del jugador en diferentes puntos de spawn según las transiciones de nivel en el juego.

## Características Principales

- **Spawn en Puntos Designados:** El script asigna al jugador un punto de spawn según las transiciones de nivel. Los puntos de spawn se definen como objetos en la escena con nombres específicos ("EmptyOne" y "EmptyTwo" en este caso).

- **Cambio de Punto de Spawn:** Al colisionar con objetos marcados como "NextLevel" y "ReturnLevel", el punto de spawn del jugador se actualiza.

- **Uso de OnLevelWasLoaded:** Se utiliza el método `OnLevelWasLoaded` para asegurar que el punto de spawn del jugador se actualice cada vez que se carga un nuevo nivel.

## Instrucciones de Uso

1. Asocia el script `SpawnPlayer` a un GameObject en tu escena de Unity.
2. Asegúrate de tener objetos de spawn llamados "EmptyOne" y "EmptyTwo" en tu escena.
3. Configura las etiquetas de colisión ("NextLevel" y "ReturnLevel") en los objetos que actúan como puntos de transición de nivel.

## Importante

Este script asume que los puntos de spawn y las transiciones de nivel están configurados correctamente en tu juego. Asegúrate de tener las capas y etiquetas necesarias.

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

# MovimientoEnemigo Script

Este script, escrito en C# para Unity, controla el movimiento de un enemigo de un punto a otro en la escena. El enemigo se mueve de un punto inicial a un punto final y luego regresa al punto inicial, repitiendo este patrón.

## Características Principales

- **Movimiento Automático:** El enemigo se mueve automáticamente entre un punto inicial y un punto final en la escena.

- **Espera en el Punto Final:** Después de llegar al punto final, el enemigo espera durante un tiempo antes de comenzar el viaje de regreso al punto inicial.

- **Orientación del Sprite:** La orientación del sprite del enemigo se ajusta para reflejar la dirección del movimiento.

## Instrucciones de Uso

1. Asocia el script `MovimientoEnemigo` a un GameObject que represente al enemigo en tu escena de Unity.
2. Configura los puntos de inicio y final (puntoInicioX y puntoFinalX) en el inspector de Unity.
3. Ajusta la velocidad de movimiento y el tiempo de espera en el punto final según tus necesidades.
4. Asegúrate de que el enemigo tenga un componente SpriteRenderer adjunto.

## Importante

Este script asume que los puntos de inicio y final están configurados correctamente en tu juego. Asegúrate de tener las capas y etiquetas necesarias.

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

# BolaDeEnergia Script

Este script, escrito en C# para Unity, controla el movimiento cíclico de una bola de energía de un punto a otro en la escena.

## Características Principales

- **Movimiento Horizontal Cíclico:** La bola de energía se desplaza horizontalmente de una posición inicial a una posición final y luego regresa a la posición inicial, repitiendo este patrón en un bucle continuo.

- **Velocidad Ajustable:** La velocidad horizontal de la bola de energía es ajustable mediante el parámetro `velocidadX` en el script.

- **Reinicio Cíclico:** Cuando la bola de energía alcanza la posición final, vuelve a la posición inicial para continuar el movimiento cíclico.

## Instrucciones de Uso

1. Asocia el script `BolaDeEnergia` a un GameObject que represente la bola de energía en tu escena de Unity.
2. Configura la velocidad horizontal (`velocidadX`) en el inspector de Unity según tus necesidades.
3. Ajusta la posición final (`posicionFinal`) en el inspector de Unity para definir hasta dónde se desplazará la bola antes de reiniciar.

## Importante

Este script asume que la posición final está configurada correctamente en tu juego. Asegúrate de tener las capas y etiquetas necesarias.

## Licencia

Este script está disponible bajo la [Licencia MIT](LICENSE).

---

**¡Importante!**
Este script forma parte de un proyecto más grande. Asegúrate de tener configuradas las capas, etiquetas y elementos necesarios en tu juego para que este script funcione correctamente.

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

# GameManager Script

El script `GameManager` en C# para Unity gestiona el flujo del juego, proporcionando funcionalidades como la transición entre niveles, reinicio del nivel, y pausa.

## Características Principales

- **Singleton Pattern:** Implementa el patrón Singleton para asegurar que solo haya una instancia del `GameManager` en ejecución.

- **Inicio y Desactivación en Escenas Específicas:** Desactiva el objeto `GameManager` en las escenas de inicio (índice 0) y la escena de créditos (índice 7), para evitar interferencias.

- **Pausa del Juego:** Al presionar la tecla 'Escape', carga la escena "Pause" para pausar el juego.

- **Transiciones de Nivel:** Proporciona métodos para cargar la siguiente, anterior o reiniciar la escena actual.

- **Cambio de Escena Externo:** Ofrece un método (`canviEscena`) para cambiar a una escena específica o salir de la aplicación.


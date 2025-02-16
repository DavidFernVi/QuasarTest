# QuasarTest
🐾 Prueba Técnica - Unity (3D)
Este proyecto es una prueba técnica en Unity que consiste en el movimiento de un jugador en un entorno 3D, la interacción con objetos y la generación dinámica de estos en zonas específicas.

🛠️ Requisitos técnicos
Motor: Unity 2022.3.9f1 (LTS)
Lenguaje: C#
Plataforma: PC
🚀 Instalación y ejecución
Clonar el repositorio:

bash
Copiar
git clone https://github.com/DavidFernVi/QuasarTest.git
Abrir en Unity:

Abre Unity Hub.
Haz clic en "Abrir proyecto" y selecciona la carpeta clonada.
Compilar y ejecutar:

Una vez abierto, presiona Play en el editor para probar la aplicación.
🎮 Instrucciones de uso
Usa WASD o las flechas direccionales para mover al jugador.
Mueve el ratón para girar la cámara y orientar al jugador.
Acércate a las galletas (cookies) para recogerlas.
🧩 Estructura del proyecto
Assets/Scripts:

Player: Lógica de movimiento y rotación del jugador.
Objects: Controladores y scripts de interacción con las galletas.
Canvas: Gestión de la interfaz de usuario (UI) para puntuaciones.
Assets/Prefabs: Prefabs de las galletas.

Assets/Materials: Materiales para el entorno.

⚙️ Lógica técnica destacada
Movimiento basado en físicas: Se utiliza un Rigidbody y fuerzas físicas para el desplazamiento del jugador.
Interacción con objetos: Implementada a través de una interfaz IInteractuableObj para acoplar fácilmente nuevos objetos interactuables.
Generación dinámica: Los objetos se generan en áreas específicas utilizando Coroutines y control de cantidad máximo.
🐛 Notas importantes
El proyecto se ha probado únicamente en el editor de Unity.
No se ha trabajado el aspecto visual, dado que no se valora según el enunciado.

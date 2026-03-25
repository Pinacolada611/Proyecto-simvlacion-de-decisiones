Sistema de Evaluación de Contenido Multimedia

Descripción
Este sistema es una aplicación en consola desarrollada en C# que permite evaluar contenido multimedia como películas, series, documentales y eventos en vivo.

El programa analiza diferentes características del contenido y, con base en reglas predefinidas, determina si debe publicarse, rechazarse o enviarse a revisión. También genera estadísticas durante la ejecución.

Cómo ejecutar el programa

En Visual Studio:

Abrir el proyecto en Visual Studio
Presionar F5 o hacer clic en “Iniciar”
Se abrirá la consola con el menú del sistema

Como archivo ejecutable:

Compilar el programa
Ejecutar el archivo .exe
Usar el menú en la consola

Funcionamiento del sistema

El sistema cuenta con un menú principal con 5 opciones:

Evaluar nuevo contenido
Permite ingresar tipo de contenido, duración, clasificación, hora y nivel de producción. El sistema valida los datos y toma una decisión automática.
Mostrar reglas del sistema
Muestra las condiciones utilizadas para evaluar el contenido, como duración permitida, horarios según clasificación y restricciones de producción.
Mostrar estadísticas
Presenta el total evaluado, publicados, rechazados, en revisión y el porcentaje de aprobación.
Reiniciar estadísticas
Borra todos los datos acumulados en la sesión.
Salir
Finaliza el programa mostrando un resumen.

Lógica de evaluación

El sistema realiza los siguientes pasos:

Validación de datos ingresados
Verificación de reglas técnicas
Clasificación de impacto (alto, medio o bajo)
Decisión final:
Rechazar si no cumple reglas
Enviar a revisión si el impacto es alto
Publicar si el impacto es medio o bajo

Objetivo del proyecto

Simular un sistema de toma de decisiones automatizado similar al utilizado en plataformas de streaming, aplicando lógica de programación, validaciones y estructuras condicionales.

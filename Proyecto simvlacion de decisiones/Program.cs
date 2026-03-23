using System;

class Proyecto
{
    static void Main()
    {
        int TotalEvaluados = 0;
        int Publicados = 0;
        int Rechazados = 0;
        int Revisiones = 0;
        int ImpactoAlto = 0;
        int ImpactoMedio = 0;
        int ImpactoBajo = 0;
        int PorcentajeAprovado = 0;

    }

    static void Menu()
    {
        int opcion = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("---Menu---");
            Console.WriteLine("1. Evaluar nuevo contenido");
            Console.WriteLine("2. Mostrar reglas del sistema");
            Console.WriteLine("3. Mostrar estadisticas de la sesion");
            Console.WriteLine("4. Reiniciar estadisticas");
            Console.WriteLine("5. Salir");
            Console.Write("\nSeleccione una opcion del menu: ");

            if (!int.TryParse(Console.ReadLine(), out opcion)) continue;

            switch (opcion)
            {
                case 1:
                    EvaluarContenido();
                    break;
                case 2:
                    MostrarReglas();
                    break;
                case 3:
                    MostrarEstadisticas();
                    break;
                case 4:
                    ReiniciarEstadisticas();
                    break;
                case 5:
                    Console.WriteLine("Saliendo del programa: ");
                    Console.ReadKey();
                    break;
            }
            if (opcion != 5)
            {
                Console.WriteLine("\nEscoja una opcion para continuar: ");
            }
        } while (opcion != 5);
    }
}
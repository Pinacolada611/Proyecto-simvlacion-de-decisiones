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

    static void EvaluarContenido()
    {
        Console.WriteLine("Ingrese el tipo de contenido. (1.pelicula, 2.serie, 3.documental, 4.evento en vivo): ");
        int Tipo = ValidarRango(1, 4);

        Console.WriteLine("Ingrese la duracion del contenido. (en mintos): ");
        int Duracion = ValidarRango(1, 100000);

        Console.WriteLine("Ingrese la clasificacion del contenido. (1.todo público, 2.+13, 3.+18): ");
        int Clasificacion = ValidarRango(1, 3);

        Console.WriteLine("Ingrese la hora programada. (0-23): ");
        int Hora = ValidarRango(0, 23);

        Console.WriteLine("Ingrese Nivel de Prodvccion. (1.bajo, 2.medio, 3.alto): ");
        int Nivel = ValidarRango(1, 3);

        TotalEvaluados++; 
        Console.WriteLine("\nDatos registrados.");

        bool cumpleTecnico = true;
        string motivoRechazo = "";

        if (Tipo == 1 && (Duracion < 60 || Duracion > 180)) { cumpleTecnico = false; motivoRechazo += "Duración película (60-180min). "; }
        if (!cumpleTecnico)
        {
            Rechazados++;
            Console.WriteLine($"\nDECISIÓN FINAL: RECHAZAR\nRazon: {motivoRechazo}");
            return;
        }
    }
}
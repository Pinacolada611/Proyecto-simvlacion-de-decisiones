using System;
using System.Security.Claims;

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

        Menu();
    }

    static void Menu()
    {
        int opcion = 0;
        do
        {
            Console.Clear();
            Console.WriteLine("---Menu--- ");
            Console.WriteLine("1. Evaluar nuevo contenido ");
            Console.WriteLine("2. Mostrar reglas del sistema ");
            Console.WriteLine("3. Mostrar estadisticas de la sesion ");
            Console.WriteLine("4. Reiniciar estadisticas ");
            Console.WriteLine("5. Salir ");
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
        int Hora = ValidarRango(1, 23);
        Console.WriteLine("Ingrese Nivel de Prodvccion. (1.bajo, 2.medio, 3.alto): ");
        int Nivel = ValidarRango(1, 3);

        TotalEvaluados++;
        Console.WriteLine("\nDatos registrados. ");

        bool cumpleTecnico = true;
        string motivoRechazo = "";

        if (Tipo == 1 && (Duracion < 60 || Duracion > 180)) { cumpleTecnico = false; motivoRechazo += "Duración película (60-180min). "; }
        if (Tipo == 2 && (Duracion < 20 || Duracion > 90)) { cumpleTecnico = false; motivoRechazo += "Duración serie (20-90min). "; }
        if (Tipo == 3 && (Duracion < 30 || Duracion > 120)) { cumpleTecnico = false; motivoRechazo += "Duración documental (30-120min). "; }
        if (Tipo == 4 && (Duracion < 30 || Duracion > 240)) { cumpleTecnico = false; motivoRechazo += "Duración evento (30-240min). "; }

        if (Clasif == 2 && (Hora < 6 || Hora > 22)) { cumpleTecnico = false; motivoRechazo += "Horario +13 (6-22h). "; }
        if (Clasif == 3 && (Hora >= 5 && Hora < 22)) { cumpleTecnico = false; motivoRechazo += "Horario +18 (22-5h). "; }

        if (Nivel == 1 && Clasif == 3) { cumpleTecnico = false; motivoRechazo += "Producción baja no apta para +18. "; }

        if (!cumpleTecnico)
        {
            Rechazados++;
            Console.WriteLine($"\nDECISIÓN FINAL: RECHAZAR\nRazon: {motivoRechazo}");
            return;
        }

        string impacto = "Bajo";
        if (Nivel == 3 || duracion > 120 || (hora >= 20 && hora <= 23)) { impacto = "Alto"; ImpactoAlto++; }
        else if (nivel == 2 || (duracion >= 60 && duracion <= 120)) { impacto = "Medio"; ImpactoMedio++; }
        else { ImpactoBajo++; }

        if (impacto == "Alto")
        {
            Revisiones++;
            Console.WriteLine("\nDECISIÓN FINAL: ENVIAR A REVISIÓN");
            Console.WriteLine("Razon: Cumple reglas técnicas pero tiene Impacto Alto.");
        }
        else
        {
            Publicados++;
            Console.WriteLine($"\ndecision final: publicar (Impacto {impacto})")
            Console.WriteLine("Razon: Cumple reglas tecnicas e impacto no es Alto.");
        }
    }

    static void MostrarReglas()
    {
        Console.Clear();
        Console.WriteLine("Reglas de timpo.");
        Console.WriteLine("Película: 60-180 minutos.");
        Console.WriteLine("Serie: 20-90 minutos.");
        Console.WriteLine("Documental: 30-120 minutos.");
        Console.WriteLine("Evento en vivo: 30-240 minutos.");

        Console.Clear();
        Console.WriteLine("Todo público: cualquier hora.");
        Console.WriteLine("+13: entre 6 y 22 horas.");
        Console.WriteLine("+18: entre 22 y 5 horas.");

        Console.Clear();
        Console.WriteLine("Producción baja ( Todo público o +13) ");
        Console.WriteLine("Producción media o alta válida ( Cualquier clasificación) ");
    }
}
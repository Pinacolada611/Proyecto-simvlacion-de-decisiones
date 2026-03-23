using System
class Proyecto
{
    static int TotalEvaluados = 0, Publicados = 0, Rechazados = 0, Revisiones = 0;
    static int ImpactoAlto = 0, ImpactoMedio = 0, ImpactoBajo = 0;

    static void Main()
    {
        Menu();
    }

    static void Menu()
    {
        int opcion = 0;
        do
        {
            Console.Clear(); //El .Clear limpiara la pantalla en cada vuelta
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
                case 1: EvaluarContenido(); break;
                case 2: MostrarReglas(); break;
                case 3: MostrarEstadisticas(); break;
                case 4: ReiniciarEstadisticas(); break;
                case 5: ResumenFinal(); break;
            }
            if (opcion != 5)
            {
                Console.WriteLine("\nPresione una tecla para continuar: ");
                Console.ReadKey();
            }
        } while (opcion != 5);
    }

    static void EvaluarContenido()
    {
        Console.Clear();
        Console.WriteLine("Ingrese el tipo de contenido. (1.pelicula, 2.serie, 3.documental, 4.evento en vivo): ");
        int Tipo = ValidarRango(1, 4);
        Console.WriteLine("Ingrese la duracion del contenido. (en minutos): ");
        int Duracion = ValidarRango(1, 100000);
        Console.WriteLine("Ingrese la clasificacion del contenido. (1.todo publico, 2.+13, 3.+18): ");
        int Clasificacion = ValidarRango(1, 3);
        Console.WriteLine("Ingrese la hora programada. (0–23): ");
        int Hora = ValidarRango(0, 23);
        Console.WriteLine("Ingrese Nivel de Produccion. (1.bajo, 2.medio, 3.alto): ");
        int Nivel = ValidarRango(1, 3);

        TotalEvaluados++;
        Console.WriteLine("\nDatos registrados. ");

        //a) Validación tecnica
        bool ValTec = true;
        string RechaMotiv = "";

        if (Tipo == 1 && (Duracion < 60 || Duracion > 180)) { ValTec = false; RechaMotiv += "Duracion pelicula (60-180min). "; }
        if (Tipo == 2 && (Duracion < 20 || Duracion > 90)) { ValTec = false; RechaMotiv += "Duracion serie (20-90min). "; }
        if (Tipo == 3 && (Duracion < 30 || Duracion > 120)) { ValTec = false; RechaMotiv += "Duracion documental (30-120min). "; }
        if (Tipo == 4 && (Duracion < 30 || Duracion > 240)) { ValTec = false; RechaMotiv += "Duracion evento (30-240min). "; }

        // Reglas de horario
        if (Clasificacion == 2 && (Hora < 6 || Hora > 22)) { ValTec = false; RechaMotiv += "Horario +13 (6-22h). "; }
        // Para +18 (22 a 5), el contenido se RECHAZA si está fuera de ese rango (o sea, si es entre las 5 y las 22)
        if (Clasificacion == 3 && (Hora >= 5 && Hora < 22)) { ValTec = false; RechaMotiv += "Horario +18 (22-5h). "; }

        // Produccion
        if (Nivel == 1 && Clasificacion == 3) { ValTec = false; RechaMotiv += "Produccion baja no apta para +18. "; }

        if (!ValTec)
        {
            Rechazados++;
            Console.WriteLine($"\nDECISION FINAL: RECHAZAR\nRazon: {RechaMotiv}");
            return;
        }

        // b) Clasificación de impacto
        string impacto = "Bajo";
        if (Nivel == 3 || Duracion > 120 || (Hora >= 20 && Hora <= 23)) { impacto = "Alto"; ImpactoAlto++; }
        else if (Nivel == 2 || (Duracion >= 60 && Duracion <= 120)) { impacto = "Medio"; ImpactoMedio++; }
        else { ImpactoBajo++; }

        // c) Decisión final
        if (impacto == "Alto")
        {
            Revisiones++;
            Console.WriteLine("\ndecision final enviar revision. ");
            Console.WriteLine("Razon: Cumple reglas técnicas pero tiene Impacto Alto.");
        }
        else
        {
            Publicados++;
            Console.WriteLine($"\ndecision final: publicar (Impacto {impacto})");
            Console.WriteLine("Razon: Cumple reglas tecnicas e impacto no es Alto.");
        }
    }

    static int ValidarRango(int min, int max)
    {
        int valor;
        while (!int.TryParse(Console.ReadLine(), out valor) || valor < min || valor > max)
        {
            Console.Write($"Entrada Invalida. Ingrese numero entre {min} y {max}: ");
        }
        return valor;
    }

    static void MostrarReglas()
    {
        Console.Clear();
        Console.WriteLine("Reglas de tiempo.");
        Console.WriteLine("Pelicula: 60–180 minutos.");
        Console.WriteLine("Serie: 20–90 minutos.");
        Console.WriteLine("Documental: 30–120 minutos.");
        Console.WriteLine("Evento en vivo: 30–240 minutos.");
        Console.WriteLine("\nReglas de horario.");
        Console.WriteLine("Todo publico: cualquier hora.");
        Console.WriteLine("+13: entre 6 y 22 horas.");
        Console.WriteLine("+18: entre 22 y 5 horas.");
        Console.WriteLine("\nProducción.");
        Console.WriteLine("Produccion baja ( Todo publico o +13) ");
        Console.WriteLine("Producción media o alta válida (Cualquier clasificación) ");
    }

    static void MostrarEstadisticas()
    {
        Console.Clear();
        Console.WriteLine($"Total Evaluados: {TotalEvaluados}");
        Console.WriteLine($"Publicados: {Publicados}");
        Console.WriteLine($"Rechazados: {Rechazados}");
        Console.WriteLine($"En Revision: {Revisiones}");

        if (TotalEvaluados > 0)
        {
            double porc = (double)Publicados / TotalEvaluados * 100;
            Console.WriteLine($"Porcentaje de Aprobacion: {porc:F2}%");
        }
    }

    static void ReiniciarEstadisticas()
    {
        TotalEvaluados = 0; Publicados = 0; Rechazados = 0; Revisiones = 0;
        ImpactoAlto = 0; ImpactoMedio = 0; ImpactoBajo = 0;
        Console.WriteLine("\nEstadisticas reiniciadas. ");
    }

    static void ResumenFinal()
    {
        Console.Clear();
        Console.WriteLine("---resumen---");
        MostrarEstadisticas();
        Console.WriteLine("\nSaliendo...");
        Console.ReadKey();
    }
}
//este seria todo el simulador.
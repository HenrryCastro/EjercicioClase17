using System;

namespace EjerciciosClase17
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcionPrincipal = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("==================================================");
                Console.WriteLine("    LABORATORIO - ESTRUCTURAS DE DATOS (CLASE 17) ");
                Console.WriteLine("==================================================");
                Console.WriteLine("1. Editor de Texto (Cola de pendientes y Pila de deshacer)");
                Console.WriteLine("2. Sistema de Turnos - Clínica Médica (Cola FIFO)");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione el ejercicio que desea ejecutar: ");

                if (int.TryParse(Console.ReadLine(), out opcionPrincipal))
                {
                    switch (opcionPrincipal)
                    {
                        case 1:
                            EditorTexto.Ejecutar();
                            break;
                        case 2:
                            ClinicaMedica.Ejecutar();
                            break;
                        case 3:
                            Console.WriteLine("\nSaliendo del programa. ¡Hasta luego!");
                            break;
                        default:
                            Console.WriteLine("\nOpción no válida. Intente de nuevo.");
                            Pausa();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nPor favor, ingrese un número válido.");
                    Pausa();
                }

            } while (opcionPrincipal != 3);
        }

        static void Pausa()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
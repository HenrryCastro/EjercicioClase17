using System;
using System.Collections.Generic;
using EjerciciosClase17.Models;

namespace EjerciciosClase17
{
    public class EditorTexto
    {
        public static void Ejecutar()
        {
            // Cola para almacenar el historial de comandos pendientes de procesar
            Queue<Comando> colaPendientes = new Queue<Comando>();
            // Pila para almacenar las acciones ya completadas que se pueden revertir (deshacer)
            Stack<Comando> pilaHistorial = new Stack<Comando>();

            int opcion = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE EDITOR DE TEXTO ===");
                Console.WriteLine("1. Registrar nueva acción (Encolar pendiente)");
                Console.WriteLine("2. Procesar acción (Pasar de Cola a Pila)");
                Console.WriteLine("3. Deshacer última acción (Pop de la Pila)");
                Console.WriteLine("4. Visualizar estados (Cola y Pila)");
                Console.WriteLine("5. Regresar al menú principal");
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Write("\nIngrese el comando (ej. Escribir 'Hola', Borrar línea 3): ");
                            string texto = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(texto))
                            {
                                Comando nuevoComando = new Comando
                                {
                                    Descripcion = texto,
                                    FechaRegistro = DateTime.Now
                                };
                                colaPendientes.Enqueue(nuevoComando);
                                Console.WriteLine("¡Comando registrado exitosamente en la cola de pendientes!");
                            }
                            else
                            {
                                Console.WriteLine("El comando no puede estar vacío.");
                            }
                            Pausa();
                            break;

                        case 2:
                            if (colaPendientes.Count > 0)
                            {
                                Comando procesado = colaPendientes.Dequeue();
                                pilaHistorial.Push(procesado);
                                Console.WriteLine($"\n[Procesado]: \"{procesado.Descripcion}\" transferido a la pila de historial.");
                            }
                            else
                            {
                                Console.WriteLine("\nNo hay comandos pendientes en la cola.");
                            }
                            Pausa();
                            break;

                        case 3:
                            if (pilaHistorial.Count > 0)
                            {
                                Comando deshecho = pilaHistorial.Pop();
                                Console.WriteLine($"\n[Deshecho]: La acción \"{deshecho.Descripcion}\" ha sido revertida.");
                            }
                            else
                            {
                                Console.WriteLine("\nNo hay acciones ejecutadas en el historial para deshacer.");
                            }
                            Pausa();
                            break;

                        case 4:
                            Console.WriteLine("\n--- ESTADO ACTUAL DEL EDITOR ---");
                            Console.WriteLine($"Comandos Pendientes en Cola ({colaPendientes.Count}):");
                            foreach (var c in colaPendientes)
                            {
                                c.MostrarDetalle();
                            }

                            Console.WriteLine($"\nAcciones Completadas en Pila - Cima arriba ({pilaHistorial.Count}):");
                            foreach (var c in pilaHistorial)
                            {
                                c.MostrarDetalle();
                            }
                            Pausa();
                            break;

                        case 5:
                            break;

                        default:
                            Console.WriteLine("\nOpción inválida.");
                            Pausa();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nEntrada inválida.");
                    Pausa();
                }

            } while (opcion != 5);
        }

        private static void Pausa()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
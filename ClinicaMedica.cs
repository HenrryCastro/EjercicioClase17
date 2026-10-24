using System;
using System.Collections.Generic;
using EjerciciosClase17.Models;

namespace EjerciciosClase17
{
    public class ClinicaMedica
    {
        public static void Ejecutar()
        {
            // Cola (Queue) donde los pacientes son atendidos en orden FIFO exacto
            Queue<Paciente> colaPacientes = new Queue<Paciente>();

            int opcion = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("=== SISTEMA DE TURNOS - CLÍNICA MÉDICA (EMERGENCIAS) ===");
                Console.WriteLine("1. Registrar llegada de paciente (Encolar)");
                Console.WriteLine("2. Atender paciente (Desencolar y liberar)");
                Console.WriteLine("3. Consultar estado (Mostrar lista de espera)");
                Console.WriteLine("4. Regresar al menú principal");
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Write("\nIngrese el ID / Carné del paciente (entero): ");
                            if (int.TryParse(Console.ReadLine(), out int id))
                            {
                                Console.Write("Ingrese el Nombre completo del paciente: ");
                                string nombre = Console.ReadLine();

                                Console.Write("Ingrese la Edad del paciente: ");
                                if (int.TryParse(Console.ReadLine(), out int edad))
                                {
                                    Paciente nuevoPaciente = new Paciente
                                    {
                                        IdCarne = id,
                                        NombreCompleto = nombre,
                                        Edad = edad
                                    };

                                    colaPacientes.Enqueue(nuevoPaciente);
                                    Console.WriteLine("\n¡Paciente registrado al final de la cola de emergencias!");
                                }
                                else
                                {
                                    Console.WriteLine("Edad no válida.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("ID / Carné no válido.");
                            }
                            Pausa();
                            break;

                        case 2:
                            if (colaPacientes.Count > 0)
                            {
                                Paciente atendido = colaPacientes.Dequeue();
                                Console.WriteLine("\n--- ATENDIENDO PACIENTE ---");
                                atendido.MostrarDatos();
                                Console.WriteLine("---------------------------");
                                Console.WriteLine("El paciente ha sido atendido y removido de la cola.");
                            }
                            else
                            {
                                Console.WriteLine("\nNo hay pacientes esperando en la cola.");
                            }
                            Pausa();
                            break;

                        case 3:
                            Console.WriteLine($"\n--- PACIENTES EN ESPERA ({colaPacientes.Count}) ---");
                            if (colaPacientes.Count > 0)
                            {
                                int turno = 1;
                                foreach (var p in colaPacientes)
                                {
                                    Console.WriteLine($"\n[Posición en Cola: {turno}]");
                                    p.MostrarDatos();
                                    turno++;
                                }
                            }
                            else
                            {
                                Console.WriteLine("La cola de espera está vacía.");
                            }
                            Pausa();
                            break;

                        case 4:
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

            } while (opcion != 4);
        }

        private static void Pausa()
        {
            Console.WriteLine("\nPresione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
}
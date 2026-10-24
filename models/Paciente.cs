using System;

namespace EjerciciosClase17.Models
{
    // Clase que representa los datos exigidos por el documento para cada paciente
    public class Paciente
    {
        public int IdCarne { get; set; }
        public string NombreCompleto { get; set; }
        public int Edad { get; set; }

        public void MostrarDatos()
        {
            Console.WriteLine($"  - ID / Carné: {IdCarne}");
            Console.WriteLine($"  - Nombre:   {NombreCompleto}");
            Console.WriteLine($"  - Edad:     {Edad} años");
        }
    }
}



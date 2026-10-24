using System;

namespace EjerciciosClase17.Models
{
    // Clase que representa el comando ejecutado en el editor de texto
    public class Comando
    {
        public string Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }

        public void MostrarDetalle()
        {
            Console.WriteLine($"  - Acción: {Descripcion} (Registrado: {FechaRegistro:HH:mm:ss})");
        }
    }
} 
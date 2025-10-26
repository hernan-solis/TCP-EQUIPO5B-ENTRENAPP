using System;

namespace Models
{
    public class Usuario
    {
        public Usuario() { }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }
        public string Telefono { get; set; }
        public int Edad { get; set; }
        public string Objetivos { get; set; }
        public string Rol { get; set; }

        public string Genero { get; set; }
        public DateTime FechaFinSuscripcion { get; set; }
        public string DiasDisponibles { get; set; }
        public string Lesiones { get; set; }
        public string CondicionMedica { get; set; }
        public string Comentarios { get; set; }
        public int ProfesorId { get; set; }
    }
}

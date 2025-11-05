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
        public string Rol { get; set; }
        public DateTime FechaFinSuscripcion { get; set; }
    }
}

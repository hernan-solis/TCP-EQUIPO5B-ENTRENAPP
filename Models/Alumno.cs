using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Alumno : Usuario
    {
        public string Telefono { get; set; }
        public int Edad { get; set; }
        public string Objetivo { get; set; }
        public string Genero { get; set; }
        public string DiasDisponibles { get; set; }
        public string Lesiones { get; set; }
        public string CondicionMedica { get; set; }
        public string Comentarios { get; set; }
        public Profesor Profesor { get; set; }

    }
}

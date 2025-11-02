using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Models
{
    public class Profesor : Usuario
    {
        public string Telefono { get; set; }
        public int Edad { get; set; }
        public List<Alumno> Alumnos { get; set; }

    }
}

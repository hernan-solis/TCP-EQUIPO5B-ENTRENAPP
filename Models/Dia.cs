using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Dia
    {
        public Dia() { }
        public int Id { get; set; }
        public int RutinaId { get; set; }
        public string NombreDia { get; set; } 
        public bool Completado { get; set; }
        public List<EjercicioAsignado> EjerciciosAsignados { get; set; }

    }
}

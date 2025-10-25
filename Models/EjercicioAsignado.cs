using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Models
{
    public class EjercicioAsignado
    {
        public EjercicioAsignado() { }

        public int Id { get; set; }
        public int DiaId { get; set; }
        public int EjercicioBaseId { get; set; } // chequear
        public int Series { get; set; }
        public int Repeticiones { get; set; }
        public int TiempoEstimado { get; set; }
        public decimal Peso { get; set; }
        public string Observaciones { get; set; }
        public string Url { get; set; }

        public List<EjercicioBase> EjercicioBase { get; set; }

    }
}

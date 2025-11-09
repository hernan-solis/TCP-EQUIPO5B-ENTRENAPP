using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Historial
    {
        public int Id { get; set; }

        public Rutina Rutina { get; set; }
        public DateTime FechaRegistro { get; set; }
        public EjercicioAsignado EjercicioAsignado { get; set; }


        ///

        //public int Id { get; set; }

        public EjercicioBase EjercicioBase { get; set; }

       // public DateTime FechaRegistro { get; set; }

        public int Series { get; set; }

        public int Repeticiones { get; set; }

        public decimal Peso { get; set; }

        public string Observaciones { get; set; }

        public string AlumnoNombreCompleto { get; set; }  // que cuando lo traiga de la Db solo guarde el nombre

        public string ProfesorNombreCompleto { get; set; }




    }
}

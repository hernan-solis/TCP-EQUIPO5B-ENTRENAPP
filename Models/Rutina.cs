using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Rutina
    {
        public Rutina() { }
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int ProfesorId { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }

        public List<Dia> Dia { get; set; }
    }
}

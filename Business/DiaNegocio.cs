using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class DiaNegocio
    {
        public List<Dia> listar()
        {

            List<Dia> lista = new List<Dia>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select ID, RutinaID, NombreDía,  from Día");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Dia aux = new Dia();
                    aux.Id = (int)datos.Lector["ID"];
                    aux.RutinaId = (int)datos.Lector["RutinaID"];
                    aux.NombreDia = (string)datos.Lector["NombreDía"];
                    aux.Completado = (bool)datos.Lector["Completado"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}


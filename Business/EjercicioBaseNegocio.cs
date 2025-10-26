using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class EjercicioBaseNegocio
    {
        public List<EjercicioBase> listar()
        {

            List<EjercicioBase> lista = new List<EjercicioBase>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select  ID, Nombre, Descripción, Url from EjercicioBase");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    EjercicioBase aux = new EjercicioBase();
                    aux.Id = (int)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripción"];
                    aux.Url = (string)datos.Lector["Url"];
                    
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


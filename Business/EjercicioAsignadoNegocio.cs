using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class EjercicioAsignadoNegocio
    {
        public List<EjercicioAsignado> listar()
        {

            List<EjercicioAsignado> lista = new List<EjercicioAsignado>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select ID, DíaID, EjercicioBaseID, Series, Repeticiones, TiempoEstimado, Peso, Observaciones, Url from EjercicioAsignado");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    EjercicioAsignado aux = new EjercicioAsignado();
                    aux.Id = (int)datos.Lector["ID"];
                    aux.DiaId = (int)datos.Lector["DíaID"];
                    aux.EjercicioBaseId = (int)datos.Lector["EjercicioBaseID"];
                    aux.Series = (int)datos.Lector["Series"];
                    aux.Repeticiones = (int)datos.Lector["Repeticiones"];
                    aux.TiempoEstimado = (int)datos.Lector["TiempoEstimado"];
                    aux.Peso = (decimal)datos.Lector["Peso"];
                    aux.Observaciones = (string)datos.Lector["Observaciones"];
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


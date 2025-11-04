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
                datos.setearConsulta("select A.ID, A.EjercicioBaseID, Nombre, Descripción, B.Url, Series, Repeticiones, TiempoEstimado, Peso, Observaciones from EjercicioAsignado A, EjercicioBase B where B.Id = A.EjercicioBaseID");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    
                    EjercicioAsignado aux = new EjercicioAsignado();
                    aux.Id = (int)datos.Lector["ID"];
                    aux.EjercicioBase = new EjercicioBase();
                    aux.EjercicioBase.Id = (int)datos.Lector["ID"];
                    aux.EjercicioBase.Nombre = (string)datos.Lector["Nombre"];
                    aux.EjercicioBase.Descripcion = (string)datos.Lector["Descripción"];
                    aux.EjercicioBase.Url = (string)datos.Lector["Url"];
                    aux.Series = (int)datos.Lector["Series"];
                    aux.Repeticiones = (int)datos.Lector["Repeticiones"];
                    aux.TiempoEstimado = (int)datos.Lector["TiempoEstimado"];
                    aux.Peso = (decimal)datos.Lector["Peso"];
                    aux.Observaciones = (string)datos.Lector["Observaciones"];
                   // aux.Url = (string)datos.Lector["Url"];

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

        public void agregar (EjercicioAsignado nuevoEjercicioAsignado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                
                datos.setearConsulta("insert into EjercicioAsignado (EjercicioBaseID, Series, Repeticiones, TiempoEstimado, Peso, Observaciones, Url) VALUES (@ejercicioBaseID,@series,@repeticiones,@tiempoEstimado,@peso,@observaciones,@url)");
                datos.setearParametro("@ejercicioBaseId", nuevoEjercicioAsignado.EjercicioBase);
                datos.setearParametro("@series", nuevoEjercicioAsignado.Series);
                datos.setearParametro("@repeticiones", nuevoEjercicioAsignado.Repeticiones);
                datos.setearParametro("@tiempoEstimado", nuevoEjercicioAsignado.TiempoEstimado);
                datos.setearParametro("@peso", nuevoEjercicioAsignado.Peso);
                datos.setearParametro("@observaciones", nuevoEjercicioAsignado.Observaciones);
                datos.setearParametro("@url", nuevoEjercicioAsignado.Url);

                datos.ejecutarAccion();
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

        public void modificar (EjercicioAsignado ejercicioAsignadoModificado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update EjercicioAsignado set EjercicioBaseID = @ejercicioBaseID, Series = @series, Repeticiones = @repeticiones, TiempoEstimado = @tiempoEstimado, Peso = @peso, Observaciones = @observaciones, Url = @url WHERE ID = @id;");
                datos.setearParametro("@ejercicioBaseId", ejercicioAsignadoModificado.EjercicioBase);
                datos.setearParametro("@series", ejercicioAsignadoModificado.Series);
                datos.setearParametro("@repeticiones", ejercicioAsignadoModificado.Repeticiones);
                datos.setearParametro("@tiempoEstimado", ejercicioAsignadoModificado.TiempoEstimado);
                datos.setearParametro("@peso", ejercicioAsignadoModificado.Peso);
                datos.setearParametro("@observaciones", ejercicioAsignadoModificado.Observaciones);
                datos.setearParametro("@url", ejercicioAsignadoModificado.Url);

                datos.ejecutarAccion();
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

        public void eliminar (int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM EjercicioAsignado WHERE id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
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


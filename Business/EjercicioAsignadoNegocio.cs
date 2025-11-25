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
        public List<EjercicioAsignado> Listar()
        {

            List<EjercicioAsignado> lista = new List<EjercicioAsignado>();

            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("select ID, EjercicioBaseID, Series, Repeticiones, TiempoEstimado, Peso, Observaciones, Url from EjercicioAsignado");
                datos.ejecutarLectura();
                EjercicioBaseNegocio ejercicioBaseNegocio = new EjercicioBaseNegocio();


                while (datos.Lector.Read())
                {
                    EjercicioAsignado aux = new EjercicioAsignado();
                    aux.Id = (int)datos.Lector["ID"];
                    aux.EjercicioBase = ejercicioBaseNegocio.ObtenerPorId((int)datos.Lector["EjercicioBaseID"]);
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

        public List<EjercicioAsignado> ListarPorDiaId(int diaId)
        {

            List<EjercicioAsignado> lista = new List<EjercicioAsignado>();

            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("select ID, EjercicioBaseID, Series, Repeticiones, TiempoEstimado, Peso, Observaciones, Url from EjercicioAsignado where DíaID = @id");
                datos.setearParametro("@id", diaId);
                datos.ejecutarLectura();
                EjercicioBaseNegocio ejercicioBaseNegocio = new EjercicioBaseNegocio();


                while (datos.Lector.Read())
                {
                    EjercicioAsignado aux = new EjercicioAsignado();
                    aux.Id = (int)datos.Lector["ID"];
                    aux.EjercicioBase = ejercicioBaseNegocio.ObtenerPorId((int)datos.Lector["EjercicioBaseID"]);
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

        public EjercicioAsignado BuscarPorId(int idEjercicioAsignado)
        {

            EjercicioAsignado aux = new EjercicioAsignado();

            AccesoDatos datos = new AccesoDatos();


            try
            {

                datos.setearConsulta("select ID, EjercicioBaseID, Series, Repeticiones, TiempoEstimado, Peso, Observaciones, Url from EjercicioAsignado where ID = @id");
                datos.setearParametro("@id", idEjercicioAsignado);
                datos.ejecutarLectura();

                if (datos.Lector.Read()) {
                    EjercicioBaseNegocio ejercicioBaseNegocio = new EjercicioBaseNegocio();

                    aux.Id = (int)datos.Lector["ID"];
                    aux.EjercicioBase = ejercicioBaseNegocio.ObtenerPorId((int)datos.Lector["EjercicioBaseID"]);
                    aux.Series = (int)datos.Lector["Series"];
                    aux.Repeticiones = (int)datos.Lector["Repeticiones"];
                    aux.TiempoEstimado = (int)datos.Lector["TiempoEstimado"];
                    aux.Peso = (decimal)datos.Lector["Peso"];
                    aux.Observaciones = (string)datos.Lector["Observaciones"];
                    aux.Url = (string)datos.Lector["Url"];
                }
                

                return aux;
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


        public void Agregar(EjercicioAsignado nuevoEjercicioAsignado, int diaId)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {

                datos.setearConsulta("insert into EjercicioAsignado (EjercicioBaseID, DíaID, Series, Repeticiones, TiempoEstimado, Peso, Observaciones, Url) VALUES (@ejercicioBaseID, @diaID, @series,@repeticiones,@tiempoEstimado,@peso,@observaciones,@url)");
                datos.setearParametro("@ejercicioBaseID", nuevoEjercicioAsignado.EjercicioBase.Id);
                datos.setearParametro("@diaID", diaId);
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

        public void Modificar(EjercicioAsignado ejercicioAsignadoModificado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update EjercicioAsignado set EjercicioBaseID = @ejercicioBaseID, Series = @series, Repeticiones = @repeticiones, TiempoEstimado = @tiempoEstimado, Peso = @peso, Observaciones = @observaciones, Url = @url WHERE ID = @id;");
                datos.setearParametro("@ejercicioBaseID", ejercicioAsignadoModificado.EjercicioBase);
                datos.setearParametro("@series", ejercicioAsignadoModificado.Series);
                datos.setearParametro("@repeticiones", ejercicioAsignadoModificado.Repeticiones);
                datos.setearParametro("@tiempoEstimado", ejercicioAsignadoModificado.TiempoEstimado);
                datos.setearParametro("@peso", ejercicioAsignadoModificado.Peso);
                datos.setearParametro("@observaciones", ejercicioAsignadoModificado.Observaciones);
                datos.setearParametro("@url", ejercicioAsignadoModificado.Url);
                datos.setearParametro("@id", ejercicioAsignadoModificado.Id);

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

        public void ModificarSinEjercicioBase(EjercicioAsignado ejercicioAsignadoModificado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update EjercicioAsignado set Series = @series, Repeticiones = @repeticiones, TiempoEstimado = @tiempoEstimado, Peso = @peso, Observaciones = @observaciones, Url = @url WHERE ID = @id;");
              
                datos.setearParametro("@series", ejercicioAsignadoModificado.Series);
                datos.setearParametro("@repeticiones", ejercicioAsignadoModificado.Repeticiones);
                datos.setearParametro("@tiempoEstimado", ejercicioAsignadoModificado.TiempoEstimado);
                datos.setearParametro("@peso", ejercicioAsignadoModificado.Peso);
                datos.setearParametro("@observaciones", ejercicioAsignadoModificado.Observaciones);
                datos.setearParametro("@url", ejercicioAsignadoModificado.Url);
                datos.setearParametro("@id", ejercicioAsignadoModificado.Id);

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

        //eliminacion física
        public void Eliminar(int id)
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

        public void EliminarPorDiaId(int idDia)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM EjercicioAsignado WHERE DíaID = @idDia");
                datos.setearParametro("@idDia", idDia);
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


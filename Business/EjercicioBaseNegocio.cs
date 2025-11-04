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
        public List<EjercicioBase> Listar()
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

        public EjercicioBase ObtenerPorId(int id)
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select  ID, Nombre, Descripción, Url from EjercicioBase where ID = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                EjercicioBase aux = new EjercicioBase();

                if (datos.Lector.Read())
                {
                   
                    aux.Id = (int)datos.Lector["ID"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripción"];
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

        public void agregar(EjercicioBase nuevoEjercioBase)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = @"INSERT INTO EjercicioBase (Nombre,Descripción,Url) VALUES (@nombre,@descripcion,@url)";

                datos.setearConsulta(consulta);

                datos.setearParametro("@nombre", nuevoEjercioBase.Nombre);
                datos.setearParametro("@descripcion", nuevoEjercioBase.Descripcion);
                datos.setearParametro("@url", nuevoEjercioBase.Url);

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

        public void Modificar(EjercicioBase ejercicioBaseModificado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {


                datos.setearConsulta("update EjercicioBase set Nombre = @nombre, Descripción = @desc, Url=@url WHERE ID = @id;");
                datos.setearParametro("@nombre", ejercicioBaseModificado.Nombre);
                datos.setearParametro("@desc", ejercicioBaseModificado.Descripcion);
                datos.setearParametro("@url", ejercicioBaseModificado.Url);
                datos.setearParametro("@id", ejercicioBaseModificado.Id);

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

        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM EjercicioBase WHERE id = @id");
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


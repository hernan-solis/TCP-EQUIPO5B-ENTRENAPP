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
        public List<Dia> Listar()
        {

            List<Dia> lista = new List<Dia>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select ID, RutinaID, NombreDía, Completado  from Día");
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

        public void Agregar(Dia dia)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO Día (RutinaID, NombreDía, Completado) VALUES (@RutinaId, @NombreDia, @Completado)");
                datos.setearParametro("@RutinaId", dia.RutinaId);
                datos.setearParametro("@NombreDia", dia.NombreDia);
                datos.setearParametro("@Completado", dia.Completado);

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

        public void Modificar(Dia dia)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE Día SET RutinaID = @RutinaId, NombreDía = @NombreDia, Completado = @Completado WHERE ID = @ID");
                datos.setearParametro("@RutinaId", dia.RutinaId);
                datos.setearParametro("@NombreDia", dia.NombreDia);
                datos.setearParametro("@Completado", dia.Completado);
                datos.setearParametro("@ID", dia.Id);
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
                datos.setearConsulta("DELETE FROM Día WHERE ID = @ID");
                datos.setearParametro("@ID", id);
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


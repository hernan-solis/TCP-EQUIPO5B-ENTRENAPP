using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class HistorialNegocio
    {
        public void AgregarDiaCompletado(Dia diaCompletado)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                foreach (var ejercicio in diaCompletado.EjerciciosAsignados)
                {

                    datos.limpiarParametros();

                    datos.setearConsulta("INSERT INTO Historial (RutinaID, FechaRegistro, EjercicioBaseID, Series, Repeticiones, Peso, Observaciones) VALUES (@RutinaID, @FechaRegistro, @EjercicioBaseID, @Series, @Repeticiones, @Peso, @Observaciones)");
                    datos.setearParametro("@RutinaId", diaCompletado.RutinaId);
                    datos.setearParametro("@FechaRegistro", DateTime.Now);
                    datos.setearParametro("@EjercicioBaseID", ejercicio.EjercicioBase.Id);
                    datos.setearParametro("@Series", ejercicio.Series);
                    datos.setearParametro("@Repeticiones", ejercicio.Repeticiones);
                    datos.setearParametro("@Peso", ejercicio.Peso);
                    datos.setearParametro("@Observaciones", ejercicio.Observaciones);


                    datos.ejecutarAccion();
                }

                datos.limpiarParametros();

                datos.setearConsulta("UPDATE Día Set Completado = 1 where ID = @ID");
                datos.setearParametro("@ID", diaCompletado.Id);

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

        public List<Historial> ListarPorIdRutina(int idRutina)
        {
            List<Historial> lista = new List<Historial>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setearConsulta("select ID, RutinaID, FechaRegistro, EjercicioBaseID, Series, Repeticiones, Peso, Observaciones from Historial where RutinaID = @id");
                datos.setearParametro("@id", idRutina);
                datos.ejecutarLectura();

                

                while (datos.Lector.Read())
                {
                    Historial aux = new Historial();

                    aux.Id = (int)datos.Lector["ID"];
                    aux.RutinaId = (int)datos.Lector["RutinaID"];
                    aux.FechaRegistro = (DateTime)datos.Lector["FechaRegistro"];
                    aux.EjercicioBase = (EjercicioBase)datos.Lector["EjercicioBaseID"];
                    aux.Series = (int)datos.Lector["Series"];
                    aux.Repeticiones = (int)datos.Lector["Repeticiones"];
                    aux.Peso = (int)datos.Lector["Peso"];
                    aux.Observaciones = (string)datos.Lector["Observaciones"];


                    lista.Add(aux);
                }

                return lista;

            }

            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }

            
        }
    }
}